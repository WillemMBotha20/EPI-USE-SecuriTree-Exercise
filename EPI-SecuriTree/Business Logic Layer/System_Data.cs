using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI_SecuriTree
{
    class System_Data
    {
        //This class is to combine 2 list objects.

        private List<Area> _areas;
        private List<Door> _doors;
        private List<AccessRules> _rules;

        public System_Data(List<Area> areas, List<Door> doors, List<AccessRules> rules)
        {
            _areas = areas;
            _doors = doors;
            _rules = rules;
        }

        public System_Data()
        {

        }

        internal List<Area> Areas { get => _areas; set => _areas = value; }
        internal List<Door> Doors { get => _doors; set => _doors = value; }
        internal List<AccessRules> Rules { get => _rules; set => _rules = value; }
    }
}
