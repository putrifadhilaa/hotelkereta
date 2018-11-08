using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasPutriEri.Model
{
    public class Hotel : BaseModel
    {
        public string Name { get; set; }
        public string Star { get; set; }
        public District Districts { get; set; }
    }
}
