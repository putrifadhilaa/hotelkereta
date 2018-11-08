using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasPutriEri.Model
{
    public class Regency : BaseModel
    {
        public string Name { get; set; }

        public District Districts { get; set; }
    }
}
