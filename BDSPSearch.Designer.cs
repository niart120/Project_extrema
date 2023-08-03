namespace Project_extrema
{
    partial class BDSPSearchForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            AdvancesColumn = new DataGridViewTextBoxColumn();
            NatureColumn = new DataGridViewTextBoxColumn();
            AbilityColumn = new DataGridViewTextBoxColumn();
            HPColumn = new DataGridViewTextBoxColumn();
            AtkColumn = new DataGridViewTextBoxColumn();
            DefColumn = new DataGridViewTextBoxColumn();
            SpAColumn = new DataGridViewTextBoxColumn();
            SpDColumn = new DataGridViewTextBoxColumn();
            SpeColumn = new DataGridViewTextBoxColumn();
            GenderColumn = new DataGridViewTextBoxColumn();
            ShinyColumn = new DataGridViewTextBoxColumn();
            HeightColumn = new DataGridViewTextBoxColumn();
            WeightColumn = new DataGridViewTextBoxColumn();
            CharColumn = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            label10 = new Label();
            MaxWeight = new NumericUpDown();
            MinWeight = new NumericUpDown();
            label9 = new Label();
            MaxHeight = new NumericUpDown();
            MinHeight = new NumericUpDown();
            ShinyComboBox = new ComboBox();
            GenderComboBox = new ComboBox();
            NatureComboBox = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            SynchronizeComboBox = new ComboBox();
            Delay = new NumericUpDown();
            label15 = new Label();
            SpeciesComboBox = new ComboBox();
            SymbolTypeComboBox = new ComboBox();
            label16 = new Label();
            label14 = new Label();
            label13 = new Label();
            SearchButton = new Button();
            UseSynchronize = new CheckBox();
            label12 = new Label();
            MaxSearchRange = new NumericUpDown();
            MinSearchRange = new NumericUpDown();
            label11 = new Label();
            seed1 = new TextBox();
            label2 = new Label();
            seed0 = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MaxWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinHeight).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Delay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxSearchRange).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinSearchRange).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { AdvancesColumn, NatureColumn, AbilityColumn, HPColumn, AtkColumn, DefColumn, SpAColumn, SpDColumn, SpeColumn, GenderColumn, ShinyColumn, HeightColumn, WeightColumn, CharColumn });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(12, 363);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 41;
            dataGridView1.Size = new Size(1150, 354);
            dataGridView1.TabIndex = 0;
            dataGridView1.TabStop = false;
            // 
            // AdvancesColumn
            // 
            AdvancesColumn.HeaderText = "Advances";
            AdvancesColumn.MinimumWidth = 10;
            AdvancesColumn.Name = "AdvancesColumn";
            AdvancesColumn.ReadOnly = true;
            AdvancesColumn.Width = 160;
            // 
            // NatureColumn
            // 
            NatureColumn.HeaderText = "性格";
            NatureColumn.MinimumWidth = 10;
            NatureColumn.Name = "NatureColumn";
            NatureColumn.ReadOnly = true;
            NatureColumn.Width = 120;
            // 
            // AbilityColumn
            // 
            AbilityColumn.HeaderText = "特性";
            AbilityColumn.MinimumWidth = 10;
            AbilityColumn.Name = "AbilityColumn";
            AbilityColumn.ReadOnly = true;
            AbilityColumn.Width = 120;
            // 
            // HPColumn
            // 
            HPColumn.HeaderText = "H";
            HPColumn.MinimumWidth = 10;
            HPColumn.Name = "HPColumn";
            HPColumn.ReadOnly = true;
            HPColumn.Width = 40;
            // 
            // AtkColumn
            // 
            AtkColumn.HeaderText = "A";
            AtkColumn.MinimumWidth = 10;
            AtkColumn.Name = "AtkColumn";
            AtkColumn.ReadOnly = true;
            AtkColumn.Width = 40;
            // 
            // DefColumn
            // 
            DefColumn.HeaderText = "B";
            DefColumn.MinimumWidth = 10;
            DefColumn.Name = "DefColumn";
            DefColumn.ReadOnly = true;
            DefColumn.Width = 40;
            // 
            // SpAColumn
            // 
            SpAColumn.HeaderText = "C";
            SpAColumn.MinimumWidth = 10;
            SpAColumn.Name = "SpAColumn";
            SpAColumn.ReadOnly = true;
            SpAColumn.Width = 40;
            // 
            // SpDColumn
            // 
            SpDColumn.HeaderText = "D";
            SpDColumn.MinimumWidth = 10;
            SpDColumn.Name = "SpDColumn";
            SpDColumn.ReadOnly = true;
            SpDColumn.Width = 40;
            // 
            // SpeColumn
            // 
            SpeColumn.HeaderText = "S";
            SpeColumn.MinimumWidth = 10;
            SpeColumn.Name = "SpeColumn";
            SpeColumn.ReadOnly = true;
            SpeColumn.Width = 40;
            // 
            // GenderColumn
            // 
            GenderColumn.HeaderText = "性別";
            GenderColumn.MinimumWidth = 10;
            GenderColumn.Name = "GenderColumn";
            GenderColumn.ReadOnly = true;
            GenderColumn.Width = 80;
            // 
            // ShinyColumn
            // 
            ShinyColumn.HeaderText = "色";
            ShinyColumn.MinimumWidth = 10;
            ShinyColumn.Name = "ShinyColumn";
            ShinyColumn.ReadOnly = true;
            ShinyColumn.Width = 40;
            // 
            // HeightColumn
            // 
            HeightColumn.HeaderText = "高さ";
            HeightColumn.MinimumWidth = 10;
            HeightColumn.Name = "HeightColumn";
            HeightColumn.ReadOnly = true;
            HeightColumn.Width = 80;
            // 
            // WeightColumn
            // 
            WeightColumn.HeaderText = "重さ";
            WeightColumn.MinimumWidth = 10;
            WeightColumn.Name = "WeightColumn";
            WeightColumn.ReadOnly = true;
            WeightColumn.Width = 80;
            // 
            // CharColumn
            // 
            CharColumn.HeaderText = "個性(WIP)";
            CharColumn.MinimumWidth = 10;
            CharColumn.Name = "CharColumn";
            CharColumn.ReadOnly = true;
            CharColumn.Width = 200;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(MaxWeight);
            groupBox2.Controls.Add(MinWeight);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(MaxHeight);
            groupBox2.Controls.Add(MinHeight);
            groupBox2.Controls.Add(ShinyComboBox);
            groupBox2.Controls.Add(GenderComboBox);
            groupBox2.Controls.Add(NatureComboBox);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(793, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(369, 345);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "検索条件";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(213, 295);
            label10.Name = "label10";
            label10.Size = new Size(38, 32);
            label10.TabIndex = 15;
            label10.Text = "～";
            // 
            // MaxWeight
            // 
            MaxWeight.Location = new Point(257, 292);
            MaxWeight.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            MaxWeight.Name = "MaxWeight";
            MaxWeight.Size = new Size(96, 39);
            MaxWeight.TabIndex = 26;
            MaxWeight.Value = new decimal(new int[] { 255, 0, 0, 0 });
            // 
            // MinWeight
            // 
            MinWeight.Location = new Point(113, 292);
            MinWeight.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            MinWeight.Name = "MinWeight";
            MinWeight.Size = new Size(96, 39);
            MinWeight.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(213, 249);
            label9.Name = "label9";
            label9.Size = new Size(38, 32);
            label9.TabIndex = 12;
            label9.Text = "～";
            // 
            // MaxHeight
            // 
            MaxHeight.Location = new Point(257, 246);
            MaxHeight.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            MaxHeight.Name = "MaxHeight";
            MaxHeight.Size = new Size(96, 39);
            MaxHeight.TabIndex = 24;
            MaxHeight.Value = new decimal(new int[] { 255, 0, 0, 0 });
            // 
            // MinHeight
            // 
            MinHeight.Location = new Point(113, 246);
            MinHeight.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            MinHeight.Name = "MinHeight";
            MinHeight.Size = new Size(96, 39);
            MinHeight.TabIndex = 23;
            // 
            // ShinyComboBox
            // 
            ShinyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ShinyComboBox.FormattingEnabled = true;
            ShinyComboBox.Items.AddRange(new object[] { "☆&◇", "☆", "◇", "-" });
            ShinyComboBox.Location = new Point(113, 145);
            ShinyComboBox.Name = "ShinyComboBox";
            ShinyComboBox.Size = new Size(210, 40);
            ShinyComboBox.TabIndex = 22;
            // 
            // GenderComboBox
            // 
            GenderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            GenderComboBox.FormattingEnabled = true;
            GenderComboBox.Items.AddRange(new object[] { "♂", "♀", "?", "-" });
            GenderComboBox.Location = new Point(113, 92);
            GenderComboBox.Name = "GenderComboBox";
            GenderComboBox.Size = new Size(210, 40);
            GenderComboBox.TabIndex = 21;
            // 
            // NatureComboBox
            // 
            NatureComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            NatureComboBox.FormattingEnabled = true;
            NatureComboBox.Location = new Point(113, 41);
            NatureComboBox.Name = "NatureComboBox";
            NatureComboBox.Size = new Size(210, 40);
            NatureComboBox.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(24, 295);
            label8.Name = "label8";
            label8.Size = new Size(54, 32);
            label8.TabIndex = 5;
            label8.Text = "重さ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 249);
            label7.Name = "label7";
            label7.Size = new Size(54, 32);
            label7.TabIndex = 4;
            label7.Text = "高さ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 145);
            label6.Name = "label6";
            label6.Size = new Size(82, 32);
            label6.TabIndex = 3;
            label6.Text = "色違い";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 95);
            label5.Name = "label5";
            label5.Size = new Size(62, 32);
            label5.TabIndex = 2;
            label5.Text = "性別";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 44);
            label3.Name = "label3";
            label3.Size = new Size(62, 32);
            label3.TabIndex = 0;
            label3.Text = "性格";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(SynchronizeComboBox);
            groupBox1.Controls.Add(Delay);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(SpeciesComboBox);
            groupBox1.Controls.Add(SymbolTypeComboBox);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(SearchButton);
            groupBox1.Controls.Add(UseSynchronize);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(MaxSearchRange);
            groupBox1.Controls.Add(MinSearchRange);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(seed1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(seed0);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(775, 345);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "基本情報";
            // 
            // SynchronizeComboBox
            // 
            SynchronizeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SynchronizeComboBox.Enabled = false;
            SynchronizeComboBox.FormattingEnabled = true;
            SynchronizeComboBox.Location = new Point(403, 289);
            SynchronizeComboBox.Name = "SynchronizeComboBox";
            SynchronizeComboBox.Size = new Size(173, 40);
            SynchronizeComboBox.TabIndex = 8;
            // 
            // Delay
            // 
            Delay.Location = new Point(661, 200);
            Delay.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            Delay.Name = "Delay";
            Delay.Size = new Size(104, 39);
            Delay.TabIndex = 6;
            Delay.Value = new decimal(new int[] { 84, 0, 0, 0 });
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(587, 203);
            label15.Name = "label15";
            label15.Size = new Size(71, 32);
            label15.TabIndex = 24;
            label15.Text = "delay";
            // 
            // SpeciesComboBox
            // 
            SpeciesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SpeciesComboBox.FormattingEnabled = true;
            SpeciesComboBox.Location = new Point(402, 200);
            SpeciesComboBox.Name = "SpeciesComboBox";
            SpeciesComboBox.Size = new Size(174, 40);
            SpeciesComboBox.TabIndex = 5;
            // 
            // SymbolTypeComboBox
            // 
            SymbolTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SymbolTypeComboBox.FormattingEnabled = true;
            SymbolTypeComboBox.Items.AddRange(new object[] { "シンオウ準伝説", "シンオウ伝説・幻", "徘徊", "ハマナス準伝説", "ハマナス伝説" });
            SymbolTypeComboBox.Location = new Point(80, 200);
            SymbolTypeComboBox.Name = "SymbolTypeComboBox";
            SymbolTypeComboBox.Size = new Size(239, 40);
            SymbolTypeComboBox.TabIndex = 4;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(18, 35);
            label16.Name = "label16";
            label16.Size = new Size(77, 32);
            label16.TabIndex = 21;
            label16.Text = "seed0";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(335, 203);
            label14.Name = "label14";
            label14.Size = new Size(62, 32);
            label14.TabIndex = 19;
            label14.Text = "種族";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 203);
            label13.Name = "label13";
            label13.Size = new Size(62, 32);
            label13.TabIndex = 18;
            label13.Text = "分類";
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(619, 285);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(150, 46);
            SearchButton.TabIndex = 9;
            SearchButton.Text = "検索";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // UseSynchronize
            // 
            UseSynchronize.AutoSize = true;
            UseSynchronize.BackColor = Color.Transparent;
            UseSynchronize.Location = new Point(279, 291);
            UseSynchronize.Name = "UseSynchronize";
            UseSynchronize.Size = new Size(118, 36);
            UseSynchronize.TabIndex = 7;
            UseSynchronize.Text = "シンクロ";
            UseSynchronize.UseVisualStyleBackColor = false;
            UseSynchronize.CheckedChanged += UseSynchronize_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(329, 140);
            label12.Name = "label12";
            label12.Size = new Size(38, 32);
            label12.TabIndex = 15;
            label12.Text = "～";
            // 
            // MaxSearchRange
            // 
            MaxSearchRange.Location = new Point(370, 137);
            MaxSearchRange.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            MaxSearchRange.Name = "MaxSearchRange";
            MaxSearchRange.Size = new Size(194, 39);
            MaxSearchRange.TabIndex = 3;
            MaxSearchRange.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // MinSearchRange
            // 
            MinSearchRange.Location = new Point(132, 137);
            MinSearchRange.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            MinSearchRange.Name = "MinSearchRange";
            MinSearchRange.Size = new Size(194, 39);
            MinSearchRange.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 137);
            label11.Name = "label11";
            label11.Size = new Size(110, 32);
            label11.TabIndex = 4;
            label11.Text = "検索範囲";
            // 
            // seed1
            // 
            seed1.BackColor = SystemColors.ControlLightLight;
            seed1.CharacterCasing = CharacterCasing.Upper;
            seed1.Location = new Point(288, 72);
            seed1.Name = "seed1";
            seed1.Size = new Size(236, 39);
            seed1.TabIndex = 1;
            seed1.Text = "0";
            seed1.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(287, 37);
            label2.Name = "label2";
            label2.Size = new Size(77, 32);
            label2.TabIndex = 2;
            label2.Text = "seed1";
            // 
            // seed0
            // 
            seed0.BackColor = SystemColors.ControlLightLight;
            seed0.CharacterCasing = CharacterCasing.Upper;
            seed0.Location = new Point(18, 72);
            seed0.Name = "seed0";
            seed0.Size = new Size(236, 39);
            seed0.TabIndex = 0;
            seed0.Text = "0";
            seed0.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(123, 37);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 0;
            // 
            // BDSPSearchForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 729);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(dataGridView1);
            Name = "BDSPSearchForm";
            Text = "BDSPSearch";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MaxWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinHeight).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Delay).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxSearchRange).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinSearchRange).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private Label label10;
        private NumericUpDown MaxWeight;
        private NumericUpDown MinWeight;
        private Label label9;
        private NumericUpDown MaxHeight;
        private NumericUpDown MinHeight;
        private ComboBox ShinyComboBox;
        private ComboBox GenderComboBox;
        private ComboBox NatureComboBox;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private GroupBox groupBox1;
        private CheckBox UseSynchronize;
        private Label label12;
        private NumericUpDown MaxSearchRange;
        private NumericUpDown MinSearchRange;
        private Label label11;
        private TextBox seed1;
        private Label label2;
        private TextBox seed0;
        private Label label1;
        private ComboBox SpeciesComboBox;
        private ComboBox SymbolTypeComboBox;
        private Label label16;
        private Label label14;
        private Label label13;
        private Button SearchButton;
        private NumericUpDown Delay;
        private Label label15;
        private ComboBox SynchronizeComboBox;
        private DataGridViewTextBoxColumn AdvancesColumn;
        private DataGridViewTextBoxColumn NatureColumn;
        private DataGridViewTextBoxColumn AbilityColumn;
        private DataGridViewTextBoxColumn HPColumn;
        private DataGridViewTextBoxColumn AtkColumn;
        private DataGridViewTextBoxColumn DefColumn;
        private DataGridViewTextBoxColumn SpAColumn;
        private DataGridViewTextBoxColumn SpDColumn;
        private DataGridViewTextBoxColumn SpeColumn;
        private DataGridViewTextBoxColumn GenderColumn;
        private DataGridViewTextBoxColumn ShinyColumn;
        private DataGridViewTextBoxColumn HeightColumn;
        private DataGridViewTextBoxColumn WeightColumn;
        private DataGridViewTextBoxColumn CharColumn;
    }
}