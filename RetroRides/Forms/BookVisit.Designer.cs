namespace RetroRides.Forms
{
    partial class BookVisit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookVisit));
            lblTitle = new Label();
            lblCarInfo = new Label();
            dtpDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            txtNotes = new TextBox();
            button1 = new Button();
            btnBack = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(378, 51);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(178, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Book a visit:";
            // 
            // lblCarInfo
            // 
            lblCarInfo.AutoSize = true;
            lblCarInfo.BackColor = Color.Transparent;
            lblCarInfo.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCarInfo.ForeColor = Color.White;
            lblCarInfo.Location = new Point(274, 124);
            lblCarInfo.Name = "lblCarInfo";
            lblCarInfo.Size = new Size(108, 31);
            lblCarInfo.TabIndex = 1;
            lblCarInfo.Text = "Selected:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(274, 234);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(250, 27);
            dtpDate.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(274, 190);
            label1.Name = "label1";
            label1.Size = new Size(149, 31);
            label1.TabIndex = 3;
            label1.Text = "Choose date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(274, 292);
            label2.Name = "label2";
            label2.Size = new Size(140, 31);
            label2.TabIndex = 4;
            label2.Text = "Description:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(274, 340);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(409, 100);
            txtNotes.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(274, 464);
            button1.Name = "button1";
            button1.Size = new Size(108, 41);
            button1.TabIndex = 6;
            button1.Text = "Reservate";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnBook_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.DarkOrange;
            btnBack.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.ControlText;
            btnBack.Location = new Point(573, 466);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(85, 39);
            btnBack.TabIndex = 27;
            btnBack.Text = "<-Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(720, 73);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 250);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // BookVisit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(982, 553);
            Controls.Add(pictureBox1);
            Controls.Add(btnBack);
            Controls.Add(button1);
            Controls.Add(txtNotes);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpDate);
            Controls.Add(lblCarInfo);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BookVisit";
            Text = "BookVisit";
            Load += BookVisit_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCarInfo;
        private DateTimePicker dtpDate;
        private Label label1;
        private Label label2;
        private TextBox txtNotes;
        private Button button1;
        private Button btnBack;
        private PictureBox pictureBox1;
    }
}