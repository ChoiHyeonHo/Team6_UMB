
namespace Team6_UMB.Forms
{
    partial class frmCompanyPopUp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyPopUp));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDetAddress = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCPNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnZip = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCGtype = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCBtype = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCFax = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCEmail = new System.Windows.Forms.TextBox();
            this.txtCNum = new System.Windows.Forms.TextBox();
            this.txtCCeo = new System.Windows.Forms.TextBox();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCompanyID = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Size = new System.Drawing.Size(612, 35);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.Text = "업체 정보";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Location = new System.Drawing.Point(232, 476);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 44);
            this.panel2.TabIndex = 21;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Gray;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(84, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 34);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "취소";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(3, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 34);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "저장";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtDetAddress);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtCPNum);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.btnZip);
            this.groupBox1.Controls.Add(this.txtZipCode);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCGtype);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtCBtype);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtCFax);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCEmail);
            this.groupBox1.Controls.Add(this.txtCNum);
            this.groupBox1.Controls.Add(this.txtCCeo);
            this.groupBox1.Controls.Add(this.txtCName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbCType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 413);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label15.Location = new System.Drawing.Point(311, 238);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 17);
            this.label15.TabIndex = 76;
            this.label15.Text = "상세주소";
            // 
            // txtDetAddress
            // 
            this.txtDetAddress.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetAddress.Location = new System.Drawing.Point(380, 237);
            this.txtDetAddress.Multiline = true;
            this.txtDetAddress.Name = "txtDetAddress";
            this.txtDetAddress.Size = new System.Drawing.Size(214, 67);
            this.txtDetAddress.TabIndex = 75;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label12.Location = new System.Drawing.Point(311, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 74;
            this.label12.Text = "업체주소";
            // 
            // txtCPNum
            // 
            this.txtCPNum.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPNum.Location = new System.Drawing.Point(111, 237);
            this.txtCPNum.Name = "txtCPNum";
            this.txtCPNum.Size = new System.Drawing.Size(179, 25);
            this.txtCPNum.TabIndex = 73;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(11, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 72;
            this.label8.Text = "전화번호";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(380, 191);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(214, 25);
            this.txtAddress.TabIndex = 71;
            // 
            // btnZip
            // 
            this.btnZip.BackColor = System.Drawing.Color.Transparent;
            this.btnZip.FlatAppearance.BorderSize = 0;
            this.btnZip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZip.ImageKey = "Search.png";
            this.btnZip.ImageList = this.imageList1;
            this.btnZip.Location = new System.Drawing.Point(572, 144);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(30, 28);
            this.btnZip.TabIndex = 70;
            this.btnZip.UseVisualStyleBackColor = false;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Search.png");
            // 
            // txtZipCode
            // 
            this.txtZipCode.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZipCode.Location = new System.Drawing.Point(380, 146);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(188, 25);
            this.txtZipCode.TabIndex = 69;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label11.Location = new System.Drawing.Point(311, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 17);
            this.label11.TabIndex = 68;
            this.label11.Text = "업체지번";
            // 
            // txtCGtype
            // 
            this.txtCGtype.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCGtype.Location = new System.Drawing.Point(380, 100);
            this.txtCGtype.Name = "txtCGtype";
            this.txtCGtype.Size = new System.Drawing.Size(214, 25);
            this.txtCGtype.TabIndex = 67;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label14.Location = new System.Drawing.Point(311, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 17);
            this.label14.TabIndex = 66;
            this.label14.Text = "업태";
            // 
            // txtCBtype
            // 
            this.txtCBtype.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCBtype.Location = new System.Drawing.Point(380, 57);
            this.txtCBtype.Name = "txtCBtype";
            this.txtCBtype.Size = new System.Drawing.Size(214, 25);
            this.txtCBtype.TabIndex = 65;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(311, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 17);
            this.label10.TabIndex = 64;
            this.label10.Text = "업종";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(111, 319);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(484, 82);
            this.txtComment.TabIndex = 63;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(10, 322);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 17);
            this.label13.TabIndex = 62;
            this.label13.Text = "비고";
            // 
            // txtCFax
            // 
            this.txtCFax.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCFax.Location = new System.Drawing.Point(380, 14);
            this.txtCFax.Name = "txtCFax";
            this.txtCFax.Size = new System.Drawing.Size(214, 25);
            this.txtCFax.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(311, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 17);
            this.label9.TabIndex = 54;
            this.label9.Text = "팩스";
            // 
            // txtCEmail
            // 
            this.txtCEmail.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCEmail.Location = new System.Drawing.Point(111, 193);
            this.txtCEmail.Name = "txtCEmail";
            this.txtCEmail.Size = new System.Drawing.Size(179, 25);
            this.txtCEmail.TabIndex = 51;
            // 
            // txtCNum
            // 
            this.txtCNum.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCNum.Location = new System.Drawing.Point(111, 146);
            this.txtCNum.Name = "txtCNum";
            this.txtCNum.Size = new System.Drawing.Size(179, 25);
            this.txtCNum.TabIndex = 50;
            // 
            // txtCCeo
            // 
            this.txtCCeo.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCeo.Location = new System.Drawing.Point(111, 102);
            this.txtCCeo.Name = "txtCCeo";
            this.txtCCeo.Size = new System.Drawing.Size(179, 25);
            this.txtCCeo.TabIndex = 49;
            // 
            // txtCName
            // 
            this.txtCName.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCName.Location = new System.Drawing.Point(111, 14);
            this.txtCName.Name = "txtCName";
            this.txtCName.Size = new System.Drawing.Size(179, 25);
            this.txtCName.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "이메일";
            // 
            // cbCType
            // 
            this.cbCType.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCType.FormattingEnabled = true;
            this.cbCType.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cbCType.Location = new System.Drawing.Point(111, 59);
            this.cbCType.Name = "cbCType";
            this.cbCType.Size = new System.Drawing.Size(179, 25);
            this.cbCType.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(10, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 33;
            this.label7.Text = "사업자등록번호";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(10, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "대표자명";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(10, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "업체구분";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(10, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "업체명";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Team6_UMB.Properties.Resources.Close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(580, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 23);
            this.btnClose.TabIndex = 46;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCompanyID
            // 
            this.lblCompanyID.AutoSize = true;
            this.lblCompanyID.Location = new System.Drawing.Point(26, 477);
            this.lblCompanyID.Name = "lblCompanyID";
            this.lblCompanyID.Size = new System.Drawing.Size(92, 12);
            this.lblCompanyID.TabIndex = 22;
            this.lblCompanyID.Text = "업체ID 임시라벨";
            this.lblCompanyID.Visible = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(26, 496);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(105, 12);
            this.lblUserName.TabIndex = 23;
            this.lblUserName.Text = "사용자명 임시라벨";
            this.lblUserName.Visible = false;
            // 
            // frmCompanyPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(636, 527);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblCompanyID);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCompanyPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCompanyPopUp";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.lblCompanyID, 0);
            this.Controls.SetChildIndex(this.lblUserName, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCFax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCEmail;
        private System.Windows.Forms.TextBox txtCNum;
        private System.Windows.Forms.TextBox txtCCeo;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCPNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnZip;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCGtype;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCBtype;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDetAddress;
        private System.Windows.Forms.Label lblCompanyID;
        private System.Windows.Forms.Label lblUserName;
    }
}
