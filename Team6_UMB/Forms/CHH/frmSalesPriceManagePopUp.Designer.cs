
namespace Team6_UMB.Forms
{
    partial class frmSalesPricePopUp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbYN = new System.Windows.Forms.ComboBox();
            this.txtPricePresent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.cbProductName = new System.Windows.Forms.ComboBox();
            this.cbCompanyName = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Size = new System.Drawing.Size(372, 35);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.button3, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(146, 24);
            this.label1.Text = "단가관리 - 등록";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCompanyName);
            this.groupBox1.Controls.Add(this.cbProductName);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbYN);
            this.groupBox1.Controls.Add(this.txtPricePresent);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 308);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpEnd.Location = new System.Drawing.Point(76, 145);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(285, 25);
            this.dtpEnd.TabIndex = 41;
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpStart.Location = new System.Drawing.Point(76, 101);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(285, 25);
            this.dtpStart.TabIndex = 40;
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtComment.Location = new System.Drawing.Point(76, 232);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(285, 70);
            this.txtComment.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(10, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "비고";
            // 
            // cbYN
            // 
            this.cbYN.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbYN.FormattingEnabled = true;
            this.cbYN.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cbYN.Location = new System.Drawing.Point(76, 189);
            this.cbYN.Name = "cbYN";
            this.cbYN.Size = new System.Drawing.Size(99, 25);
            this.cbYN.TabIndex = 37;
            // 
            // txtPricePresent
            // 
            this.txtPricePresent.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPricePresent.Location = new System.Drawing.Point(256, 189);
            this.txtPricePresent.Name = "txtPricePresent";
            this.txtPricePresent.Size = new System.Drawing.Size(105, 25);
            this.txtPricePresent.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(190, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 35;
            this.label4.Text = "현재단가";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(10, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 33;
            this.label7.Text = "사용유무";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(10, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "종료일";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(10, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "시작일";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "거래처명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "제품명";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::Team6_UMB.Properties.Resources.Close;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(340, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 23);
            this.button3.TabIndex = 19;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Location = new System.Drawing.Point(118, 371);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 40);
            this.panel2.TabIndex = 25;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Gray;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(84, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 34);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "취소";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(3, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 34);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "저장";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // cbProductName
            // 
            this.cbProductName.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbProductName.FormattingEnabled = true;
            this.cbProductName.Location = new System.Drawing.Point(76, 13);
            this.cbProductName.Name = "cbProductName";
            this.cbProductName.Size = new System.Drawing.Size(285, 25);
            this.cbProductName.TabIndex = 42;
            // 
            // cbCompanyName
            // 
            this.cbCompanyName.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbCompanyName.FormattingEnabled = true;
            this.cbCompanyName.Location = new System.Drawing.Point(76, 57);
            this.cbCompanyName.Name = "cbCompanyName";
            this.cbCompanyName.Size = new System.Drawing.Size(285, 25);
            this.cbCompanyName.TabIndex = 43;
            // 
            // frmSalesPricePopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(394, 416);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSalesPricePopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbYN;
        private System.Windows.Forms.TextBox txtPricePresent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox cbCompanyName;
        private System.Windows.Forms.ComboBox cbProductName;
    }
}
