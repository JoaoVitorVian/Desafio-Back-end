using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utilities;
using ViewModels.Response;
using ViewModels.User;

namespace Presentation.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        //[Authorize]
        [Route("/api/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel viewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(viewModel);
                var userCreated = await _userService.Create(userDTO);

                return Ok(new ResultViewModel {
                    Message = "Usuário criado com sucesso!",
                    Success = true,
                    Data = userCreated
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("/api/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel viewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(viewModel);
                var userUpdated = await _userService.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso!",
                    Success = true,
                    Data = userUpdated
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("api/users/remove{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _userService.Delete(id);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário removido com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/users/get{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var user = await _userService.Get(id);

                if (user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado.",
                        Success = true,
                        Data = user
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/users/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allUsers = await _userService.GetAll();

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/users/get-by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.GetByEmail(email);

                if (user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado.",
                        Success = true,
                        Data = user
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/users/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var user = await _userService.SearchByName(name);

                if (user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado.",
                        Success = true,
                        Data = user
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/users/search-by-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.SearchByEmail(email);

                if (user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado.",
                        Success = true,
                        Data = user
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
