using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasPutriEri.Model
{
    public class Account : BaseModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public int Hp { get; set; }
        
    }
}
