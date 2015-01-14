using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BLL;
using BLL.Common;
using DAL;
using UI.Common;

namespace UI
{
    public partial class ImportHolder : Form
    {
        #region variables

        private double _totalMinute;
        private string _extension = string.Empty;

        #endregion

        public ImportHolder()
        {
            InitializeComponent();

            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            pb.Hide();
        }

        #region Protected

        private void btnFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "excel files (*.xls,*.xlsx)|*.xls;*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;
                _extension = Path.GetExtension(ofd.FileName);

                btnStart.Enabled = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BoConstant.Config.ConnectionString))
            {
                MessageBox.Show("Chưa kết nối máy chủ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrEmpty(txtFile.Text))
            {
                MessageBox.Show("Chọn đường dẫn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStart.Focus();
                return;
            }

            if (bgw.IsBusy != true)
            {
                pb.Show();
                bgw.RunWorkerAsync();
                btnStart.Enabled = false;
                btnFile.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bgw.Dispose();
            DialogResult = DialogResult.Cancel;
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            var dt = DateTime.Now;
            DoWork(txtFile.Text.Trim());
            var ts = DateTime.Now - dt;
            _totalMinute = ts.TotalMinutes;
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pb.Hide();
            btnStart.Enabled = true;
        }

        #endregion

        #region function

        void DoWork(string path)
        {
            var connectionString = string.Empty;
            switch (_extension)
            {
                case ".xls":
                    connectionString = @"Provider=Microsoft.ACE.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=0'";
                    break;

                case ".xlsx":
                    connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";
                    break;
            }
            var dt = new DataTable();

            try
            {
                using (var cn = new OleDbConnection(connectionString))
                {
                    cn.Open();
                    const string sql = "Select * from [Sheet1$]";
                    var cmd = new OleDbCommand { Connection = cn, CommandText = sql };
                    var da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                    cn.Close();
                }
            }
            catch { }

            var cb = new CompanyBusiness();
            var companyModel = cb.Detail();
            var companyId = 0;
            if (companyModel != null && companyModel.Id > 0)
                companyId = companyModel.Id;

            var lstHolder = new List<Holder>();
            decimal totalShare = 0;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var code = dt.Rows[i]["Code"] != null ? dt.Rows[i]["Code"].ToString() : string.Empty;
                var authorizerName = dt.Rows[i]["AuthorizerName"] != null
                    ? dt.Rows[i]["AuthorizerName"].ToString()
                    : string.Empty;
                var cmnd = dt.Rows[i]["cmnd"] != null
                    ? dt.Rows[i]["cmnd"].ToString()
                    : string.Empty;
                var name = dt.Rows[i]["Name"] != null ? dt.Rows[i]["Name"].ToString() : string.Empty;
                if (dt.Rows[i]["TotalShare"] != null &&
                        !string.IsNullOrEmpty(dt.Rows[i]["TotalShare"].ToString()))
                    totalShare = decimal.Parse(dt.Rows[i]["TotalShare"].ToString());

                var hb = new HolderBusiness();
                if (!hb.CheckExist(code, name, authorizerName, totalShare, cmnd))
                    lstHolder.Add(new Holder
                    {
                        Code = code,
                        AuthorizerName = authorizerName,
                        Name = name,
                        TotalShare = totalShare,
                        IsActive = true,
                        IsConfirm = false,
                        CompanyId = companyId,
                        CreateDate = DateTime.Now,
                        CreateUser = "aBc",
                        CMND = cmnd
                    });
            }

            if (lstHolder.Any())
            {
                var hb = new HolderBusiness();
                var result = hb.Saves(lstHolder);
                if (result)
                {
                    bgw.Dispose();
                    btnFile.Enabled = true;
                    btnStart.Enabled = true;

                    MessageBox.Show("Import thành công", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        #endregion

    }
}
