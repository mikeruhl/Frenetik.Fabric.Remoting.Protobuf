using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.ServiceFabric.Services.Remoting.V2;
using Microsoft.ServiceFabric.Services.Remoting.V2.Messaging;
using ProtoBuf;

namespace Frenetik.Fabric.Remoting.Protobuf
{
    public class ServiceRemotingRequestProtobufMessageBodySerializer : IServiceRemotingRequestMessageBodySerializer
    {
        public ServiceRemotingRequestProtobufMessageBodySerializer(Type serviceInterfaceType,
            IEnumerable<Type> parameterInfo)
        {
        }

        IOutgoingMessageBody IServiceRemotingRequestMessageBodySerializer.Serialize(IServiceRemotingRequestMessageBody serviceRemotingRequestMessageBody)
        {
            if (serviceRemotingRequestMessageBody == null)
            {
                return null;
            }

            var writeStream = new MemoryStream();
            Serializer.Serialize(writeStream, serviceRemotingRequestMessageBody);

            var segment = new ArraySegment<byte>(writeStream.ToArray());
            var segments = new List<ArraySegment<byte>> { segment };
            return new OutgoingMessageBody(segments);
        }

        public IServiceRemotingRequestMessageBody Deserialize(IIncomingMessageBody messageBody)
        {
            return Serializer.Deserialize<ProtobufRemotingRequestBody>(messageBody.GetReceivedBuffer());
        }
    }
}
