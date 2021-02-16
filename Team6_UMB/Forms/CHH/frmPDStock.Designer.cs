
namespace Team6_UMB.Forms
{
    partial class frmPDStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbProdName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.periodSearchControl = new PJT_Olive.Control.PeriodSearchControl();
            this.cbWHName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbProdType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_PDStock = new Team6_UMB.DGV_Custom();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.newBtns1 = new Team6_UMB.Controls.NewBtns();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PDStock)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.newBtns1);
            this.panel1.Size = new System.Drawing.Size(1511, 35);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.newBtns1, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.Text = "재고현황";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbProdName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.periodSearchControl);
            this.groupBox1.Controls.Add(this.cbWHName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cbProdType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1511, 50);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // cbProdName
            // 
            this.cbProdName.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbProdName.FormattingEnabled = true;
            this.cbProdName.Location = new System.Drawing.Point(414, 16);
            this.cbProdName.Name = "cbProdName";
            this.cbProdName.Size = new System.Drawing.Size(178, 25);
            this.cbProdName.TabIndex = 37;
            this.cbProdName.SelectedIndexChanged += new System.EventHandler(this.cbProdName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 36;
            this.label4.Text = "기간";
            // 
            // periodSearchControl
            // 
            this.periodSearchControl.DateType = "";
            this.periodSearchControl.dtFrom = "2021-01-12";
            this.periodSearchControl.dtTo = "2021-01-19";
            this.periodSearchControl.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.periodSearchControl.Location = new System.Drawing.Point(41, 15);
            this.periodSearchControl.Name = "periodSearchControl";
            this.periodSearchControl.Size = new System.Drawing.Size(301, 29);
            this.periodSearchControl.TabIndex = 35;
            this.periodSearchControl.ChangedPeriod += new System.EventHandler(this.periodSearchControl1_ChangedPeriod);
            // 
            // cbWHName
            // 
            this.cbWHName.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbWHName.FormattingEnabled = true;
            this.cbWHName.Location = new System.Drawing.Point(969, 15);
            this.cbWHName.Name = "cbWHName";
            this.cbWHName.Size = new System.Drawing.Size(199, 25);
            this.cbWHName.TabIndex = 34;
            this.cbWHName.SelectedIndexChanged += new System.EventHandler(this.cbWHName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(920, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "창고명";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackgroundImage = global::Team6_UMB.Properties.Resources.Search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(1174, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 30);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbProdType
            // 
            this.cbProdType.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbProdType.FormattingEnabled = true;
            this.cbProdType.Location = new System.Drawing.Point(689, 15);
            this.cbProdType.Name = "cbProdType";
            this.cbProdType.Size = new System.Drawing.Size(199, 25);
            this.cbProdType.TabIndex = 27;
            this.cbProdType.SelectedIndexChanged += new System.EventHandler(this.cbProdType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(646, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "분류";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(361, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "품목명";
            // 
            // dgv_PDStock
            // 
            this.dgv_PDStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_PDStock.BackgroundColor = System.Drawing.Color.White;
            this.dgv_PDStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔바른고딕", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PDStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_PDStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PDStock.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgv_PDStock.GridColor = System.Drawing.Color.LightGray;
            this.dgv_PDStock.Location = new System.Drawing.Point(12, 141);
            this.dgv_PDStock.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgv_PDStock.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgv_PDStock.Name = "dgv_PDStock";
            this.dgv_PDStock.RowTemplate.Height = 23;
            this.dgv_PDStock.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_PDStock.Size = new System.Drawing.Size(1510, 800);
            this.dgv_PDStock.TabIndex = 19;
            this.dgv_PDStock.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PDStock_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(12, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1511, 35);
            this.panel2.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "재고현황 리스트";
            // 
            // newBtns1
            // 
            this.newBtns1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.newBtns1.Dock = System.Windows.Forms.DockStyle.Right;
            this.newBtns1.Location = new System.Drawing.Point(741, 0);
            this.newBtns1.Name = "newBtns1";
            this.newBtns1.Size = new System.Drawing.Size(770, 35);
            this.newBtns1.TabIndex = 2;
            this.newBtns1.btnRefresh_Event += new System.EventHandler(this.newBtns1_btnRefresh_Event);
            // 
            // frmPDStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1535, 950);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_PDStock);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPDStock";
            this.Load += new System.EventHandler(this.frmPDStock_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dgv_PDStock, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PDStock)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbProdType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private PJT_Olive.Control.PeriodSearchControl periodSearchControl;
        private System.Windows.Forms.ComboBox cbWHName;
        private System.Windows.Forms.Label label5;
        private DGV_Custom dgv_PDStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private Controls.NewBtns newBtns1;
        private System.Windows.Forms.ComboBox cbProdName;
    }
}
