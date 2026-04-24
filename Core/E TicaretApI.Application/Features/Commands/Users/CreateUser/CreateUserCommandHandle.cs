using E_TicaretApI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandHandle : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandle(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser appUser = new AppUser()
            {
                Id=new Guid().ToString(),
                NameSurname=request.NameSurname,
                UserName=request.Username,
                Email=request.Email,
                
            };
          IdentityResult result= await _userManager.CreateAsync(appUser, request.Password);
            if (result.Succeeded)
            {
                CreateUserCommandResponse response = new CreateUserCommandResponse
                {
                    Success=true,
                    Message="Qeydiyyat ugurludur"
                };
                return response;
                
            }
            else
            {
                return new CreateUserCommandResponse
                {
                    Success = false,
                    Message = string.Join(", ", result.Errors.Select(e => e.Description))
                };
            }

           
        }
    }
}
