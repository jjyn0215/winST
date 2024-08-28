using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winST
{
    public partial class Form4 : MaterialForm
    {
        public Form4()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo600, Primary.Indigo800, Primary.Indigo200, Accent.Pink200, TextShade.WHITE);
            //this.FormBorderStyle = FormBorderStyle.None; // 테두리 없음
            this.StartPosition = FormStartPosition.Manual; // 위치를 수동으로 설정
            this.TopMost = true; // 다른 창 위에 표시
            this.Size = new Size(300, 75); // 알림창 크기
        }
        public void SetNotification(string message)
        {

            MaterialLabel lblMessage = new MaterialLabel
            {
                Text = message,
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                FontType = MaterialSkinManager.fontType.H5,
                AutoSize = true,
            };
            this.Controls.Add(lblMessage);
            this.Size = new Size(lblMessage.Width + 15, lblMessage.Height + 25);
        }

        public void ShowNotification(string message)
        {
            Form4 notificationForm = new Form4();
            notificationForm.SetNotification(message);
            
            // 현재 화면 해상도를 가져옴
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            // 알림창의 위치를 화면의 우측 하단으로 설정
            int x = workingArea.Width - notificationForm.Width; // 오른쪽 여백
            int y = workingArea.Height - notificationForm.Height; // 아래쪽 여백
            notificationForm.Location = new Point(x, y);

            // 알림창 표시
            notificationForm.Show();

            // 일정 시간 후 알림창을 닫는 타이머 설정
            Timer timer = new Timer();
            timer.Interval = 3000; // 3초 후 닫기
            timer.Tick += async (s, e) =>
            {
                notificationForm.Close();
                timer.Stop();
            };
            timer.Start();
        }
    }
}
