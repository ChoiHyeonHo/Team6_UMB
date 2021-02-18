
namespace Team6_UMB.Forms
{
    partial class frmProductManagePopUp
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
            this.lblCompanyID = new System.Windows.Forms.Label();
            this.cbDeleted = new System.Windows.Forms.ComboBox();
            this.lblWHID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtProdID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbProdName = new System.Windows.Forms.ComboBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.cbWHouse = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStnd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbExamYN = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nuSafeCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nuMinOrder = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbProdType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuSafeCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuMinOrder)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Size = new System.Drawing.Size(586, 35);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.Text = "품목 등록 / 수정";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCompanyID);
            this.groupBox1.Controls.Add(this.cbDeleted);
            this.groupBox1.Controls.Add(this.lblWHID);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtProdID);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbProdName);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cbCompany);
            this.groupBox1.Controls.Add(this.cbWHouse);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtStnd);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbExamYN);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nuSafeCount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nuMinOrder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbUnit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbProdType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 274);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // lblCompanyID
            // 
            this.lblCompanyID.AutoSize = true;
            this.lblCompanyID.Location = new System.Drawing.Point(490, 178);
            this.lblCompanyID.Name = "lblCompanyID";
            this.lblCompanyID.Size = new System.Drawing.Size(88, 12);
            this.lblCompanyID.TabIndex = 64;
            this.lblCompanyID.Text = "업체ID임시변수";
            this.lblCompanyID.Visible = false;
            // 
            // cbDeleted
            // 
            this.cbDeleted.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbDeleted.FormattingEnabled = true;
            this.cbDeleted.Items.AddRange(new object[] {
            "",
            "Y",
            "N"});
            this.cbDeleted.Location = new System.Drawing.Point(72, 172);
            this.cbDeleted.Name = "cbDeleted";
            this.cbDeleted.Size = new System.Drawing.Size(198, 25);
            this.cbDeleted.TabIndex = 66;
            // 
            // lblWHID
            // 
            this.lblWHID.AutoSize = true;
            this.lblWHID.Location = new System.Drawing.Point(378, 178);
            this.lblWHID.Name = "lblWHID";
            this.lblWHID.Size = new System.Drawing.Size(88, 12);
            this.lblWHID.TabIndex = 63;
            this.lblWHID.Text = "창고ID임시변수";
            this.lblWHID.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label12.Location = new System.Drawing.Point(6, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 65;
            this.label12.Text = "사용여부";
            // 
            // txtProdID
            // 
            this.txtProdID.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProdID.Location = new System.Drawing.Point(72, 13);
            this.txtProdID.Name = "txtProdID";
            this.txtProdID.Size = new System.Drawing.Size(198, 25);
            this.txtProdID.TabIndex = 64;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label11.Location = new System.Drawing.Point(6, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 17);
            this.label11.TabIndex = 63;
            this.label11.Text = "제품ID";
            // 
            // cbProdName
            // 
            this.cbProdName.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbProdName.FormattingEnabled = true;
            this.cbProdName.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cbProdName.Location = new System.Drawing.Point(380, 10);
            this.cbProdName.Name = "cbProdName";
            this.cbProdName.Size = new System.Drawing.Size(198, 25);
            this.cbProdName.TabIndex = 62;
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtComment.Location = new System.Drawing.Point(72, 203);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(506, 62);
            this.txtComment.TabIndex = 61;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(6, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 17);
            this.label14.TabIndex = 60;
            this.label14.Text = "비고";
            // 
            // cbCompany
            // 
            this.cbCompany.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cbCompany.Location = new System.Drawing.Point(380, 73);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(198, 25);
            this.cbCompany.TabIndex = 53;
            // 
            // cbWHouse
            // 
            this.cbWHouse.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbWHouse.FormattingEnabled = true;
            this.cbWHouse.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cbWHouse.Location = new System.Drawing.Point(380, 41);
            this.cbWHouse.Name = "cbWHouse";
            this.cbWHouse.Size = new System.Drawing.Size(198, 25);
            this.cbWHouse.TabIndex = 52;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(314, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 17);
            this.label10.TabIndex = 51;
            this.label10.Text = "창고";
            // 
            // txtStnd
            // 
            this.txtStnd.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtStnd.Location = new System.Drawing.Point(380, 140);
            this.txtStnd.Name = "txtStnd";
            this.txtStnd.Size = new System.Drawing.Size(198, 25);
            this.txtStnd.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(314, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 17);
            this.label9.TabIndex = 49;
            this.label9.Text = "규격";
            // 
            // cbExamYN
            // 
            this.cbExamYN.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbExamYN.FormattingEnabled = true;
            this.cbExamYN.Items.AddRange(new object[] {
            "",
            "Y",
            "N"});
            this.cbExamYN.Location = new System.Drawing.Point(380, 106);
            this.cbExamYN.Name = "cbExamYN";
            this.cbExamYN.Size = new System.Drawing.Size(198, 25);
            this.cbExamYN.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(314, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 47;
            this.label8.Text = "검사여부";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(314, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 45;
            this.label7.Text = "업체명";
            // 
            // nuSafeCount
            // 
            this.nuSafeCount.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nuSafeCount.Location = new System.Drawing.Point(72, 141);
            this.nuSafeCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nuSafeCount.Name = "nuSafeCount";
            this.nuSafeCount.Size = new System.Drawing.Size(198, 25);
            this.nuSafeCount.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 43;
            this.label6.Text = "안전재고";
            // 
            // nuMinOrder
            // 
            this.nuMinOrder.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nuMinOrder.Location = new System.Drawing.Point(72, 109);
            this.nuMinOrder.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nuMinOrder.Name = "nuMinOrder";
            this.nuMinOrder.Size = new System.Drawing.Size(198, 25);
            this.nuMinOrder.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(6, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 41;
            this.label5.Text = "최소발주";
            // 
            // cbUnit
            // 
            this.cbUnit.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Items.AddRange(new object[] {
            "",
            "EA"});
            this.cbUnit.Location = new System.Drawing.Point(72, 75);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(198, 25);
            this.cbUnit.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "단위";
            // 
            // cbProdType
            // 
            this.cbProdType.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbProdType.FormattingEnabled = true;
            this.cbProdType.Items.AddRange(new object[] {
            "",
            "반제품",
            "원자재",
            "완제품"});
            this.cbProdType.Location = new System.Drawing.Point(72, 44);
            this.cbProdType.Name = "cbProdType";
            this.cbProdType.Size = new System.Drawing.Size(198, 25);
            this.cbProdType.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "제품분류";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(314, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "품목명";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Team6_UMB.Properties.Resources.Close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(549, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 23);
            this.btnClose.TabIndex = 20;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancle);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Location = new System.Drawing.Point(232, 337);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 40);
            this.panel2.TabIndex = 25;
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.Color.Gray;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancle.ForeColor = System.Drawing.Color.White;
            this.btnCancle.Location = new System.Drawing.Point(84, 4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 34);
            this.btnCancle.TabIndex = 18;
            this.btnCancle.Text = "취소";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 34);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "저장";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmProductManagePopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(610, 390);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProductManagePopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuSafeCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuMinOrder)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbProdType;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.ComboBox cbWHouse;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStnd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbExamYN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nuSafeCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nuMinOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblWHID;
        private System.Windows.Forms.Label lblCompanyID;
        private System.Windows.Forms.ComboBox cbProdName;
        private System.Windows.Forms.TextBox txtProdID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbDeleted;
        private System.Windows.Forms.Label label12;
    }
}
