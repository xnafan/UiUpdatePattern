namespace UiUpdatePattern.WinForm
{
    partial class MainForm
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
            lstCustomers = new ListBox();
            btnGetCustomers = new Button();
            SuspendLayout();
            // 
            // lstCustomers
            // 
            lstCustomers.Dock = DockStyle.Left;
            lstCustomers.FormattingEnabled = true;
            lstCustomers.ItemHeight = 25;
            lstCustomers.Location = new Point(0, 0);
            lstCustomers.Margin = new Padding(5);
            lstCustomers.Name = "lstCustomers";
            lstCustomers.Size = new Size(469, 750);
            lstCustomers.TabIndex = 0;
            // 
            // btnGetCustomers
            // 
            btnGetCustomers.Location = new Point(500, 20);
            btnGetCustomers.Margin = new Padding(5);
            btnGetCustomers.Name = "btnGetCustomers";
            btnGetCustomers.Size = new Size(271, 38);
            btnGetCustomers.TabIndex = 1;
            btnGetCustomers.Text = "&Get customers";
            btnGetCustomers.UseVisualStyleBackColor = true;
            btnGetCustomers.Click += BtnGetCustomers_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 750);
            Controls.Add(btnGetCustomers);
            Controls.Add(lstCustomers);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5);
            Name = "MainForm";
            Text = "Customer updater";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstCustomers;
        private Button btnGetCustomers;
    }
}
