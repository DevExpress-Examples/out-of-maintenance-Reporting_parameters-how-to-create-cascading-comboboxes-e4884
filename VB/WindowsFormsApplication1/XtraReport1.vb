Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraEditors

Namespace WindowsFormsApplication1
	Partial Public Class XtraReport1
		Inherits DevExpress.XtraReports.UI.XtraReport
		Public Sub New()
			InitializeComponent()
			categoriesTableAdapter.Fill(ds.Categories)
		End Sub
		Private editor1 As LookUpEdit
		Private editor2 As LookUpEdit
		Private ds As New nwindDataSet()
		Private Sub XtraReport1_ParametersRequestBeforeShow(ByVal sender As Object, ByVal e As DevExpress.XtraReports.Parameters.ParametersRequestEventArgs) Handles MyBase.ParametersRequestBeforeShow
			editor1 = (CType(e.ParametersInformation(0).Editor, LookUpEdit))
			editor1.Properties.DataSource = ds.Categories
			editor1.Properties.DisplayMember = "CategoryName"
			editor1.Properties.ValueMember = "CategoryID"
			editor1.Properties.Columns.Clear()
			editor1.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CategoryName", 200, "CategoryName"))
			AddHandler editor1.EditValueChanged, AddressOf XtraReport1_EditValueChanged
			editor1.Properties.EditValueChangedDelay = 0
			editor1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered

			e.ParametersInformation(1).Editor = New LookUpEdit()
			editor2 = (CType(e.ParametersInformation(1).Editor, LookUpEdit))
			editor2.Properties.DataSource = ds.Products
			editor2.Properties.DisplayMember = "ProductName"
			editor2.Properties.ValueMember = "ProductID"
			editor2.Properties.Columns.Clear()
			editor2.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", 200, "ProductName"))
		End Sub

		Private Sub XtraReport1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			productsTableAdapter.FillByCatID(ds.Products, Convert.ToInt32(editor1.EditValue))
		End Sub

	End Class
End Namespace
