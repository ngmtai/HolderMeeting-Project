namespace UI
{
    partial class TcpChat
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
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.txtMsg = new DevExpress.XtraEditors.TextEdit();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.btnListen = new DevExpress.XtraEditors.SimpleButton();
            this.lstResult = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtMsg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(355, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 30);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(21, 57);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(227, 20);
            this.txtMsg.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(263, 52);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 30);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(355, 52);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(75, 30);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "Listen";
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // lstResult
            // 
            this.lstResult.Location = new System.Drawing.Point(21, 92);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(409, 157);
            this.lstResult.TabIndex = 4;
            // 
            // TcpChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 261);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnConnect);
            this.Name = "TcpChat";
            this.Text = "Tcp Chat";
            ((System.ComponentModel.ISupportInitialize)(this.txtMsg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.TextEdit txtMsg;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.SimpleButton btnListen;
        private DevExpress.XtraEditors.ListBoxControl lstResult;
    }
}