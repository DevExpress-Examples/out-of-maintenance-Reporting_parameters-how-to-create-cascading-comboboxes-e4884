using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;

namespace WindowsFormsApplication1 {
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        public XtraReport1() {
            InitializeComponent();
            categoriesTableAdapter.Fill(ds.Categories);
        }
        LookUpEdit editor1;
        LookUpEdit editor2;
        nwindDataSet ds = new nwindDataSet();
        private void XtraReport1_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {            
            editor1 = ((LookUpEdit)e.ParametersInformation[0].Editor);
            editor1.Properties.DataSource = ds.Categories;
            editor1.Properties.DisplayMember = "CategoryName";
            editor1.Properties.ValueMember = "CategoryID";
            editor1.Properties.Columns.Clear();
            editor1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CategoryName", 200, "CategoryName"));
            editor1.EditValueChanged += new EventHandler(XtraReport1_EditValueChanged);
            editor1.Properties.EditValueChangedDelay = 0;
            editor1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;

            e.ParametersInformation[1].Editor = new LookUpEdit();
            editor2 = ((LookUpEdit)e.ParametersInformation[1].Editor);
            editor2.Properties.DataSource = ds.Products;
            editor2.Properties.DisplayMember = "ProductName";
            editor2.Properties.ValueMember = "ProductID";
            editor2.Properties.Columns.Clear();
            editor2.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", 200, "ProductName"));            
        }

        void XtraReport1_EditValueChanged(object sender, EventArgs e) {
            productsTableAdapter.FillByCatID(ds.Products, Convert.ToInt32(editor1.EditValue));
        }

    }
}
