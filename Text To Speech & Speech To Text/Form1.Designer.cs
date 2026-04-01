namespace Text_To_Speech___Speech_To_Text
{
    partial class Form1
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
            mainText = new RichTextBox();
            read_btn = new Button();
            talk_btn = new Button();
            SuspendLayout();
            // 
            // mainText
            // 
            mainText.BackColor = SystemColors.MenuText;
            mainText.Font = new Font("Snap ITC", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mainText.ForeColor = SystemColors.InactiveBorder;
            mainText.Location = new Point(12, 21);
            mainText.Name = "mainText";
            mainText.Size = new Size(776, 288);
            mainText.TabIndex = 0;
            mainText.Text = "";
            // 
            // read_btn
            // 
            read_btn.BackColor = SystemColors.HighlightText;
            read_btn.FlatStyle = FlatStyle.Flat;
            read_btn.ForeColor = SystemColors.ActiveCaptionText;
            read_btn.Location = new Point(194, 347);
            read_btn.Name = "read_btn";
            read_btn.Size = new Size(94, 29);
            read_btn.TabIndex = 1;
            read_btn.Text = "Read";
            read_btn.UseVisualStyleBackColor = false;
            read_btn.Click += read_btn_Click;
            // 
            // talk_btn
            // 
            talk_btn.FlatStyle = FlatStyle.Flat;
            talk_btn.Location = new Point(486, 347);
            talk_btn.Name = "talk_btn";
            talk_btn.Size = new Size(94, 29);
            talk_btn.TabIndex = 2;
            talk_btn.Text = "Talk";
            talk_btn.UseVisualStyleBackColor = true;
            talk_btn.Click += talk_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 450);
            Controls.Add(talk_btn);
            Controls.Add(read_btn);
            Controls.Add(mainText);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox mainText;
        private Button read_btn;
        private Button talk_btn;
    }
}
