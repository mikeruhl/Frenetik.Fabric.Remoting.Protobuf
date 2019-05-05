using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.V2;
using ProtoBuf;

namespace Frenetik.Fabric.Remoting.Protobuf
{
    public class ProtobufSerializationProvider : IServiceRemotingMessageSerializationProvider
    {
        public IServiceRemotingMessageBodyFactory CreateMessageBodyFactory()
        {
            return new ProtobufMessageFactory();
        }

        public IServiceRemotingRequestMessageBodySerializer CreateRequestMessageSerializer(Type serviceInterfaceType, IEnumerable<Type> requestWrappedTypes, IEnumerable<Type> requestBodyTypes = null)
        {
            return new ServiceRemotingRequestProtobufMessageBodySerializer(serviceInterfaceType, requestBodyTypes);
        }

        public IServiceRemotingResponseMessageBodySerializer CreateResponseMessageSerializer(Type serviceInterfaceType, IEnumerable<Type> responseWrappedTypes, IEnumerable<Type> responseBodyTypes = null)
        {
            return new ServiceRemotingResponseProtobufMessageBodySerializer(serviceInterfaceType, responseBodyTypes);
        }
    }
}
