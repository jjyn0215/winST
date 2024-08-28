using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;


namespace winST
{
    public partial class Form1 : MaterialForm
    {

        private string snackMessage;

        public Form1(string message)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo600, Primary.Indigo800, Primary.Indigo200, Accent.Pink200, TextShade.WHITE);
            this.Resize += Form1_Resize;
            snackMessage = message;
        }

        private MaterialSnackBar snackBar; 

        /*
         * Show_Snackbar
         * MaterialSkin의 컨트롤인 Snackbar를 표시하기 위한 함수
         * 함수를 따로 만든 이유는 Snackbar도 하나의 컨트롤이고 연속으로 표시할 때
         * 메세지가 겹치거나 null 에러가 나서 조건을 추가했습니다.
         */
        private void Show_Snackbar(string text, int duration)
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
         * Form1_Resize
         * Form1의 창 크기가 변할 때 핸들러가 실행하는 함수
         * Form1의 컨트롤을 가운데에 정렬하고 싶은데 해상도가 바뀔 때마다 제각각이라 CenterControl과 추가한 함수
         */
        private void Form1_Resize(object sender, EventArgs e)
        {
            Center_Control(tb_id_form1, 100, 0);
            Center_Control(tb_pw_form1, -50, 0);
            Center_Control(auto_login_checkbox, -175, -345);
            Center_Control(sign_up_button_form1, -200, 200);
            Center_Control(login_button, -200, 380);
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
         * Form1_Load
         * 특별한 기능은 없고 다른 form에서 추가한 메세지가 있으면 출력함
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            Form1_Resize(sender, e);
            if (snackMessage != null)
            {
                Show_Snackbar(snackMessage, 5000);
            }
        }

        /*
         * sign_up_button_Click
         * 회원가입 버튼을 클릭하면 form2로 이동
         */
        private void sign_up_button_form1_Click(object sender, EventArgs e)
        {
            if (snackBar != null)
            {
                snackBar.Close();
            }
            new Form2().Show();
            this.Hide();
        }

        /*
         * login_button_Click
         * 로그인 버튼을 클릭하면 id입력란과 pw입력란에서 텍스트를 받아서
         * Data 클래스의 Verify_User_Login 함수로 정보가 일치하면 form3로 이동합니다.
         */
        private void login_button_Click(object sender, EventArgs e)
        {
            // 입력된 아이디와 비밀번호 받아오기
            string inputId = tb_id_form1.Text;
            string inputPw = tb_pw_form1.Text;

            if (Data.Verify_User_Login(inputId, inputPw))
            {
                if (snackBar != null)
                {
                    snackBar.Close();
                }
                new Form3().Show();
                this.Hide();
            }
            else
            {
                Show_Snackbar("아이디 또는 비밀번호가 잘못되었습니다.", 5000);
            }
        }
    }
}
