using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace AmazonModule
{
    public class AmazonSigningEndpointBehavior : IEndpointBehavior
    {
        private readonly string _accessKeyId = "";
        private readonly string _secretKey = "";

        public AmazonSigningEndpointBehavior(string accessKeyId, string secretKey)
        {
            _accessKeyId = accessKeyId;
            _secretKey = secretKey;
        }

        public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new AmazonSigningMessageInspector(_accessKeyId, _secretKey));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher) { }
        public void Validate(ServiceEndpoint serviceEndpoint) { }
        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters) { }
    }
}
