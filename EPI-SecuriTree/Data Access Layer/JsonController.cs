using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EPI_SecuriTree
{
    class JsonController
    {
		private readonly string _pathData = $"";
		private readonly string _pathUsers = $"registered_users.json";	


		//Creates and converts to the json string;

		public string ReadUsers()
        {
			string jsonFromFile = "";			
				
			using (var reader = new StreamReader(_pathUsers))
			{
				jsonFromFile = reader.ReadToEnd();
			}		

			return jsonFromFile;				
		}
		
		//Reads the json string and converts it to a list of users.

		public List<User> UserData()
        {
            JObject obj = JObject.Parse(ReadUsers());

			List<User> temp = new List<User>();
					
            foreach (var item in obj["registered_users"])
            {
				temp.Add(item.ToObject<User>());
            }

			return temp;
		}		
	}   
}
