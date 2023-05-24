using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая7.Model
{
    public class Champion
    {
        public string name { get; set; }
        public List<string> classesNames { get; set; }
        public int cost { get; set; }
        public string icon { get; set; }
        public string ultDescription { get; set; }
        
        public Champion(string name, List<string> classesNames, int cost, string icon, string ultDescription)
        {
            this.name = name;
            this.classesNames = classesNames;
            this.cost = cost;
            this.icon = icon;
            this.ultDescription = ultDescription;
        }
    }
}
