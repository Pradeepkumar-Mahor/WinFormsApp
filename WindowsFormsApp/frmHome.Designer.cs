namespace WindowsFormsApp
{
    partial class frmHome
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
            this.TileProduct = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // TileProduct
            // 
            this.TileProduct.Location = new System.Drawing.Point(33, 82);
            this.TileProduct.Name = "TileProduct";
            this.TileProduct.Size = new System.Drawing.Size(128, 84);
            this.TileProduct.TabIndex = 0;
            this.TileProduct.Text = "metroTile1";
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TileProduct);
            this.Name = "frmHome";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile TileProduct;
    }
}