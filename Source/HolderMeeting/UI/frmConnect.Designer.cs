namespace UI
{
    partial class frmConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtIp = new DevExpress.XtraEditors.TextEdit();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtIp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nhập địa chỉ: ";
            // 
            // txtIp
            // 
            this.txtIp.EditValue = "192.168.1.2";
            this.txtIp.Location = new System.Drawing.Point(102, 10);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(102, 20);
            this.txtIp.TabIndex = 1;
            this.txtIp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIp_KeyDown);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(219, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 33);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUser
            // 
            this.txtUser.EditValue = "";
            this.txtUser.Location = new System.Drawing.Point(102, 36);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(102, 20);
            this.txtUser.TabIndex = 4;
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIp_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Tên đăng nhập:";
            // 
            // txtPass
            // 
            this.txtPass.EditValue = "";
            this.txtPass.Location = new System.Drawing.Point(102, 62);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(102, 20);
            this.txtPass.TabIndex = 6;
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIp_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Mật khẩu:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(219, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 100);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết nối";
            ((System.ComponentModel.ISupportInitialize)(this.txtIp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtIp;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}