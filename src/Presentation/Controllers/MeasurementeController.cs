using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utilities;
using Presentation.ViewModels.Measurement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Response;

namespace Presentation.Controllers
{
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;
        private readonly IMapper _mapper;

        public MeasurementController(IMeasurementService measurementService, IMapper mapper)
        {
            _measurementService = measurementService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route("/api/measurements/create")]
        public async Task<IActionResult> Create([FromBody] CreateMeasurementViewModel viewModel)
        {
            try
            {
                var measurementDTO = _mapper.Map<MeasurementDTO>(viewModel);
                var measurementCreated = await _measurementService.Create(measurementDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Medição criada com sucesso!",
                    Success = true,
                    Data = measurementCreated
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
        [Route("/api/measurements/update")]
        public async Task<IActionResult> Update([FromBody] UpdateMeasurementViewModel viewModel)
        {
            try
            {
                var measurementDTO = _mapper.Map<MeasurementDTO>(viewModel);
                var measurementUpdated = await _measurementService.Update(measurementDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Medição atualizada com sucesso!",
                    Success = true,
                    Data = measurementUpdated
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
        [Route("/api/measurements/get/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var measurement = await _measurementService.Get(id);

                if (measurement == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma medição foi encontrada.",
                        Success = true,
                        Data = measurement
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Medição encontrada com sucesso!",
                    Success = true,
                    Data = measurement
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
        [Route("/api/measurements/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allMeasurements = await _measurementService.GetAll();

                return Ok(new ResultViewModel
                {
                    Message = "Medições encontradas com sucesso!",
                    Success = true,
                    Data = allMeasurements
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
