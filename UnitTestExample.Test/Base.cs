using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using UnitTestExample.App.Models;
using UnitTestExample.App.Repository;

namespace UnitTestExample.Test
{
    public class Base<TEntitiy> where TEntitiy : class
    {

        private readonly IServiceProvider serviceProvider;

        internal readonly IRepository<TEntitiy> _repo;

        public Base()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: true)
           .AddEnvironmentVariables()
           .Build();

            var services = new ServiceCollection();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<UnitTestDbContext>(options =>
            {
                options.UseSqlServer(configuration["SqlConn"]);
            });

            serviceProvider = services.BuildServiceProvider();

            _repo = serviceProvider.GetService<IRepository<TEntitiy>>();
        }
    }
}