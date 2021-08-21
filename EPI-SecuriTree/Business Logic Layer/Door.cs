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
        private bool _status;

        public Door(string id, string name, string privateArea, bool status)
        {
            _id = id;
            _name = name;
            _privateArea = privateArea;
            _status = status;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string PrivateArea { get => _privateArea; set => _privateArea = value; }
        public bool Status { get => _status; set => _status = value; }

        public override bool Equals(object obj)
        {
            return obj is Door door &&
                   _id == door._id &&
                   _name == door._name &&
                   _privateArea == door._privateArea &&
                   _status == door._status;
        }

        public override int GetHashCode()
        {
            int hashCode = -1319615308;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_privateArea);
            hashCode = hashCode * -1521134295 + _status.GetHashCode();
            return hashCode;
        }
    }
}
