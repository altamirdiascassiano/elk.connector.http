using elk.connector.http;
using System;

namespace TesteManualConsole
{
    class TesteManual
    {
        static void Main(string[] args)
        {
            var configuration= new ConfigurationConnectorClient();
            var httpConnectorClient = new HttpConnectorClient(configuration);
            
            Console.WriteLine("Quantas mensagem?");
            var countMessages = Int32.Parse(Console.ReadLine());
            var elkMessage = new ElkMessage();

            for (int i = 0; i < countMessages; i++)
            {
                elkMessage.Mensagem = string.Concat("Process message= ",i);
                elkMessage.ProcessoUnico = Guid.NewGuid().ToString();
                httpConnectorClient.Send(elkMessage);
                Console.WriteLine($"Mensage " + (i+1) + " sended");
            }
            Console.ReadLine();
        }
    }
}
