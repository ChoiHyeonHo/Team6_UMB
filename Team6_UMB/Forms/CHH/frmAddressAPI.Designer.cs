namespace Team6_UMB.Forms.CHH
{
    partial class frmAddressAPI
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
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvRoadAPI = new Team6_UMB.DGV_Custom();
            this.txtRoadAddr2 = new System.Windows.Forms.TextBox();
            this.txtRoadZipcode = new System.Windows.Forms.TextBox();
            this.txtRoadAddr1 = new System.Windows.Forms.TextBox();
            this.btnRoad = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoadAPI)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Size = new System.Drawing.Size(1027, 35);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.Text = "주소찾기";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Team6_UMB.Properties.Resources.Close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(984, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 23);
            this.btnClose.TabIndex = 47;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1027, 50);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackgroundImage = global::Team6_UMB.Properties.Resources.Search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(777, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 30);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearch.Location = new System.Drawing.Point(368, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(394, 25);
            this.txtSearch.TabIndex = 23;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(260, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "도로명주소 검색";
            // 
            // dgvRoadAPI
            // 
            this.dgvRoadAPI.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoadAPI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("나눔바른고딕", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoadAPI.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoadAPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoadAPI.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvRoadAPI.GridColor = System.Drawing.Color.LightGray;
            this.dgvRoadAPI.Location = new System.Drawing.Point(13, 111);
            this.dgvRoadAPI.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgvRoadAPI.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgvRoadAPI.Name = "dgvRoadAPI";
            this.dgvRoadAPI.RowTemplate.Height = 23;
            this.dgvRoadAPI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRoadAPI.Size = new System.Drawing.Size(1026, 250);
            this.dgvRoadAPI.TabIndex = 25;
            this.dgvRoadAPI.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoadAPI_CellDoubleClick);
            // 
            // txtRoadAddr2
            // 
            this.txtRoadAddr2.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRoadAddr2.Location = new System.Drawing.Point(13, 396);
            this.txtRoadAddr2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoadAddr2.Name = "txtRoadAddr2";
            this.txtRoadAddr2.ReadOnly = true;
            this.txtRoadAddr2.Size = new System.Drawing.Size(894, 25);
            this.txtRoadAddr2.TabIndex = 29;
            // 
            // txtRoadZipcode
            // 
            this.txtRoadZipcode.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRoadZipcode.Location = new System.Drawing.Point(13, 366);
            this.txtRoadZipcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoadZipcode.Name = "txtRoadZipcode";
            this.txtRoadZipcode.ReadOnly = true;
            this.txtRoadZipcode.Size = new System.Drawing.Size(162, 25);
            this.txtRoadZipcode.TabIndex = 28;
            // 
            // txtRoadAddr1
            // 
            this.txtRoadAddr1.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRoadAddr1.Location = new System.Drawing.Point(181, 366);
            this.txtRoadAddr1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoadAddr1.Name = "txtRoadAddr1";
            this.txtRoadAddr1.ReadOnly = true;
            this.txtRoadAddr1.Size = new System.Drawing.Size(726, 25);
            this.txtRoadAddr1.TabIndex = 27;
            // 
            // btnRoad
            // 
            this.btnRoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoad.Location = new System.Drawing.Point(913, 366);
            this.btnRoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRoad.Name = "btnRoad";
            this.btnRoad.Size = new System.Drawing.Size(126, 55);
            this.btnRoad.TabIndex = 26;
            this.btnRoad.Text = "주소 확인";
            this.btnRoad.UseVisualStyleBackColor = true;
            this.btnRoad.Click += new System.EventHandler(this.btnRoad_Click);
            // 
            // frmAddressAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1051, 432);
            this.Controls.Add(this.txtRoadAddr2);
            this.Controls.Add(this.txtRoadZipcode);
            this.Controls.Add(this.txtRoadAddr1);
            this.Controls.Add(this.btnRoad);
            this.Controls.Add(this.dgvRoadAPI);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddressAPI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dgvRoadAPI, 0);
            this.Controls.SetChildIndex(this.btnRoad, 0);
            this.Controls.SetChildIndex(this.txtRoadAddr1, 0);
            this.Controls.SetChildIndex(this.txtRoadZipcode, 0);
            this.Controls.SetChildIndex(this.txtRoadAddr2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoadAPI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private DGV_Custom dgvRoadAPI;
        private System.Windows.Forms.TextBox txtRoadAddr2;
        private System.Windows.Forms.TextBox txtRoadZipcode;
        private System.Windows.Forms.TextBox txtRoadAddr1;
        private System.Windows.Forms.Button btnRoad;
    }
}
