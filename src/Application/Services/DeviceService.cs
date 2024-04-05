using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Core.Exceptions;
using Domain.Entities;
using Infra.Interfaces;
using Infra.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IMapper _mapper;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMeasurementRepository _measurementRepository;

        public DeviceService(IMapper mapper, IDeviceRepository deviceRepository, IMeasurementRepository measurementRepository)
        {
            _mapper = mapper;
            _deviceRepository = deviceRepository;
            _measurementRepository = measurementRepository;
        }

        public async Task<DeviceDTO> Create(DeviceDTO deviceDTO)
        {
            var device = _mapper.Map<Device>(deviceDTO);
            device.Validate();

            if (deviceDTO.Commands != null)
            {
                foreach (var command in deviceDTO.Commands)
                {
                    if (command.Parameters != null)
                    {
                        foreach (var parameter in command.Parameters)
                        {
                            var measurement = await _measurementRepository.GetByParameterName(parameter.Name);

                            if (measurement != null && deviceDTO.Manufacturer == "PredictWeather" && command.Name == "get_rainfall_intensity")
                            {
                                device.MeasurementId = measurement.Id;
                            }
                            else
                            {
                                throw new DomainExceptions($"Parâmetros incorretos. Corrija-os!");
                            }
                        }
                    }
                }
            }

            var deviceCreated = await _deviceRepository.Create(device);

            return _mapper.Map<DeviceDTO>(deviceCreated);
        }

        public async Task<DeviceDTO> Update(DeviceDTO deviceDTO)
        {
            var existingDevice = await _deviceRepository.Get(deviceDTO.Id);

            if (existingDevice == null)
            {
                throw new DomainExceptions("Não existe nenhum dispositivo com o ID informado!");
            }

            _mapper.Map(deviceDTO, existingDevice);

            existingDevice.Validate();

            if (deviceDTO.Commands != null)
            {
                foreach (var command in deviceDTO.Commands)
                {
                    if (command.Parameters != null)
                    {
                        foreach (var parameter in command.Parameters)
                        {
                            var measurement = await _measurementRepository.GetByParameterName(parameter.Name);

                            if (measurement != null && deviceDTO.Manufacturer == "PredictWeather" && command.Name == "get_rainfall_intensity")
                            {
                                existingDevice.MeasurementId = measurement.Id;
                            }
                            else
                            {
                                throw new DomainExceptions($"Nenhuma medição correspondente encontrada para o nome do parâmetro '{parameter.Name}' fornecido.");
                            }
                        }
                    }
                }
            }

            var updatedDevice = await _deviceRepository.Update(existingDevice);

            return _mapper.Map<DeviceDTO>(updatedDevice);
        }

        public async Task Delete(long id)
        {
            await _deviceRepository.Delete(id);
        }

        public async Task<DeviceDTO> Get(long id)
        {
            var device = await _deviceRepository.Get(id);

            if (device == null)
            {
                throw new DomainExceptions("Não existe nenhum dispositivo com o id informado!");
            }

            return _mapper.Map<DeviceDTO>(device);
        }

        public async Task<List<DeviceDTO>> GetAll()
        {

            var allDevices = await _deviceRepository.GetAllDevices();

            return _mapper.Map<List<DeviceDTO>>(allDevices);
        }

        public async Task<List<DeviceDTO>> GetDevicesWithRainfallIntensity()
        {
            var devices = await _deviceRepository.GetAllDevices();

            var devicesWithRainfallIntensity = new List<DeviceDTO>();

            foreach (var device in devices)
            {
                if (device.Manufacturer == "PredictWeather")
                {
                    var rainfallIntensityCommand = device.Commands.FirstOrDefault(c => c.Name == "get_rainfall_intensity");
                    if (rainfallIntensityCommand != null)
                    {
                        var measurement = await _measurementRepository.Get((long)device.MeasurementId);
                        if (measurement != null)
                        {
                            var deviceDTO = _mapper.Map<DeviceDTO>(device);
                            var measurementDTO = _mapper.Map<MeasurementDTO>(measurement);

                            deviceDTO.Measurement = measurementDTO;

                            deviceDTO.Commands = _mapper.Map<List<CommandDTO>>(device.Commands);
                            foreach (var command in deviceDTO.Commands)
                            {
                                command.Parameters = _mapper.Map<List<ParameterDTO>>(command.Parameters);
                            }

                            devicesWithRainfallIntensity.Add(deviceDTO);
                        }
                    }
                }
            }
            return devicesWithRainfallIntensity;
        }
    }
}
