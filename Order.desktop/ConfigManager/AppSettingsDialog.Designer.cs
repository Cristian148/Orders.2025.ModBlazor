
namespace RuFramework.Config
{
    partial class AppSettingsDialog
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
            propertyGrid = new System.Windows.Forms.PropertyGrid();
            menuStrip = new System.Windows.Forms.MenuStrip();
            toolStripMenuItemOK = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemCancel = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // propertyGrid
            // 
            propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            propertyGrid.Location = new System.Drawing.Point(0, 24);
            propertyGrid.Name = "propertyGrid";
            propertyGrid.Size = new System.Drawing.Size(800, 426);
            propertyGrid.TabIndex = 0;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemOK, toolStripMenuItemCancel });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(800, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip";
            menuStrip.ItemClicked += menuStrip_ItemClicked;
            // 
            // toolStripMenuItemOK
            // 
            toolStripMenuItemOK.Name = "toolStripMenuItemOK";
            toolStripMenuItemOK.Size = new System.Drawing.Size(34, 20);
            toolStripMenuItemOK.Text = "Ok";
            // 
            // toolStripMenuItemCancel
            // 
            toolStripMenuItemCancel.Name = "toolStripMenuItemCancel";
            toolStripMenuItemCancel.Size = new System.Drawing.Size(55, 20);
            toolStripMenuItemCancel.Text = "Cancel";
            // 
            // AppSettingsDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(propertyGrid);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "AppSettingsDialog";
            Text = "AppSettingsDialog";
            FormClosed += AppSettingsDialog_FormClosed;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOK;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCancel;
        public System.Windows.Forms.PropertyGrid propertyGrid;
    }
}