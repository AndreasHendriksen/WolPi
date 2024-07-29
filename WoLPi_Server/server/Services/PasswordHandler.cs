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

        public void InitializeUsers()
        {
            User userA = new User();
            userA.Username = "admin";
            userA.Password = "2acd3216ee98303062b7b43a9ac9e5a0a5c638ff521ea2ee049047d71b8edb2f";
            users.Users.Add(userA);

            User userB = new User();
            userB.Username = "Otter";
            userB.Password = "dsadsa";
            users.Users.Add(userB);

            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(usersFilePath, json);
        }

        public bool CheckPassword(string _password)
        {
            User? user = users.Users.Find((x) => x.Password == _password);
            return user != null;
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
