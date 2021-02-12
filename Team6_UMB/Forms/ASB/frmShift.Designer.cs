
namespace Team6_UMB.Forms.ASB
{
    partial class frmShift
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvShift = new Team6_UMB.DGV_Custom();
            this.shift_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_stime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_etime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_sdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_edate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_yn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_personnel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_ptime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_uadmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_udate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAllButtons1 = new Team6_UMB.Controls.btnAllButtons();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.periodSearchControl1 = new PJT_Olive.Control.PeriodSearchControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvShift
            // 
            this.dgvShift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShift.BackgroundColor = System.Drawing.Color.White;
            this.dgvShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShift.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shift_id,
            this.m_id,
            this.shift_stime,
            this.shift_etime,
            this.shift_sdate,
            this.shift_edate,
            this.shift_yn,
            this.shift_personnel,
            this.shift_ptime,
            this.shift_comment,
            this.shift_uadmin,
            this.shift_udate});
            this.dgvShift.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvShift.GridColor = System.Drawing.Color.LightGray;
            this.dgvShift.Location = new System.Drawing.Point(14, 176);
            this.dgvShift.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.dgvShift.MinimumSize = new System.Drawing.Size(171, 188);
            this.dgvShift.Name = "dgvShift";
            this.dgvShift.RowHeadersWidth = 51;
            this.dgvShift.RowTemplate.Height = 23;
            this.dgvShift.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvShift.Size = new System.Drawing.Size(1726, 1000);
            this.dgvShift.TabIndex = 33;
            // 
            // shift_id
            // 
            this.shift_id.HeaderText = "시프트ID";
            this.shift_id.MinimumWidth = 6;
            this.shift_id.Name = "shift_id";
            this.shift_id.Width = 125;
            // 
            // m_id
            // 
            this.m_id.HeaderText = "설비ID";
            this.m_id.MinimumWidth = 6;
            this.m_id.Name = "m_id";
            this.m_id.Width = 125;
            // 
            // shift_stime
            // 
            this.shift_stime.HeaderText = "시작시간";
            this.shift_stime.MinimumWidth = 6;
            this.shift_stime.Name = "shift_stime";
            this.shift_stime.Width = 125;
            // 
            // shift_etime
            // 
            this.shift_etime.HeaderText = "완료시간";
            this.shift_etime.MinimumWidth = 6;
            this.shift_etime.Name = "shift_etime";
            this.shift_etime.Width = 125;
            // 
            // shift_sdate
            // 
            this.shift_sdate.HeaderText = "적용시작일자";
            this.shift_sdate.MinimumWidth = 6;
            this.shift_sdate.Name = "shift_sdate";
            this.shift_sdate.Width = 125;
            // 
            // shift_edate
            // 
            this.shift_edate.HeaderText = "적용완료일자";
            this.shift_edate.MinimumWidth = 6;
            this.shift_edate.Name = "shift_edate";
            this.shift_edate.Width = 125;
            // 
            // shift_yn
            // 
            this.shift_yn.HeaderText = "사용유무";
            this.shift_yn.MinimumWidth = 6;
            this.shift_yn.Name = "shift_yn";
            this.shift_yn.Width = 125;
            // 
            // shift_personnel
            // 
            this.shift_personnel.HeaderText = "현장투입인원";
            this.shift_personnel.MinimumWidth = 6;
            this.shift_personnel.Name = "shift_personnel";
            this.shift_personnel.Width = 125;
            // 
            // shift_ptime
            // 
            this.shift_ptime.HeaderText = "현장투입시간";
            this.shift_ptime.MinimumWidth = 6;
            this.shift_ptime.Name = "shift_ptime";
            this.shift_ptime.Width = 125;
            // 
            // shift_comment
            // 
            this.shift_comment.HeaderText = "비고";
            this.shift_comment.MinimumWidth = 6;
            this.shift_comment.Name = "shift_comment";
            this.shift_comment.Width = 125;
            // 
            // shift_uadmin
            // 
            this.shift_uadmin.HeaderText = "수정자";
            this.shift_uadmin.MinimumWidth = 6;
            this.shift_uadmin.Name = "shift_uadmin";
            this.shift_uadmin.Width = 125;
            // 
            // shift_udate
            // 
            this.shift_udate.HeaderText = "수정일";
            this.shift_udate.MinimumWidth = 6;
            this.shift_udate.Name = "shift_udate";
            this.shift_udate.Width = 125;
            // 
            // btnAllButtons1
            // 
            this.btnAllButtons1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.btnAllButtons1.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAllButtons1.Location = new System.Drawing.Point(1296, 0);
            this.btnAllButtons1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAllButtons1.Name = "btnAllButtons1";
            this.btnAllButtons1.Size = new System.Drawing.Size(431, 44);
            this.btnAllButtons1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "SHIFT 기준정보";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.btnAllButtons1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(14, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1727, 44);
            this.panel1.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::Team6_UMB.Properties.Resources.Search;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(727, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 38);
            this.button1.TabIndex = 21;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(72, 19);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 29);
            this.textBox1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "주/야간";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.periodSearchControl1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(14, 71);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1727, 62);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(301, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 24);
            this.label6.TabIndex = 37;
            this.label6.Text = "기간조회";
            // 
            // periodSearchControl1
            // 
            this.periodSearchControl1.DateType = "";
            this.periodSearchControl1.dtFrom = "2021-01-11";
            this.periodSearchControl1.dtTo = "2021-01-18";
            this.periodSearchControl1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.periodSearchControl1.Location = new System.Drawing.Point(376, 18);
            this.periodSearchControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.periodSearchControl1.Name = "periodSearchControl1";
            this.periodSearchControl1.Size = new System.Drawing.Size(344, 36);
            this.periodSearchControl1.TabIndex = 36;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(14, 132);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1727, 44);
            this.panel2.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 22;
            this.label2.Text = "SHIFT 목록";
            // 
            // frmShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1754, 1102);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvShift);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmShift";
            this.Text = "frmShift";
            this.Load += new System.EventHandler(this.frmShift_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DGV_Custom dgvShift;
        private Controls.btnAllButtons btnAllButtons1;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_stime;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_etime;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_sdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_edate;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_yn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_personnel;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_ptime;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_uadmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_udate;
        private System.Windows.Forms.Label label6;
        private PJT_Olive.Control.PeriodSearchControl periodSearchControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}