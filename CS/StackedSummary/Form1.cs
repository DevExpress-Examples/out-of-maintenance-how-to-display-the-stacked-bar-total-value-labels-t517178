using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Designer;

namespace StackedSummary {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        Dictionary<string, PointInfo> Totals { get; set; }
        List<Color> SeriesColors = new List<Color> { Color.Yellow, Color.Orange, Color.LightYellow };

        private void Form1_Load(object sender, EventArgs e) {
            Totals = new Dictionary<string, PointInfo>();
            this.chartControl.BoundDataChanged += new DevExpress.XtraCharts.BoundDataChangedEventHandler(chartControl_BoundDataChanged);
            this.chartControl.SeriesDataMember = "Month";
            this.chartControl.SeriesTemplate.View = new StackedBarSeriesView();
            this.chartControl.SeriesTemplate.ArgumentDataMember = "Section";
            this.chartControl.SeriesTemplate.ValueDataMembers.AddRange(new string[] {"Value"});
            this.chartControl.DataSource = CreateChartData();
        }

        void chartControl_BoundDataChanged(object sender, EventArgs e) {
            Totals.Clear();
            int i = 0;

            foreach (Series series in chartControl.Series) {
                if (series.Tag.ToString() != "CustomTotal") {
                    series.View.Color = SeriesColors[i++];
                    foreach (SeriesPoint sp in series.Points) {
                        if (!Totals.ContainsKey(sp.Argument))
                            Totals.Add(sp.Argument, new PointInfo() { ActualValue = sp.Values[0], DisplayValue = sp.Values[0] > 0 ? sp.Values[0] : 0 });
                        else {
                            PointInfo info = Totals[sp.Argument];
                            info.ActualValue += sp.Values[0];
                            if (sp.Values[0] > 0)
                                info.DisplayValue += sp.Values[0];
                            Totals[sp.Argument] = info;
                        }
                    }
                }
            }
        }


        private DataTable CreateChartData() {

            DataTable table = new DataTable("Table1");

            table.Columns.Add("Month", typeof(String));
            table.Columns.Add("Section", typeof(String));
            table.Columns.Add("Value", typeof(Int32));

            table.Rows.Add(new object[] { "Jan", "Section1", 10 });
            table.Rows.Add(new object[] { "Jan", "Section2", 20 });
            table.Rows.Add(new object[] { "Feb", "Section1", -12 });
            table.Rows.Add(new object[] { "Feb", "Section2", 30 });
            table.Rows.Add(new object[] { "March", "Section1", 14 });
            table.Rows.Add(new object[] { "March", "Section2", 25 });

            return table;
        }


        private void button1_Click(object sender, EventArgs e) {
            this.chartControl.AnnotationRepository.Clear();
            if (chartControl.Series[0].Tag.ToString() == "CustomTotal")
                this.chartControl.Series.RemoveAt(0);
            foreach (string arg in Totals.Keys) {
                TextAnnotation ann = this.chartControl.Annotations.AddTextAnnotation();
                RelativePosition pos = new RelativePosition() { Angle = 90, ConnectorLength = 10 };
                ann.Text = string.Format("{0:N2}", Totals[arg].ActualValue);
                PaneAnchorPoint anchor = new PaneAnchorPoint();
                anchor.AxisXCoordinate.AxisValue = arg ;
                anchor.AxisYCoordinate.AxisValue = Totals[arg].DisplayValue;
                ann.ShapePosition = pos;
                ann.AnchorPoint = anchor;
            }
           
        }

        private void button2_Click(object sender, EventArgs e) {
            this.chartControl.AnnotationRepository.Clear();
            if (chartControl.Series[0].Tag.ToString() == "CustomTotal")
                this.chartControl.Series.RemoveAt(0);
            Series totalSeries = new Series("Total", ViewType.Bar);
            totalSeries.ShowInLegend = false;
            totalSeries.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.False;
            totalSeries.Tag = "CustomTotal";
            foreach (string arg in Totals.Keys) {
                SeriesPoint sp = new SeriesPoint(arg, Totals[arg].DisplayValue);
                sp.ToolTipHint = Totals[arg].ActualValue.ToString();
                totalSeries.Points.Add(sp);
            }
            totalSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            totalSeries.Label.TextPattern = "{HINT}";
            ((BarSeriesLabel)totalSeries.Label).Position = BarSeriesLabelPosition.Top;
            this.chartControl.Series.Insert(0, totalSeries);
        }


    }

    public class PointInfo {
        public double ActualValue { get; set; }
        public double DisplayValue { get; set; }
    }
}
