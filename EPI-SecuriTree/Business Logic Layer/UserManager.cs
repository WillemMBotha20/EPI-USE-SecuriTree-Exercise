using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace EPI_SecuriTree
{
    class UserManager
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream;

        public void SerializeUser(string name, string surname)
        {
            User tempUser = new User();
            tempUser.First_name = name;
            tempUser.Surname = surname;

            Stream stream = new FileStream(@"User.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, tempUser);
            stream.Close();
        }

        public string DeserializeUser()
        {
            stream = new FileStream(@"User.txt", FileMode.Open, FileAccess.Read);
            User userObj = (User)formatter.Deserialize(stream);
            stream.Close();

            return userObj.First_name + " " + userObj.Surname;
        }

        public void ClearCache()
        {
            File.Delete(@"User.txt");
        }

        public void InsertUser(string Username,string First, string Surname, string Password)
        {
            UserDataAccessController uac = new UserDataAccessController();
            uac.InsertUser(new User(Username,First,Surname,Password));
        }
    }
}
