using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.ServiceFabric.Services.Remoting.V2;
using Microsoft.ServiceFabric.Services.Remoting.V2.Messaging;
using ProtoBuf;

namespace Frenetik.Fabric.Remoting.Protobuf
{
    public class ServiceRemotingResponseProtobufMessageBodySerializer : IServiceRemotingResponseMessageBodySerializer
    {
        public ServiceRemotingResponseProtobufMessageBodySerializer(Type serviceInterfaceType,
            IEnumerable<Type> parameterInfo)
        {
        }

        IOutgoingMessageBody IServiceRemotingResponseMessageBodySerializer.Serialize(IServiceRemotingResponseMessageBody serviceRemotingResponseMessageBody)
        {
            byte[] bytes;
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, serviceRemotingResponseMessageBody);
                bytes = ms.ToArray();
            }

            var segment = new ArraySegment<byte>(bytes);
            var list = new List<ArraySegment<byte>> { segment };
            return new OutgoingMessageBody(list);
        }

        public IServiceRemotingResponseMessageBody Deserialize(IIncomingMessageBody messageBody)
        {
            return Serializer.Deserialize<ProtobufRemotingResponseBody>(messageBody.GetReceivedBuffer());
        }
    }
}
