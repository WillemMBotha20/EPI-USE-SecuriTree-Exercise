using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EPI_SecuriTree
{
    class JsonController
    {
		private readonly string _pathData = $"system_data.json";
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
		
		public void ReadAreaData()
        {
			string jsonFromFile = "";

			using (var reader = new StreamReader(_pathData))
			{
				jsonFromFile = reader.ReadToEnd();
			}

			JObject obj = JObject.Parse(jsonFromFile);

			List<Area> Areas = new List<Area>();
			List<Door> Doors = new List<Door>();
			List<AccessRules> Rules = new List<AccessRules>();

			string type = "areas";
			int inx = 0;

			foreach (var item in obj["system_data"])
			{
				foreach (var itemnum in obj[type])
				{
                    if (inx == 0)
                    {
						Areas.Add(item.ToObject<Area>());
                    }
                    else if(inx == 1)
					{
						Doors.Add(item.ToObject<Door>());
					}
                    else if (inx == 2)
                    {
						Rules.Add(item.ToObject<AccessRules>());
					}
					
				}

				inx++;
                if (inx == 1)
                {
					type = "doors";
                }else if (inx == 2)
                {
					type = "access_rules";

				}
			}


		}

	}   
}
