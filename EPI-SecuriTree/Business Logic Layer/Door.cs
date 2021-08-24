using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI_SecuriTree
{
    class Door
    {
        private string _id;
        private string _name;
        private string _privateArea;
        private string _status;

        public Door(string id, string name, string privateArea, string status)
        {
            _id = id;
            _name = name;
            _privateArea = privateArea;
            _status = status;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string PrivateArea { get => _privateArea; set => _privateArea = value; }
        public string Status { get => _status; set => _status = value; }
    }
}
