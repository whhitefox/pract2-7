using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая7.Model
{
    public class ClassBuff
    {
        public int championsCount { get; set; }
        public string description { get; set; }

        public ClassBuff(int championsCount, string description)
        {
            this.championsCount = championsCount;
            this.description = description;
        }
    }
}
