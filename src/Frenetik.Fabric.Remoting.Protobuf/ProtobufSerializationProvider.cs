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
        private Type _service;

        public ProtobufSerializationProvider(Type iService)
        {
            if (iService.GetInterface("IService") == null)
                throw new ArgumentException("Service Passed must inherit type IService");
            _service = iService;

        }
        public IServiceRemotingMessageBodyFactory CreateMessageBodyFactory()
        {
            return new ProtobufMessageFactory(_service);
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
