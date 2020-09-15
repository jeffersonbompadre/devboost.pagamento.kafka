﻿using Drone.EnviarPedido.Api.Services;
using Drone.EnviarPedido.Api.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Devboost.Kafka.Test.Config
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

            var host = configuration["Kafka:host"];
            var topic = configuration["Kafka:topic"];
            int.TryParse(configuration["Kafka:port"], out int port);

            _services.AddScoped<IKafkaProducer>(x => new KafkaProducer(host, port, topic));

            //var urlAuthorization = configuration["EndPointDroneDelivery:urlAuthorization"];
            //var urlRealizarPedido = configuration["EndPointDroneDelivery:urlRealizarPedido"];
            //var urlPagamentoAtualizar = configuration["EndPointDroneDelivery:urlPagamentoAtualizar"];

            //_services.AddScoped<IAutorizationService>(x => new AutorizationService(urlAuthorization));
            //_services.AddScoped<IPedidoService>(x => new PedidoService(urlRealizarPedido));
            //_services.AddScoped<IPagamentoService>(x => new PagamentoService(urlPagamentoAtualizar));

            // Constroe o Provider
            ServiceProvider = _services.BuildServiceProvider();
        }
    }
}
