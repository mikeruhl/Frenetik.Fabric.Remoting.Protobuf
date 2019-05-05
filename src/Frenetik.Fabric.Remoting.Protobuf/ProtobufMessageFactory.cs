using System;
using System.Linq;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.V2;

namespace Frenetik.Fabric.Remoting.Protobuf
{
    public class ProtobufMessageFactory : IServiceRemotingMessageBodyFactory
    {
        private Type _service;

        public ProtobufMessageFactory(Type service)
        {
            _service = service;
        }
        public IServiceRemotingRequestMessageBody CreateRequest(string interfaceName, string methodName, int numberOfParameters, object wrappedRequestObject)
        {
            var method = _service.GetMethod(methodName);
            var types = method.GetParameters().Select(p=>p.ParameterType).ToArray();
            return new ProtobufRemotingRequestBody(types);
        }

        public IServiceRemotingResponseMessageBody CreateResponse(string interfaceName, string methodName, object wrappedResponseObject)
        {
            return new ProtobufRemotingResponseBody();
        }
    }
}
