namespace RetroRides.Forms
{
    partial class AddEditExhibit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditExhibit));
            btnBack = new Button();
            btnSave = new Button();
            pictureBox1 = new PictureBox();
            pbImage = new Button();
            txtDescription = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtMake = new TextBox();
            label1 = new Label();
            txtModel = new TextBox();
            cmbType = new ComboBox();
            numYear = new NumericUpDown();
            label2 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Orange;
            btnBack.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.ControlText;
            btnBack.Location = new Point(456, 529);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 40);
            btnBack.TabIndex = 41;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Lime;
            btnSave.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(325, 529);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 39;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(689, 88);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 198);
            pictureBox1.TabIndex = 37;
            pictureBox1.TabStop = false;
            // 
            // pbImage
            // 
            pbImage.BackColor = SystemColors.ActiveBorder;
            pbImage.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            pbImage.ImeMode = ImeMode.NoControl;
            pbImage.Location = new Point(710, 297);
            pbImage.Margin = new Padding(3, 4, 3, 4);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(154, 34);
            pbImage.TabIndex = 36;
            pbImage.Text = "Upload image";
            pbImage.UseVisualStyleBackColor = false;
            pbImage.Click += PbImage_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(239, 400);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(405, 91);
            txtDescription.TabIndex = 35;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(266, 357);
            label5.Name = "label5";
            label5.Size = new Size(120, 28);
            label5.TabIndex = 34;
            label5.Text = "Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(279, 237);
            label4.Name = "label4";
            label4.Size = new Size(60, 28);
            label4.TabIndex = 32;
            label4.Text = "Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(279, 176);
            label3.Name = "label3";
            label3.Size = new Size(75, 28);
            label3.TabIndex = 30;
            label3.Text = "Model:";
            // 
            // txtMake
            // 
            txtMake.Location = new Point(239, 136);
            txtMake.Name = "txtMake";
            txtMake.Size = new Size(149, 27);
            txtMake.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(279, 105);
            label1.Name = "label1";
            label1.Size = new Size(67, 28);
            label1.TabIndex = 28;
            label1.Text = "Make:";
            // 
            // txtModel
            // 
            txtModel.Location = new Point(237, 207);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(149, 27);
            txtModel.TabIndex = 42;
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Car", "Motorcycle" });
            cmbType.Location = new Point(237, 268);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(151, 28);
            cmbType.TabIndex = 43;
            // 
            // numYear
            // 
            numYear.Location = new Point(239, 327);
            numYear.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(150, 27);
            numYear.TabIndex = 44;
            numYear.Value = new decimal(new int[] { 1900, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(279, 299);
            label2.Name = "label2";
            label2.Size = new Size(56, 28);
            label2.TabIndex = 45;
            label2.Text = "Year:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(355, 49);
            label6.Name = "label6";
            label6.Size = new Size(265, 38);
            label6.TabIndex = 46;
            label6.Text = "Add or edit exhibit";
            // 
            // AddEditExhibit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 600);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(numYear);
            Controls.Add(cmbType);
            Controls.Add(txtModel);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(pictureBox1);
            Controls.Add(pbImage);
            Controls.Add(txtDescription);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtMake);
            Controls.Add(label1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddEditExhibit";
            Text = "AddEditExhibit";
            Load += AddEditExhibit_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Button btnSave;
        private PictureBox pictureBox1;
        private Button pbImage;
        private TextBox txtDescription;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtMake;
        private Label label1;
        private TextBox txtModel;
        private ComboBox cmbType;
        private NumericUpDown numYear;
        private Label label2;
        private Label label6;
    }
}