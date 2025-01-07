namespace WinFormsApp
{
    partial class FrmHCC2
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
            listView = new ListView();
            SuspendLayout();
            // 
            // listView
            // 
            listView.Dock = DockStyle.Fill;
            listView.Location = new Point(0, 0);
            listView.Name = "listView";
            listView.Size = new Size(800, 450);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.List;
            // 
            // FrmHCC2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView);
            Name = "FrmHCC2";
            Text = "FrmHCC2";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView;
    }
}