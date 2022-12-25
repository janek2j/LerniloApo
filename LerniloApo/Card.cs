using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerniloApo
{
    internal class Card
    {
        public string Front { get; set; }
        public string Back { get; set; }

        public List<string> Tags { get; set; } = new List<string>();
        public DateTime CreatedOn { get; set; }
    }
}
