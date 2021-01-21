
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.periodSearchControl1 = new PJT_Olive.Control.PeriodSearchControl();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgV_Custom1 = new Team6_UMB.DGV_Custom();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearchExcelPrint1 = new Team6_UMB.Controls.btnSearchExcelPrint();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgV_Custom1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearchExcelPrint1);
            this.panel1.Size = new System.Drawing.Size(1511, 35);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnSearchExcelPrint1, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.Text = "재고현황";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.periodSearchControl1);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1511, 50);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(11, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 36;
            this.label4.Text = "기간";
            // 
            // periodSearchControl1
            // 
            this.periodSearchControl1.DateType = "";
            this.periodSearchControl1.dtFrom = "2021-01-12";
            this.periodSearchControl1.dtTo = "2021-01-19";
            this.periodSearchControl1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.periodSearchControl1.Location = new System.Drawing.Point(51, 11);
            this.periodSearchControl1.Name = "periodSearchControl1";
            this.periodSearchControl1.Size = new System.Drawing.Size(301, 29);
            this.periodSearchControl1.TabIndex = 35;
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(1170, 14);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(199, 25);
            this.comboBox3.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(1117, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "창고";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Team6_UMB.Properties.Resources.Search;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1471, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 30);
            this.button1.TabIndex = 32;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(843, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(199, 25);
            this.comboBox1.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(777, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "제품분류";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(458, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 25);
            this.textBox1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(405, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "제품명";
            // 
            // dgV_Custom1
            // 
            this.dgV_Custom1.BackgroundColor = System.Drawing.Color.White;
            this.dgV_Custom1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("나눔바른고딕", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgV_Custom1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgV_Custom1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgV_Custom1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column6,
            this.Column7});
            this.dgV_Custom1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgV_Custom1.GridColor = System.Drawing.Color.LightGray;
            this.dgV_Custom1.Location = new System.Drawing.Point(12, 111);
            this.dgV_Custom1.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgV_Custom1.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgV_Custom1.Name = "dgV_Custom1";
            this.dgV_Custom1.RowTemplate.Height = 23;
            this.dgV_Custom1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgV_Custom1.Size = new System.Drawing.Size(1510, 879);
            this.dgV_Custom1.TabIndex = 19;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "제품명";
            this.Column2.Name = "Column2";
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "제품유형";
            this.Column3.Name = "Column3";
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "창고";
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "재고량";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "업체명";
            this.Column8.Name = "Column8";
            this.Column8.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "입고일";
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "출고일";
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // btnSearchExcelPrint1
            // 
            this.btnSearchExcelPrint1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.btnSearchExcelPrint1.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearchExcelPrint1.Location = new System.Drawing.Point(1285, 0);
            this.btnSearchExcelPrint1.Name = "btnSearchExcelPrint1";
            this.btnSearchExcelPrint1.Size = new System.Drawing.Size(226, 35);
            this.btnSearchExcelPrint1.TabIndex = 2;
            this.btnSearchExcelPrint1.btnSearch_Event += new System.EventHandler(this.btnSearchExcelPrint1_btnSearch_Event);
            // 
            // frmPDStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1535, 950);
            this.Controls.Add(this.dgV_Custom1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPDStock";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dgV_Custom1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgV_Custom1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private PJT_Olive.Control.PeriodSearchControl periodSearchControl1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private DGV_Custom dgV_Custom1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label4;
        private Controls.btnSearchExcelPrint btnSearchExcelPrint1;
    }
}
