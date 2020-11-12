using System.Reflection;
using System.Resources;

namespace elk.connector.http
{
    public class ConfigurationConnectorClient
    {
        public string EndPoint { get; set; }

        public ConfigurationConnectorClient(string UriEndPoint)
        {
            this.EndPoint = UriEndPoint;
        }
        public ConfigurationConnectorClient()
        {
            ResourceManager rm = new ResourceManager("elk.connector.http.Resource", Assembly.GetExecutingAssembly());
            this.EndPoint = rm.GetString("DefaultEndPointHttp");
        }
    }
}
