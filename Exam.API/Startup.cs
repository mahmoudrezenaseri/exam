using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ackee.Config;
using Ackee.Config.Autofac;
using Ackee.Config.Loader;
using Ackee.Core;
using Ackee.DataAccess.EfCore;
using Ackee.Logger;
using Autofac;
using Exam.API.Controllers;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Exam.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Exam.API", Version = "v1" }); });
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        var connectionString = "Data Source=.;Initial Catalog=Khoros;integrated security=true";
        AckeeLoader.Create()
            .RegisterIocModule(new AutofacAckeeModule(builder))
            .RegisterModule(new ExamModule(connectionString))
            .RegisterModule(new LoggerAckeeModule())
            .RegisterModule(new EfCoreModule(new EfCoreConfiguration()
            {
                ConnectionString = connectionString
            }))
            .RegisterBc(new BcConfig()
            {
                Code = 1000,
                Name = "Khoros"
            })
            .Install();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exam.API v1"));
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}

public class ExamModule : IAckeeModule
{
    private readonly string _connectionString;

    public ExamModule(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Load(IRegistration registration)
    {
        registration.RegisterRepositories(typeof(UserRepository).Assembly);
        registration.RegisterControllers(typeof(UserController).Assembly);
        registration.RegisterInstanceAsScoped(a => CreateDbContext());
        registration.RegisterInstanceAsScoped<AckeeDbContext>(a => a.Resolve<ExamDbContext>());
    }

    private ExamDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder().UseSqlServer(_connectionString);
        return new ExamDbContext(options.Options);
    }
}