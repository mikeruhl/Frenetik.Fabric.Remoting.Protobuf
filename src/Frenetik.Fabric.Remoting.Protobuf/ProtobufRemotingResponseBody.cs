using System;
using Microsoft.ServiceFabric.Services.Remoting.V2;
using ProtoBuf;

namespace Frenetik.Fabric.Remoting.Protobuf
{
    [ProtoInclude(10, typeof(object))]
    [ProtoContract]
    internal class ProtobufRemotingResponseBody : IServiceRemotingResponseMessageBody
    {
        [ProtoMember(1, DynamicType = true)]
        public object Value;

        public void Set(object response)
        {
            this.Value = response;
        }

        public object Get(Type paramType)
        {
            return this.Value;
        }
    }
}
