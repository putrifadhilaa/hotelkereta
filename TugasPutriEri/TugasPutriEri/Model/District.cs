using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasPutriEri.Model
{
    public class District : BaseModel
    {
      public string Name { get; set; }

        public Province Provinces { get; set; }
    }
}
