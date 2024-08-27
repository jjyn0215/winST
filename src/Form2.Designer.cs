namespace TeamProject01
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tb_id_form2 = new MaterialSkin.Controls.MaterialTextBox();
            this.sign_up_button_form2 = new MaterialSkin.Controls.MaterialButton();
            this.sign_up_cancel_button = new MaterialSkin.Controls.MaterialButton();
            this.tb_pw_form2 = new MaterialSkin.Controls.MaterialTextBox();
            this.tb_name_form2 = new MaterialSkin.Controls.MaterialTextBox2();
            this.SuspendLayout();
            // 
            // tb_id_form2
            // 
            this.tb_id_form2.AnimateReadOnly = false;
            this.tb_id_form2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_id_form2.Depth = 0;
            this.tb_id_form2.Font = new System.Drawing.Font("Noto Sans KR", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tb_id_form2.Hint = "아이디";
            this.tb_id_form2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tb_id_form2.LeadingIcon = null;
            this.tb_id_form2.Location = new System.Drawing.Point(253, 180);
            this.tb_id_form2.Margin = new System.Windows.Forms.Padding(4);
            this.tb_id_form2.MaxLength = 20;
            this.tb_id_form2.MouseState = MaterialSkin.MouseState.OUT;
            this.tb_id_form2.Multiline = false;
            this.tb_id_form2.Name = "tb_id_form2";
            this.tb_id_form2.Size = new System.Drawing.Size(745, 50);
            this.tb_id_form2.TabIndex = 0;
            this.tb_id_form2.Text = "";
            this.tb_id_form2.TrailingIcon = null;
            this.tb_id_form2.UseAccent = false;
            // 
            // sign_up_button_form2
            // 
            this.sign_up_button_form2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sign_up_button_form2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.sign_up_button_form2.Depth = 0;
            this.sign_up_button_form2.HighEmphasis = true;
            this.sign_up_button_form2.Icon = null;
            this.sign_up_button_form2.Location = new System.Drawing.Point(463, 565);
            this.sign_up_button_form2.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.sign_up_button_form2.MouseState = MaterialSkin.MouseState.HOVER;
            this.sign_up_button_form2.Name = "sign_up_button_form2";
            this.sign_up_button_form2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.sign_up_button_form2.Size = new System.Drawing.Size(64, 36);
            this.sign_up_button_form2.TabIndex = 7;
            this.sign_up_button_form2.Text = "가입!";
            this.sign_up_button_form2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.sign_up_button_form2.UseAccentColor = false;
            this.sign_up_button_form2.UseVisualStyleBackColor = true;
            this.sign_up_button_form2.Click += new System.EventHandler(this.sign_up_button_form2_Click);
            // 
            // sign_up_cancel_button
            // 
            this.sign_up_cancel_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sign_up_cancel_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.sign_up_cancel_button.Depth = 0;
            this.sign_up_cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sign_up_cancel_button.HighEmphasis = true;
            this.sign_up_cancel_button.Icon = null;
            this.sign_up_cancel_button.Location = new System.Drawing.Point(682, 565);
            this.sign_up_cancel_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sign_up_cancel_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.sign_up_cancel_button.Name = "sign_up_cancel_button";
            this.sign_up_cancel_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.sign_up_cancel_button.Size = new System.Drawing.Size(64, 36);
            this.sign_up_cancel_button.TabIndex = 8;
            this.sign_up_cancel_button.Text = "취소";
            this.sign_up_cancel_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.sign_up_cancel_button.UseAccentColor = false;
            this.sign_up_cancel_button.UseVisualStyleBackColor = true;
            this.sign_up_cancel_button.Click += new System.EventHandler(this.sign_up_cancel_button_Click);
            // 
            // tb_pw_form2
            // 
            this.tb_pw_form2.AnimateReadOnly = false;
            this.tb_pw_form2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_pw_form2.Depth = 0;
            this.tb_pw_form2.Font = new System.Drawing.Font("Noto Sans KR", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tb_pw_form2.Hint = "패스워드";
            this.tb_pw_form2.LeadingIcon = null;
            this.tb_pw_form2.Location = new System.Drawing.Point(253, 300);
            this.tb_pw_form2.Margin = new System.Windows.Forms.Padding(2);
            this.tb_pw_form2.MaxLength = 50;
            this.tb_pw_form2.MouseState = MaterialSkin.MouseState.OUT;
            this.tb_pw_form2.Multiline = false;
            this.tb_pw_form2.Name = "tb_pw_form2";
            this.tb_pw_form2.Size = new System.Drawing.Size(745, 50);
            this.tb_pw_form2.TabIndex = 3;
            this.tb_pw_form2.Text = "";
            this.tb_pw_form2.TrailingIcon = null;
            this.tb_pw_form2.UseAccent = false;
            // 
            // tb_name_form2
            // 
            this.tb_name_form2.AnimateReadOnly = false;
            this.tb_name_form2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tb_name_form2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tb_name_form2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tb_name_form2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tb_name_form2.Depth = 0;
            this.tb_name_form2.Font = new System.Drawing.Font("Noto Sans KR", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tb_name_form2.HideSelection = true;
            this.tb_name_form2.Hint = "이름";
            this.tb_name_form2.LeadingIcon = null;
            this.tb_name_form2.Location = new System.Drawing.Point(253, 420);
            this.tb_name_form2.MaxLength = 20;
            this.tb_name_form2.MouseState = MaterialSkin.MouseState.OUT;
            this.tb_name_form2.Name = "tb_name_form2";
            this.tb_name_form2.PasswordChar = '\0';
            this.tb_name_form2.PrefixSuffixText = null;
            this.tb_name_form2.ReadOnly = false;
            this.tb_name_form2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tb_name_form2.SelectedText = "";
            this.tb_name_form2.SelectionLength = 0;
            this.tb_name_form2.SelectionStart = 0;
            this.tb_name_form2.ShortcutsEnabled = true;
            this.tb_name_form2.Size = new System.Drawing.Size(745, 48);
            this.tb_name_form2.TabIndex = 4;
            this.tb_name_form2.TabStop = false;
            this.tb_name_form2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_name_form2.TrailingIcon = null;
            this.tb_name_form2.UseAccent = false;
            this.tb_name_form2.UseSystemPasswordChar = false;
            // 
            // Form2
            // 
            this.AcceptButton = this.sign_up_button_form2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.CancelButton = this.sign_up_cancel_button;
            this.ClientSize = new System.Drawing.Size(1352, 792);
            this.Controls.Add(this.tb_name_form2);
            this.Controls.Add(this.tb_pw_form2);
            this.Controls.Add(this.sign_up_cancel_button);
            this.Controls.Add(this.sign_up_button_form2);
            this.Controls.Add(this.tb_id_form2);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_48;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(3, 72, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign Up";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox tb_id_form2;
        private MaterialSkin.Controls.MaterialButton sign_up_button_form2;
        private MaterialSkin.Controls.MaterialButton sign_up_cancel_button;
        private MaterialSkin.Controls.MaterialTextBox tb_pw_form2;
        private MaterialSkin.Controls.MaterialTextBox2 tb_name_form2;
    }
}