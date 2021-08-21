using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI_SecuriTree
{
    class OnStartUpController
    {
        DatabaseController datacon = new DatabaseController();

        public void StartUpDatabase()
        {
            datacon.CreateDatabase();
            datacon.CreateUserTable();
        }

    }
}
