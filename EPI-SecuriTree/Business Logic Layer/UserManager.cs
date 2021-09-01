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
        //Class manages the connection between the presentation layer and the data access layer.
        //This class manages users and any information needed about users.

        readonly IFormatter formatter = new BinaryFormatter();
        Stream stream;

        //Used to store a signed in user.
        public void SerializeUser(string name, string surname)
        {
            User tempUser = new User
            {
                First_name = name,
                Surname = surname
            };

            Stream stream = new FileStream(@"User.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, tempUser);
            stream.Close();
        }

        //Used to read stored signed in user.
        public string DeserializeUser()
        {
            stream = new FileStream(@"User.txt", FileMode.Open, FileAccess.Read);
            User userObj = (User)formatter.Deserialize(stream);
            stream.Close();

            return userObj.First_name + " " + userObj.Surname;
        }

        //Cleaning up the user that was logged in.
        public void ClearCache()
        {
            File.Delete(@"User.txt");
        }

        //Inserting a user into the database.
        public void InsertUser(string Username,string First, string Surname, string Password)
        {
            UserDataAccessController uac = new UserDataAccessController();
            uac.InsertUser(new User(Username,First,Surname,Password));
        }
    }
}
