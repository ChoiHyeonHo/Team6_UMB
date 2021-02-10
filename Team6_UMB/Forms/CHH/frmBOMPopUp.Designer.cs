
namespace Team6_UMB.Forms
{
    partial class frmBOMPopUp
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
            this.nuUseCount = new System.Windows.Forms.NumericUpDown();
            this.cbParent = new System.Windows.Forms.ComboBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.nuLevel = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbProd = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblBOMParentID = new System.Windows.Forms.Label();
            this.lblProdParentID = new System.Windows.Forms.Label();
            this.lblProdID = new System.Windows.Forms.Label();
            this.lblBOMID = new System.Windows.Forms.Label();
            this.lblProdType = new System.Windows.Forms.Label();
            this.lblProdUnit = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuUseCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuLevel)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Size = new System.Drawing.Size(381, 35);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.button3, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.Text = "BOM 등록 / 현황";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nuUseCount);
            this.groupBox1.Controls.Add(this.cbParent);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.nuLevel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbProd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 222);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // nuUseCount
            // 
            this.nuUseCount.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nuUseCount.Location = new System.Drawing.Point(71, 82);
            this.nuUseCount.Name = "nuUseCount";
            this.nuUseCount.Size = new System.Drawing.Size(102, 25);
            this.nuUseCount.TabIndex = 63;
            // 
            // cbParent
            // 
            this.cbParent.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbParent.FormattingEnabled = true;
            this.cbParent.Location = new System.Drawing.Point(72, 20);
            this.cbParent.Name = "cbParent";
            this.cbParent.Size = new System.Drawing.Size(300, 25);
            this.cbParent.TabIndex = 62;
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtComment.Location = new System.Drawing.Point(72, 113);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(300, 100);
            this.txtComment.TabIndex = 61;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(6, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 17);
            this.label14.TabIndex = 60;
            this.label14.Text = "비고";
            // 
            // nuLevel
            // 
            this.nuLevel.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nuLevel.Location = new System.Drawing.Point(269, 82);
            this.nuLevel.Name = "nuLevel";
            this.nuLevel.Size = new System.Drawing.Size(103, 25);
            this.nuLevel.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(207, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 41;
            this.label5.Text = "Level";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(5, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "소요량";
            // 
            // cbProd
            // 
            this.cbProd.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbProd.FormattingEnabled = true;
            this.cbProd.Location = new System.Drawing.Point(72, 51);
            this.cbProd.Name = "cbProd";
            this.cbProd.Size = new System.Drawing.Size(300, 25);
            this.cbProd.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "제품명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "상위품목";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::Team6_UMB.Properties.Resources.Close;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(348, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 23);
            this.button3.TabIndex = 21;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancle);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Location = new System.Drawing.Point(121, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 40);
            this.panel2.TabIndex = 64;
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
            // lblBOMParentID
            // 
            this.lblBOMParentID.AutoSize = true;
            this.lblBOMParentID.Location = new System.Drawing.Point(12, 294);
            this.lblBOMParentID.Name = "lblBOMParentID";
            this.lblBOMParentID.Size = new System.Drawing.Size(72, 12);
            this.lblBOMParentID.TabIndex = 65;
            this.lblBOMParentID.Text = "상위BOM ID";
            this.lblBOMParentID.Visible = false;
            // 
            // lblProdParentID
            // 
            this.lblProdParentID.AutoSize = true;
            this.lblProdParentID.Location = new System.Drawing.Point(12, 310);
            this.lblProdParentID.Name = "lblProdParentID";
            this.lblProdParentID.Size = new System.Drawing.Size(64, 12);
            this.lblProdParentID.TabIndex = 66;
            this.lblProdParentID.Text = "상위품목ID";
            this.lblProdParentID.Visible = false;
            // 
            // lblProdID
            // 
            this.lblProdID.AutoSize = true;
            this.lblProdID.Location = new System.Drawing.Point(304, 282);
            this.lblProdID.Name = "lblProdID";
            this.lblProdID.Size = new System.Drawing.Size(40, 12);
            this.lblProdID.TabIndex = 67;
            this.lblProdID.Text = "제품ID";
            this.lblProdID.Visible = false;
            // 
            // lblBOMID
            // 
            this.lblBOMID.AutoSize = true;
            this.lblBOMID.Location = new System.Drawing.Point(12, 282);
            this.lblBOMID.Name = "lblBOMID";
            this.lblBOMID.Size = new System.Drawing.Size(48, 12);
            this.lblBOMID.TabIndex = 68;
            this.lblBOMID.Text = "BOM ID";
            this.lblBOMID.Visible = false;
            // 
            // lblProdType
            // 
            this.lblProdType.AutoSize = true;
            this.lblProdType.Location = new System.Drawing.Point(304, 294);
            this.lblProdType.Name = "lblProdType";
            this.lblProdType.Size = new System.Drawing.Size(29, 12);
            this.lblProdType.TabIndex = 69;
            this.lblProdType.Text = "분류";
            this.lblProdType.Visible = false;
            // 
            // lblProdUnit
            // 
            this.lblProdUnit.AutoSize = true;
            this.lblProdUnit.Location = new System.Drawing.Point(304, 310);
            this.lblProdUnit.Name = "lblProdUnit";
            this.lblProdUnit.Size = new System.Drawing.Size(29, 12);
            this.lblProdUnit.TabIndex = 70;
            this.lblProdUnit.Text = "단위";
            this.lblProdUnit.Visible = false;
            // 
            // frmBOMPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(401, 332);
            this.Controls.Add(this.lblProdUnit);
            this.Controls.Add(this.lblProdType);
            this.Controls.Add(this.lblBOMID);
            this.Controls.Add(this.lblProdID);
            this.Controls.Add(this.lblProdParentID);
            this.Controls.Add(this.lblBOMParentID);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBOMPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.lblBOMParentID, 0);
            this.Controls.SetChildIndex(this.lblProdParentID, 0);
            this.Controls.SetChildIndex(this.lblProdID, 0);
            this.Controls.SetChildIndex(this.lblBOMID, 0);
            this.Controls.SetChildIndex(this.lblProdType, 0);
            this.Controls.SetChildIndex(this.lblProdUnit, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuUseCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuLevel)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nuLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbProd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nuUseCount;
        private System.Windows.Forms.ComboBox cbParent;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblBOMParentID;
        private System.Windows.Forms.Label lblProdParentID;
        private System.Windows.Forms.Label lblProdID;
        private System.Windows.Forms.Label lblBOMID;
        private System.Windows.Forms.Label lblProdType;
        private System.Windows.Forms.Label lblProdUnit;
    }
}
