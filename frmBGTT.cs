using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CHUNGKHOAN
{
    public partial class frmBGTT : DevExpress.XtraEditors.XtraForm
    {
        private const string TABLE_NAME = "BANGGIATRUCTUYEN";

        private SqlConnection connection = null;
        private SqlCommand command = null;
        private DataSet dataToWatch = null;
        public frmBGTT()
        {
            InitializeComponent();
            SqlDependency.Start(GetConnectionString());
        }

        private void frmBGTT_Load(object sender, EventArgs e)
        {
            this.gcMua.Enabled = this.gcBan.Enabled = false;

            // set loại lệnh trong Combobox 
            cbLoaiLenh_Ban.DisplayMember = "Text";
            cbLoaiLenh_Ban.ValueMember = "Value";
            cbLoaiLenh_Ban.Items.Add(new { Text = "Lệnh khớp liên tục(LO)", Value = "LO" });
            cbLoaiLenh_Ban.SelectedIndex = 0;

            cbLoaiLenh_Mua.DisplayMember = "Text";
            cbLoaiLenh_Mua.ValueMember = "Value";
            cbLoaiLenh_Mua.Items.Add(new { Text = "Lệnh khớp liên tục(LO)", Value = "LO" });
            cbLoaiLenh_Mua.SelectedIndex = 0;
            cbLoaiLenh_Mua.SelectedIndex = 0;

            // TODO: This line of code loads data into the 'cHUNGKHOANDataSet.LENHDAT' table. You can move, or remove it, as needed.
            //this.lENHDATTableAdapter.Fill(this.cHUNGKHOANDataSet.LENHDAT);
            // DEPENDENCY
            if (CanRequestNotifications() == true)
                BatDau();
            else
                MessageBox.Show("Bạn chưa kích hoạt dịch vụ Broker", "", MessageBoxButtons.OK);
            //// TODO: This line of code loads data into the 'cHUNGKHOANDataSet.BANGGIATRUCTUYEN' table. You can move, or remove it, as needed.
            //this.bANGGIATRUCTUYENTableAdapter.Fill(this.cHUNGKHOANDataSet.BANGGIATRUCTUYEN);

        }

        private void BatDau()
        {
            // Remove any existing dependency connection, then create a new one.
            // Remove any existing dependency connection, then create a new one.
            SqlDependency.Stop(GetConnectionString());
            try
            {
                SqlDependency.Start(GetConnectionString());
            }
            catch (Exception ex)
            {
                /*Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation);
                return;*/
            }
            if (connection == null)
            {
                connection = new SqlConnection(GetConnectionString());
                connection.Open();
            }
            if (command == null)
                // GetSQL is a local procedure that returns
                // a paramaterized SQL string. You might want
                // to use a stored procedure in your application.
                command = new SqlCommand(GetSQL(), connection);

            if (dataToWatch == null)
                dataToWatch = new DataSet();
            GetData();
        }

        private void GetData()
        {
            // Empty the dataset so that there is only
            // one batch worth of data displayed.
            dataToWatch.Clear();

            // Make sure the command object does not already have
            // a notification object associated with it.

            command.Notification = null;

            // Create and bind the SqlDependency object
            // to the command object.

            SqlDependency dependency = new SqlDependency(command);
            dependency.OnChange += dependency_OnChange;

            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataToWatch, TABLE_NAME);

                this.gvBGTT.DataSource = dataToWatch;
                this.gvBGTT.DataMember = TABLE_NAME;
            }
        }

        private string GetSQL()
        {
            return "select MACP as [MACP],BM_GIA3 as [BM_GIA3],BM_KL3 as [BM_KL3]," +
                "BM_GIA2 as [BM_GIA2],BM_KL2 as [BM_KL2]," +
                "BM_GIA1 as [BM_GIA1],BM_KL1 as [BM_KL1]," +
                "KL_GIA as [KL_GIA],KL_KL as [KL_KL]," +
                "BB_GIA1 as [BB_GIA1],BB_KL1 as [BB_KL1]," +
                "BB_GIA2 as [BB_GIA2],BB_KL2 as [BB_KL2]," +
                "BB_GIA3 as [BB_GIA3],BB_KL3 as [BB_KL3] from dbo.BANGGIATRUCTUYEN";
        }

        private bool CanRequestNotifications()
        {
            // In order to use the callback feature of the
            // SqlDependency, the application must have
            // the SqlClientPermission permission.
            try
            {
                SqlClientPermission perm = new SqlClientPermission(PermissionState.Unrestricted);

                perm.Demand();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string GetConnectionString()
        {
            return "Data Source = LAPTOP-FO9D3FR5; Initial Catalog = CHUNGKHOAN; User ID = sa; Password = 123456";

        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            // This event will occur on a thread pool thread.
            // It is illegal to update the UI from a worker thread
            // The following code checks to see if it is safe update the UI.
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;

            // If InvokeRequired returns True, the code is executing on a worker thread.
            if (i.InvokeRequired)
            {
                // Create a delegate to perform the thread switch
                OnChangeEventHandler tempDelegate = new OnChangeEventHandler(dependency_OnChange);

                object[] args = new[] { sender, e };

                // Marshal the data from the worker thread
                // to the UI thread.
                i.BeginInvoke(tempDelegate, args);

                return;
            }

            // Remove the handler since it's only good
            // for a single notification
            SqlDependency dependency = (SqlDependency)sender;

            dependency.OnChange -= dependency_OnChange;

            // At this point, the code is executing on the
            // UI thread, so it is safe to update the UI.


            // Reload the dataset that's bound to the grid.
            GetData();
        }

        private void rbBan_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;


            if (rb.Checked)
            {
                this.gcMua.Enabled = false;
                this.gcBan.Enabled = true;
                return;
            }
        }

        private void rbMua_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;



            if (rb.Checked)
            {

                this.gcMua.Enabled = true;
                this.gcBan.Enabled = false;
                return;
            }
        }

        private bool ValidateEmptyString(TextEdit txtCK, System.Windows.Forms.ComboBox cmbLenhDat, SpinEdit numSoluong, SpinEdit numGia)
        {

            // TODO : Check khoảng trống ở textField
            if (txtCK.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã Cổ Phiếu không được để trống!", "Lỗi", MessageBoxButtons.OK);
                txtCK.Focus();
                return false;
            }
            if (!(cmbLenhDat.SelectedIndex > -1))
            {
                MessageBox.Show("Bạn chưa chọn lệnh đặt!", "Lỗi", MessageBoxButtons.OK);
                cmbLenhDat.Focus();
                return false;
            }
            if (numSoluong.Value == 0)
            {
                MessageBox.Show("Bạn chưa điền số lượng Cổ Phiếu!", "Lỗi", MessageBoxButtons.OK);
                numSoluong.Focus();
                return false;
            }
            if (numGia.Value == 0)
            {
                MessageBox.Show("Bạn chưa điền giá!", "Lỗi", MessageBoxButtons.OK);
                numGia.Focus();
                return false;
            }

            return true;

        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            bool check = this.ValidateEmptyString(tbMaCP_Ban, cbLoaiLenh_Ban, spSoLuong_Ban, spGiaDat_Ban);
            if (check)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_KHOPLENH_LO", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //get value member from combobox

                        //get daytime
                        DateTime time = DateTime.Now;
                        string format = "yyyy-MM-dd HH:mm:ss.mmm";

                        cmd.Parameters.Add(new SqlParameter("@macp", tbMaCP_Ban.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@Ngay", time.ToString(format)));
                        cmd.Parameters.Add(new SqlParameter("@LoaiGD", "B"));
                        cmd.Parameters.Add(new SqlParameter("@soluongMB", spSoLuong_Ban.Value));
                        cmd.Parameters.Add(new SqlParameter("@giadatMB", spGiaDat_Ban.Value));

                        con.Open();
                        cmd.ExecuteNonQuery();


                    }
                }
            }
            else
            {
                return;
            }
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            bool check = this.ValidateEmptyString(tbMaCP_Mua, cbLoaiLenh_Mua, spSoLuong_Mua, spGiaDat_Mua);

            if (check)
            {
                //do something

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_KHOPLENH_LO", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //get value member from combobox

                        //get daytime
                        DateTime time = DateTime.Now;
                        string format = "yyyy-MM-dd HH:mm:ss.mmm";

                        cmd.Parameters.Add(new SqlParameter("@macp", tbMaCP_Mua.Text.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@Ngay", time.ToString(format)));
                        cmd.Parameters.Add(new SqlParameter("@LoaiGD", "M"));
                        cmd.Parameters.Add(new SqlParameter("@soluongMB", spSoLuong_Mua.Value));
                        cmd.Parameters.Add(new SqlParameter("@giadatMB", spGiaDat_Mua.Value));

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}