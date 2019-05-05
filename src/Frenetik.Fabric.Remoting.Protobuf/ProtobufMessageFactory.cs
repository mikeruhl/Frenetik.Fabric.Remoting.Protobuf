using System;
using System.Linq;
using System.Reflection;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.V2;

namespace Frenetik.Fabric.Remoting.Protobuf
{
    public class ProtobufMessageFactory : IServiceRemotingMessageBodyFactory
    {

        public ProtobufMessageFactory()
        {
        }
        public IServiceRemotingRequestMessageBody CreateRequest(string interfaceName, string methodName, int numberOfParameters, object wrappedRequestObject)
        {
            Type type = null;
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                type = assembly.GetType(interfaceName);
                if (type != null)
                    break;
            }
            if (type == null)
                throw new ArgumentException($"Interface not found: {interfaceName}");
            var method = type.GetMethod(methodName);
            if (method == null)
                throw new ArgumentException($"Method could not be found: {interfaceName}");
            var types = method.GetParameters().Select(p=>p.ParameterType).ToArray();
            return new ProtobufRemotingRequestBody(types);
        }

        public IServiceRemotingResponseMessageBody CreateResponse(string interfaceName, string methodName, object wrappedResponseObject)
        {
            return new ProtobufRemotingResponseBody();
        }
    }
}
