namespace RetroRides.Forms
{
    partial class ManageExhibits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageExhibits));
            dgvExhibits = new DataGridView();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExhibits).BeginInit();
            SuspendLayout();
            // 
            // dgvExhibits
            // 
            dgvExhibits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExhibits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExhibits.BackgroundColor = Color.White;
            dgvExhibits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExhibits.Location = new Point(154, 228);
            dgvExhibits.Name = "dgvExhibits";
            dgvExhibits.RowHeadersWidth = 51;
            dgvExhibits.Size = new Size(300, 188);
            dgvExhibits.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(633, 28);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(202, 52);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add new vehicle";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // ManageExhibits
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 600);
            Controls.Add(btnAdd);
            Controls.Add(dgvExhibits);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ManageExhibits";
            Text = "ManageExhibits";
            Load += ManageExhibits_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExhibits).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvExhibits;
        private Button btnAdd;
    }
}