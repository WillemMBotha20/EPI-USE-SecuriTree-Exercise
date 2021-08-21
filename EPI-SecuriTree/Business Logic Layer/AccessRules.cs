using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI_SecuriTree
{
    class AccessRules
    {
        private string _id;
        private string _name;
        private string[] _doors;

        public AccessRules(string id, string name, string[] doors)
        {
            _id = id;
            _name = name;
            _doors = doors;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string[] Doors { get => _doors; set => _doors = value; }
    }
}
