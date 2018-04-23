using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraPivotGrid;
using System.Collections;

namespace ChartMonthSum
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            CreatePivotGrid();
        }

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;

        private void CreatePivotGrid() {
            DevExpress.XtraPivotGrid.PivotGridField fieldMonth = new PivotGridField();
            DevExpress.XtraPivotGrid.PivotGridField fieldSalesValue = new PivotGridField();
            DevExpress.XtraPivotGrid.PivotGridField fieldYear = new PivotGridField();

            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridControl1.DataSource = new SalesData().Tables[0];
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            fieldYear,
            fieldMonth,
            fieldSalesValue});
            this.pivotGridControl1.OptionsChartDataSource.SelectionOnly = false;
            this.pivotGridControl1.OptionsChartDataSource.ShowColumnTotals = false;
            this.pivotGridControl1.OptionsChartDataSource.ShowRowTotals = false;
            this.pivotGridControl1.OptionsChartDataSource.ShowColumnGrandTotals = false;
            this.pivotGridControl1.OptionsChartDataSource.ShowRowGrandTotals = false;
            // 
            // fieldYear
            // 
            fieldYear.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldYear.AreaIndex = 0;
            fieldYear.FieldName = "Day";
            fieldYear.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
            fieldYear.Name = "fieldYear";
            fieldYear.UnboundFieldName = "fieldYear";
            // 
            // fieldMonth
            // 
            fieldMonth.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldMonth.AreaIndex = 1;
            fieldMonth.FieldName = "Day";
            fieldMonth.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth;
            fieldMonth.Name = "fieldMonth";
            fieldMonth.UnboundFieldName = "fieldDay";
            // 
            // fieldSalesValue
            // 
            fieldSalesValue.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldSalesValue.AreaIndex = 0;
            fieldSalesValue.FieldName = "SalesValue";
            fieldSalesValue.Name = "fieldSalesValue";


            // Show a resulting PivotGridControl
            Form form = new Form();

            pivotGridControl1.Dock = DockStyle.Fill;
            form.Controls.Add(pivotGridControl1);
            form.Show();
        }

        DataTable table = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cpecify ScaleTypes
            chartControl1.SeriesTemplate.ArgumentScaleType = ScaleType.Qualitative;
            chartControl1.SeriesTemplate.ValueScaleType = ScaleType.Numerical;

            // Bound series template to data
            chartControl1.DataSource = pivotGridControl1;
            chartControl1.SeriesDataMember = "Series";
            chartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
            chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });

            // Adjust AxisX
            (chartControl1.Diagram as XYDiagram).AxisX.DateTimeOptions.Format = DateTimeFormat.ShortDate;
            (chartControl1.Diagram as XYDiagram).AxisX.DateTimeMeasureUnit = DateTimeMeasurementUnit.Month;
            (chartControl1.Diagram as XYDiagram).AxisX.GridSpacingAuto = false;
            (chartControl1.Diagram as XYDiagram).AxisX.GridSpacing = 1;
        }
       
    }

    public class SalesData : DataSet {
        public SalesData() {
            DataTable dt = new DataTable("SalesDataTable");

            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Day", typeof(DateTime));
            dt.Columns.Add("SalesValue", typeof(decimal));
            dt.Constraints.Add("IDPK", dt.Columns["ID"], true);

            DateTime start = new DateTime(2008, 1, 1);
            Random rnd = new Random();

            for(int i = 0; i < 180; i++) {
                dt.Rows.Add(new object[] { i, start.AddDays(i * 5), i/*rnd.NextDouble() * 100*/ });
            }

            this.Tables.Add(dt);
        }

    }

}