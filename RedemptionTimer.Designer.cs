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
            SuspendLayout();
            // 
            // tbl_MainLayout
            // 
            tbl_MainLayout.AutoScroll = true;
            tbl_MainLayout.ColumnCount = 2;
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.875F));
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.125F));
            tbl_MainLayout.Dock = DockStyle.Fill;
            tbl_MainLayout.Location = new Point(0, 0);
            tbl_MainLayout.Name = "tbl_MainLayout";
            tbl_MainLayout.RowCount = 1;
            tbl_MainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_MainLayout.Size = new Size(800, 450);
            tbl_MainLayout.TabIndex = 0;
            // 
            // RedemptionTimer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbl_MainLayout);
            Name = "RedemptionTimer";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tbl_MainLayout;
    }
}