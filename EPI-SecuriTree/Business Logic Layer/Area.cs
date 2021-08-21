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
        private string[] _child_area_ids;

        public Area(string id, string name, string parentAreaId, string[] child_area_ids)
        {
            _id = id;
            _name = name;
            _parentAreaId = parentAreaId;
            _child_area_ids = child_area_ids;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string ParentAreaId { get => _parentAreaId; set => _parentAreaId = value; }
        public string[] Child_area_ids { get => _child_area_ids; set => _child_area_ids = value; }
    }
}
