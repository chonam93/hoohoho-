using DevExpress.XtraEditors.Repository;
using System;
using System.Data;

namespace dxSample {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        DataTable table;
        private DataTable CreateDataTable() {
            table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("IsActive", typeof(bool));
            table.Columns.Add("OrderCount", typeof(int));
            table.Columns.Add("RegistrationDate", typeof(DateTime));
            table.Rows.Add(1, "Alex", true, 73, DateTime.Now.AddDays(-100));
            table.Rows.Add(2, "Sarah", false, 12, DateTime.Now.AddDays(-50));
            table.Rows.Add(3, "Bob", true, 3, DateTime.Now.AddDays(-12));
            return table;
        }
        RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
        public Form1() {
            InitializeComponent();
            this.gridControl1.DataSource = CreateDataTable();
            edit.Enabled = false;
            edit.ReadOnly = true;
            this.gridView1.ShowingEditor += GridView1_ShowingEditor;
            this.gridView1.CustomRowCellEdit += GridView1_CustomRowCellEdit;      
        }

        private void GridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e) {
            if (e.Column.FieldName == "IsActive")
                if (this.gridView1.GetRowCellValue(e.RowHandle, "Name").ToString() == "Alex") {
                    e.RepositoryItem = edit;
                }
        }

        private void GridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e) {
            if (this.gridView1.GetFocusedRowCellValue("Name").ToString() == "Alex") {
                e.Cancel = true;
            }
        }
    }
}
