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
        private List<Door> _doors;

        public AccessRules(string id, string name, List<Door> doors)
        {
            _id = id;
            _name = name;
            _doors = doors;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        internal List<Door> Doors { get => _doors; set => _doors = value; }

        public override bool Equals(object obj)
        {
            return obj is AccessRules rules &&
                   _id == rules._id &&
                   _name == rules._name &&
                   EqualityComparer<List<Door>>.Default.Equals(_doors, rules._doors);
        }

        public override int GetHashCode()
        {
            int hashCode = -1564479013;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Door>>.Default.GetHashCode(_doors);
            return hashCode;
        }
    }
}
