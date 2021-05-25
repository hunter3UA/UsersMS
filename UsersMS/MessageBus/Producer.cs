using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using UsersMS.Models.Events;
using System.Text;

namespace UsersMS.MessageBus
{
    public static class Producer       
    {
        private static string rmqServiceAddress = "localhost";
        private static ConnectionFactory rmConnectionFactory
            = new ConnectionFactory() { HostName = rmqServiceAddress };
        // укзать название очереди сообщений для событий пользователей
        // если очереди нет  - она будет создана автоматически 
        private static string usersMsQueueName = "UsersMs-events";

        public static void UserDeleted(int userID)
        {
            // устанавливаем соединение со службой RabbitMq
            using(IConnection rmqConnection = rmConnectionFactory.CreateConnection())
            {
                // устанавливаем канал связи с сервисом 
                using (IModel channel = rmqConnection.CreateModel())
                {
                    // Подкючаемся к очереди сообщений 
                    channel.QueueDeclare(
                        queue:usersMsQueueName,
                        durable:false,
                        exclusive:false,
                        autoDelete:true // автоматичеки удалять сообщение из очереди как только получатель его получит 
                        );
                    // готовим сообщение к отправки. Сообщение  - єто об єкт произвольного формата 
                    UserEvent message = new UserEvent() { EventType = "UserDeleted", PayLoad = userID.ToString() };
                    // чтобы сделать сообщение платформонезависимой мы преобразуем его в общедоступный формат JSON
                    string messageJSON = JsonConvert.SerializeObject(message);
                    // главное что б он был представлен в веди массива байт для передачи по сети 
                    byte[] messageBinary = Encoding.UTF8.GetBytes(messageJSON);
                    // Публикуем сообщение в очереди Rabbit
                    channel.BasicPublish(
                        exchange: "",
                        routingKey: usersMsQueueName,
                        mandatory: false,
                        basicProperties:null,
                        body:messageBinary
                        );
                }
            }
        }
    }
}
