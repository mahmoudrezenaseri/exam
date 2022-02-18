using Exam.API;
using Exam.Persistence.SqlServer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;

namespace Exam.IntegrationTests
{
    public abstract class IntegrationTest
    {
        protected HttpClient GetClient(Action<ExamDbContext> InitializeDbForTestAction = null) 
        {
            var applicationFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                 {
                     builder.ConfigureServices(services =>
                     {
                         var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ExamDbContext>));
                         services.Remove(descriptor);

                         services.AddDbContext<ExamDbContext>(options =>
                         {
                             options.UseInMemoryDatabase("InMemoryDbForTesting");
                         });


                         var sp = services.BuildServiceProvider();
                         using (var scope = sp.CreateScope())
                         {
                             var scopedServices = scope.ServiceProvider;
                             var db = scopedServices.GetRequiredService<ExamDbContext>();

                             db.Database.EnsureDeleted();
                             db.Database.EnsureCreated();

                             InitializeDbForTests(db);

                             if(InitializeDbForTestAction != null)
                                InitializeDbForTestAction.Invoke(db);
                         }
                     });
                 });

            return applicationFactory.CreateClient();
        }

        private void InitializeDbForTests(ExamDbContext db) 
        {
            // add global data on db
        }
    }
}