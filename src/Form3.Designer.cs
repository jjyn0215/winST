using MaterialSkin.Controls;
using System.Reflection.Emit;

namespace winST
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.menuIconList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.favorite_flowlayoutpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.main_panel = new System.Windows.Forms.Panel();
            this.welcome_label = new MaterialSkin.Controls.MaterialLabel();
            this.favorite_label = new MaterialSkin.Controls.MaterialLabel();
            this.location_status_label_2 = new MaterialSkin.Controls.MaterialLabel();
            this.location_status_label_1 = new MaterialSkin.Controls.MaterialLabel();
            this.name_label = new MaterialSkin.Controls.MaterialLabel();
            this.location_status_picturebox = new System.Windows.Forms.PictureBox();
            this.main_tab_control = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.set_location_status_combobox = new MaterialSkin.Controls.MaterialComboBox();
            this.change_theme_button = new MaterialSkin.Controls.MaterialButton();
            this.delete_account_button = new MaterialSkin.Controls.MaterialButton();
            this.btn_changePW = new MaterialSkin.Controls.MaterialButton();
            this.change_pw_label = new MaterialSkin.Controls.MaterialLabel();
            this.tb_changePW = new MaterialSkin.Controls.MaterialTextBox();
            this.token_label = new MaterialSkin.Controls.MaterialLabel();
            this.token_textbox = new MaterialSkin.Controls.MaterialTextBox();
            this.settings_label = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage1.SuspendLayout();
            this.main_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.location_status_picturebox)).BeginInit();
            this.main_tab_control.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuIconList
            // 
            this.menuIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("menuIconList.ImageStream")));
            this.menuIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.menuIconList.Images.SetKeyName(0, "home_24dp_FILL0_wght400_GRAD0_opsz24.png");
            this.menuIconList.Images.SetKeyName(1, "home_iot_device_24dp_FILL0_wght400_GRAD0_opsz24.png");
            this.menuIconList.Images.SetKeyName(2, "logout_24dp_FILL0_wght400_GRAD0_opsz24.png");
            this.menuIconList.Images.SetKeyName(3, "settings_24dp_FILL0_wght400_GRAD0_opsz24.png");
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.favorite_flowlayoutpanel);
            this.tabPage1.Controls.Add(this.main_panel);
            this.tabPage1.ImageKey = "home_24dp_FILL0_wght400_GRAD0_opsz24.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1909, 964);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "메인";
            // 
            // favorite_flowlayoutpanel
            // 
            this.favorite_flowlayoutpanel.AutoScroll = true;
            this.favorite_flowlayoutpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.favorite_flowlayoutpanel.Location = new System.Drawing.Point(3, 563);
            this.favorite_flowlayoutpanel.Name = "favorite_flowlayoutpanel";
            this.favorite_flowlayoutpanel.Size = new System.Drawing.Size(1903, 398);
            this.favorite_flowlayoutpanel.TabIndex = 1;
            // 
            // main_panel
            // 
            this.main_panel.Controls.Add(this.welcome_label);
            this.main_panel.Controls.Add(this.favorite_label);
            this.main_panel.Controls.Add(this.location_status_label_2);
            this.main_panel.Controls.Add(this.location_status_label_1);
            this.main_panel.Controls.Add(this.name_label);
            this.main_panel.Controls.Add(this.location_status_picturebox);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.main_panel.Location = new System.Drawing.Point(3, 3);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1903, 560);
            this.main_panel.TabIndex = 0;
            // 
            // welcome_label
            // 
            this.welcome_label.AutoSize = true;
            this.welcome_label.Depth = 0;
            this.welcome_label.Font = new System.Drawing.Font("Noto Sans KR Light", 96F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.welcome_label.FontType = MaterialSkin.MaterialSkinManager.fontType.H1;
            this.welcome_label.Location = new System.Drawing.Point(130, 227);
            this.welcome_label.MouseState = MaterialSkin.MouseState.HOVER;
            this.welcome_label.Name = "welcome_label";
            this.welcome_label.Size = new System.Drawing.Size(469, 139);
            this.welcome_label.TabIndex = 15;
            this.welcome_label.Text = "환영합니다!";
            // 
            // favorite_label
            // 
            this.favorite_label.AutoSize = true;
            this.favorite_label.Depth = 0;
            this.favorite_label.Font = new System.Drawing.Font("Noto Sans KR", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.favorite_label.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.favorite_label.Location = new System.Drawing.Point(20, 478);
            this.favorite_label.MouseState = MaterialSkin.MouseState.HOVER;
            this.favorite_label.Name = "favorite_label";
            this.favorite_label.Size = new System.Drawing.Size(125, 49);
            this.favorite_label.TabIndex = 14;
            this.favorite_label.Text = "즐겨찾기";
            // 
            // location_status_label_2
            // 
            this.location_status_label_2.AutoSize = true;
            this.location_status_label_2.Depth = 0;
            this.location_status_label_2.Font = new System.Drawing.Font("Noto Sans KR", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.location_status_label_2.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.location_status_label_2.Location = new System.Drawing.Point(1630, 405);
            this.location_status_label_2.MouseState = MaterialSkin.MouseState.HOVER;
            this.location_status_label_2.Name = "location_status_label_2";
            this.location_status_label_2.Size = new System.Drawing.Size(89, 70);
            this.location_status_label_2.TabIndex = 7;
            this.location_status_label_2.Text = "상태";
            this.location_status_label_2.UseAccent = true;
            // 
            // location_status_label_1
            // 
            this.location_status_label_1.AutoSize = true;
            this.location_status_label_1.Depth = 0;
            this.location_status_label_1.Font = new System.Drawing.Font("Noto Sans KR", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.location_status_label_1.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.location_status_label_1.Location = new System.Drawing.Point(1369, 425);
            this.location_status_label_1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.location_status_label_1.MouseState = MaterialSkin.MouseState.HOVER;
            this.location_status_label_1.Name = "location_status_label_1";
            this.location_status_label_1.Size = new System.Drawing.Size(162, 49);
            this.location_status_label_1.TabIndex = 8;
            this.location_status_label_1.Text = "장소 상태 : ";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Depth = 0;
            this.name_label.Font = new System.Drawing.Font("Noto Sans KR Light", 96F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.name_label.FontType = MaterialSkin.MaterialSkinManager.fontType.H1;
            this.name_label.Location = new System.Drawing.Point(130, 29);
            this.name_label.MouseState = MaterialSkin.MouseState.HOVER;
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(44, 139);
            this.name_label.TabIndex = 12;
            this.name_label.Text = "?";
            // 
            // location_status_picturebox
            // 
            this.location_status_picturebox.Location = new System.Drawing.Point(1366, 29);
            this.location_status_picturebox.Margin = new System.Windows.Forms.Padding(2);
            this.location_status_picturebox.Name = "location_status_picturebox";
            this.location_status_picturebox.Size = new System.Drawing.Size(384, 384);
            this.location_status_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.location_status_picturebox.TabIndex = 13;
            this.location_status_picturebox.TabStop = false;
            // 
            // main_tab_control
            // 
            this.main_tab_control.Controls.Add(this.tabPage1);
            this.main_tab_control.Controls.Add(this.tabPage2);
            this.main_tab_control.Controls.Add(this.tabPage3);
            this.main_tab_control.Controls.Add(this.tabPage4);
            this.main_tab_control.Depth = 0;
            this.main_tab_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tab_control.ImageList = this.menuIconList;
            this.main_tab_control.Location = new System.Drawing.Point(0, 72);
            this.main_tab_control.MouseState = MaterialSkin.MouseState.HOVER;
            this.main_tab_control.Multiline = true;
            this.main_tab_control.Name = "main_tab_control";
            this.main_tab_control.SelectedIndex = 0;
            this.main_tab_control.Size = new System.Drawing.Size(1917, 1005);
            this.main_tab_control.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.ImageKey = "home_iot_device_24dp_FILL0_wght400_GRAD0_opsz24.png";
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1909, 964);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "기기";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.set_location_status_combobox);
            this.tabPage3.Controls.Add(this.change_theme_button);
            this.tabPage3.Controls.Add(this.delete_account_button);
            this.tabPage3.Controls.Add(this.btn_changePW);
            this.tabPage3.Controls.Add(this.change_pw_label);
            this.tabPage3.Controls.Add(this.tb_changePW);
            this.tabPage3.Controls.Add(this.token_label);
            this.tabPage3.Controls.Add(this.token_textbox);
            this.tabPage3.Controls.Add(this.settings_label);
            this.tabPage3.ImageKey = "settings_24dp_FILL0_wght400_GRAD0_opsz24.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 37);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1909, 964);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "설정";
            // 
            // set_location_status_combobox
            // 
            this.set_location_status_combobox.AutoResize = true;
            this.set_location_status_combobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.set_location_status_combobox.Depth = 0;
            this.set_location_status_combobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.set_location_status_combobox.DropDownHeight = 174;
            this.set_location_status_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.set_location_status_combobox.DropDownWidth = 121;
            this.set_location_status_combobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.set_location_status_combobox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.set_location_status_combobox.FormattingEnabled = true;
            this.set_location_status_combobox.Hint = "주 장소";
            this.set_location_status_combobox.IntegralHeight = false;
            this.set_location_status_combobox.ItemHeight = 43;
            this.set_location_status_combobox.Location = new System.Drawing.Point(919, 118);
            this.set_location_status_combobox.MaxDropDownItems = 4;
            this.set_location_status_combobox.MouseState = MaterialSkin.MouseState.OUT;
            this.set_location_status_combobox.Name = "set_location_status_combobox";
            this.set_location_status_combobox.Size = new System.Drawing.Size(121, 49);
            this.set_location_status_combobox.StartIndex = 0;
            this.set_location_status_combobox.TabIndex = 10;
            this.set_location_status_combobox.SelectedIndexChanged += new System.EventHandler(this.set_location_status_combobox_SelectedIndexChanged);
            // 
            // change_theme_button
            // 
            this.change_theme_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.change_theme_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.change_theme_button.Depth = 0;
            this.change_theme_button.HighEmphasis = false;
            this.change_theme_button.Icon = global::winST.Properties.Resources.contrast_24dp_FILL0_wght400_GRAD0_opsz24;
            this.change_theme_button.Location = new System.Drawing.Point(1213, 134);
            this.change_theme_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.change_theme_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.change_theme_button.Name = "change_theme_button";
            this.change_theme_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.change_theme_button.Size = new System.Drawing.Size(76, 36);
            this.change_theme_button.TabIndex = 2;
            this.change_theme_button.Text = "테마";
            this.change_theme_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.change_theme_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.change_theme_button.UseAccentColor = false;
            this.change_theme_button.UseVisualStyleBackColor = true;
            this.change_theme_button.Click += new System.EventHandler(this.change_theme_button_Clicked);
            // 
            // delete_account_button
            // 
            this.delete_account_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delete_account_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.delete_account_button.Depth = 0;
            this.delete_account_button.HighEmphasis = true;
            this.delete_account_button.Icon = null;
            this.delete_account_button.Location = new System.Drawing.Point(1212, 907);
            this.delete_account_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.delete_account_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.delete_account_button.Name = "delete_account_button";
            this.delete_account_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.delete_account_button.Size = new System.Drawing.Size(79, 36);
            this.delete_account_button.TabIndex = 9;
            this.delete_account_button.Text = "계정 삭제";
            this.delete_account_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.delete_account_button.UseAccentColor = true;
            this.delete_account_button.UseVisualStyleBackColor = true;
            this.delete_account_button.Click += new System.EventHandler(this.delete_account_button_Clicked);
            // 
            // btn_changePW
            // 
            this.btn_changePW.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_changePW.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn_changePW.Depth = 0;
            this.btn_changePW.HighEmphasis = true;
            this.btn_changePW.Icon = null;
            this.btn_changePW.Location = new System.Drawing.Point(1235, 630);
            this.btn_changePW.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_changePW.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_changePW.Name = "btn_changePW";
            this.btn_changePW.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn_changePW.Size = new System.Drawing.Size(64, 36);
            this.btn_changePW.TabIndex = 6;
            this.btn_changePW.Text = "변경!";
            this.btn_changePW.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_changePW.UseAccentColor = false;
            this.btn_changePW.UseVisualStyleBackColor = true;
            this.btn_changePW.Click += new System.EventHandler(this.btn_changePW_Click);
            // 
            // change_pw_label
            // 
            this.change_pw_label.AutoSize = true;
            this.change_pw_label.Depth = 0;
            this.change_pw_label.Font = new System.Drawing.Font("Noto Sans KR", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.change_pw_label.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.change_pw_label.Location = new System.Drawing.Point(97, 444);
            this.change_pw_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.change_pw_label.MouseState = MaterialSkin.MouseState.HOVER;
            this.change_pw_label.Name = "change_pw_label";
            this.change_pw_label.Size = new System.Drawing.Size(140, 35);
            this.change_pw_label.TabIndex = 5;
            this.change_pw_label.Text = "비밀번호 변경";
            // 
            // tb_changePW
            // 
            this.tb_changePW.AnimateReadOnly = false;
            this.tb_changePW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_changePW.Depth = 0;
            this.tb_changePW.Font = new System.Drawing.Font("Noto Sans KR", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tb_changePW.Hint = "변경할 비밀번호";
            this.tb_changePW.LeadingIcon = null;
            this.tb_changePW.Location = new System.Drawing.Point(97, 528);
            this.tb_changePW.MaxLength = 50;
            this.tb_changePW.MouseState = MaterialSkin.MouseState.OUT;
            this.tb_changePW.Multiline = false;
            this.tb_changePW.Name = "tb_changePW";
            this.tb_changePW.Size = new System.Drawing.Size(1233, 50);
            this.tb_changePW.TabIndex = 4;
            this.tb_changePW.Text = "";
            this.tb_changePW.TrailingIcon = null;
            this.tb_changePW.UseAccent = false;
            // 
            // token_label
            // 
            this.token_label.AutoSize = true;
            this.token_label.Depth = 0;
            this.token_label.Font = new System.Drawing.Font("Noto Sans KR", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.token_label.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.token_label.Location = new System.Drawing.Point(97, 244);
            this.token_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.token_label.MouseState = MaterialSkin.MouseState.HOVER;
            this.token_label.Name = "token_label";
            this.token_label.Size = new System.Drawing.Size(204, 35);
            this.token_label.TabIndex = 2;
            this.token_label.Text = "스마트싱스 API 토큰";
            // 
            // token_textbox
            // 
            this.token_textbox.AnimateReadOnly = false;
            this.token_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.token_textbox.Depth = 0;
            this.token_textbox.Font = new System.Drawing.Font("Noto Sans KR", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.token_textbox.LeadingIcon = null;
            this.token_textbox.Location = new System.Drawing.Point(97, 326);
            this.token_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.token_textbox.MaxLength = 36;
            this.token_textbox.MouseState = MaterialSkin.MouseState.OUT;
            this.token_textbox.Multiline = false;
            this.token_textbox.Name = "token_textbox";
            this.token_textbox.Size = new System.Drawing.Size(1233, 50);
            this.token_textbox.TabIndex = 1;
            this.token_textbox.Text = "";
            this.token_textbox.TrailingIcon = null;
            this.token_textbox.UseAccent = false;
            this.token_textbox.TextChanged += new System.EventHandler(this.token_textbox_TextChanged);
            // 
            // settings_label
            // 
            this.settings_label.AutoSize = true;
            this.settings_label.Depth = 0;
            this.settings_label.Font = new System.Drawing.Font("Noto Sans KR Light", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.settings_label.FontType = MaterialSkin.MaterialSkinManager.fontType.H2;
            this.settings_label.Location = new System.Drawing.Point(90, 68);
            this.settings_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.settings_label.MouseState = MaterialSkin.MouseState.HOVER;
            this.settings_label.Name = "settings_label";
            this.settings_label.Size = new System.Drawing.Size(111, 87);
            this.settings_label.TabIndex = 0;
            this.settings_label.Text = "설정";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.ImageKey = "logout_24dp_FILL0_wght400_GRAD0_opsz24.png";
            this.tabPage4.Location = new System.Drawing.Point(4, 37);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1909, 964);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "로그아웃";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.main_tab_control);
            this.DrawerIndicatorWidth = 2;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.main_tab_control;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_48;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form3";
            this.Padding = new System.Windows.Forms.Padding(0, 72, 3, 3);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "메인";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tabPage1.ResumeLayout(false);
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.location_status_picturebox)).EndInit();
            this.main_tab_control.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.ImageList menuIconList;
        private System.Windows.Forms.TabPage tabPage1;
        private MaterialTabControl main_tab_control;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private MaterialLabel settings_label;
        private MaterialTextBox token_textbox;
        private MaterialLabel token_label;
        private MaterialLabel change_pw_label;
        private MaterialTextBox tb_changePW;
        private MaterialButton btn_changePW;
        private MaterialButton delete_account_button;
        private MaterialButton change_theme_button;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel favorite_flowlayoutpanel;
        private System.Windows.Forms.Panel main_panel;
        private MaterialLabel name_label;
        private MaterialLabel location_status_label_1;
        private MaterialLabel location_status_label_2;
        private System.Windows.Forms.PictureBox location_status_picturebox;
        private MaterialLabel favorite_label;
        private MaterialLabel welcome_label;
        private MaterialComboBox set_location_status_combobox;
    }
}