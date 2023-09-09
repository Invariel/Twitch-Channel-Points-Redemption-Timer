namespace Twitch_Channel_Points_Redemption_Timer
{
    partial class RedemptionTimer
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
            tbl_MainLayout = new TableLayoutPanel();
            tabControl_Settings = new TabControl();
            tab_Redemptions = new TabPage();
            dg_Redemptions = new DataGridView();
            tab_Settings = new TabPage();
            tbl_Settings = new TableLayoutPanel();
            grp_Credentials = new GroupBox();
            tbl_Credentials = new TableLayoutPanel();
            txt_Username = new TextBox();
            txt_UserId = new TextBox();
            txt_OAuth = new TextBox();
            lbl_Username = new Label();
            lbl_UserId = new Label();
            lbl_Oauth = new Label();
            btn_OAuth = new Button();
            grp_Output = new GroupBox();
            tbl_OutputSettings = new TableLayoutPanel();
            txt_OutputFileName = new TextBox();
            lbl_OutputFile = new Label();
            tbl_MainLayout.SuspendLayout();
            tabControl_Settings.SuspendLayout();
            tab_Redemptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_Redemptions).BeginInit();
            tab_Settings.SuspendLayout();
            tbl_Settings.SuspendLayout();
            grp_Credentials.SuspendLayout();
            tbl_Credentials.SuspendLayout();
            grp_Output.SuspendLayout();
            tbl_OutputSettings.SuspendLayout();
            SuspendLayout();
            // 
            // tbl_MainLayout
            // 
            tbl_MainLayout.AutoScroll = true;
            tbl_MainLayout.ColumnCount = 2;
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.875F));
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.125F));
            tbl_MainLayout.Controls.Add(tabControl_Settings, 0, 0);
            tbl_MainLayout.Dock = DockStyle.Fill;
            tbl_MainLayout.Location = new Point(0, 0);
            tbl_MainLayout.Name = "tbl_MainLayout";
            tbl_MainLayout.RowCount = 1;
            tbl_MainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_MainLayout.Size = new Size(800, 450);
            tbl_MainLayout.TabIndex = 0;
            // 
            // tabControl_Settings
            // 
            tabControl_Settings.Controls.Add(tab_Redemptions);
            tabControl_Settings.Controls.Add(tab_Settings);
            tabControl_Settings.Dock = DockStyle.Fill;
            tabControl_Settings.Location = new Point(3, 3);
            tabControl_Settings.Name = "tabControl_Settings";
            tabControl_Settings.SelectedIndex = 0;
            tabControl_Settings.Size = new Size(681, 444);
            tabControl_Settings.TabIndex = 0;
            // 
            // tab_Redemptions
            // 
            tab_Redemptions.Controls.Add(dg_Redemptions);
            tab_Redemptions.Location = new Point(4, 24);
            tab_Redemptions.Name = "tab_Redemptions";
            tab_Redemptions.Padding = new Padding(3);
            tab_Redemptions.Size = new Size(673, 416);
            tab_Redemptions.TabIndex = 0;
            tab_Redemptions.Text = "Redemptions";
            tab_Redemptions.UseVisualStyleBackColor = true;
            // 
            // dg_Redemptions
            // 
            dg_Redemptions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dg_Redemptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_Redemptions.Dock = DockStyle.Fill;
            dg_Redemptions.Location = new Point(3, 3);
            dg_Redemptions.Name = "dg_Redemptions";
            dg_Redemptions.RowTemplate.Height = 25;
            dg_Redemptions.Size = new Size(667, 410);
            dg_Redemptions.TabIndex = 0;
            // 
            // tab_Settings
            // 
            tab_Settings.Controls.Add(tbl_Settings);
            tab_Settings.Location = new Point(4, 24);
            tab_Settings.Name = "tab_Settings";
            tab_Settings.Padding = new Padding(3);
            tab_Settings.Size = new Size(673, 416);
            tab_Settings.TabIndex = 1;
            tab_Settings.Text = "Settings";
            tab_Settings.UseVisualStyleBackColor = true;
            // 
            // tbl_Settings
            // 
            tbl_Settings.ColumnCount = 1;
            tbl_Settings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_Settings.Controls.Add(grp_Credentials, 0, 0);
            tbl_Settings.Controls.Add(grp_Output, 0, 1);
            tbl_Settings.Dock = DockStyle.Fill;
            tbl_Settings.Location = new Point(3, 3);
            tbl_Settings.Name = "tbl_Settings";
            tbl_Settings.RowCount = 3;
            tbl_Settings.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tbl_Settings.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tbl_Settings.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tbl_Settings.Size = new Size(667, 410);
            tbl_Settings.TabIndex = 0;
            // 
            // grp_Credentials
            // 
            grp_Credentials.Controls.Add(tbl_Credentials);
            grp_Credentials.Dock = DockStyle.Fill;
            grp_Credentials.Location = new Point(3, 3);
            grp_Credentials.Name = "grp_Credentials";
            grp_Credentials.Size = new Size(661, 158);
            grp_Credentials.TabIndex = 0;
            grp_Credentials.TabStop = false;
            grp_Credentials.Text = "Credentials";
            // 
            // tbl_Credentials
            // 
            tbl_Credentials.ColumnCount = 2;
            tbl_Credentials.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.77863F));
            tbl_Credentials.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.2213745F));
            tbl_Credentials.Controls.Add(txt_Username, 1, 0);
            tbl_Credentials.Controls.Add(txt_UserId, 1, 1);
            tbl_Credentials.Controls.Add(txt_OAuth, 1, 2);
            tbl_Credentials.Controls.Add(lbl_Username, 0, 0);
            tbl_Credentials.Controls.Add(lbl_UserId, 0, 1);
            tbl_Credentials.Controls.Add(lbl_Oauth, 0, 2);
            tbl_Credentials.Controls.Add(btn_OAuth, 1, 3);
            tbl_Credentials.Dock = DockStyle.Fill;
            tbl_Credentials.Location = new Point(3, 19);
            tbl_Credentials.Name = "tbl_Credentials";
            tbl_Credentials.RowCount = 4;
            tbl_Credentials.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tbl_Credentials.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tbl_Credentials.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tbl_Credentials.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_Credentials.Size = new Size(655, 136);
            tbl_Credentials.TabIndex = 0;
            // 
            // txt_Username
            // 
            txt_Username.Dock = DockStyle.Fill;
            txt_Username.Location = new Point(126, 3);
            txt_Username.Name = "txt_Username";
            txt_Username.Size = new Size(526, 23);
            txt_Username.TabIndex = 0;
            // 
            // txt_UserId
            // 
            txt_UserId.Dock = DockStyle.Fill;
            txt_UserId.Location = new Point(126, 28);
            txt_UserId.Name = "txt_UserId";
            txt_UserId.Size = new Size(526, 23);
            txt_UserId.TabIndex = 1;
            // 
            // txt_OAuth
            // 
            txt_OAuth.Dock = DockStyle.Fill;
            txt_OAuth.Location = new Point(126, 53);
            txt_OAuth.Name = "txt_OAuth";
            txt_OAuth.Size = new Size(526, 23);
            txt_OAuth.TabIndex = 2;
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.Dock = DockStyle.Fill;
            lbl_Username.Location = new Point(3, 0);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new Size(117, 25);
            lbl_Username.TabIndex = 3;
            lbl_Username.Text = "Username";
            lbl_Username.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_UserId
            // 
            lbl_UserId.AutoSize = true;
            lbl_UserId.Dock = DockStyle.Fill;
            lbl_UserId.Location = new Point(3, 25);
            lbl_UserId.Name = "lbl_UserId";
            lbl_UserId.Size = new Size(117, 25);
            lbl_UserId.TabIndex = 4;
            lbl_UserId.Text = "User ID (optional)";
            lbl_UserId.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Oauth
            // 
            lbl_Oauth.AutoSize = true;
            lbl_Oauth.Dock = DockStyle.Fill;
            lbl_Oauth.Location = new Point(3, 50);
            lbl_Oauth.Name = "lbl_Oauth";
            lbl_Oauth.Size = new Size(117, 25);
            lbl_Oauth.TabIndex = 5;
            lbl_Oauth.Text = "OAuth Token";
            lbl_Oauth.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn_OAuth
            // 
            btn_OAuth.Location = new Point(126, 78);
            btn_OAuth.Name = "btn_OAuth";
            btn_OAuth.Size = new Size(125, 23);
            btn_OAuth.TabIndex = 6;
            btn_OAuth.Text = "Get OAuth Token";
            btn_OAuth.UseVisualStyleBackColor = true;
            // 
            // grp_Output
            // 
            grp_Output.Controls.Add(tbl_OutputSettings);
            grp_Output.Dock = DockStyle.Fill;
            grp_Output.Location = new Point(3, 167);
            grp_Output.Name = "grp_Output";
            grp_Output.Size = new Size(661, 76);
            grp_Output.TabIndex = 1;
            grp_Output.TabStop = false;
            grp_Output.Text = "Output Settings";
            // 
            // tbl_OutputSettings
            // 
            tbl_OutputSettings.ColumnCount = 2;
            tbl_OutputSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.78F));
            tbl_OutputSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.22F));
            tbl_OutputSettings.Controls.Add(txt_OutputFileName, 1, 0);
            tbl_OutputSettings.Controls.Add(lbl_OutputFile, 0, 0);
            tbl_OutputSettings.Dock = DockStyle.Fill;
            tbl_OutputSettings.Location = new Point(3, 19);
            tbl_OutputSettings.Name = "tbl_OutputSettings";
            tbl_OutputSettings.RowCount = 3;
            tbl_OutputSettings.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tbl_OutputSettings.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tbl_OutputSettings.RowStyles.Add(new RowStyle());
            tbl_OutputSettings.Size = new Size(655, 54);
            tbl_OutputSettings.TabIndex = 0;
            // 
            // txt_OutputFileName
            // 
            txt_OutputFileName.Dock = DockStyle.Fill;
            txt_OutputFileName.Location = new Point(126, 3);
            txt_OutputFileName.Name = "txt_OutputFileName";
            txt_OutputFileName.Size = new Size(526, 23);
            txt_OutputFileName.TabIndex = 0;
            // 
            // lbl_OutputFile
            // 
            lbl_OutputFile.AutoSize = true;
            lbl_OutputFile.Dock = DockStyle.Fill;
            lbl_OutputFile.Location = new Point(3, 0);
            lbl_OutputFile.Name = "lbl_OutputFile";
            lbl_OutputFile.Size = new Size(117, 25);
            lbl_OutputFile.TabIndex = 2;
            lbl_OutputFile.Text = "Timer File";
            lbl_OutputFile.TextAlign = ContentAlignment.MiddleRight;
            // 
            // RedemptionTimer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbl_MainLayout);
            Name = "RedemptionTimer";
            Text = "Form1";
            tbl_MainLayout.ResumeLayout(false);
            tabControl_Settings.ResumeLayout(false);
            tab_Redemptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_Redemptions).EndInit();
            tab_Settings.ResumeLayout(false);
            tbl_Settings.ResumeLayout(false);
            grp_Credentials.ResumeLayout(false);
            tbl_Credentials.ResumeLayout(false);
            tbl_Credentials.PerformLayout();
            grp_Output.ResumeLayout(false);
            tbl_OutputSettings.ResumeLayout(false);
            tbl_OutputSettings.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tbl_MainLayout;
        private TabControl tabControl_Settings;
        private TabPage tab_Redemptions;
        private TabPage tab_Settings;
        private TableLayoutPanel tbl_Settings;
        private GroupBox grp_Credentials;
        private GroupBox grp_Output;
        private TableLayoutPanel tbl_Credentials;
        private TextBox txt_Username;
        private TextBox txt_UserId;
        private TextBox txt_OAuth;
        private Label lbl_Username;
        private Label lbl_UserId;
        private Label lbl_Oauth;
        private Button btn_OAuth;
        private TableLayoutPanel tbl_OutputSettings;
        private TextBox txt_OutputFileName;
        private Label lbl_OutputFile;
        private DataGridView dg_Redemptions;
    }
}