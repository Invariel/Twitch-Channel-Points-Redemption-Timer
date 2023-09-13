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
            tbl_AuthToken = new TableLayoutPanel();
            btn_OAuth = new Button();
            btn_LoadConfiguration = new Button();
            btn_SaveConfiguration = new Button();
            grp_Output = new GroupBox();
            tbl_OutputSettings = new TableLayoutPanel();
            txt_OutputFileName = new TextBox();
            lbl_OutputFile = new Label();
            grp_CreateRedemption = new GroupBox();
            tbl_CreateRedemption = new TableLayoutPanel();
            lbl_RedemptionName = new Label();
            txt_RedemptionName = new TextBox();
            lbl_RedemptionPoints = new Label();
            numud_RedemptionPoints = new NumericUpDown();
            lbl_RedemptionPrompt = new Label();
            txt_RedemptionPrompt = new TextBox();
            btn_RedemptionCreate = new Button();
            tbl_Controls = new TableLayoutPanel();
            lbl_TwitchControls = new Label();
            btn_EnableAll = new Button();
            btn_DisableAll = new Button();
            lbl_TimerControls = new Label();
            btn_PauseTimers = new Button();
            lbl_SoundControls = new Label();
            btn_MuteSounds = new Button();
            lbl_Volume = new Label();
            numud_Volume = new NumericUpDown();
            btn_StartListening = new Button();
            lbl_RedemptionUserInputRequired = new Label();
            chk_RedemptionUserInputRequired = new CheckBox();
            tbl_MainLayout.SuspendLayout();
            tabControl_Settings.SuspendLayout();
            tab_Redemptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_Redemptions).BeginInit();
            tab_Settings.SuspendLayout();
            tbl_Settings.SuspendLayout();
            grp_Credentials.SuspendLayout();
            tbl_Credentials.SuspendLayout();
            tbl_AuthToken.SuspendLayout();
            grp_Output.SuspendLayout();
            tbl_OutputSettings.SuspendLayout();
            grp_CreateRedemption.SuspendLayout();
            tbl_CreateRedemption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numud_RedemptionPoints).BeginInit();
            tbl_Controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numud_Volume).BeginInit();
            SuspendLayout();
            // 
            // tbl_MainLayout
            // 
            tbl_MainLayout.AutoScroll = true;
            tbl_MainLayout.ColumnCount = 2;
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.875F));
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.125F));
            tbl_MainLayout.Controls.Add(tabControl_Settings, 0, 0);
            tbl_MainLayout.Controls.Add(tbl_Controls, 1, 0);
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
            tbl_Settings.Controls.Add(grp_CreateRedemption, 0, 2);
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
            tbl_Credentials.Controls.Add(tbl_AuthToken, 1, 3);
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
            // tbl_AuthToken
            // 
            tbl_AuthToken.ColumnCount = 4;
            tbl_AuthToken.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tbl_AuthToken.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tbl_AuthToken.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tbl_AuthToken.ColumnStyles.Add(new ColumnStyle());
            tbl_AuthToken.Controls.Add(btn_OAuth, 0, 0);
            tbl_AuthToken.Controls.Add(btn_LoadConfiguration, 1, 0);
            tbl_AuthToken.Controls.Add(btn_SaveConfiguration, 2, 0);
            tbl_AuthToken.Dock = DockStyle.Fill;
            tbl_AuthToken.Location = new Point(126, 78);
            tbl_AuthToken.Name = "tbl_AuthToken";
            tbl_AuthToken.RowCount = 1;
            tbl_AuthToken.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_AuthToken.Size = new Size(526, 55);
            tbl_AuthToken.TabIndex = 6;
            // 
            // btn_OAuth
            // 
            btn_OAuth.Dock = DockStyle.Top;
            btn_OAuth.Location = new Point(3, 3);
            btn_OAuth.Name = "btn_OAuth";
            btn_OAuth.Size = new Size(169, 23);
            btn_OAuth.TabIndex = 6;
            btn_OAuth.Text = "Get OAuth Token";
            btn_OAuth.UseVisualStyleBackColor = true;
            // 
            // btn_LoadConfiguration
            // 
            btn_LoadConfiguration.Dock = DockStyle.Top;
            btn_LoadConfiguration.Location = new Point(178, 3);
            btn_LoadConfiguration.Name = "btn_LoadConfiguration";
            btn_LoadConfiguration.Size = new Size(169, 23);
            btn_LoadConfiguration.TabIndex = 7;
            btn_LoadConfiguration.Text = "Load Configuration";
            btn_LoadConfiguration.UseVisualStyleBackColor = true;
            // 
            // btn_SaveConfiguration
            // 
            btn_SaveConfiguration.Dock = DockStyle.Top;
            btn_SaveConfiguration.Location = new Point(353, 3);
            btn_SaveConfiguration.Name = "btn_SaveConfiguration";
            btn_SaveConfiguration.Size = new Size(169, 23);
            btn_SaveConfiguration.TabIndex = 8;
            btn_SaveConfiguration.Text = "Save Configuration";
            btn_SaveConfiguration.UseVisualStyleBackColor = true;
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
            // grp_CreateRedemption
            // 
            grp_CreateRedemption.Controls.Add(tbl_CreateRedemption);
            grp_CreateRedemption.Dock = DockStyle.Fill;
            grp_CreateRedemption.Location = new Point(3, 249);
            grp_CreateRedemption.Name = "grp_CreateRedemption";
            grp_CreateRedemption.Size = new Size(661, 158);
            grp_CreateRedemption.TabIndex = 2;
            grp_CreateRedemption.TabStop = false;
            grp_CreateRedemption.Text = "Create Redemption";
            // 
            // tbl_CreateRedemption
            // 
            tbl_CreateRedemption.ColumnCount = 4;
            tbl_CreateRedemption.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tbl_CreateRedemption.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tbl_CreateRedemption.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tbl_CreateRedemption.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tbl_CreateRedemption.Controls.Add(lbl_RedemptionName, 0, 0);
            tbl_CreateRedemption.Controls.Add(txt_RedemptionName, 1, 0);
            tbl_CreateRedemption.Controls.Add(lbl_RedemptionPoints, 2, 0);
            tbl_CreateRedemption.Controls.Add(numud_RedemptionPoints, 3, 0);
            tbl_CreateRedemption.Controls.Add(btn_RedemptionCreate, 3, 2);
            tbl_CreateRedemption.Controls.Add(txt_RedemptionPrompt, 3, 1);
            tbl_CreateRedemption.Controls.Add(lbl_RedemptionPrompt, 2, 1);
            tbl_CreateRedemption.Controls.Add(lbl_RedemptionUserInputRequired, 0, 1);
            tbl_CreateRedemption.Controls.Add(chk_RedemptionUserInputRequired, 1, 1);
            tbl_CreateRedemption.Dock = DockStyle.Fill;
            tbl_CreateRedemption.Location = new Point(3, 19);
            tbl_CreateRedemption.Name = "tbl_CreateRedemption";
            tbl_CreateRedemption.RowCount = 5;
            tbl_CreateRedemption.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_CreateRedemption.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_CreateRedemption.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_CreateRedemption.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_CreateRedemption.RowStyles.Add(new RowStyle());
            tbl_CreateRedemption.Size = new Size(655, 136);
            tbl_CreateRedemption.TabIndex = 0;
            // 
            // lbl_RedemptionName
            // 
            lbl_RedemptionName.AutoSize = true;
            lbl_RedemptionName.Dock = DockStyle.Fill;
            lbl_RedemptionName.Location = new Point(3, 0);
            lbl_RedemptionName.Name = "lbl_RedemptionName";
            lbl_RedemptionName.Size = new Size(92, 30);
            lbl_RedemptionName.TabIndex = 0;
            lbl_RedemptionName.Text = "Name";
            lbl_RedemptionName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txt_RedemptionName
            // 
            txt_RedemptionName.Dock = DockStyle.Fill;
            txt_RedemptionName.Location = new Point(101, 3);
            txt_RedemptionName.Name = "txt_RedemptionName";
            txt_RedemptionName.Size = new Size(223, 23);
            txt_RedemptionName.TabIndex = 1;
            // 
            // lbl_RedemptionPoints
            // 
            lbl_RedemptionPoints.AutoSize = true;
            lbl_RedemptionPoints.Dock = DockStyle.Fill;
            lbl_RedemptionPoints.Location = new Point(330, 0);
            lbl_RedemptionPoints.Name = "lbl_RedemptionPoints";
            lbl_RedemptionPoints.Size = new Size(92, 30);
            lbl_RedemptionPoints.TabIndex = 2;
            lbl_RedemptionPoints.Text = "Points";
            lbl_RedemptionPoints.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numud_RedemptionPoints
            // 
            numud_RedemptionPoints.Dock = DockStyle.Fill;
            numud_RedemptionPoints.Location = new Point(428, 3);
            numud_RedemptionPoints.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numud_RedemptionPoints.Name = "numud_RedemptionPoints";
            numud_RedemptionPoints.Size = new Size(224, 23);
            numud_RedemptionPoints.TabIndex = 3;
            // 
            // lbl_RedemptionPrompt
            // 
            lbl_RedemptionPrompt.AutoSize = true;
            lbl_RedemptionPrompt.Dock = DockStyle.Fill;
            lbl_RedemptionPrompt.Location = new Point(330, 30);
            lbl_RedemptionPrompt.Name = "lbl_RedemptionPrompt";
            lbl_RedemptionPrompt.Size = new Size(92, 30);
            lbl_RedemptionPrompt.TabIndex = 4;
            lbl_RedemptionPrompt.Text = "Prompt";
            lbl_RedemptionPrompt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txt_RedemptionPrompt
            // 
            txt_RedemptionPrompt.Dock = DockStyle.Fill;
            txt_RedemptionPrompt.Location = new Point(428, 33);
            txt_RedemptionPrompt.Name = "txt_RedemptionPrompt";
            txt_RedemptionPrompt.Size = new Size(224, 23);
            txt_RedemptionPrompt.TabIndex = 5;
            // 
            // btn_RedemptionCreate
            // 
            btn_RedemptionCreate.Dock = DockStyle.Fill;
            btn_RedemptionCreate.Location = new Point(428, 63);
            btn_RedemptionCreate.Name = "btn_RedemptionCreate";
            btn_RedemptionCreate.Size = new Size(224, 24);
            btn_RedemptionCreate.TabIndex = 6;
            btn_RedemptionCreate.Text = "Create Redemption";
            btn_RedemptionCreate.UseVisualStyleBackColor = true;
            // 
            // tbl_Controls
            // 
            tbl_Controls.ColumnCount = 1;
            tbl_Controls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_Controls.Controls.Add(lbl_TwitchControls, 0, 0);
            tbl_Controls.Controls.Add(btn_EnableAll, 0, 1);
            tbl_Controls.Controls.Add(btn_DisableAll, 0, 2);
            tbl_Controls.Controls.Add(lbl_TimerControls, 0, 4);
            tbl_Controls.Controls.Add(btn_PauseTimers, 0, 5);
            tbl_Controls.Controls.Add(lbl_SoundControls, 0, 7);
            tbl_Controls.Controls.Add(btn_MuteSounds, 0, 8);
            tbl_Controls.Controls.Add(lbl_Volume, 0, 10);
            tbl_Controls.Controls.Add(numud_Volume, 0, 11);
            tbl_Controls.Controls.Add(btn_StartListening, 0, 13);
            tbl_Controls.Dock = DockStyle.Fill;
            tbl_Controls.Location = new Point(690, 3);
            tbl_Controls.Name = "tbl_Controls";
            tbl_Controls.RowCount = 14;
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_Controls.RowStyles.Add(new RowStyle());
            tbl_Controls.Size = new Size(107, 444);
            tbl_Controls.TabIndex = 1;
            // 
            // lbl_TwitchControls
            // 
            lbl_TwitchControls.AutoSize = true;
            lbl_TwitchControls.Dock = DockStyle.Fill;
            lbl_TwitchControls.Location = new Point(3, 0);
            lbl_TwitchControls.Name = "lbl_TwitchControls";
            lbl_TwitchControls.Size = new Size(101, 30);
            lbl_TwitchControls.TabIndex = 4;
            lbl_TwitchControls.Text = "Twitch Controls";
            lbl_TwitchControls.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_EnableAll
            // 
            btn_EnableAll.Dock = DockStyle.Fill;
            btn_EnableAll.Location = new Point(3, 33);
            btn_EnableAll.Name = "btn_EnableAll";
            btn_EnableAll.Size = new Size(101, 24);
            btn_EnableAll.TabIndex = 1;
            btn_EnableAll.Text = "Enable All";
            btn_EnableAll.UseVisualStyleBackColor = true;
            // 
            // btn_DisableAll
            // 
            btn_DisableAll.Dock = DockStyle.Fill;
            btn_DisableAll.Location = new Point(3, 63);
            btn_DisableAll.Name = "btn_DisableAll";
            btn_DisableAll.Size = new Size(101, 24);
            btn_DisableAll.TabIndex = 0;
            btn_DisableAll.Text = "Disable All";
            btn_DisableAll.UseVisualStyleBackColor = true;
            // 
            // lbl_TimerControls
            // 
            lbl_TimerControls.AutoSize = true;
            lbl_TimerControls.Dock = DockStyle.Fill;
            lbl_TimerControls.Location = new Point(3, 120);
            lbl_TimerControls.Name = "lbl_TimerControls";
            lbl_TimerControls.Size = new Size(101, 30);
            lbl_TimerControls.TabIndex = 5;
            lbl_TimerControls.Text = "Timer Controls";
            lbl_TimerControls.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_PauseTimers
            // 
            btn_PauseTimers.Dock = DockStyle.Fill;
            btn_PauseTimers.Location = new Point(3, 153);
            btn_PauseTimers.Name = "btn_PauseTimers";
            btn_PauseTimers.Size = new Size(101, 24);
            btn_PauseTimers.TabIndex = 2;
            btn_PauseTimers.Text = "Pause Timers";
            btn_PauseTimers.UseVisualStyleBackColor = true;
            // 
            // lbl_SoundControls
            // 
            lbl_SoundControls.AutoSize = true;
            lbl_SoundControls.Dock = DockStyle.Fill;
            lbl_SoundControls.Location = new Point(3, 210);
            lbl_SoundControls.Name = "lbl_SoundControls";
            lbl_SoundControls.Size = new Size(101, 30);
            lbl_SoundControls.TabIndex = 6;
            lbl_SoundControls.Text = "Sound Controls";
            lbl_SoundControls.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_MuteSounds
            // 
            btn_MuteSounds.Dock = DockStyle.Fill;
            btn_MuteSounds.Location = new Point(3, 243);
            btn_MuteSounds.Name = "btn_MuteSounds";
            btn_MuteSounds.Size = new Size(101, 24);
            btn_MuteSounds.TabIndex = 7;
            btn_MuteSounds.Text = "Mute Sounds";
            btn_MuteSounds.UseVisualStyleBackColor = true;
            // 
            // lbl_Volume
            // 
            lbl_Volume.AutoSize = true;
            lbl_Volume.Dock = DockStyle.Fill;
            lbl_Volume.Location = new Point(3, 300);
            lbl_Volume.Name = "lbl_Volume";
            lbl_Volume.Size = new Size(101, 30);
            lbl_Volume.TabIndex = 8;
            lbl_Volume.Text = "Volume";
            lbl_Volume.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numud_Volume
            // 
            numud_Volume.DecimalPlaces = 1;
            numud_Volume.Dock = DockStyle.Fill;
            numud_Volume.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numud_Volume.Location = new Point(3, 333);
            numud_Volume.Name = "numud_Volume";
            numud_Volume.Size = new Size(101, 23);
            numud_Volume.TabIndex = 9;
            numud_Volume.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // btn_StartListening
            // 
            btn_StartListening.Dock = DockStyle.Fill;
            btn_StartListening.Location = new Point(3, 393);
            btn_StartListening.Name = "btn_StartListening";
            btn_StartListening.Size = new Size(101, 48);
            btn_StartListening.TabIndex = 10;
            btn_StartListening.Text = "Start Listening";
            btn_StartListening.UseVisualStyleBackColor = true;
            // 
            // lbl_RedemptionUserInputRequired
            // 
            lbl_RedemptionUserInputRequired.AutoSize = true;
            lbl_RedemptionUserInputRequired.Dock = DockStyle.Fill;
            lbl_RedemptionUserInputRequired.Location = new Point(3, 30);
            lbl_RedemptionUserInputRequired.Name = "lbl_RedemptionUserInputRequired";
            lbl_RedemptionUserInputRequired.Size = new Size(92, 30);
            lbl_RedemptionUserInputRequired.TabIndex = 7;
            lbl_RedemptionUserInputRequired.Text = "User Input?";
            lbl_RedemptionUserInputRequired.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chk_RedemptionUserInputRequired
            // 
            chk_RedemptionUserInputRequired.AutoSize = true;
            chk_RedemptionUserInputRequired.CheckAlign = ContentAlignment.MiddleCenter;
            chk_RedemptionUserInputRequired.Dock = DockStyle.Fill;
            chk_RedemptionUserInputRequired.Location = new Point(101, 33);
            chk_RedemptionUserInputRequired.Name = "chk_RedemptionUserInputRequired";
            chk_RedemptionUserInputRequired.Size = new Size(223, 24);
            chk_RedemptionUserInputRequired.TabIndex = 8;
            chk_RedemptionUserInputRequired.UseVisualStyleBackColor = true;
            // 
            // RedemptionTimer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbl_MainLayout);
            Name = "RedemptionTimer";
            Text = "Redemption Timer";
            tbl_MainLayout.ResumeLayout(false);
            tabControl_Settings.ResumeLayout(false);
            tab_Redemptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_Redemptions).EndInit();
            tab_Settings.ResumeLayout(false);
            tbl_Settings.ResumeLayout(false);
            grp_Credentials.ResumeLayout(false);
            tbl_Credentials.ResumeLayout(false);
            tbl_Credentials.PerformLayout();
            tbl_AuthToken.ResumeLayout(false);
            grp_Output.ResumeLayout(false);
            tbl_OutputSettings.ResumeLayout(false);
            tbl_OutputSettings.PerformLayout();
            grp_CreateRedemption.ResumeLayout(false);
            tbl_CreateRedemption.ResumeLayout(false);
            tbl_CreateRedemption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numud_RedemptionPoints).EndInit();
            tbl_Controls.ResumeLayout(false);
            tbl_Controls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numud_Volume).EndInit();
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
        private TableLayoutPanel tbl_Controls;
        private Button btn_DisableAll;
        private Button btn_EnableAll;
        private Button btn_PauseTimers;
        private Label lbl_TwitchControls;
        private Label lbl_TimerControls;
        private Label lbl_SoundControls;
        private Button btn_MuteSounds;
        private Label lbl_Volume;
        private NumericUpDown numud_Volume;
        private Button btn_StartListening;
        private TableLayoutPanel tbl_AuthToken;
        private Button btn_LoadConfiguration;
        private Button btn_SaveConfiguration;
        private GroupBox grp_CreateRedemption;
        private TableLayoutPanel tbl_CreateRedemption;
        private Label lbl_RedemptionName;
        private TextBox txt_RedemptionName;
        private Label lbl_RedemptionPoints;
        private NumericUpDown numud_RedemptionPoints;
        private Label lbl_RedemptionPrompt;
        private TextBox txt_RedemptionPrompt;
        private Button btn_RedemptionCreate;
        private Label lbl_RedemptionUserInputRequired;
        private CheckBox chk_RedemptionUserInputRequired;
    }
}