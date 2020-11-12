using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace elk.connector.http
{
    public class HttpConnectorClient
    {
        static readonly HttpClient client = new HttpClient();
        static private ConfigurationConnectorClient _configuration= null;

        public HttpConnectorClient(ConfigurationConnectorClient configuration)
        {
            _configuration = configuration;
            client.BaseAddress = new Uri(_configuration.EndPoint);
        }
        public HttpConnectorClient()
        {
            if (_configuration == null){
                _configuration = new ConfigurationConnectorClient();
                client.BaseAddress = new Uri(_configuration.EndPoint);
            }
                
        }
        public async Task Send(ElkMessage elkMessage)
        {           
            try
            {
                elkMessage = elkMessage ?? new ElkMessage(){ProcessoUnico= Guid.NewGuid().ToString(), Mensagem= "N/A" };
                var dtElkFormat = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                elkMessage.DataMensagem = dtElkFormat;                
                var json = JsonConvert.SerializeObject(elkMessage); 
                var content =  new StringContent(json, Encoding.UTF8, "application/json");
                
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage() { RequestUri = new Uri(_configuration.EndPoint), Method = HttpMethod.Post, Content = content};              
                client.SendAsync(httpRequestMessage);               
            }
            catch (HttpRequestException ex)
            {
                var erroMessage = ex.Message;
            }
        }
    }

}