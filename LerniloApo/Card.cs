using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerniloApo
{
    internal class Card
    {
        public int Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public string Extra { get; set; }
        public string Image { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
