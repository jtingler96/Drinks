using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks
{
    public class Drink
    {
        public string strCategory { get; set; }
    }

    public class Root
    {
        public List<Drink> drinks { get; set; }
    }
}
