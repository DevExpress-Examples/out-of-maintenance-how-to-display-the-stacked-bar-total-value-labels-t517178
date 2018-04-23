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
            this.chartControl.SeriesDataMember = "Month";
            this.chartControl.SeriesTemplate.View = new StackedBarSeriesView();
            this.chartControl.SeriesTemplate.ArgumentDataMember = "Section";
            this.chartControl.SeriesTemplate.ValueDataMembers.AddRange(new string[] {"Value"});
            this.chartControl.DataSource = CreateChartData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ((XYDiagram)this.chartControl.Diagram).DefaultPane.StackedBarTotalLabel.Visible = checkBox1.Checked;
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

        
    }

    public class PointInfo {
        public double ActualValue { get; set; }
        public double DisplayValue { get; set; }
    }
}
