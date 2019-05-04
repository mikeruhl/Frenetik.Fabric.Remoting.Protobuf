using System;
using System.Collections.Generic;
using Microsoft.ServiceFabric.Services.Remoting.V2;
using ProtoBuf;

namespace Frenetik.Fabric.Remoting.Protobuf
{
    [ProtoInclude(10, typeof(object))]
    [ProtoContract]
    public class ProtobufRemotingRequestBody : IServiceRemotingRequestMessageBody
    {
        [ProtoMember(1, DynamicType = true)]
        public readonly Dictionary<string, object> parameters = new Dictionary<string, object>();

        public void SetParameter(int position, string parameName, object parameter)
        {
            this.parameters[parameName] = parameter;
        }

        public object GetParameter(int position, string parameName, Type paramType)
        {
            return this.parameters[parameName];
        }
    }
}
