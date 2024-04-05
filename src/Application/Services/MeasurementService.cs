using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infra.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMapper _mapper;
        private readonly IMeasurementRepository _measurementRepository;

        public MeasurementService(IMapper mapper, IMeasurementRepository measurementRepository)
        {
            _mapper = mapper;
            _measurementRepository = measurementRepository;
        }

        public async Task<MeasurementDTO> Create(MeasurementDTO measurementDTO)
        {
            var measurementEntity = _mapper.Map<Measurement>(measurementDTO);

            var createdMeasurement = await _measurementRepository.Create(measurementEntity);
            return _mapper.Map<MeasurementDTO>(createdMeasurement);
        }

        public async Task<MeasurementDTO> Update(MeasurementDTO measurementDTO)
        {
            var measurementEntity = _mapper.Map<Measurement>(measurementDTO);

            var updatedMeasurement = await _measurementRepository.Update(measurementEntity);
            return _mapper.Map<MeasurementDTO>(updatedMeasurement);
        }

        public async Task<MeasurementDTO> Get(long id)
        {
            var measurementEntity = await _measurementRepository.Get(id);
            return _mapper.Map<MeasurementDTO>(measurementEntity);
        }

        public async Task<List<MeasurementDTO>> GetAll()
        {
            var measurements = await _measurementRepository.GetAll();
            return _mapper.Map<List<MeasurementDTO>>(measurements);
        }
    }
}