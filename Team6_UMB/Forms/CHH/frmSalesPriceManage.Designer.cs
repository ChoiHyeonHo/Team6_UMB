
namespace Team6_UMB.Forms
{
    partial class frmSalesPriceManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPrice = new Team6_UMB.DGV_Custom();
            this.temp6 = new System.Windows.Forms.GroupBox();
            this.cheView = new System.Windows.Forms.CheckBox();
            this.btnWhere = new System.Windows.Forms.Button();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.periodSearchControl = new PJT_Olive.Control.PeriodSearchControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.newBtns = new Team6_UMB.Controls.NewBtns();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrice)).BeginInit();
            this.temp6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.newBtns);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Size = new System.Drawing.Size(1511, 35);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.newBtns, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.Text = "영업단가관리";
            // 
            // dgvPrice
            // 
            this.dgvPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrice.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrice.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvPrice.GridColor = System.Drawing.Color.LightGray;
            this.dgvPrice.Location = new System.Drawing.Point(12, 141);
            this.dgvPrice.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgvPrice.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.RowTemplate.Height = 23;
            this.dgvPrice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPrice.Size = new System.Drawing.Size(1510, 800);
            this.dgvPrice.TabIndex = 21;
            this.dgvPrice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrice_CellDoubleClick);
            // 
            // temp6
            // 
            this.temp6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.temp6.Controls.Add(this.cheView);
            this.temp6.Controls.Add(this.btnWhere);
            this.temp6.Controls.Add(this.txtCompanyName);
            this.temp6.Controls.Add(this.label4);
            this.temp6.Controls.Add(this.txtProdName);
            this.temp6.Controls.Add(this.label3);
            this.temp6.Controls.Add(this.label2);
            this.temp6.Controls.Add(this.periodSearchControl);
            this.temp6.Location = new System.Drawing.Point(12, 57);
            this.temp6.Name = "temp6";
            this.temp6.Size = new System.Drawing.Size(1511, 50);
            this.temp6.TabIndex = 17;
            this.temp6.TabStop = false;
            // 
            // cheView
            // 
            this.cheView.AutoSize = true;
            this.cheView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cheView.Location = new System.Drawing.Point(1426, 19);
            this.cheView.Name = "cheView";
            this.cheView.Size = new System.Drawing.Size(79, 22);
            this.cheView.TabIndex = 23;
            this.cheView.Text = "전체보기";
            this.cheView.UseVisualStyleBackColor = true;
            this.cheView.Click += new System.EventHandler(this.cheView_Click);
            // 
            // btnWhere
            // 
            this.btnWhere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWhere.BackgroundImage = global::Team6_UMB.Properties.Resources.Search;
            this.btnWhere.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWhere.FlatAppearance.BorderSize = 0;
            this.btnWhere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhere.Location = new System.Drawing.Point(859, 12);
            this.btnWhere.Name = "btnWhere";
            this.btnWhere.Size = new System.Drawing.Size(34, 30);
            this.btnWhere.TabIndex = 21;
            this.btnWhere.UseVisualStyleBackColor = true;
            this.btnWhere.Click += new System.EventHandler(this.btnWhere_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCompanyName.Location = new System.Drawing.Point(689, 15);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(164, 24);
            this.txtCompanyName.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(622, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "거래처명";
            // 
            // txtProdName
            // 
            this.txtProdName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProdName.Location = new System.Drawing.Point(414, 15);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(180, 24);
            this.txtProdName.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(361, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "품목명";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "기간";
            // 
            // periodSearchControl
            // 
            this.periodSearchControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.periodSearchControl.DateType = "";
            this.periodSearchControl.dtFrom = "2021-01-11";
            this.periodSearchControl.dtTo = "2021-01-18";
            this.periodSearchControl.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.periodSearchControl.Location = new System.Drawing.Point(41, 15);
            this.periodSearchControl.Name = "periodSearchControl";
            this.periodSearchControl.Size = new System.Drawing.Size(301, 29);
            this.periodSearchControl.TabIndex = 0;
            this.periodSearchControl.ChangedPeriod += new System.EventHandler(this.periodSearchControl_ChangedPeriod);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(12, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1511, 35);
            this.panel2.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 18);
            this.label5.TabIndex = 22;
            this.label5.Text = "영업단가 리스트";
            // 
            // newBtns
            // 
            this.newBtns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.newBtns.Dock = System.Windows.Forms.DockStyle.Right;
            this.newBtns.Location = new System.Drawing.Point(741, 0);
            this.newBtns.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.newBtns.Name = "newBtns";
            this.newBtns.Size = new System.Drawing.Size(770, 35);
            this.newBtns.TabIndex = 2;
            this.newBtns.btnRefresh_Event += new System.EventHandler(this.newBtns_btnRefresh_Event);
            this.newBtns.btnCreate_Event += new System.EventHandler(this.newBtns_btnCreate_Event);
            this.newBtns.btnUpdate_Event += new System.EventHandler(this.newBtns_btnUpdate_Event);
            this.newBtns.btnDelete_Event += new System.EventHandler(this.newBtns_btnDelete_Event);
            this.newBtns.btnExcel_Event += new System.EventHandler(this.newBtns_btnExcel_Event);
            // 
            // frmSalesPriceManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1535, 950);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvPrice);
            this.Controls.Add(this.temp6);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSalesPriceManage";
            this.Load += new System.EventHandler(this.frmSalesPriceManage_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.temp6, 0);
            this.Controls.SetChildIndex(this.dgvPrice, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrice)).EndInit();
            this.temp6.ResumeLayout(false);
            this.temp6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DGV_Custom dgvPrice;
        private System.Windows.Forms.GroupBox temp6;
        private System.Windows.Forms.Button btnWhere;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private Controls.NewBtns newBtns;
        private System.Windows.Forms.CheckBox cheView;
        private System.Windows.Forms.Label label2;
        private PJT_Olive.Control.PeriodSearchControl periodSearchControl;
    }
}
