using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamProject01
{
    class Data
    {
        public static string apiKey;
        public static string name;
        public static int infoIndex;
        
        /*
         * Load_User_Data 
         * Data 파일에서 요소를 불러옵니다.
         */
        public static List<UserCredentials> Load_User_Data(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<UserCredentials>>(json);
            }
            return new List<UserCredentials>();
        }

        /*
         * Add_New_Users
         * 계정 정보를 받아서 Data 파일에 저장합니다.
         * 이때 비밀번호는 BCrypt의 해싱으로 암호화됩니다.
         */
        public static void Add_New_Users(string id, string password, string name)
        {
            List<UserCredentials> users = Load_User_Data("data.data");
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            users.Add(new UserCredentials
            {
                Id = id,
                Password = hashedPassword,
                Name = name,
                ApiToken = "",
                Keys = new List<string>(),
                SavedDeviceInfo = new JArray(),
            });
            Save_User_Data(users);
        }

        /*
         * Save_User_Data
         * 클래스를 직렬화해서 Data 파일에 저장합니다.
         */
        static void Save_User_Data(List<UserCredentials> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("data.data", json);
        }

        /*
         * Update_Info
         * 비밀번호와 API 토큰을 받아서 Data 파일에 업데이트합니다.
         */
        public static void Update_Info(string password, string key)
        {
            List<UserCredentials> users = Load_User_Data("data.data");
            users[infoIndex].ApiToken = apiKey;
            if (password != null)
            {
                users[infoIndex].Password = BCrypt.Net.BCrypt.HashPassword(password);
            }
            if (key != null)
            {
                users[infoIndex].Keys.Add(key);
            }
            Save_User_Data(users);
        }

        /*
         * Remove_Info
         * 등록된 단축키를 Data 파일에서 삭제합니다.
         */
        public static void Remove_Info(string key)
        {
            List<UserCredentials> users = Load_User_Data("data.data");
            users[infoIndex].Keys.Remove(key);
            Save_User_Data(users);
        }

        /*
         * Delete_User_Data
         * 현재 계정을 삭제합니다.
         */
        public static void Delete_User_Data()
        {
            List<UserCredentials> users = Load_User_Data("data.data");
            users.RemoveAt(infoIndex);
            Save_User_Data(users);
        }

        /*
         * Verift_User_Login
         * 로그인 정보를 받아서 Data 파일의 정보와 일치하는지 확인합니다.
         * 정보가 일치하면 모든 정보를 불러옵니다.
         */
        public static bool Verify_User_Login(string loginId, string loginPassword)
        {
            List<UserCredentials> users = Load_User_Data("data.data");
            bool isValidUser = false;
            foreach (var user in users)
            {
                if (user.Id == loginId && BCrypt.Net.BCrypt.Verify(loginPassword, user.Password))
                {
                    isValidUser = true;
                    apiKey = user.ApiToken;
                    name = user.Name;
                    infoIndex = users.IndexOf(user);
                    break;
                }
            }
            return isValidUser;
        } 

        /*
         * Check_User_Id
         * 받은 아이디가 Data 파일에 존재하는지 확인합니다.
         */
        public static bool Check_User_Id(string Id)
        {
            List<UserCredentials> users = Load_User_Data("data.data");
            bool isValidUser = false;
            foreach (var user in users)
            {
                if (user.Id == Id)
                {
                    isValidUser = true;
                    break;
                }
            }
            return isValidUser;
        }

        /*
         * Check_Key_Data
         * 받은 단축키가 Data 파일에 존재하면 정보를 반환합니다.
         */
        public static string Check_Key_Data(string key)
        {
            List<UserCredentials> users = Load_User_Data("data.data");
            return users[infoIndex].Keys.Find(value => value.Contains(key));
        }

        /*
         * Return_All_Keys
         * Data 파일에 저장된 해당 사용자의 모든 단축키를 반환합니다.
         */
        public static List<string> Return_All_Keys()
        {
            List<UserCredentials> users = Load_User_Data("data.data");
            return users[infoIndex].Keys;
        }
    }

    class UserCredentials
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name {  get; set; }
        public string ApiToken { get; set; }
        public List<string> Keys { get; set; }
        public JArray SavedDeviceInfo {  get; set; }
    }
}