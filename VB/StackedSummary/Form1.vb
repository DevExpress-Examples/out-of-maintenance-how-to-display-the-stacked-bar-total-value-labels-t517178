Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
Imports DevExpress.XtraCharts.Designer

Namespace StackedSummary
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Property Totals() As Dictionary(Of String, PointInfo)
        Private SeriesColors As New List(Of Color) From {Color.Yellow, Color.Orange, Color.LightYellow}

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Totals = New Dictionary(Of String, PointInfo)()
            Me.chartControl.SeriesDataMember = "Month"
            Me.chartControl.SeriesTemplate.View = New StackedBarSeriesView()
            Me.chartControl.SeriesTemplate.ArgumentDataMember = "Section"
            Me.chartControl.SeriesTemplate.ValueDataMembers.AddRange(New String() {"Value"})
            Me.chartControl.DataSource = CreateChartData()
        End Sub

        Private Sub checkBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBox1.CheckedChanged
            CType(Me.chartControl.Diagram, XYDiagram).DefaultPane.StackedBarTotalLabel.Visible = checkBox1.Checked
        End Sub
        Private Function CreateChartData() As DataTable

            Dim table As New DataTable("Table1")

            table.Columns.Add("Month", GetType(String))
            table.Columns.Add("Section", GetType(String))
            table.Columns.Add("Value", GetType(Int32))

            table.Rows.Add(New Object() { "Jan", "Section1", 10 })
            table.Rows.Add(New Object() { "Jan", "Section2", 20 })
            table.Rows.Add(New Object() { "Feb", "Section1", -12 })
            table.Rows.Add(New Object() { "Feb", "Section2", 30 })
            table.Rows.Add(New Object() { "March", "Section1", 14 })
            table.Rows.Add(New Object() { "March", "Section2", 25 })

            Return table
        End Function


    End Class

    Public Class PointInfo
        Public Property ActualValue() As Double
        Public Property DisplayValue() As Double
    End Class
End Namespace
