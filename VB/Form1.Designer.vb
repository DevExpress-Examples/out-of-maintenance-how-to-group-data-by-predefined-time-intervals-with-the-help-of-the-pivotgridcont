Imports Microsoft.VisualBasic
Imports System
Namespace ChartMonthSum
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim pointSeriesLabel1 As New DevExpress.XtraCharts.PointSeriesLabel()
			Dim lineSeriesView1 As New DevExpress.XtraCharts.LineSeriesView()
			Me.chartControl1 = New DevExpress.XtraCharts.ChartControl()
			CType(Me.chartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(pointSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(lineSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' chartControl1
			' 
			Me.chartControl1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.chartControl1.Location = New System.Drawing.Point(12, 11)
			Me.chartControl1.Name = "chartControl1"
			Me.chartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series(){}
			pointSeriesLabel1.LineVisible = True
			Me.chartControl1.SeriesTemplate.Label = pointSeriesLabel1
			Me.chartControl1.SeriesTemplate.View = lineSeriesView1
			Me.chartControl1.Size = New System.Drawing.Size(1060, 557)
			Me.chartControl1.TabIndex = 0
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1084, 581)
			Me.Controls.Add(Me.chartControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(pointSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(lineSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.chartControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private chartControl1 As DevExpress.XtraCharts.ChartControl
	End Class
End Namespace

