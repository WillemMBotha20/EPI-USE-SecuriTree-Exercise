using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI_SecuriTree
{
    [Serializable]
    class User
    {
        private string _username;
        private string _first_name;
        private string _surname;
        private string _password;

        public User(string username, string first_name, string surname, string password)
        {
            _username = username;
            _first_name = first_name;
            _surname = surname;
            _password = password;
        }

        public User()
        {

        }

        public User(string username)
        {
            _username = username;
        }

        public string Username { get => _username; set => _username = value; }
        public string First_name { get => _first_name; set => _first_name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
