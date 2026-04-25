using E_TicaretApI.Application.Dtos;
using E_TicaretApI.Application.Exceptions;
using E_TicaretApI.Application.Token;
using E_TicaretApI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Commands.Users.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }


        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UsernameorEmail) ??
                 await _userManager.FindByEmailAsync(request.UsernameorEmail);

            if (user==null)
            {
                throw new NotFoundUserException("Istifadeci adi ve ya parol yanlisdir");
            }

            SignInResult result= await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);
            if (result.Succeeded)
            {
                Application.Dtos.Token token= _tokenHandler.CreateAccessToken();
                return new LoginUserCommandResponse
                {
                    Token=token
                };
            }
            else
            {
                return new LoginUserCommandResponse
                {
                    Mesaage = "Istifadeci adi ve ya parol yablisdir"
                };
            }

            


        }
    }
}
