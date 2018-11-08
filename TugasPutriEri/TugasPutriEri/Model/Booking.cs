using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasPutriEri.Model
{
    public class Booking : BaseModel
    {
        public Account Accounts { get; set; }

        public DetailRoom DetailRooms { get; set; }
    }
}
