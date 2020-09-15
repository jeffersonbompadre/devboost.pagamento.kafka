using Consumer.Drone.AzureFunction.Config;
using IoC.Pay;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Tests.Pay.TDD.Config
{
    public class StartInjection
    {
        public StartInjection()
        {
            BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider { get; private set; }

        void BuildServiceProvider()
        {
            var _services = new ServiceCollection();

            IConfiguration configuration = StartConfiguration.Configuration;
            _services.AddSingleton(x => configuration);

            _services.RegisterDbContextInMemory();
            _services.RegisterServices(configuration, true);

            ServiceProvider = _services.BuildServiceProvider();
        }
    }
}
