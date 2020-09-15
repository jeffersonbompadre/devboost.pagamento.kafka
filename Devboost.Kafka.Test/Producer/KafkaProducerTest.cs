using Devboost.Kafka.Test.Config;
using Drone.EnviarPedido.Api.Dto;
using Drone.EnviarPedido.Api.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Devboost.Kafka.Test.Producer
{
    public class KafkaProducerTest
    {
        readonly IKafkaProducer _kafkaProducer;

        public KafkaProducerTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;

            _kafkaProducer = _serviceProvider.GetService<IKafkaProducer>();
        }

        [Fact]
        public void ProducerTest()
        {
            var result = _kafkaProducer.RealizarPedido(new PedidoDto
            {
                Peso = 5,
                Bandeira = "VISA",
                Numero = "1234567890123456",
                CodigoSeguranca = 123,
                Valor = (decimal)500.20,
                Vencimento = DateTime.Now
            }).Result;
            Assert.NotNull(result);
        }
    }
}
