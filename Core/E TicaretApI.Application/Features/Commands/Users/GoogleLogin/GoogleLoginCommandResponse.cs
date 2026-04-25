using E_TicaretApI.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Commands.Users.GoogleLogin
{
    public class GoogleLoginCommandResponse
    {
        public Application.Dtos.Token Token { get; set; }
    }
}
