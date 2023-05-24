using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая7.Model
{
    public class ChampionClass
    {
        public string name { get; set; }
        public List<ClassBuff> buffs { get; set; }
        public string icon { get; set; }

        public ChampionClass(string name, List<ClassBuff> buffs, string icon)
        {
            this.name = name;
            this.buffs = buffs;
            this.icon = icon;
        }
    }
}
