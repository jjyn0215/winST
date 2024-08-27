using System;
using System.Net.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json.Linq;

/*
 * 구현 필요 기능
 * 2. 센서 데이터 카드에 표시 .. 복잡함 ...
 * 10. 자동로그인 ....
 */

namespace TeamProject01
{
    public partial class Form3 : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private KeyboardHook keyboardHook = new KeyboardHook();
        public Form3()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo600, Primary.Indigo800, Primary.Indigo200, Accent.Pink200, TextShade.WHITE);
            this.main_tab_control.SelectedIndexChanged += Tabcontrol_index;
            this.KeyPreview = true;
            this.keyboardHook.KeyDown += Get_Key_Pressed;
            this.Resize += Form3_Resize;
            MaterialContextMenuStrip menuStrip = new MaterialContextMenuStrip();
            menuStrip.Items.Add("업데이트");
            this.ContextMenuStrip = menuStrip;
            menuStrip.ItemClicked += Update_Strip_Clicked;
        }

        private string checkStatus = "false";
        private readonly string apiLocation = "https://api.smartthings.com/v1/locations";
        private readonly string apiDevice = "https://api.smartthings.com/v1/devices";
        private List<JObject> roomsList = new List<JObject>();
        private List<JObject> deviceStatus = new List<JObject>();
        private JArray deviceInfo = new JArray();
        private JArray locationInfo = new JArray();
        private List<string> healthReport = new List<string>();
        private List<string> currentMode = new List<string>();
        private NotifyIcon trayIcon = new NotifyIcon();
        private ContextMenu trayMenu = new ContextMenu();
        private MaterialSnackBar snackBar;
        private bool enableKey = false;
        private string shortCutText = null;
        private int keyCount = 0;

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

        /* Toast 알림은 레지스트리 추가해야함 ... Form4로 대체
        private void Show_Notification(string title, string content)
        {
            var toastContent = new ToastContentBuilder()
                .AddText(title)
                .AddText(content)
                .GetToastContent();

            var toast = new ToastNotification(toastContent.GetXml());

            ToastNotificationManager.CreateToastNotifier("Teamproject.smart").Show(toast);
        }
        */

        /*
         * Form3_Load
         * 
         */
        private async void Form3_Load(object sender, EventArgs e)
        {
            Tray_Task();
            keyboardHook.SetHook();
            tabPage2.Hide();
            location_status_label_2.Hide();
            favorite_label.Hide();
            location_status_label_1.Hide();
            location_status_picturebox.Hide();
            name_label.Text = $"{Data.name}님,";
            token_textbox.Text = Data.apiKey;
            Load_Device();
            await Update_Device();
        }

        /*
         * Form3_Resize
         * 화면이 최소화 됐을 때 폼을 숨기고 트레이를 보이게 함
         */
        private void Form3_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                trayIcon.Visible = true;
                this.ShowInTaskbar = false;
                this.Hide();
                //new Form4().ShowNotification("백그라운드 실행 중");
            }
        }

        /*
         * Background_Task
         * 트레이를 설정하는 함수
         */
        private void Tray_Task()
        { 
            trayMenu.MenuItems.Add("열기", Form_Restore);
            trayMenu.MenuItems.Add("종료", Form_Exit);
            trayIcon.Text = "우클릭해서 여세용";
            trayIcon.Icon = this.Icon;
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = false;
        }

        /*
         * Form_Restore
         * 트레이에서 열기를 누르면 Form3를 보여줌
         */
        private void Form_Restore(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
            trayIcon.Visible = false;
        }

        /*
         * Form_Exit
         * 트레이에서 종료를 누르면 프로그램 종료
         */
        private void Form_Exit(object sender, EventArgs e)
        {
            // 애플리케이션 종료
            Application.Exit();
        }

       /*
        * OnFormClosing
        * 종료시 사용되는 리소스를 모두 해제
        */
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            keyboardHook.Unhook();
            trayIcon.Dispose();
            base.OnFormClosing(e);
        }

        /*
         *  Tabcontrol_index
         *  Form3의 Drawer에 있는 메뉴를 선택하면 핸들러가 실행하는 함수
         */
        private void Tabcontrol_index(object sender, EventArgs e) // 메뉴 인덱스
        {
            if (main_tab_control.SelectedIndex == 0)
            {
                this.Text = "메인";
                if (checkStatus == "false")
                {
                    checkStatus = "loading";
                    Load_Device();
                }
            }
            else if (main_tab_control.SelectedIndex == 1)
            {
                this.Text = "기기";
                if (checkStatus == "false")
                {
                    checkStatus = "loading";
                    Load_Device();
                }
            }
            else if (main_tab_control.SelectedIndex == 2)
            {
                this.Text = "설정";
            }

            else if (main_tab_control.SelectedIndex == 3 && checkStatus != "loading")
            {
                if (snackBar != null)
                {
                    snackBar.Close();
                }
                new Form1(null).Show();
                this.Hide();
            }
        }

        /*
         * Load_Device()
         * 키가 있는지 판단해서 디바이스를 로드하거나 메세지를 출력하는 함수
         */
        private async void Load_Device()
        {
            if (Data.apiKey != "" && token_textbox.Text.Length != 36)
            {
                checkStatus = "false";
                tabPage2.Controls.Clear();
                if (main_tab_control.SelectedIndex != 2) {
                    Show_Snackbar("유효하지 않은 토큰입니다.", 5000);
                }
            }
            else if (Data.apiKey == "")
            {
                checkStatus = "false";
                tabPage2.Controls.Clear();
                if (main_tab_control.SelectedIndex != 2)
                {
                    Show_Snackbar("토큰이 없습니다.", 5000);
                }
            }
            else if (checkStatus == "false" && Data.apiKey != "")
            {
                checkStatus = "loading";
                change_theme_button.Enabled = false;
                token_textbox.Enabled = false;
                this.MinimizeBox = false;
                await Get_Device();
                this.Cursor = Cursors.WaitCursor;
            }
        }

        /*
         * Show_Main
         * 메인화면의 정보를 출력하는 함수
         * 장소 상태는 이미지로, 등록된 단축키(즐겨찾기) 모음은 MaterialCard 형태로 표시합니다.
         */
        private void Show_Main(string locationIndex)
        {
            if (locationIndex !=  null)
            {
                if (currentMode[int.Parse(locationIndex)] == "Away")
                {
                    location_status_label_2.Text = "외출";
                    location_status_picturebox.Image = Properties.Resources.location_away_48dp_FILL0_wght500_GRAD0_opsz48;
                }
                else if (currentMode[int.Parse(locationIndex)] == "Home")
                {
                    location_status_label_2.Text = "귀가";
                    location_status_picturebox.Image = Properties.Resources.location_home_48dp_FILL0_wght500_GRAD0_opsz48;
                }
            }
            location_status_picturebox.Show();
            location_status_label_2.Show();
            favorite_label.Show();
            location_status_label_1.Show();
            favorite_flowlayoutpanel.Controls.Clear();
            if (Data.Return_All_Keys().Count != 0)
            {
                favorite_label.Text = "즐겨찾기";
                foreach (var key in Data.Return_All_Keys())
                {
                    MaterialLabel materialLabel = this.Controls.Find(key, true).FirstOrDefault() as MaterialLabel;
                    int index = deviceInfo.Select((jObject, i) => new { jObject, i }).FirstOrDefault(x => x.jObject["deviceId"]?.ToString().Contains(key.Split(',')[1]) == true)?.i ?? -1;
                    if (materialLabel != null)
                    {
                        MaterialCard materialCard = Device_Card(materialLabel.Text, healthReport[index], key.Split(',')[0]);
                        materialCard.Size = new Size(250, 150);
                        MaterialLabel cardLabel = materialCard.Controls.Find(materialLabel.Name, true).FirstOrDefault() as MaterialLabel;
                        cardLabel.Text = cardLabel.Text.Split('*')[0];
                        cardLabel.Location = new Point(24, 16);
                        MaterialLabel keyLabel = new MaterialLabel
                        {
                            Location = new Point(24, 48),
                            Text = key.Split(',')[0],
                            AutoSize = true,
                        };
                        //var devComponent = deviceStatus[index].SelectToken("components.main");
                        MaterialLabel healthLabel = new MaterialLabel
                        {
                            Location = new Point(196, 102),
                            //Text = devComponent["switch"]["switch"]["value"].ToString() == "on" ? "켜짐" : "꺼짐",
                            AutoSize = true,
                        };
                        MaterialSwitch materialSwitch = this.Controls.Find(key.Split(',')[1], true).FirstOrDefault() as MaterialSwitch;
                        healthLabel.Text = materialSwitch.Checked == true ? "켜짐" : "꺼짐";
                        materialCard.Controls.Add(healthLabel);

                        materialCard.Controls.Add(keyLabel);
                        materialCard.Controls.Add(cardLabel);
                        favorite_flowlayoutpanel.Controls.Add(materialCard);
                    }
                }
            }
            else
            {
                favorite_label.Text = "즐겨찾기 없음";
            }
        }

        /*
         * Show_Locations
         * 기기 페이지에서 모든 요소(모든 장소와 그 하위 요소들)를 표시합니다.
         */
        private void Show_Locations() // 페이지 전체 출력
        {
            tabPage2.Controls.Clear();
            MaterialTabControl materialTabControl = new MaterialTabControl
            {
                Dock = DockStyle.Fill,
                Name = "materialTabControl2"
            };
            tabPage2.Controls.Add(materialTabControl);
            MaterialTabSelector materialTabSelector = Home_Selector(materialTabControl);
            tabPage2.Controls.Add(materialTabSelector);
            set_location_status_combobox.Items.Clear();
            locationInfo.Reverse();
            for (int i = locationInfo.Count() - 1; i > -1; i--)
            {
                Add_Page(locationInfo[i]["name"].ToString(), i, materialTabControl);
                set_location_status_combobox.Items.Add(locationInfo[i]["name"].ToString());
            }
            set_location_status_combobox.StartIndex = 0;
            Show_Main(Math.Abs(set_location_status_combobox.SelectedIndex - (set_location_status_combobox.Items.Count - 1)).ToString());
            Show_Snackbar("로딩 완료.", 3000);
            change_theme_button.Enabled = true;
            token_textbox.Enabled = true;
            this.MinimizeBox = true;
            checkStatus = "done";
            this.Cursor = Cursors.Default;
        }

        /*
         * Add_Page
         * 한 장소와 그 하위 요소들을 모두 표시합니다.
         * 장소는 MaterialTabSelecter, 방은 MaterialExpansionPaenl, 기기는 MaterialCard 입니다.
         */
        private TabPage Add_Page(string name, int index, MaterialTabControl materialTabControl) // 위치, 방, 디바이스 페이지 출력
        {
            TabPage tabPage = new TabPage
            {
                Text = name,
                AutoScroll = true,
            };
            materialTabControl.TabPages.Add(tabPage);
            JArray roomItems = (JArray)roomsList[index]["items"];
            for (int i = roomItems.Count() - 1; i > -1; i--)
            {
                MaterialExpansionPanel materialExpansionPanel = new MaterialExpansionPanel
                {
                    Dock = DockStyle.Top,
                    Title = roomItems[i]["name"].ToString(),
                    ShowValidationButtons = false,
                    Collapse = true,
                    ExpandHeight = 300,
                };
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true,
                    Padding = new Padding(10),
                };
                materialExpansionPanel.Controls.Add(flowLayoutPanel);
                int count = 0;
                for (int j = 0; j < deviceInfo.Count(); j++)
                {
                    if (deviceInfo[j]["roomId"] != null)
                    {
                        if (roomItems[i]["roomId"].ToString() == deviceInfo[j]["roomId"].ToString())
                        {
                            MaterialCard materialCard = Device_Card(deviceInfo[j]["label"].ToString(), healthReport[j], deviceInfo[j]["deviceId"].ToString());
                            var devComponent = deviceStatus[j].SelectToken("components.main");

                            if (devComponent != null)
                            {

                                if (materialCard.Enabled == true)
                                {
                                    if (devComponent["switch"] != null)
                                    {
                                        MaterialSwitch materialSwitch = new MaterialSwitch
                                        {
                                            Location = new Point(128, 96),
                                            AutoSize = true,
                                            Name = deviceInfo[j]["deviceId"].ToString(),
                                            Checked = devComponent["switch"]["switch"]["value"].ToString() == "on" ? true : false,
                                        };
                                        materialCard.Controls.Add(materialSwitch);
                                    }
                                    else
                                    {
                                        //JObject jObject = JObject.Parse(devComponent.ToString());
                                    }
                                }
                                else
                                {
                                    MaterialLabel healthLabel = new MaterialLabel
                                    {
                                        Location = new Point(114, 102),
                                        Text = "오프라인",
                                        AutoSize = true,
                                        UseAccent = true,
                                    };
                                    materialCard.Controls.Add(healthLabel);
                                }
                            }
                            PictureBox pictureBox = new PictureBox
                            {
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Size = new Size(32, 32),
                                Location = new Point(16, 14),
                            };
                            if (deviceInfo[j]["name"].ToString().Contains("light") || deviceInfo[j]["name"].ToString().Contains("bulb"))
                            {
                                pictureBox.Image = materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? Properties.Resources.lightbulb_40dp_FILL0_wght500_GRAD0_opsz40 : Properties.Resources.lightbulb_40dp_FILL0_wght500_GRAD0_opsz40__1_;
                            }
                            else if (deviceInfo[j]["name"].ToString().Contains("switch"))
                            {
                                pictureBox.Image = materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? Properties.Resources.switch_40dp_FILL0_wght500_GRAD0_opsz40 : Properties.Resources.switch_40dp_FILL0_wght500_GRAD0_opsz40__1_;
                            }
                            else if (deviceInfo[j]["name"].ToString().Contains("plug") || deviceInfo[j]["name"].ToString().Contains("outlet"))
                            {
                                pictureBox.Image = materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? Properties.Resources.smart_outlet_40dp_FILL0_wght500_GRAD0_opsz40 : Properties.Resources.smart_outlet_40dp_FILL0_wght500_GRAD0_opsz40__1_;
                            }
                            else if (deviceInfo[j]["name"].ToString().Contains("contact") || deviceInfo[j]["name"].ToString().Contains("sensor"))
                            {
                                pictureBox.Image = materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? Properties.Resources.sensors_40dp_FILL0_wght500_GRAD0_opsz40 : Properties.Resources.sensors_40dp_FILL0_wght500_GRAD0_opsz40__1_;
                            }
                            else if (deviceInfo[j]["name"].ToString().Contains("temp") || deviceInfo[j]["name"].ToString().Contains("humidity"))
                            {
                                pictureBox.Image = materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? Properties.Resources.device_thermostat_40dp_FILL0_wght500_GRAD0_opsz40 : Properties.Resources.device_thermostat_40dp_FILL0_wght500_GRAD0_opsz40__1_;
                            }
                            else
                            {
                                pictureBox.Image = materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? Properties.Resources.signal_wifi_statusbar_not_connected_40dp_FILL0_wght500_GRAD0_opsz40 : Properties.Resources.signal_wifi_statusbar_not_connected_40dp_FILL0_wght500_GRAD0_opsz40__1_;
                            }
                            materialCard.Controls.Add(pictureBox);
                            flowLayoutPanel.Controls.Add(materialCard);
                            Add_Event_Handler(materialCard);
                            count++;
                        }
                    }
                }
                materialExpansionPanel.ExpandHeight = 200 * Math.Abs((int)Math.Ceiling((double)count / (tabPage2.Width / 250))) + 60;
                //materialExpansionPanel.Description = roomItems[i]["roomId"].ToString() + " " + materialExpansionPanel.Width + " " + materialExpansionPanel.Height + " " + flowLayoutPanel.Height + " " + tabPage.Width + " " + materialExpansionPanel.ExpandHeight + " " + count + " " + Math.Abs((int)Math.Ceiling((double)count / (tabPage2.Width / 250)));
                materialExpansionPanel.Description = "";
                materialExpansionPanel.Collapse = false;
                tabPage.Controls.Add(materialExpansionPanel);
            }
            return tabPage;
        }

        /*
         * Home_Selector
         * MaterialTabSelector를 생성해서 반환합니다.
         */
        private MaterialTabSelector Home_Selector(MaterialTabControl materialTabControl)
        {
            MaterialTabSelector materialTabSelector = new MaterialTabSelector
            {
                Dock = DockStyle.Top,
                BaseTabControl = materialTabControl,
            };
            return materialTabSelector;
        }

        /*
         * Device_Card
         * MaterialCard를 생성해서 반환합니다.
         */
        private MaterialCard Device_Card(string name, string stat, string deviceId) // 디바이스카드 컨트롤 생성해서 반납
        {
            MaterialCard card = new MaterialCard
            {
                Size = new Size(200, 150),
                Name = name,
            };
            MaterialLabel deviceLabel = new MaterialLabel
            {
                Location = new Point(56, 16),
                Text = name,
                Name = deviceId,
                AutoSize = true,
            };
            string value = Data.Check_Key_Data(deviceId);
            if (value != null)
            {
                deviceLabel.Name = value;
                deviceLabel.Text += " *";
            }
            if (stat == "OFFLINE")
            {
                card.Enabled = false;
            }
            card.Controls.Add(deviceLabel);
            return card;
        }

        /*
         * Get_Device
         * 스마트싱스 API로 스마트싱스에 있는 장소, 방, 기기 관련 정보를 받아옵니다.
         */
        private async Task Get_Device() // 위치, 디바이스 리스트 요청
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Data.apiKey);
                    Show_Snackbar($"로드 중...", 99999);
                    HttpResponseMessage locresponse = await client.GetAsync(apiLocation);
                    HttpResponseMessage devresponse = await client.GetAsync(apiDevice);
                    if (locresponse.IsSuccessStatusCode && devresponse.IsSuccessStatusCode)
                    {
                        string locresponseBody = await locresponse.Content.ReadAsStringAsync();
                        string devresponseBody = await devresponse.Content.ReadAsStringAsync();
                        
                        locationInfo = (JArray)JObject.Parse(locresponseBody)["items"];
                        deviceInfo = (JArray)JObject.Parse(devresponseBody)["items"];
                        for (int i = 0; i < locationInfo.Count(); i++)
                        {
                            string roomUrl = $"{apiLocation}/{locationInfo[i]["locationId"]}/rooms";
                            string modeUrl = $"{apiLocation}/{locationInfo[i]["locationId"]}/modes/current";
                            roomsList.Add(await Get_rooms(roomUrl));
                            currentMode.Add(await Get_Modes_Current(modeUrl));
                            
                        }
                        for (int j = 0; j < deviceInfo.Count(); j++)
                        {
                            string deviceUrl = $"{apiDevice}/{deviceInfo[j]["deviceId"]}/status";
                            string healthUrl = $"{apiDevice}/{deviceInfo[j]["deviceId"]}/health";
                            healthReport.Add(await Get_Health_Status(healthUrl));
                            deviceStatus.Add(await Get_Device_Status(deviceUrl));
                        }
                        Show_Locations();
                    }
                    else
                    {
                        Show_Snackbar($"API 요청 실패에요! 사유 : {locresponse.StatusCode}", 3000);
                        checkStatus = "false";
                    }
                }
            }
            catch (Exception ex)
            {
                Show_Snackbar($"알 수 없는 오류 발생. 사유 : {ex.Message}", 3000);
                checkStatus = "false";
            }
        }
        
        /*
         * Get_rooms
         * 방의 정보를 받아옵니다.
         */
        private async Task<JObject> Get_rooms(string roomsUrl) // 방 리스트 요청
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Data.apiKey);
                    HttpResponseMessage roomsResponse = await client.GetAsync(roomsUrl);

                    if (roomsResponse.IsSuccessStatusCode)
                    {
                        string roomsResponseBody = await roomsResponse.Content.ReadAsStringAsync();
                        JObject items = JObject.Parse(roomsResponseBody);
                        return items;
                    }
                    else
                    {
                        Show_Snackbar($"API 요청 실패에요! 사유 : {roomsResponse.StatusCode}", 3000);
                        checkStatus = "false";
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Show_Snackbar($"알 수 없는 오류 발생. 사유 : {ex.Message}", 3000);
                checkStatus = "false";
                return null;
            }
        }

        /*
         * Get_Device_Status
         * 디바이스의 상세 정보를 받아옵니다.
         */
        private async Task<JObject> Get_Device_Status(string deviceUrl) // 디바이스 상세 데이터 요청
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // HTTP 요청 헤더 설정
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Data.apiKey);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET 요청 보내기
                    HttpResponseMessage response = await client.GetAsync(deviceUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // 응답 본문 읽기
                        string deviceStatusJson = await response.Content.ReadAsStringAsync();
                        JObject items = JObject.Parse(deviceStatusJson);
                        return items;
                    }
                    else
                    {
                        Show_Snackbar($"API 요청 실패에요! 사유 : {response.StatusCode}", 3000);
                        checkStatus = "false";
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Show_Snackbar($"알 수 없는 오류 발생. 사유 : {ex.Message}", 3000);
                checkStatus = "false";
                return null;
            }
        }

        /*
         * Get_Modes_Current
         * 현재 장소의 상태를 받아옵니다.
         */
        private async Task<string> Get_Modes_Current(string modeUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Data.apiKey);
                    HttpResponseMessage roomsResponse = await client.GetAsync(modeUrl);

                    if (roomsResponse.IsSuccessStatusCode)
                    {
                        string roomsResponseBody = await roomsResponse.Content.ReadAsStringAsync();
                        JObject items = JObject.Parse(roomsResponseBody);
                        return items.SelectToken("name").ToString();
                    }
                    else
                    {
                        Show_Snackbar($"API 요청 실패에요! 사유 : {roomsResponse.StatusCode}", 3000);
                        checkStatus = "false";
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Show_Snackbar($"알 수 없는 오류 발생. 사유 : {ex.Message}", 3000);
                checkStatus = "false";
                return null;
            }
        }

        /*
         * Get_Health_Status
         * 디바이스의 온라인 여부를 받아옵니다.
         */
        private async Task<string> Get_Health_Status(string healthUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Data.apiKey);
                    HttpResponseMessage roomsResponse = await client.GetAsync(healthUrl);

                    if (roomsResponse.IsSuccessStatusCode)
                    {
                        string roomsResponseBody = await roomsResponse.Content.ReadAsStringAsync();
                        JObject items = JObject.Parse(roomsResponseBody);
                        return items.SelectToken("state").ToString();
                    }
                    else
                    {
                        Show_Snackbar($"API 요청 실패에요! 사유 : {roomsResponse.StatusCode}", 3000);
                        checkStatus = "false";
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Show_Snackbar($"알 수 없는 오류 발생. 사유 : {ex.Message}", 3000);
                checkStatus = "false";
                return null;
            }
        }

        /*
         * Send_Switch_Command
         * 스마트싱스 서버로 스위치 명령을 전송합니다.
         */
        private async Task<string> Send_Switch_Command(string deviceId, string command) // 스위치 명령 송신
        {
            var commandBody = new
            {
                commands = new[]
                {
                    new
                    {
                        component = "main",
                        capability = "switch",
                        command = command,
                    }
                }
            };

            try
            {
                string apiUrl = $"{apiDevice}/{deviceId}/commands";
                using (HttpClient client = new HttpClient())
                {
                    // HTTP 요청 헤더 설정
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Data.apiKey);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // 요청 본문 설정
                    string jsonBody = JObject.FromObject(commandBody).ToString();
                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    // HTTP POST 요청 보내기
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    return response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                Show_Snackbar($"알 수 없는 오류 발생{ex.Message}", 3000);
                return null;
            }
        }

        /*
         * Update_Device
         * 5초마다 디바이스의 상태를 업데이트합니다.
         */
        
        private async Task Update_Device()
        {
            while (true)
            {
                int test = 0; 
                await Task.Delay(5000);
                if (checkStatus == "done" && main_tab_control.SelectedIndex != 2)
                {   
                    token_textbox.Enabled = false;
                    for (int i = 0; i < deviceInfo.Count; i++)
                    {
                        string deviceUrl = $"{apiDevice}/{deviceInfo[i]["deviceId"]}/status";
                        deviceStatus[i] = await Get_Device_Status(deviceUrl);
                        MaterialSwitch @switch = this.Controls.Find(deviceInfo[i]["deviceId"].ToString(), true).FirstOrDefault() as MaterialSwitch;
                        if (@switch != null && @switch.Enabled && checkStatus == "done")
                        {
                            test++;
                            var devComponent = deviceStatus[i].SelectToken("components.main");
                            @switch.Checked = devComponent["switch"]["switch"]["value"].ToString() == "on" ? true : false;
                        }
                    }
                    token_textbox.Enabled = true;
                    //Show_Snackbar(test.ToString(), 1000);
                    Show_Main(null);
                }
            }
        }

        /*
         * Update_Strip_Clicked
         * 업데이트(우클릭)을 클릭했을 때 새로고침합니다.
         */
        private async void Update_Strip_Clicked(object sender, EventArgs e)
        {
            if (checkStatus == "done")
            {
                checkStatus = "loading";
                await Get_Device();
            }
        }

        /*
         * Add_Event_Handler
         * 원하는 컨트롤의 핸들러(하위 컨트롤 포함)를 추가합니다.
         */
        private void Add_Event_Handler(Control parentControl) // 이벤트 핸들러 등록
        {
            foreach (Control control in parentControl.Controls)
            {
                control.MouseClick += Control_Mouse_Click;
                // 자식 컨트롤이 있는 경우 재귀 호출
                if (control.HasChildren)
                {
                    Add_Event_Handler(control);
                }
            }
        }

        /*
         * Control_MouseClick
         * 컨트롤이 클릭했을 때 연결된 핸들러가 실행하는 함수
         * 라벨을 클릭하면 단축키 등록과 삭제, 스위치를 클릭하면 명령 전송입니다.
         */
        private async void Control_Mouse_Click(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(MaterialLabel)){
                MaterialLabel clickedCard = sender as MaterialLabel;
                if (clickedCard != null && clickedCard.Name.Length == 36)
                {
                    if (enableKey == false)
                    {
                        clickedCard.Text += " ? ";
                        enableKey = true;
                        Show_Snackbar("입력 대기 중..", 3000);
                        await Task.Delay(2000);
                        if (shortCutText != null && Data.Check_Key_Data(shortCutText) == null && checkStatus == "done")
                        {
                            clickedCard.Text = clickedCard.Text.Replace(" ? ", "");
                            clickedCard.Text += " *";
                            shortCutText += "," + clickedCard.Name;
                            clickedCard.Name = shortCutText;
                            Data.Update_Info(null, shortCutText);
                            Show_Main(null);
                            Show_Snackbar("등록됨.", 3000);
                        }
                        else
                        {
                            clickedCard.Text = clickedCard.Text.Replace(" ? ", "");
                            Show_Snackbar("다시 시도하세요!", 3000);
                        }
                        shortCutText = null;
                        enableKey = false;
                    }
                }
                else
                {
                    MaterialDialog materialDialog = new MaterialDialog(this, $"{clickedCard.Name.Split(',')[0]} 단축키 제거", "이 기기의 단축키를 제거하시겠어요?", "제거", true, "취소");
                    DialogResult result = materialDialog.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        Data.Remove_Info(clickedCard.Name);
                        clickedCard.Name = clickedCard.Name.Split(',')[1];
                        clickedCard.Text = clickedCard.Text.Replace(" *", "");
                        Show_Main(null);
                    }
                }
            }
            else if (sender.GetType() == typeof(MaterialSwitch))
            {
                MaterialSwitch materialSwitch = sender as MaterialSwitch;
                Change_Switch(materialSwitch);
            }
        }

        /*
         * Change_Switch
         * 스위치가 클릭되면 명령을 전송하고 1초 마다 5번 상태를 요청해서 스위치가 동기화됐는지 확인합니다.
         * 백그라운드 상태에서 단축키로 스위치가 바뀌면 우하단에 알림이 표시됩니다.
         */
        private async void Change_Switch(MaterialSwitch clickedSwitch)
        {
            if (clickedSwitch != null)
            {
                clickedSwitch.Enabled = false;
                string result = await Send_Switch_Command(clickedSwitch.Name, clickedSwitch.Checked ? "on" : "off");
                foreach (JObject obj in deviceInfo)
                {
                    if (this.WindowState == FormWindowState.Minimized && obj["deviceId"].ToString().Contains(clickedSwitch.Name))
                    {
                        new Form4().ShowNotification($"{obj["label"]} {(clickedSwitch.Checked ? "켜짐" : "꺼짐")}");
                        break;
                    }
                }
                string deviceUrl = $"{apiDevice}/" + clickedSwitch.Name + "/status";
                if (result != null)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        await Task.Delay(1000);
                        JObject sync = await Get_Device_Status(deviceUrl);
                        if (sync != null)
                        {
                            if (sync.SelectToken("components.main")["switch"]["switch"]["value"].ToString() == "on" ? true : false == clickedSwitch.Checked)
                            {
                                clickedSwitch.Enabled = true;
                                Show_Main(null);
                                break;
                            }
                            else if (i == 4)
                            {
                                clickedSwitch.Enabled = true;
                                clickedSwitch.Checked = clickedSwitch.Checked ? false : true;
                                Show_Snackbar("동기화 실패.", 3000);
                                break;
                            }
                        }
                        else
                        {
                            clickedSwitch.Enabled = true;
                            clickedSwitch.Checked = clickedSwitch.Checked ? false : true;
                            break;
                        }
                    }
                }
                else
                {
                    clickedSwitch.Enabled = true;
                    clickedSwitch.Checked = clickedSwitch.Checked ? false : true;
                }
            }
        }

        /*
         * Get_Key_Pressed
         * Ctrl + ? + ? 조합의 키를 인식해서 단축키를 등록하거나
         * 스위치를 제어합니다. 키는 백그라운드에서도 인식됩니다.
         */
        private void Get_Key_Pressed(object sender, KeyEventArgs e)
        {
            if (checkStatus == "done")
            {
                keyCount++;
                if (shortCutText == null)
                {
                    if (e.KeyCode.ToString() == "LControlKey")
                    {
                        shortCutText += e.KeyCode.ToString();
                        Show_Snackbar(shortCutText, 1000);
                    }
                    else
                    {
                        keyCount = 0;
                    }
                }
                else if (keyCount < 4)
                {
                    if (!shortCutText.Contains(e.KeyCode.ToString()))
                    {
                        shortCutText += " + " + e.KeyCode.ToString();
                        Show_Snackbar(shortCutText, 1000);
                    }
                }
                if (keyCount >= 3 && enableKey == true)
                {
                    enableKey = false;
                    keyCount = 0;
                    return;
                }
                else if (keyCount >= 3)
                {

                    keyCount = 0;
                    string value = Data.Check_Key_Data(shortCutText);
                    if (value != null && value.Split(',')[0] == shortCutText)
                    {
                        MaterialSwitch materialSwitch = this.Controls.Find(value.Split(',')[1], true).FirstOrDefault() as MaterialSwitch;
                        if (materialSwitch != null)
                        {
                            materialSwitch.Checked = materialSwitch.Checked ? false : true;
                            Change_Switch(materialSwitch);
                        }
                        
                        else
                        {
                            Data.Remove_Info(value);
                        }
                    }
                    else
                    {
                        //Show_Snackbar("실패!!", 3000);
                    }
                    shortCutText = null;
                    return;
                }
            }
        }

        /*
         * btn_changePW_Click
         * 변경 버튼을 누르면 계정 비밀번호를 업데이트합니다.
         */
        private void btn_changePW_Click(object sender, EventArgs e)
        {
            string newPassword = tb_changePW.Text;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Show_Snackbar("새 비밀번호를 입력하세요.", 3000);
                return;
            }

            MaterialDialog materialDialog = new MaterialDialog(this, "경고", "비밀번호를 변경하시겠어요?", "변경", true, "취소");
            DialogResult result = materialDialog.ShowDialog(this);
            // 입력된 ID의 비밀번호 변경
            if (result == DialogResult.OK)
            {
                Data.Update_Info(newPassword, null);
                Show_Snackbar("비밀번호가 변경됨.", 3000);
                tb_changePW.Text = null;
            }
        }
        
        /*
         * token_textbox_TextChanged
         * 토큰 입력창에서 토큰이 바뀌면 업데이트합니다.
         */
        private void token_textbox_TextChanged(object sender, EventArgs e)
        {   
             Data.apiKey = token_textbox.Text;
             Load_Device();
             Data.Update_Info(null, null);
        }

        /*
         * change_theme_button_Clicked
         * 테마 버튼을 누르면 폼의 테마를 라이트 혹은 다크로 변경합니다.
         */
        private void change_theme_button_Clicked(object sender, EventArgs e)
        {
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
            Show_Locations();
            Invalidate();   
        }
        
        /*
         * delete_account_button_Clicked
         * 계정 삭제 버튼을 클릭하면 계정을 삭제하고 Form1으로 이동합니다.
         */
        private void delete_account_button_Clicked(object sender, EventArgs e)
        {
            MaterialDialog materialDialog = new MaterialDialog(this, "경고", "계정을 삭제하면 모든 정보가 지워집니다.", "삭제", true, "취소");
            DialogResult result = materialDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Data.Delete_User_Data();
                if (snackBar != null)
                {
                    snackBar.Close();
                }
                new Form1(null).Show();
                this.Hide();
            }
        }

        private void set_location_status_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show_Main(Math.Abs(set_location_status_combobox.SelectedIndex - (set_location_status_combobox.Items.Count - 1)).ToString());
        }
    }
}