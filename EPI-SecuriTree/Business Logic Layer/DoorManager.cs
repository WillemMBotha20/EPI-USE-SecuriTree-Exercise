using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI_SecuriTree
{
    class DoorManager
    {
        DatabaseController con = new DatabaseController();
        public bool GetDoor(string doorId)
        {
            DataSet set = con.CheckDoorStatus(doorId);

            try
            {
                if ((string)set.Tables[0].Rows[0]["doorstatus"] == "open")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }          
            
        }

        public void LockDoor(string id)
        {
            con.ManageDoorStatusTrue(id);
        }

        public void UnlockDoor(string id)
        {
            con.ManageDoorStatusFalse(id);
        }
    }
}
