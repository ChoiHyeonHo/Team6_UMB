
namespace Team6_UMB.Forms.ASB
{
    partial class frmBORPopup
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMachine = new System.Windows.Forms.ComboBox();
            this.txtTactTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUadmin = new System.Windows.Forms.TextBox();
            this.cboYN = new System.Windows.Forms.ComboBox();
            this.cboProductName = new System.Windows.Forms.ComboBox();
            this.cboProcessName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Size = new System.Drawing.Size(425, 35);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.Text = "BillOfResource";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancle);
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Location = new System.Drawing.Point(139, 491);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 44);
            this.panel2.TabIndex = 23;
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.Color.Gray;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancle.ForeColor = System.Drawing.Color.White;
            this.btnCancle.Location = new System.Drawing.Point(84, 7);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 34);
            this.btnCancle.TabIndex = 18;
            this.btnCancle.Text = "취소";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(3, 7);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 34);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "저장";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "품목";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "공정";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(10, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 18);
            this.label5.TabIndex = 29;
            this.label5.Text = "설비";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(10, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "TactTime(Sec)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(10, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 18);
            this.label7.TabIndex = 33;
            this.label7.Text = "사용유무";
            // 
            // cboMachine
            // 
            this.cboMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboMachine.FormattingEnabled = true;
            this.cboMachine.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cboMachine.Location = new System.Drawing.Point(135, 103);
            this.cboMachine.Name = "cboMachine";
            this.cboMachine.Size = new System.Drawing.Size(263, 26);
            this.cboMachine.TabIndex = 43;
            // 
            // txtTactTime
            // 
            this.txtTactTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTactTime.Location = new System.Drawing.Point(135, 146);
            this.txtTactTime.Name = "txtTactTime";
            this.txtTactTime.Size = new System.Drawing.Size(263, 24);
            this.txtTactTime.TabIndex = 49;
            this.txtTactTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTactTime_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(10, 296);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 18);
            this.label13.TabIndex = 62;
            this.label13.Text = "비고";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtComment.Location = new System.Drawing.Point(135, 296);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(263, 117);
            this.txtComment.TabIndex = 63;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUadmin);
            this.groupBox1.Controls.Add(this.cboYN);
            this.groupBox1.Controls.Add(this.cboProductName);
            this.groupBox1.Controls.Add(this.cboProcessName);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtTactTime);
            this.groupBox1.Controls.Add(this.cboMachine);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 418);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // txtUadmin
            // 
            this.txtUadmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUadmin.Location = new System.Drawing.Point(135, 243);
            this.txtUadmin.Name = "txtUadmin";
            this.txtUadmin.Size = new System.Drawing.Size(263, 24);
            this.txtUadmin.TabIndex = 67;
            // 
            // cboYN
            // 
            this.cboYN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboYN.FormattingEnabled = true;
            this.cboYN.Items.AddRange(new object[] {
            "",
            "y",
            "n"});
            this.cboYN.Location = new System.Drawing.Point(135, 189);
            this.cboYN.Name = "cboYN";
            this.cboYN.Size = new System.Drawing.Size(263, 26);
            this.cboYN.TabIndex = 66;
            // 
            // cboProductName
            // 
            this.cboProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboProductName.FormattingEnabled = true;
            this.cboProductName.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cboProductName.Location = new System.Drawing.Point(135, 14);
            this.cboProductName.Name = "cboProductName";
            this.cboProductName.Size = new System.Drawing.Size(263, 26);
            this.cboProductName.TabIndex = 65;
            // 
            // cboProcessName
            // 
            this.cboProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboProcessName.FormattingEnabled = true;
            this.cboProcessName.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cboProcessName.Location = new System.Drawing.Point(135, 57);
            this.cboProcessName.Name = "cboProcessName";
            this.cboProcessName.Size = new System.Drawing.Size(263, 26);
            this.cboProcessName.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 62;
            this.label4.Text = "수정자";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Team6_UMB.Properties.Resources.Close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(393, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 23);
            this.btnClose.TabIndex = 46;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmBORPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(452, 546);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBORPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBorPopUp";
            this.Load += new System.EventHandler(this.frmBORPopup_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMachine;
        private System.Windows.Forms.TextBox txtTactTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboYN;
        private System.Windows.Forms.ComboBox cboProductName;
        private System.Windows.Forms.ComboBox cboProcessName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtUadmin;
        private System.Windows.Forms.Label label4;
    }
}
