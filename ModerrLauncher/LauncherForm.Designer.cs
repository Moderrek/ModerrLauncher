
using MLCore;

namespace ModerrLauncher
{
    partial class LauncherForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.LauncherTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonChat = new System.Windows.Forms.Button();
            this.buttonMyGames = new System.Windows.Forms.Button();
            this.buttonSearchGames = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userPicture = new MLCore.CirclePictureBox();
            this.childPanel = new System.Windows.Forms.Panel();
            this.buttonDevour = new System.Windows.Forms.Button();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // LauncherTray
            // 
            this.LauncherTray.Icon = ((System.Drawing.Icon)(resources.GetObject("LauncherTray.Icon")));
            this.LauncherTray.Text = "Moderr Launcher";
            this.LauncherTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LauncherTray_MouseDoubleClick);
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelSidebar.Controls.Add(this.buttonDevour);
            this.panelSidebar.Controls.Add(this.label2);
            this.panelSidebar.Controls.Add(this.buttonSettings);
            this.panelSidebar.Controls.Add(this.buttonChat);
            this.panelSidebar.Controls.Add(this.buttonMyGames);
            this.panelSidebar.Controls.Add(this.buttonSearchGames);
            this.panelSidebar.Controls.Add(this.buttonHome);
            this.panelSidebar.Controls.Add(this.label1);
            this.panelSidebar.Controls.Add(this.pictureBox1);
            this.panelSidebar.Controls.Add(this.panel2);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(213, 644);
            this.panelSidebar.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(48, 623);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "v0.1";
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.buttonSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.buttonSettings.Image = global::ModerrLauncher.Properties.Resources.icon_gear;
            this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.Location = new System.Drawing.Point(0, 334);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.buttonSettings.Size = new System.Drawing.Size(213, 50);
            this.buttonSettings.TabIndex = 10;
            this.buttonSettings.Text = "USTAWIENIA";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.btnClick);
            // 
            // buttonChat
            // 
            this.buttonChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.buttonChat.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonChat.Enabled = false;
            this.buttonChat.FlatAppearance.BorderSize = 0;
            this.buttonChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChat.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonChat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.buttonChat.Image = global::ModerrLauncher.Properties.Resources.icon_chat;
            this.buttonChat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChat.Location = new System.Drawing.Point(0, 284);
            this.buttonChat.Name = "buttonChat";
            this.buttonChat.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.buttonChat.Size = new System.Drawing.Size(213, 50);
            this.buttonChat.TabIndex = 9;
            this.buttonChat.Text = "ROZMOWY";
            this.buttonChat.UseVisualStyleBackColor = false;
            this.buttonChat.Click += new System.EventHandler(this.btnClick);
            // 
            // buttonMyGames
            // 
            this.buttonMyGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.buttonMyGames.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMyGames.Enabled = false;
            this.buttonMyGames.FlatAppearance.BorderSize = 0;
            this.buttonMyGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMyGames.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonMyGames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.buttonMyGames.Image = global::ModerrLauncher.Properties.Resources.icon_game;
            this.buttonMyGames.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMyGames.Location = new System.Drawing.Point(0, 234);
            this.buttonMyGames.Name = "buttonMyGames";
            this.buttonMyGames.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.buttonMyGames.Size = new System.Drawing.Size(213, 50);
            this.buttonMyGames.TabIndex = 8;
            this.buttonMyGames.Text = "TWOJE GRY";
            this.buttonMyGames.UseVisualStyleBackColor = false;
            this.buttonMyGames.Click += new System.EventHandler(this.btnClick);
            // 
            // buttonSearchGames
            // 
            this.buttonSearchGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.buttonSearchGames.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSearchGames.Enabled = false;
            this.buttonSearchGames.FlatAppearance.BorderSize = 0;
            this.buttonSearchGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchGames.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSearchGames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.buttonSearchGames.Image = global::ModerrLauncher.Properties.Resources.icon_book;
            this.buttonSearchGames.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchGames.Location = new System.Drawing.Point(0, 184);
            this.buttonSearchGames.Name = "buttonSearchGames";
            this.buttonSearchGames.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.buttonSearchGames.Size = new System.Drawing.Size(213, 50);
            this.buttonSearchGames.TabIndex = 7;
            this.buttonSearchGames.Text = "PRZEGLĄDAJ GRY";
            this.buttonSearchGames.UseVisualStyleBackColor = false;
            this.buttonSearchGames.Click += new System.EventHandler(this.btnClick);
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.buttonHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.buttonHome.Image = global::ModerrLauncher.Properties.Resources.icon_home;
            this.buttonHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.Location = new System.Drawing.Point(0, 134);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.buttonHome.Size = new System.Drawing.Size(213, 50);
            this.buttonHome.TabIndex = 6;
            this.buttonHome.Text = "STRONA GŁÓWNA";
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.btnClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(45, 606);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Moderr Launcher";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ModerrLauncher.Properties.Resources.big_icon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 606);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel2.Controls.Add(this.userNameLabel);
            this.panel2.Controls.Add(this.userPicture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 134);
            this.panel2.TabIndex = 2;
            // 
            // userNameLabel
            // 
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.userNameLabel.Location = new System.Drawing.Point(3, 95);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(207, 22);
            this.userNameLabel.TabIndex = 3;
            this.userNameLabel.Text = "Nazwa użytkownika";
            this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userPicture
            // 
            this.userPicture.Image = global::ModerrLauncher.Properties.Resources.default_user;
            this.userPicture.Location = new System.Drawing.Point(66, 12);
            this.userPicture.Name = "userPicture";
            this.userPicture.Size = new System.Drawing.Size(80, 80);
            this.userPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPicture.TabIndex = 2;
            this.userPicture.TabStop = false;
            // 
            // childPanel
            // 
            this.childPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.childPanel.Location = new System.Drawing.Point(213, 0);
            this.childPanel.Name = "childPanel";
            this.childPanel.Size = new System.Drawing.Size(969, 644);
            this.childPanel.TabIndex = 2;
            // 
            // buttonDevour
            // 
            this.buttonDevour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.buttonDevour.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDevour.FlatAppearance.BorderSize = 0;
            this.buttonDevour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDevour.Font = new System.Drawing.Font("Mistral", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDevour.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonDevour.Image = global::ModerrLauncher.Properties.Resources.icon_game;
            this.buttonDevour.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDevour.Location = new System.Drawing.Point(0, 384);
            this.buttonDevour.Name = "buttonDevour";
            this.buttonDevour.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.buttonDevour.Size = new System.Drawing.Size(213, 50);
            this.buttonDevour.TabIndex = 12;
            this.buttonDevour.Text = "DEVOUR";
            this.buttonDevour.UseVisualStyleBackColor = false;
            this.buttonDevour.Click += new System.EventHandler(this.btnClick);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1182, 644);
            this.Controls.Add(this.childPanel);
            this.Controls.Add(this.panelSidebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1198, 683);
            this.Name = "LauncherForm";
            this.Text = "Moderr Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LauncherForm_FormClosing);
            this.Resize += new System.EventHandler(this.LauncherForm_Resize);
            this.panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon LauncherTray;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonChat;
        private System.Windows.Forms.Button buttonMyGames;
        private System.Windows.Forms.Button buttonSearchGames;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label userNameLabel;
        private CirclePictureBox userPicture;
        private System.Windows.Forms.Panel childPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDevour;
    }
}