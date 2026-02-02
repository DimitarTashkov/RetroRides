namespace RetroRides.Forms
{
    partial class ManageSouvenirs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageSouvenirs));
            btnAdd = new Button();
            dgvSouvenirs = new DataGridView();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSouvenirs).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(768, 53);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(202, 52);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add new vehicle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvSouvenirs
            // 
            dgvSouvenirs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSouvenirs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSouvenirs.BackgroundColor = Color.White;
            dgvSouvenirs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSouvenirs.Location = new Point(12, 111);
            dgvSouvenirs.Name = "dgvSouvenirs";
            dgvSouvenirs.RowHeadersWidth = 51;
            dgvSouvenirs.Size = new Size(958, 430);
            dgvSouvenirs.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.DarkOrange;
            btnBack.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.ControlText;
            btnBack.Location = new Point(12, 66);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(85, 39);
            btnBack.TabIndex = 26;
            btnBack.Text = "<-Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // ManageSouvenirs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(982, 553);
            Controls.Add(btnBack);
            Controls.Add(btnAdd);
            Controls.Add(dgvSouvenirs);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ManageSouvenirs";
            Text = "ManageSouvenirs";
            Load += ManageSouvenirs_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSouvenirs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdd;
        private DataGridView dgvSouvenirs;
        private Button btnBack;
    }
}