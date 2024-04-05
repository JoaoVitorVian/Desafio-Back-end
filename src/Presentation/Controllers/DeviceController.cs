using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Devices;
using ViewModels.Login;
using ViewModels.Response;

namespace Presentation.Controllers
{
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public DeviceController(IDeviceService deviceService, IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route("api/devices/create")]
        public async Task<IActionResult> Create([FromBody] CreateDeviceViewModel viewModel)
        {
            try
            {
                var deviceDTO = _mapper.Map<DeviceDTO>(viewModel);
                var createdDevice = await _deviceService.Create(deviceDTO);

                var response = new ResultViewModel
                {
                    Message = "Dispositivo criado com sucesso!",
                    Success = true,
                    Data = createdDevice
                };

                return Ok(response);
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false,
                    Data = ex.Errors
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel { Message = ex.Message, Success = false });
            }
        }

        [HttpPut]
        [Authorize]
        [Route("api/devices/update")]
        public async Task<IActionResult> Update([FromBody] UpdateDeviceViewModel viewModel)
        {
            try
            {
                var deviceDTO = _mapper.Map<DeviceDTO>(viewModel);
                var updatedDevice = await _deviceService.Update(deviceDTO);

                var response = new ResultViewModel
                {
                    Message = "Dispositivo atualizado com sucesso!",
                    Success = true,
                    Data = updatedDevice
                };

                return Ok(response);
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false,
                    Data = ex.Errors
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false
                });
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("api/devices/remove{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _deviceService.Delete(id);

                return Ok(new ResultViewModel
                {
                    Message = "Dispositivo deletado com sucesso",
                    Success = true
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false,
                    Data = ex.Errors
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false
                });
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/devices/get{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var device = await _deviceService.Get(id);

                var response = new ResultViewModel
                {
                    Message = "Dispositivo encontrado!",
                    Success = true,
                    Data = device
                };

                return Ok(response);
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false,
                    Data = ex.Errors
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false
                });
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/devices/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var devices = await _deviceService.GetAll();

                var response = new ResultViewModel
                {
                    Message = "Dispositivos encontrados",
                    Success = true,
                    Data = devices
                };

                return Ok(response);
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false,
                    Data = ex.Errors
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false
                });
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/devices/get-devices-with-rainfall")]
        public async Task<IActionResult> GetDevicesWithRainfallIntensity()
        {
            try
            {
                var devices = await _deviceService.GetDevicesWithRainfallIntensity();

                var response = new ResultViewModel
                {
                    Message = "Dispositivos encontrados com intensidade de chuva",
                    Success = true,
                    Data = devices
                };

                return Ok(response);
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false,
                    Data = ex.Errors
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false
                });
            }
        }
    }
}