using Application.DTO;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Presentation.Token;
using Presentation.ViewModels.Devices;
using Presentation.ViewModels.Measurement;
using Services;
using System.Text;
using ViewModels.Devices;
using ViewModels.Login;
using ViewModels.User;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Desafio Back-End",
        Version = "v1",
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor utilize Bearer <TOKEN>",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
});

var configuration = builder.Configuration;

#region jwt

var secretKey = configuration["Jwt:Key"];

builder.Services.AddAuthentication( x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
        };
    });

#endregion

#region automapper
var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, UserDTO>().ReverseMap();
    cfg.CreateMap<UserDTO, User>().ReverseMap();
    cfg.CreateMap<Device, DeviceDTO>().ReverseMap();
    cfg.CreateMap<Command, CommandDTO>().ReverseMap();
    cfg.CreateMap<Parameter, ParameterDTO>().ReverseMap();
    cfg.CreateMap<Measurement, MeasurementDTO>().ReverseMap();
    cfg.CreateMap<MeasurementDTO, Measurement>().ReverseMap();

    cfg.CreateMap<CreateUserViewModel,UserDTO>().ReverseMap();
    cfg.CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();

    cfg.CreateMap<UpdateDeviceViewModel, DeviceDTO>()
     .ForMember(dest => dest.Commands, opt => opt.MapFrom(src => src.Commands))
     .ForMember(dest => dest.Commands, opt => opt.MapFrom(src => src.Commands.Select(c => new CommandDTO
     {
         Id = c.Id,
         Name = c.Name,
         Description = c.Description,
         Parameters = c.Parameters.Select(p => new ParameterDTO
         {
             Id = p.Id,
             Name = p.Name,
             Description = p.Description
         }).ToList()
     })))
     .ReverseMap();
    cfg.CreateMap<CreateDeviceViewModel, DeviceDTO>().ReverseMap();

    cfg.CreateMap<CreateCommandViewModel, CommandDTO>().ReverseMap();
    cfg.CreateMap<UpdateCommandViewModel, CommandDTO>().ReverseMap();

    cfg.CreateMap<UpdateParameterViewModel, ParameterDTO>().ReverseMap();
    cfg.CreateMap<CreateParameterViewModel, ParameterDTO>().ReverseMap();

    cfg.CreateMap<CreateMeasurementViewModel, MeasurementDTO>().ReverseMap();
    cfg.CreateMap<UpdateMeasurementViewModel, MeasurementDTO>().ReverseMap();
});
#endregion

#region DI
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<ICommandRepository, CommandRepository>();
builder.Services.AddScoped<IParameterRepository, ParameterRepository>();

builder.Services.AddScoped<IMeasurementRepository, MeasurementRepository>();
builder.Services.AddScoped<IMeasurementService, MeasurementService>();

#endregion


builder.Services.AddSingleton(d => configuration);
builder.Services.AddDbContext<ManagerContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DESAFIO_BACK_END"]), ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();