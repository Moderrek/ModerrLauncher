
namespace ModerrLauncher.Pages
{
    partial class MainPage
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
            this.newGameButton1 = new MLCore.NewGameButton();
            this.SuspendLayout();
            // 
            // newGameButton1
            // 
            this.newGameButton1.BackgroundImage = global::ModerrLauncher.Properties.Resources.devour1;
            this.newGameButton1.Location = new System.Drawing.Point(12, 12);
            this.newGameButton1.Name = "newGameButton1";
            this.newGameButton1.Size = new System.Drawing.Size(200, 240);
            this.newGameButton1.TabIndex = 0;
            this.newGameButton1.Load += new System.EventHandler(this.newGameButton1_Load);
            this.newGameButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.newGameButton1_MouseUp);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(969, 644);
            this.Controls.Add(this.newGameButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.ResumeLayout(false);

        }

        #endregion

        private MLCore.NewGameButton newGameButton1;
    }
}