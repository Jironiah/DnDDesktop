namespace DnDDesktop.Views.ViewsPopup
{
    partial class AbilityScore_Skills
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
            rtbDescriptionSkillsUpdate = new RichTextBox();
            label130 = new Label();
            cbAbilityScoreSkillsUpdate = new ComboBox();
            label127 = new Label();
            label128 = new Label();
            label129 = new Label();
            tbIndexSkillsUpdate = new TextBox();
            tbNameSkillsUpdate = new TextBox();
            SuspendLayout();
            // 
            // rtbDescriptionSkillsUpdate
            // 
            rtbDescriptionSkillsUpdate.Location = new Point(367, 34);
            rtbDescriptionSkillsUpdate.Margin = new Padding(3, 4, 3, 4);
            rtbDescriptionSkillsUpdate.Name = "rtbDescriptionSkillsUpdate";
            rtbDescriptionSkillsUpdate.Size = new Size(493, 127);
            rtbDescriptionSkillsUpdate.TabIndex = 65;
            rtbDescriptionSkillsUpdate.Text = "";
            // 
            // label130
            // 
            label130.AutoSize = true;
            label130.Location = new Point(10, 74);
            label130.Name = "label130";
            label130.Size = new Size(89, 20);
            label130.TabIndex = 64;
            label130.Text = "AbilityScore";
            // 
            // cbAbilityScoreSkillsUpdate
            // 
            cbAbilityScoreSkillsUpdate.FormattingEnabled = true;
            cbAbilityScoreSkillsUpdate.Location = new Point(13, 96);
            cbAbilityScoreSkillsUpdate.Margin = new Padding(3, 4, 3, 4);
            cbAbilityScoreSkillsUpdate.Name = "cbAbilityScoreSkillsUpdate";
            cbAbilityScoreSkillsUpdate.Size = new Size(121, 28);
            cbAbilityScoreSkillsUpdate.TabIndex = 63;
            // 
            // label127
            // 
            label127.AutoSize = true;
            label127.Location = new Point(10, 10);
            label127.Name = "label127";
            label127.Size = new Size(45, 20);
            label127.TabIndex = 62;
            label127.Text = "Index";
            // 
            // label128
            // 
            label128.AutoSize = true;
            label128.Location = new Point(77, 10);
            label128.Name = "label128";
            label128.Size = new Size(49, 20);
            label128.TabIndex = 61;
            label128.Text = "Name";
            // 
            // label129
            // 
            label129.AutoSize = true;
            label129.Location = new Point(367, 10);
            label129.Name = "label129";
            label129.Size = new Size(85, 20);
            label129.TabIndex = 60;
            label129.Text = "Description";
            // 
            // tbIndexSkillsUpdate
            // 
            tbIndexSkillsUpdate.Location = new Point(13, 32);
            tbIndexSkillsUpdate.Margin = new Padding(3, 4, 3, 4);
            tbIndexSkillsUpdate.Name = "tbIndexSkillsUpdate";
            tbIndexSkillsUpdate.Size = new Size(41, 27);
            tbIndexSkillsUpdate.TabIndex = 59;
            // 
            // tbNameSkillsUpdate
            // 
            tbNameSkillsUpdate.Location = new Point(79, 32);
            tbNameSkillsUpdate.Margin = new Padding(3, 4, 3, 4);
            tbNameSkillsUpdate.Name = "tbNameSkillsUpdate";
            tbNameSkillsUpdate.Size = new Size(252, 27);
            tbNameSkillsUpdate.TabIndex = 58;
            // 
            // AbilityScore_Skills
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 315);
            Controls.Add(rtbDescriptionSkillsUpdate);
            Controls.Add(label130);
            Controls.Add(cbAbilityScoreSkillsUpdate);
            Controls.Add(label127);
            Controls.Add(label128);
            Controls.Add(label129);
            Controls.Add(tbIndexSkillsUpdate);
            Controls.Add(tbNameSkillsUpdate);
            Name = "AbilityScore_Skills";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public RichTextBox rtbDescriptionSkillsUpdate;
        public Label label127;
        public Label label128;
        public Label label129;
        public TextBox tbIndexSkillsUpdate;
        public TextBox tbNameSkillsUpdate;
        public Label label130;
        public ComboBox cbAbilityScoreSkillsUpdate;
    }
}