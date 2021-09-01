using Newtonsoft.Json;
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

        #region "ReadUsers"
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
        #endregion "ReadUsers"

        #region "UserData"
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
        #endregion "UserData"

        #region "ReadAreaData"
        public System_Data ReadAreaData()
        {
			string jsonFromFile = "";

			using (var reader = new StreamReader(_pathData))
			{
				jsonFromFile = reader.ReadToEnd();
			}

			JObject obj = JObject.Parse(jsonFromFile);
			JObject obj2;

			List<Area> Areas = new List<Area>();
			List<Door> Doors = new List<Door>();
			List<AccessRules> Rules = new List<AccessRules>();
			List<string> AreaTemp = new List<string>();
            _ = new string[] { };
            int inx = 0;

			foreach (var item in obj["system_data"])
			{
                foreach (var item2 in item)
                {
                    foreach (var item3 in item2)
                    {
						obj2 = (JObject)item3;
                        string holder = obj2["id"].ToString();
                        string[] hold;
                        if (inx == 0)
                        {
                            foreach (var item4 in obj2["child_area_ids"])
                            {
                                AreaTemp.Add(item4.ToString());
                            }

                            hold = AreaTemp.ToArray();

                            if (obj2["parent_area"] == null)
                            {
                                Areas.Add(new Area(obj2["id"].ToString(), obj2["name"].ToString(), "null", hold));
                            }
                            else
                            {
                                Areas.Add(new Area(obj2["id"].ToString(), obj2["name"].ToString(), obj2["parent_area"].ToString(), hold));
                            }

                            AreaTemp.Clear();
                        }
                        else if (inx == 1)
                        {
                            Doors.Add(new Door(obj2["id"].ToString(), obj2["name"].ToString(), obj2["parent_area"].ToString(), obj2["status"].ToString()));
                        }
                        else if (inx == 2)
                        {
                            foreach (var item4 in obj2["doors"])
                            {
                                AreaTemp.Add(item4.ToString());
                            }

                            hold = AreaTemp.ToArray();

                            Rules.Add(new AccessRules(obj2["id"].ToString(), obj2["name"].ToString(), hold));

                            AreaTemp.Clear();
                        }
                    }
					inx++;
				}              
            }

			System_Data data = new System_Data(Areas,Doors,Rules);

			Console.WriteLine(data);

			return data;
		}
        #endregion "ReadAreaData"
    }
}
