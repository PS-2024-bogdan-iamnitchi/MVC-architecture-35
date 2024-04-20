namespace MVC_architecture_35.View
{
    partial class GameGUI
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
            this.gameTitle = new System.Windows.Forms.Label();
            this.playerLabel = new System.Windows.Forms.Label();
            this.oponentLabel = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.opoScoreLabel = new System.Windows.Forms.Label();
            this.plyScoreLabel = new System.Windows.Forms.Label();
            this.nudLevel = new System.Windows.Forms.NumericUpDown();
            this.nudOponentScore = new System.Windows.Forms.NumericUpDown();
            this.nudPlayerScore = new System.Windows.Forms.NumericUpDown();
            this.timerCPU = new System.Windows.Forms.Timer(this.components);
            this.buttonsTableLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.nudLoggedInPlayerScore = new System.Windows.Forms.NumericUpDown();
            this.loggedInPlayerScoreLabel = new System.Windows.Forms.Label();
            this.leaveGameButton = new System.Windows.Forms.Button();
            this.playPauseButton = new System.Windows.Forms.Button();
            this.restartGameButton = new System.Windows.Forms.Button();
            this.playerMovesPictureBox = new System.Windows.Forms.PictureBox();
            this.oponentMovesPictureBox = new System.Windows.Forms.PictureBox();
            this.langComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOponentScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayerScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoggedInPlayerScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerMovesPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oponentMovesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTitle
            // 
            this.gameTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameTitle.AutoSize = true;
            this.gameTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.gameTitle.Location = new System.Drawing.Point(275, 52);
            this.gameTitle.Name = "gameTitle";
            this.gameTitle.Size = new System.Drawing.Size(484, 55);
            this.gameTitle.TabIndex = 2;
            this.gameTitle.Text = "Arrow Puzzle Game";
            // 
            // playerLabel
            // 
            this.playerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerLabel.AutoSize = true;
            this.playerLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.playerLabel.Location = new System.Drawing.Point(753, 200);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(136, 24);
            this.playerLabel.TabIndex = 25;
            this.playerLabel.Text = "Your moves:";
            // 
            // oponentLabel
            // 
            this.oponentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oponentLabel.AutoSize = true;
            this.oponentLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oponentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.oponentLabel.Location = new System.Drawing.Point(486, 200);
            this.oponentLabel.Name = "oponentLabel";
            this.oponentLabel.Size = new System.Drawing.Size(176, 24);
            this.oponentLabel.TabIndex = 26;
            this.oponentLabel.Text = "Oponent moves:";
            // 
            // levelLabel
            // 
            this.levelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.levelLabel.Location = new System.Drawing.Point(349, 119);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(118, 37);
            this.levelLabel.TabIndex = 29;
            this.levelLabel.Text = "Level: ";
            // 
            // opoScoreLabel
            // 
            this.opoScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.opoScoreLabel.AutoSize = true;
            this.opoScoreLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opoScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.opoScoreLabel.Location = new System.Drawing.Point(486, 410);
            this.opoScoreLabel.Name = "opoScoreLabel";
            this.opoScoreLabel.Size = new System.Drawing.Size(167, 24);
            this.opoScoreLabel.TabIndex = 32;
            this.opoScoreLabel.Text = "Oponent score:";
            // 
            // plyScoreLabel
            // 
            this.plyScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plyScoreLabel.AutoSize = true;
            this.plyScoreLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plyScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.plyScoreLabel.Location = new System.Drawing.Point(764, 410);
            this.plyScoreLabel.Name = "plyScoreLabel";
            this.plyScoreLabel.Size = new System.Drawing.Size(127, 24);
            this.plyScoreLabel.TabIndex = 31;
            this.plyScoreLabel.Text = "Your score:";
            // 
            // nudLevel
            // 
            this.nudLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudLevel.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.nudLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.nudLevel.Location = new System.Drawing.Point(502, 119);
            this.nudLevel.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.ReadOnly = true;
            this.nudLevel.Size = new System.Drawing.Size(125, 38);
            this.nudLevel.TabIndex = 40;
            this.nudLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLevel.UseWaitCursor = true;
            this.nudLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudOponentScore
            // 
            this.nudOponentScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudOponentScore.Cursor = System.Windows.Forms.Cursors.No;
            this.nudOponentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudOponentScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.nudOponentScore.Location = new System.Drawing.Point(490, 458);
            this.nudOponentScore.Name = "nudOponentScore";
            this.nudOponentScore.ReadOnly = true;
            this.nudOponentScore.Size = new System.Drawing.Size(128, 38);
            this.nudOponentScore.TabIndex = 37;
            this.nudOponentScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudPlayerScore
            // 
            this.nudPlayerScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudPlayerScore.Cursor = System.Windows.Forms.Cursors.No;
            this.nudPlayerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPlayerScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.nudPlayerScore.Location = new System.Drawing.Point(757, 459);
            this.nudPlayerScore.Name = "nudPlayerScore";
            this.nudPlayerScore.ReadOnly = true;
            this.nudPlayerScore.Size = new System.Drawing.Size(128, 38);
            this.nudPlayerScore.TabIndex = 38;
            this.nudPlayerScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerCPU
            // 
            this.timerCPU.Interval = 1000;
            // 
            // buttonsTableLayout
            // 
            this.buttonsTableLayout.Location = new System.Drawing.Point(38, 199);
            this.buttonsTableLayout.Name = "buttonsTableLayout";
            this.buttonsTableLayout.Size = new System.Drawing.Size(441, 405);
            this.buttonsTableLayout.TabIndex = 42;
            // 
            // nudLoggedInPlayerScore
            // 
            this.nudLoggedInPlayerScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudLoggedInPlayerScore.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.nudLoggedInPlayerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLoggedInPlayerScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.nudLoggedInPlayerScore.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLoggedInPlayerScore.Location = new System.Drawing.Point(56, 79);
            this.nudLoggedInPlayerScore.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudLoggedInPlayerScore.Name = "nudLoggedInPlayerScore";
            this.nudLoggedInPlayerScore.ReadOnly = true;
            this.nudLoggedInPlayerScore.Size = new System.Drawing.Size(125, 35);
            this.nudLoggedInPlayerScore.TabIndex = 44;
            this.nudLoggedInPlayerScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLoggedInPlayerScore.UseWaitCursor = true;
            // 
            // loggedInPlayerScoreLabel
            // 
            this.loggedInPlayerScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loggedInPlayerScoreLabel.AutoSize = true;
            this.loggedInPlayerScoreLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loggedInPlayerScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.loggedInPlayerScoreLabel.Location = new System.Drawing.Point(31, 36);
            this.loggedInPlayerScoreLabel.Name = "loggedInPlayerScoreLabel";
            this.loggedInPlayerScoreLabel.Size = new System.Drawing.Size(167, 28);
            this.loggedInPlayerScoreLabel.TabIndex = 43;
            this.loggedInPlayerScoreLabel.Text = "Saved Score:";
            // 
            // leaveGameButton
            // 
            this.leaveGameButton.BackgroundImage = global::MVC_architecture_35.Properties.Resources.delete;
            this.leaveGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leaveGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leaveGameButton.FlatAppearance.BorderSize = 0;
            this.leaveGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveGameButton.Location = new System.Drawing.Point(525, 534);
            this.leaveGameButton.Name = "leaveGameButton";
            this.leaveGameButton.Size = new System.Drawing.Size(70, 70);
            this.leaveGameButton.TabIndex = 41;
            this.leaveGameButton.UseVisualStyleBackColor = true;
            // 
            // playPauseButton
            // 
            this.playPauseButton.BackgroundImage = global::MVC_architecture_35.Properties.Resources.start;
            this.playPauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playPauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playPauseButton.FlatAppearance.BorderSize = 0;
            this.playPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playPauseButton.Location = new System.Drawing.Point(821, 534);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(70, 70);
            this.playPauseButton.TabIndex = 35;
            this.playPauseButton.UseVisualStyleBackColor = true;
            // 
            // restartGameButton
            // 
            this.restartGameButton.BackgroundImage = global::MVC_architecture_35.Properties.Resources.update;
            this.restartGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.restartGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restartGameButton.FlatAppearance.BorderSize = 0;
            this.restartGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartGameButton.Location = new System.Drawing.Point(671, 534);
            this.restartGameButton.Name = "restartGameButton";
            this.restartGameButton.Size = new System.Drawing.Size(70, 70);
            this.restartGameButton.TabIndex = 39;
            this.restartGameButton.UseVisualStyleBackColor = true;
            // 
            // playerMovesPictureBox
            // 
            this.playerMovesPictureBox.Image = global::MVC_architecture_35.Properties.Resources.green_level1;
            this.playerMovesPictureBox.Location = new System.Drawing.Point(757, 251);
            this.playerMovesPictureBox.Name = "playerMovesPictureBox";
            this.playerMovesPictureBox.Size = new System.Drawing.Size(128, 125);
            this.playerMovesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.playerMovesPictureBox.TabIndex = 36;
            this.playerMovesPictureBox.TabStop = false;
            // 
            // oponentMovesPictureBox
            // 
            this.oponentMovesPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.oponentMovesPictureBox.Image = global::MVC_architecture_35.Properties.Resources.red_level1;
            this.oponentMovesPictureBox.Location = new System.Drawing.Point(490, 250);
            this.oponentMovesPictureBox.Name = "oponentMovesPictureBox";
            this.oponentMovesPictureBox.Size = new System.Drawing.Size(128, 126);
            this.oponentMovesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.oponentMovesPictureBox.TabIndex = 23;
            this.oponentMovesPictureBox.TabStop = false;
            // 
            // langComboBox
            // 
            this.langComboBox.AccessibleName = "";
            this.langComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.langComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.langComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.langComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.langComboBox.FormattingEnabled = true;
            this.langComboBox.Items.AddRange(new object[] {
            "English",
            "French",
            "German"});
            this.langComboBox.Location = new System.Drawing.Point(788, 22);
            this.langComboBox.Name = "langComboBox";
            this.langComboBox.Size = new System.Drawing.Size(174, 32);
            this.langComboBox.TabIndex = 45;
            this.langComboBox.Text = "Langauge";
            //this.langComboBox.SelectedIndexChanged += new System.EventHandler(this.langComboBox_SelectedIndexChanged);
            // 
            // GameGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.langComboBox);
            this.Controls.Add(this.nudLoggedInPlayerScore);
            this.Controls.Add(this.loggedInPlayerScoreLabel);
            this.Controls.Add(this.buttonsTableLayout);
            this.Controls.Add(this.leaveGameButton);
            this.Controls.Add(this.playPauseButton);
            this.Controls.Add(this.restartGameButton);
            this.Controls.Add(this.nudPlayerScore);
            this.Controls.Add(this.nudOponentScore);
            this.Controls.Add(this.playerMovesPictureBox);
            this.Controls.Add(this.nudLevel);
            this.Controls.Add(this.opoScoreLabel);
            this.Controls.Add(this.plyScoreLabel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.oponentLabel);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.oponentMovesPictureBox);
            this.Controls.Add(this.gameTitle);
            this.Name = "GameGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameGUI";
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOponentScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayerScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoggedInPlayerScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerMovesPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oponentMovesPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameTitle;
        private System.Windows.Forms.PictureBox oponentMovesPictureBox;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label oponentLabel;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label opoScoreLabel;
        private System.Windows.Forms.Label plyScoreLabel;
        private System.Windows.Forms.NumericUpDown nudLevel;
        private System.Windows.Forms.PictureBox playerMovesPictureBox;
        private System.Windows.Forms.NumericUpDown nudOponentScore;
        private System.Windows.Forms.NumericUpDown nudPlayerScore;
        private System.Windows.Forms.Button restartGameButton;
        private System.Windows.Forms.Button playPauseButton;
        private System.Windows.Forms.Button leaveGameButton;
        private System.Windows.Forms.Timer timerCPU;
        private System.Windows.Forms.FlowLayoutPanel buttonsTableLayout;
        private System.Windows.Forms.NumericUpDown nudLoggedInPlayerScore;
        private System.Windows.Forms.Label loggedInPlayerScoreLabel;
        private System.Windows.Forms.ComboBox langComboBox;
    }
}