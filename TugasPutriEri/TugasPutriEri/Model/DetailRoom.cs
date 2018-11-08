using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasPutriEri.Model
{
    public class DetailRoom : BaseModel
    {
       public double Price { get; set; }
        public Room Rooms { get; set; }
        public Facility Facilities { get; set; }
    }
}
