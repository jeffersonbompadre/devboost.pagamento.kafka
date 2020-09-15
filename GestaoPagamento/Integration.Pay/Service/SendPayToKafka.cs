using Confluent.Kafka;
using Integration.Pay.Dto;
using Integration.Pay.Interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Integration.Pay.Service
{
    public class SendPayToKafka : ISendPayToKafka
    {
        readonly string _host;
        readonly int _port;
        readonly string _topic;

        public SendPayToKafka(string host, int port, string topic)
        {
            _host = host;
            _port = port;
            _topic = topic;
        }

        public async Task<DeliveryResult<Null, string>> SendPay(RequestPaymentDto requestPaymentDto)
        {
            if (requestPaymentDto == null)
                return null;

            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = $"{_host}:{_port}"
            };

            using IProducer<Null, string> producer = new ProducerBuilder<Null, string>(config).Build();
            var result = await producer.ProduceAsync(
                _topic,
                new Message<Null, string>
                {
                    Value = ConvertObjectToJson(requestPaymentDto)
                }
            );

            return result;
        }

        private string ConvertObjectToJson(RequestPaymentDto requestPaymentDto) =>
            JsonConvert.SerializeObject(requestPaymentDto);
    }
}
