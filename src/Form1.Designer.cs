namespace winST
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.auto_login_checkbox = new MaterialSkin.Controls.MaterialCheckbox();
            this.sign_up_button_form1 = new MaterialSkin.Controls.MaterialButton();
            this.login_button = new MaterialSkin.Controls.MaterialButton();
            this.tb_id_form1 = new MaterialSkin.Controls.MaterialTextBox();
            this.tb_pw_form1 = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // auto_login_checkbox
            // 
            this.auto_login_checkbox.AutoSize = true;
            this.auto_login_checkbox.Depth = 0;
            this.auto_login_checkbox.Location = new System.Drawing.Point(305, 434);
            this.auto_login_checkbox.Margin = new System.Windows.Forms.Padding(0);
            this.auto_login_checkbox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.auto_login_checkbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.auto_login_checkbox.Name = "auto_login_checkbox";
            this.auto_login_checkbox.ReadOnly = false;
            this.auto_login_checkbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.auto_login_checkbox.Ripple = true;
            this.auto_login_checkbox.Size = new System.Drawing.Size(114, 37);
            this.auto_login_checkbox.TabIndex = 19;
            this.auto_login_checkbox.Text = "자동 로그인";
            this.auto_login_checkbox.UseVisualStyleBackColor = true;
            // 
            // sign_up_button_form1
            // 
            this.sign_up_button_form1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sign_up_button_form1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.sign_up_button_form1.Depth = 0;
            this.sign_up_button_form1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sign_up_button_form1.HighEmphasis = true;
            this.sign_up_button_form1.Icon = null;
            this.sign_up_button_form1.Location = new System.Drawing.Point(783, 492);
            this.sign_up_button_form1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sign_up_button_form1.MouseState = MaterialSkin.MouseState.HOVER;
            this.sign_up_button_form1.Name = "sign_up_button_form1";
            this.sign_up_button_form1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.sign_up_button_form1.Size = new System.Drawing.Size(75, 36);
            this.sign_up_button_form1.TabIndex = 23;
            this.sign_up_button_form1.Text = "회원가입";
            this.sign_up_button_form1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.sign_up_button_form1.UseAccentColor = false;
            this.sign_up_button_form1.UseVisualStyleBackColor = true;
            this.sign_up_button_form1.Click += new System.EventHandler(this.sign_up_button_form1_Click);
            // 
            // login_button
            // 
            this.login_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.login_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.login_button.Depth = 0;
            this.login_button.HighEmphasis = true;
            this.login_button.Icon = null;
            this.login_button.Location = new System.Drawing.Point(926, 492);
            this.login_button.Margin = new System.Windows.Forms.Padding(9, 14, 9, 14);
            this.login_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.login_button.Name = "login_button";
            this.login_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.login_button.Size = new System.Drawing.Size(66, 36);
            this.login_button.TabIndex = 22;
            this.login_button.Text = "로그인!";
            this.login_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.login_button.UseAccentColor = false;
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // tb_id_form1
            // 
            this.tb_id_form1.AnimateReadOnly = false;
            this.tb_id_form1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_id_form1.Depth = 0;
            this.tb_id_form1.Font = new System.Drawing.Font("Noto Sans KR", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tb_id_form1.Hint = "아이디";
            this.tb_id_form1.LeadingIcon = null;
            this.tb_id_form1.Location = new System.Drawing.Point(305, 224);
            this.tb_id_form1.Margin = new System.Windows.Forms.Padding(2);
            this.tb_id_form1.MaxLength = 20;
            this.tb_id_form1.MouseState = MaterialSkin.MouseState.OUT;
            this.tb_id_form1.Multiline = false;
            this.tb_id_form1.Name = "tb_id_form1";
            this.tb_id_form1.Size = new System.Drawing.Size(669, 50);
            this.tb_id_form1.TabIndex = 17;
            this.tb_id_form1.Text = "";
            this.tb_id_form1.TrailingIcon = null;
            this.tb_id_form1.UseAccent = false;
            // 
            // tb_pw_form1
            // 
            this.tb_pw_form1.AnimateReadOnly = false;
            this.tb_pw_form1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_pw_form1.Depth = 0;
            this.tb_pw_form1.Font = new System.Drawing.Font("Noto Sans KR", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tb_pw_form1.Hint = "패스워드";
            this.tb_pw_form1.LeadingIcon = null;
            this.tb_pw_form1.Location = new System.Drawing.Point(305, 329);
            this.tb_pw_form1.Margin = new System.Windows.Forms.Padding(2);
            this.tb_pw_form1.MaxLength = 50;
            this.tb_pw_form1.MouseState = MaterialSkin.MouseState.OUT;
            this.tb_pw_form1.Multiline = false;
            this.tb_pw_form1.Name = "tb_pw_form1";
            this.tb_pw_form1.Password = true;
            this.tb_pw_form1.Size = new System.Drawing.Size(669, 50);
            this.tb_pw_form1.TabIndex = 18;
            this.tb_pw_form1.Text = "";
            this.tb_pw_form1.TrailingIcon = null;
            this.tb_pw_form1.UseAccent = false;
            // 
            // Form1
            // 
            this.AcceptButton = this.login_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.sign_up_button_form1;
            this.ClientSize = new System.Drawing.Size(1352, 852);
            this.Controls.Add(this.tb_pw_form1);
            this.Controls.Add(this.tb_id_form1);
            this.Controls.Add(this.auto_login_checkbox);
            this.Controls.Add(this.sign_up_button_form1);
            this.Controls.Add(this.login_button);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_48;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(6, 162, 6, 6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialCheckbox auto_login_checkbox;
        private MaterialSkin.Controls.MaterialButton sign_up_button_form1;
        private MaterialSkin.Controls.MaterialButton login_button;
        private MaterialSkin.Controls.MaterialTextBox tb_id_form1;
        private MaterialSkin.Controls.MaterialTextBox tb_pw_form1;
    }
}

