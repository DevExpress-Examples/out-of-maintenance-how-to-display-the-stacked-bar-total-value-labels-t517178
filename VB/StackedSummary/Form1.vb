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
            AddHandler chartControl.BoundDataChanged, AddressOf chartControl_BoundDataChanged
            Me.chartControl.SeriesDataMember = "Month"
            Me.chartControl.SeriesTemplate.View = New StackedBarSeriesView()
            Me.chartControl.SeriesTemplate.ArgumentDataMember = "Section"
            Me.chartControl.SeriesTemplate.ValueDataMembers.AddRange(New String() {"Value"})
            Me.chartControl.DataSource = CreateChartData()
        End Sub

        Private Sub chartControl_BoundDataChanged(ByVal sender As Object, ByVal e As EventArgs)
            Totals.Clear()
            Dim i As Integer = 0

            For Each series As Series In chartControl.Series
                If series.Tag.ToString() <> "CustomTotal" Then
                    series.View.Color = SeriesColors(i)
                    i += 1
                    For Each sp As SeriesPoint In series.Points
                        If Not Totals.ContainsKey(sp.Argument) Then
                            Totals.Add(sp.Argument, New PointInfo() With { _
                                .ActualValue = sp.Values(0), _
                                .DisplayValue = If(sp.Values(0) > 0, sp.Values(0), 0) _
                            })
                        Else
                            Dim info As PointInfo = Totals(sp.Argument)
                            info.ActualValue += sp.Values(0)
                            If sp.Values(0) > 0 Then
                                info.DisplayValue += sp.Values(0)
                            End If
                            Totals(sp.Argument) = info
                        End If
                    Next sp
                End If
            Next series
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


        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            Me.chartControl.AnnotationRepository.Clear()
            If chartControl.Series(0).Tag.ToString() = "CustomTotal" Then
                Me.chartControl.Series.RemoveAt(0)
            End If
            For Each arg As String In Totals.Keys
                Dim ann As TextAnnotation = Me.chartControl.Annotations.AddTextAnnotation()
                Dim pos As New RelativePosition() With { _
                    .Angle = 90, _
                    .ConnectorLength = 10 _
                }
                ann.Text = String.Format("{0:N2}", Totals(arg).ActualValue)

                Dim anchor_Renamed As New PaneAnchorPoint()
                anchor_Renamed.AxisXCoordinate.AxisValue = arg
                anchor_Renamed.AxisYCoordinate.AxisValue = Totals(arg).DisplayValue
                ann.ShapePosition = pos
                ann.AnchorPoint = anchor_Renamed
            Next arg

        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
            Me.chartControl.AnnotationRepository.Clear()
            If chartControl.Series(0).Tag.ToString() = "CustomTotal" Then
                Me.chartControl.Series.RemoveAt(0)
            End If
            Dim totalSeries As New Series("Total", ViewType.Bar)
            totalSeries.ShowInLegend = False
            totalSeries.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.False
            totalSeries.Tag = "CustomTotal"
            For Each arg As String In Totals.Keys
                Dim sp As New SeriesPoint(arg, Totals(arg).DisplayValue)
                sp.ToolTipHint = Totals(arg).ActualValue.ToString()
                totalSeries.Points.Add(sp)
            Next arg
            totalSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True
            totalSeries.Label.TextPattern = "{HINT}"
            CType(totalSeries.Label, BarSeriesLabel).Position = BarSeriesLabelPosition.Top
            Me.chartControl.Series.Insert(0, totalSeries)
        End Sub


    End Class

    Public Class PointInfo
        Public Property ActualValue() As Double
        Public Property DisplayValue() As Double
    End Class
End Namespace
