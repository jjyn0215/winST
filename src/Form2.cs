using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace winST
{
    public partial class Form2 : MaterialForm
    {
        public Form2()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo600, Primary.Indigo800, Primary.Indigo200, Accent.Pink200, TextShade.WHITE);
            this.Resize += Form2_Resize;
        }

        private MaterialSnackBar snackBar;

        /*
         * Show_Snackbar
         * MaterialSkin의 컨트롤인 Snackbar를 표시하기 위한 함수
         * 함수를 따로 만든 이유는 Snackbar도 하나의 컨트롤이고 연속으로 표시할 때
         * 메세지가 겹치거나 null 에러가 나서 조건을 추가했습니다.
         */
        private void Show_SnackBar(string text, int duration)
        {
            if (snackBar != null)
            {
                snackBar.Close();
            }
            snackBar = new MaterialSnackBar
            {
                ShowActionButton = true,
                ActionButtonText = "OK",
                UseAccentColor = true,
                Text = text,
                Duration = duration,
            };
            snackBar.Show(this);
        }

        /*
         * Form2_Resize
         * Form2의 창 크기가 변할 때 핸들러가 실행하는 함수
         * Form2의 컨트롤을 가운데에 정렬하고 싶은데 해상도가 바뀔 때마다 제각각이라 CenterControl과 추가한 함수
         */
        private void Form2_Resize(object sender, EventArgs e)
        {
            Center_Control(tb_id_form2, 150, 0);
            Center_Control(tb_pw_form2, 0, 0);
            Center_Control(tb_name_form2, -150, 0);
            Center_Control(sign_up_button_form2, -300, -100);
            Center_Control(sign_up_cancel_button, -300, 100);
        }

        /*
         * Center_Control
         * 원하는 컨트롤을 창 가운데에 정렬할 수 있도록 하는 함수
         * 추가값을 넣어서 원하는 위치에 고정할 수 있음
         */
        private void Center_Control(Control control, int customHeight, int customWidth)
        {
            control.Location = new Point((this.ClientSize.Width - control.Width + customWidth) / 2,
                                          (this.ClientSize.Height - control.Height - customHeight) / 2);
        }

        /*
         * Form2_Load
         * 컨트롤 정렬 이외에 특별한 기능은 없습니다.
         */
        private void Form2_Load(object sender, EventArgs e)
        {
            Form2_Resize(sender, e);
        }

        /*
         * sign_up_button_form2_Click
         * 가입 버튼을 누르면 입력된 id, pw, name을 받아서 계정을 추가합니다.
         */
        private void sign_up_button_form2_Click(object sender, EventArgs e)
        {
            string id = tb_id_form2.Text;
            string pw = tb_pw_form2.Text;
            string name = tb_name_form2.Text;
            
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(pw))
            {
                Show_SnackBar("아이디와 비밀번호를 모두 입력하세요.", 5000);
                return;
            }
            else if (Data.Check_User_Id(id))
            {
                Show_SnackBar("이미 존재하는 아이디입니다.", 5000);
                return;
            }
            if (name == "")
            {
                name = "?";
            }
            Data.Add_New_Users(id, pw, name);
            new Form1("회원가입 성공.").Show();
            this.Hide();
        }
    
        /*
         * sign_up_cancel_button_Click
         * 취소 버튼을 누르면 form1으로 이동합니다.
         */
        private void sign_up_cancel_button_Click(object sender, EventArgs e)
        {
            if (snackBar != null)
            {
                snackBar.Close();
            }
            new Form1(null).Show();
            this.Hide();
        }
    }
}
