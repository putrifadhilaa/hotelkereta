using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasPutriEri.Model
{
    public class Room : BaseModel
    {
        public string Name { get; set; }
        public Hotel Hotels { get; set; }
    }
}
