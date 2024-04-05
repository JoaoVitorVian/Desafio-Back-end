using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Token;
using Presentation.Utilities;
using ViewModels.Login;
using ViewModels.Response;

namespace Presentation.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator, IUserService userService, IMapper mapper)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            try
            {
                var userDTO = await _userService.CheckLogin(model.Login, model.Password);

                if (userDTO != null)
                {
                    var user = _mapper.Map<User>(userDTO);

                    return Ok(new ResultViewModel
                    {
                        Message = "Usuário autenticado com sucesso",
                        Success = true,
                        Data = new
                        {
                            Token = _tokenGenerator.GenerateToken(user),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"])),
                        }
                    });
                }
                else
                {
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
                }
            }
            catch (Exception )
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
