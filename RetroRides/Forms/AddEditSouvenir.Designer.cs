namespace RetroRides.Forms
{
    partial class AddEditSouvenir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditSouvenir));
            label6 = new Label();
            label2 = new Label();
            numYear = new NumericUpDown();
            txtPrice = new TextBox();
            btnBack = new Button();
            btnSave = new Button();
            pictureBox1 = new PictureBox();
            pbImage = new Button();
            txtDescription = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            label1 = new Label();
            label7 = new Label();
            txtStock = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(192, -35);
            label6.Name = "label6";
            label6.Size = new Size(265, 38);
            label6.TabIndex = 61;
            label6.Text = "Add or edit exhibit";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(308, 272);
            label2.Name = "label2";
            label2.Size = new Size(56, 28);
            label2.TabIndex = 60;
            label2.Text = "Year:";
            // 
            // numYear
            // 
            numYear.Location = new Point(268, 300);
            numYear.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(150, 27);
            numYear.TabIndex = 59;
            numYear.Value = new decimal(new int[] { 1900, 0, 0, 0 });
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(266, 180);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(149, 27);
            txtPrice.TabIndex = 57;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Orange;
            btnBack.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.ControlText;
            btnBack.Location = new Point(485, 502);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 40);
            btnBack.TabIndex = 56;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Lime;
            btnSave.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(354, 502);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 55;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(723, 78);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 198);
            pictureBox1.TabIndex = 54;
            pictureBox1.TabStop = false;
            // 
            // pbImage
            // 
            pbImage.BackColor = SystemColors.ActiveBorder;
            pbImage.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            pbImage.ImeMode = ImeMode.NoControl;
            pbImage.Location = new Point(739, 300);
            pbImage.Margin = new Padding(3, 4, 3, 4);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(154, 34);
            pbImage.TabIndex = 53;
            pbImage.Text = "Upload image";
            pbImage.UseVisualStyleBackColor = false;
            pbImage.Click += PbImage_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(268, 373);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(405, 91);
            txtDescription.TabIndex = 52;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(295, 330);
            label5.Name = "label5";
            label5.Size = new Size(120, 28);
            label5.TabIndex = 51;
            label5.Text = "Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(308, 210);
            label4.Name = "label4";
            label4.Size = new Size(95, 28);
            label4.TabIndex = 50;
            label4.Text = "Quantity:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(308, 149);
            label3.Name = "label3";
            label3.Size = new Size(61, 28);
            label3.TabIndex = 49;
            label3.Text = "Price:";
            // 
            // txtName
            // 
            txtName.Location = new Point(268, 109);
            txtName.Name = "txtName";
            txtName.Size = new Size(149, 27);
            txtName.TabIndex = 48;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(308, 78);
            label1.Name = "label1";
            label1.Size = new Size(71, 28);
            label1.TabIndex = 47;
            label1.Text = "Name:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(341, 40);
            label7.Name = "label7";
            label7.Size = new Size(286, 38);
            label7.TabIndex = 62;
            label7.Text = "Add or edit souvenir";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(266, 242);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(149, 27);
            txtStock.TabIndex = 63;
            // 
            // AddEditSouvenir
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(982, 553);
            Controls.Add(txtStock);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(numYear);
            Controls.Add(txtPrice);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(pictureBox1);
            Controls.Add(pbImage);
            Controls.Add(txtDescription);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddEditSouvenir";
            Text = "AddEditSouvenir";
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label2;
        private NumericUpDown numYear;
        private TextBox txtPrice;
        private Button btnBack;
        private Button btnSave;
        private PictureBox pictureBox1;
        private Button pbImage;
        private TextBox txtDescription;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtName;
        private Label label1;
        private Label label7;
        private TextBox txtStock;
    }
}