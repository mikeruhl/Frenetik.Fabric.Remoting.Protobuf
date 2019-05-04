using Microsoft.ServiceFabric.Services.Remoting.V2;

namespace Frenetik.Fabric.Remoting.Protobuf
{
    public class ProtobufMessageFactory : IServiceRemotingMessageBodyFactory
    {
        public IServiceRemotingRequestMessageBody CreateRequest(string interfaceName, string methodName, int numberOfParameters, object wrappedRequestObject)
        {
            return new ProtobufRemotingRequestBody();
        }

        public IServiceRemotingResponseMessageBody CreateResponse(string interfaceName, string methodName, object wrappedResponseObject)
        {
            return new ProtobufRemotingResponseBody();
        }
    }
}
