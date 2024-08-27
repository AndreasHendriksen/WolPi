using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace server.Services
{
    public class PasswordHandler
    {
        private string usersFilePath = "users.txt";
        private UsersObject users;

        public PasswordHandler()
        {
            users = new UsersObject();

            if (!File.Exists(usersFilePath))
            {
                InitializeUsers();
            }
            else
            {
                string json = File.ReadAllText(usersFilePath);
                users = JsonConvert.DeserializeObject<UsersObject>(json);
            }

            if (users == null)
                throw new Exception("users object is null");
        }

        void InitializeUsers()
        {
            //User userA = new User();
            //userA.Username = "admin";
            //userA.Password = "7722a1de1d8b8dad950e3b92d9c6c7c5ba6f50db54b8fe79625ca024d4765001";
            //users.Users.Add(userA);

            User userB = new User();
            userB.Username = "Otter";
            userB.Password = "fe65935667f0a3e9fa5745aa5147f33b281111263178286f368a803dffeb704e";
            users.Users.Add(userB);

            WriteUsers();
        }

        void WriteUsers()
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(usersFilePath, json);
        }

        public bool CheckPassword(string _password)
        {
            User? user = users.Users.Find((x) => x.Password == _password);
            return user != null;
        }

        public void ChangePassword(string _password)
        {
            users.Users[0].Password = _password;
            WriteUsers();
        }

        private class UsersObject
        {
            public List<User> Users { get; set; }

            public UsersObject()
            {
                Users = new List<User>();
            }
        }

        private class User
        {
            public string? Username { get; set; }

            public string? Password { get; set; }
        }
    }
}
