using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasPutriEri.Model
{
    public class Village : BaseModel
    {
        public string Name { get; set; }

        public Regency Regencies { get; set; }
    }
}
