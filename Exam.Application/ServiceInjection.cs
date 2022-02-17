namespace Exam.Application;

using AutoMapper;
using Exam.Application.Features.Users.Mapping;
using Exam.Domain.Interfaces;
using Exam.Repositories.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class ServiceInjection
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddScoped<IMediator, Mediator>();
        services.AddMediatR(Assembly.GetExecutingAssembly());

        var mapperConfig = new MapperConfiguration(mc => mc.AddProfile<UserMapping>());
        var mapper = mapperConfig.CreateMapper();

        services.AddSingleton(mapper);
    }
}
