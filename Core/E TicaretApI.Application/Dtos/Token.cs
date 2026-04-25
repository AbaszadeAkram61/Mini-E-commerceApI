using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Dtos
{
    public class Token
    {
        public string AccessToken {  get; set; }
        public DateTime Expiration {  get; set; }
    }
}
