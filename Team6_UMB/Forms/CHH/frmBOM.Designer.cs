
namespace Team6_UMB.Forms
{
    partial class frmBOM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvBOM_Lv0 = new Team6_UMB.DGV_Custom();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.newBtns1 = new Team6_UMB.Controls.NewBtns();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvBOM_Lv1 = new Team6_UMB.DGV_Custom();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvBOM_Lv2 = new Team6_UMB.DGV_Custom();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvBOM_Lv3 = new Team6_UMB.DGV_Custom();
            this.btnPreView = new System.Windows.Forms.Button();
            this.dgvPreView = new Team6_UMB.DGV_Custom();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM_Lv0)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM_Lv1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM_Lv2)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM_Lv3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreView)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.Text = "BOM";
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(535, 825);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1511, 50);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // comboBox4
            // 
            this.comboBox4.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(350, 15);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(199, 25);
            this.comboBox4.TabIndex = 35;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(72, 15);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(199, 25);
            this.comboBox2.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(19, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Level";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::Team6_UMB.Properties.Resources.Search;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1110, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 30);
            this.button1.TabIndex = 32;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(905, 15);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(199, 25);
            this.comboBox3.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(866, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "창고";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(635, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(199, 25);
            this.comboBox1.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(569, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "제품분류";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(297, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "제품명";
            // 
            // dgvBOM_Lv0
            // 
            this.dgvBOM_Lv0.BackgroundColor = System.Drawing.Color.White;
            this.dgvBOM_Lv0.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("나눔바른고딕", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBOM_Lv0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBOM_Lv0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOM_Lv0.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvBOM_Lv0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOM_Lv0.GridColor = System.Drawing.Color.LightGray;
            this.dgvBOM_Lv0.Location = new System.Drawing.Point(3, 17);
            this.dgvBOM_Lv0.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgvBOM_Lv0.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgvBOM_Lv0.Name = "dgvBOM_Lv0";
            this.dgvBOM_Lv0.RowTemplate.Height = 23;
            this.dgvBOM_Lv0.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBOM_Lv0.Size = new System.Drawing.Size(479, 160);
            this.dgvBOM_Lv0.TabIndex = 19;
            this.dgvBOM_Lv0.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBOM_Lv0_CellDoubleClick);
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
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "BOM 목록";
            // 
            // newBtns1
            // 
            this.newBtns1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.newBtns1.Dock = System.Windows.Forms.DockStyle.Right;
            this.newBtns1.Location = new System.Drawing.Point(741, 0);
            this.newBtns1.Name = "newBtns1";
            this.newBtns1.Size = new System.Drawing.Size(770, 35);
            this.newBtns1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvBOM_Lv0);
            this.groupBox2.Location = new System.Drawing.Point(12, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 180);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvBOM_Lv1);
            this.groupBox4.Location = new System.Drawing.Point(12, 333);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(485, 180);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            // 
            // dgvBOM_Lv1
            // 
            this.dgvBOM_Lv1.BackgroundColor = System.Drawing.Color.White;
            this.dgvBOM_Lv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔바른고딕", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBOM_Lv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBOM_Lv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOM_Lv1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvBOM_Lv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOM_Lv1.GridColor = System.Drawing.Color.LightGray;
            this.dgvBOM_Lv1.Location = new System.Drawing.Point(3, 17);
            this.dgvBOM_Lv1.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgvBOM_Lv1.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgvBOM_Lv1.Name = "dgvBOM_Lv1";
            this.dgvBOM_Lv1.RowTemplate.Height = 23;
            this.dgvBOM_Lv1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBOM_Lv1.Size = new System.Drawing.Size(479, 160);
            this.dgvBOM_Lv1.TabIndex = 19;
            this.dgvBOM_Lv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBOM_Lv1_CellDoubleClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvBOM_Lv2);
            this.groupBox5.Location = new System.Drawing.Point(12, 519);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(485, 199);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            // 
            // dgvBOM_Lv2
            // 
            this.dgvBOM_Lv2.BackgroundColor = System.Drawing.Color.White;
            this.dgvBOM_Lv2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("나눔바른고딕", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBOM_Lv2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBOM_Lv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOM_Lv2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvBOM_Lv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOM_Lv2.GridColor = System.Drawing.Color.LightGray;
            this.dgvBOM_Lv2.Location = new System.Drawing.Point(3, 17);
            this.dgvBOM_Lv2.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgvBOM_Lv2.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgvBOM_Lv2.Name = "dgvBOM_Lv2";
            this.dgvBOM_Lv2.RowTemplate.Height = 23;
            this.dgvBOM_Lv2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBOM_Lv2.Size = new System.Drawing.Size(479, 179);
            this.dgvBOM_Lv2.TabIndex = 19;
            this.dgvBOM_Lv2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBOM_Lv2_CellDoubleClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvBOM_Lv3);
            this.groupBox6.Location = new System.Drawing.Point(12, 724);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(485, 181);
            this.groupBox6.TabIndex = 46;
            this.groupBox6.TabStop = false;
            // 
            // dgvBOM_Lv3
            // 
            this.dgvBOM_Lv3.BackgroundColor = System.Drawing.Color.White;
            this.dgvBOM_Lv3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("나눔바른고딕", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBOM_Lv3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBOM_Lv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOM_Lv3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvBOM_Lv3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOM_Lv3.GridColor = System.Drawing.Color.LightGray;
            this.dgvBOM_Lv3.Location = new System.Drawing.Point(3, 17);
            this.dgvBOM_Lv3.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgvBOM_Lv3.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgvBOM_Lv3.Name = "dgvBOM_Lv3";
            this.dgvBOM_Lv3.RowTemplate.Height = 23;
            this.dgvBOM_Lv3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBOM_Lv3.Size = new System.Drawing.Size(479, 161);
            this.dgvBOM_Lv3.TabIndex = 19;
            // 
            // btnPreView
            // 
            this.btnPreView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPreView.FlatAppearance.BorderSize = 0;
            this.btnPreView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreView.Font = new System.Drawing.Font("나눔바른고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPreView.Location = new System.Drawing.Point(12, 906);
            this.btnPreView.Name = "btnPreView";
            this.btnPreView.Size = new System.Drawing.Size(485, 40);
            this.btnPreView.TabIndex = 47;
            this.btnPreView.Text = "PreView";
            this.btnPreView.UseVisualStyleBackColor = false;
            this.btnPreView.Click += new System.EventHandler(this.btnPreView_Click);
            // 
            // dgvPreView
            // 
            this.dgvPreView.BackgroundColor = System.Drawing.Color.White;
            this.dgvPreView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("나눔바른고딕", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPreView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPreView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvPreView.GridColor = System.Drawing.Color.LightGray;
            this.dgvPreView.Location = new System.Drawing.Point(575, 163);
            this.dgvPreView.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgvPreView.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgvPreView.Name = "dgvPreView";
            this.dgvPreView.RowTemplate.Height = 23;
            this.dgvPreView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPreView.Size = new System.Drawing.Size(735, 512);
            this.dgvPreView.TabIndex = 48;
            // 
            // frmBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1535, 950);
            this.Controls.Add(this.dgvPreView);
            this.Controls.Add(this.btnPreView);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBOM";
            this.Load += new System.EventHandler(this.frmBOM_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.Controls.SetChildIndex(this.btnPreView, 0);
            this.Controls.SetChildIndex(this.dgvPreView, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM_Lv0)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM_Lv1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM_Lv2)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM_Lv3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private DGV_Custom dgvBOM_Lv0;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private Controls.NewBtns newBtns1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private DGV_Custom dgvBOM_Lv1;
        private System.Windows.Forms.GroupBox groupBox5;
        private DGV_Custom dgvBOM_Lv2;
        private System.Windows.Forms.GroupBox groupBox6;
        private DGV_Custom dgvBOM_Lv3;
        private System.Windows.Forms.Button btnPreView;
        private DGV_Custom dgvPreView;
    }
}
