using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI_SecuriTree
{
    class Area
    {
        private string _id;
        private string _name;
        private string _parentAreaId;
        private List<Area> _childAreas;

        public Area(string id, string name, string parentAreaId, List<Area> childAreas)
        {
            _id = id;
            _name = name;
            _parentAreaId = parentAreaId;
            _childAreas = childAreas;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string ParentAreaId { get => _parentAreaId; set => _parentAreaId = value; }
        internal List<Area> ChildAreas { get => _childAreas; set => _childAreas = value; }

        public override bool Equals(object obj)
        {
            return obj is Area area &&
                   _id == area._id &&
                   _name == area._name &&
                   _parentAreaId == area._parentAreaId &&
                   EqualityComparer<List<Area>>.Default.Equals(_childAreas, area._childAreas);
        }

        public override int GetHashCode()
        {
            int hashCode = -138353048;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_parentAreaId);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Area>>.Default.GetHashCode(_childAreas);
            return hashCode;
        }
    }
}
