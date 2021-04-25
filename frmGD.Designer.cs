
namespace CHUNGKHOAN
{
    partial class frmGD
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.gcBan = new DevExpress.XtraEditors.GroupControl();
            this.gcMua = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMua)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.radioButton2);
            this.groupControl1.Controls.Add(this.radioButton1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(817, 100);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Loại GD";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(86, 52);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Đặt bán";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(298, 52);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(82, 21);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Đặt mua";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // gcBan
            // 
            this.gcBan.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcBan.Location = new System.Drawing.Point(0, 100);
            this.gcBan.Name = "gcBan";
            this.gcBan.Size = new System.Drawing.Size(409, 350);
            this.gcBan.TabIndex = 1;
            this.gcBan.Text = "Đặt bán";
            // 
            // gcMua
            // 
            this.gcMua.Dock = System.Windows.Forms.DockStyle.Right;
            this.gcMua.Location = new System.Drawing.Point(407, 100);
            this.gcMua.Name = "gcMua";
            this.gcMua.Size = new System.Drawing.Size(410, 350);
            this.gcMua.TabIndex = 2;
            this.gcMua.Text = "Đặt mua";
            // 
            // frmGD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 450);
            this.Controls.Add(this.gcMua);
            this.Controls.Add(this.gcBan);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmGD";
            this.Text = "frmGD";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private DevExpress.XtraEditors.GroupControl gcBan;
        private DevExpress.XtraEditors.GroupControl gcMua;
    }
}