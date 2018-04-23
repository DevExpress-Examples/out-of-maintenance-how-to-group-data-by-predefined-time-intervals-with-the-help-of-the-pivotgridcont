Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
Imports DevExpress.XtraPivotGrid
Imports System.Collections

Namespace ChartMonthSum
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			CreatePivotGrid()
		End Sub

		Private pivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl

		Private Sub CreatePivotGrid()
			Dim fieldMonth As DevExpress.XtraPivotGrid.PivotGridField = New PivotGridField()
			Dim fieldSalesValue As DevExpress.XtraPivotGrid.PivotGridField = New PivotGridField()
			Dim fieldYear As DevExpress.XtraPivotGrid.PivotGridField = New PivotGridField()

			' 
			' pivotGridControl1
			' 
			Me.pivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
			Me.pivotGridControl1.DataSource = New SalesData().Tables(0)
			Me.pivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() { fieldYear, fieldMonth, fieldSalesValue})
			Me.pivotGridControl1.OptionsChartDataSource.SelectionOnly = False
			Me.pivotGridControl1.OptionsChartDataSource.ProvideColumnTotals = False
			Me.pivotGridControl1.OptionsChartDataSource.ProvideRowTotals = False
			Me.pivotGridControl1.OptionsChartDataSource.ProvideColumnGrandTotals = False
			Me.pivotGridControl1.OptionsChartDataSource.ProvideRowGrandTotals = False
			' 
			' fieldYear
			' 
			fieldYear.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
			fieldYear.AreaIndex = 0
			fieldYear.FieldName = "Day"
			fieldYear.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear
			fieldYear.Name = "fieldYear"
			fieldYear.UnboundFieldName = "fieldYear"
			' 
			' fieldMonth
			' 
			fieldMonth.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			fieldMonth.AreaIndex = 1
			fieldMonth.FieldName = "Day"
			fieldMonth.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth
			fieldMonth.Name = "fieldMonth"
			fieldMonth.UnboundFieldName = "fieldDay"
			' 
			' fieldSalesValue
			' 
			fieldSalesValue.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
			fieldSalesValue.AreaIndex = 0
			fieldSalesValue.FieldName = "SalesValue"
			fieldSalesValue.Name = "fieldSalesValue"


			' Show a resulting PivotGridControl
			Dim form As New Form()

			pivotGridControl1.Dock = DockStyle.Fill
			form.Controls.Add(pivotGridControl1)
			form.Show()
		End Sub

		Private table As New DataTable()

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Cpecify ScaleTypes
			chartControl1.SeriesTemplate.ArgumentScaleType = ScaleType.Qualitative
			chartControl1.SeriesTemplate.ValueScaleType = ScaleType.Numerical

			' Bound series template to data
			chartControl1.DataSource = pivotGridControl1
			chartControl1.SeriesDataMember = "Series"
			chartControl1.SeriesTemplate.ArgumentDataMember = "Arguments"
			chartControl1.SeriesTemplate.ValueDataMembers.AddRange(New String() { "Values" })

			' Adjust AxisX
			TryCast(chartControl1.Diagram, XYDiagram).AxisX.Label.DateTimeOptions.Format = DateTimeFormat.ShortDate
			TryCast(chartControl1.Diagram, XYDiagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month
			TryCast(chartControl1.Diagram, XYDiagram).AxisX.GridSpacingAuto = False
			TryCast(chartControl1.Diagram, XYDiagram).AxisX.GridSpacing = 1
		End Sub
	End Class

	Public Class SalesData
		Inherits DataSet
		Public Sub New()
			Dim dt As New DataTable("SalesDataTable")

			dt.Columns.Add("ID", GetType(Int32))
			dt.Columns.Add("Day", GetType(DateTime))
			dt.Columns.Add("SalesValue", GetType(Decimal))
			dt.Constraints.Add("IDPK", dt.Columns("ID"), True)

			Dim start As New DateTime(2008, 1, 1)
			Dim rnd As New Random()

			For i As Integer = 0 To 179
'INSTANT VB NOTE: Embedded comments are not maintained by Instant VB
'ORIGINAL LINE: dt.Rows.Add(new object[] { i, start.AddDays(i * 5), i/*rnd.NextDouble() * 100*/ });
				dt.Rows.Add(New Object() { i, start.AddDays(i * 5), i })
			Next i

			Me.Tables.Add(dt)
		End Sub

	End Class

End Namespace