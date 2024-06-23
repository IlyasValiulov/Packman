namespace Packman
{
    partial class MainGameForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameForm));
            pictureBox = new PictureBox();
            labelScore = new Label();
            labelScoreResult = new Label();
            labelWin = new Label();
            labelLose = new Label();
            pictureBoxHeart1 = new PictureBox();
            pictureBoxHeart2 = new PictureBox();
            pictureBoxHeart3 = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeart3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(-1, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(595, 550);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // labelScore
            // 
            labelScore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelScore.AutoSize = true;
            labelScore.Font = new Font("Copperplate Gothic Bold", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelScore.ForeColor = Color.IndianRed;
            labelScore.Location = new Point(705, 24);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(146, 41);
            labelScore.TabIndex = 1;
            labelScore.Text = "Score";
            labelScore.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelScoreResult
            // 
            labelScoreResult.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelScoreResult.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            labelScoreResult.ForeColor = SystemColors.ButtonHighlight;
            labelScoreResult.Location = new Point(705, 65);
            labelScoreResult.Name = "labelScoreResult";
            labelScoreResult.Size = new Size(146, 45);
            labelScoreResult.TabIndex = 2;
            labelScoreResult.Text = "0";
            labelScoreResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelWin
            // 
            labelWin.AutoSize = true;
            labelWin.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            labelWin.ForeColor = Color.IndianRed;
            labelWin.Location = new Point(226, 209);
            labelWin.Name = "labelWin";
            labelWin.Size = new Size(162, 86);
            labelWin.TabIndex = 3;
            labelWin.Text = "WIN";
            labelWin.Visible = false;
            // 
            // labelLose
            // 
            labelLose.AutoSize = true;
            labelLose.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            labelLose.ForeColor = Color.IndianRed;
            labelLose.Location = new Point(209, 209);
            labelLose.Name = "labelLose";
            labelLose.Size = new Size(179, 86);
            labelLose.TabIndex = 4;
            labelLose.Text = "LOSE";
            labelLose.Visible = false;
            // 
            // pictureBoxHeart1
            // 
            pictureBoxHeart1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBoxHeart1.Image = (Image)resources.GetObject("pictureBoxHeart1.Image");
            pictureBoxHeart1.Location = new Point(638, 470);
            pictureBoxHeart1.Name = "pictureBoxHeart1";
            pictureBoxHeart1.Size = new Size(65, 53);
            pictureBoxHeart1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHeart1.TabIndex = 5;
            pictureBoxHeart1.TabStop = false;
            // 
            // pictureBoxHeart2
            // 
            pictureBoxHeart2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBoxHeart2.Image = (Image)resources.GetObject("pictureBoxHeart2.Image");
            pictureBoxHeart2.Location = new Point(751, 470);
            pictureBoxHeart2.Name = "pictureBoxHeart2";
            pictureBoxHeart2.Size = new Size(65, 53);
            pictureBoxHeart2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHeart2.TabIndex = 6;
            pictureBoxHeart2.TabStop = false;
            // 
            // pictureBoxHeart3
            // 
            pictureBoxHeart3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBoxHeart3.Image = (Image)resources.GetObject("pictureBoxHeart3.Image");
            pictureBoxHeart3.Location = new Point(858, 470);
            pictureBoxHeart3.Name = "pictureBoxHeart3";
            pictureBoxHeart3.Size = new Size(65, 53);
            pictureBoxHeart3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHeart3.TabIndex = 7;
            pictureBoxHeart3.TabStop = false;
            // 
            // MainGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(968, 551);
            Controls.Add(pictureBoxHeart3);
            Controls.Add(pictureBoxHeart2);
            Controls.Add(pictureBoxHeart1);
            Controls.Add(labelLose);
            Controls.Add(labelWin);
            Controls.Add(labelScoreResult);
            Controls.Add(labelScore);
            Controls.Add(pictureBox);
            Name = "MainGameForm";
            Text = "Packman";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeart3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Label labelScore;
        private Label labelScoreResult;
        private Label labelWin;
        private Label labelLose;
        private PictureBox pictureBoxHeart1;
        private PictureBox pictureBoxHeart2;
        private PictureBox pictureBoxHeart3;
        private System.Windows.Forms.Timer timer;
    }
}
