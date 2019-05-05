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
        private object _objectValue;
        [ProtoMember(3)]
        private int _intValue;
        [ProtoMember(5)]
        private double _doublevalue;
        [ProtoMember(7)]
        private float _floatValue;
        [ProtoMember(9)]
        private short _shortValue;
        [ProtoMember(11)]
        private bool _boolValue;
        [ProtoMember(13)]
        private char _charValue;

        public void Set(object response)
        {
            switch (response)
            {
                case bool b:
                    _boolValue = b;
                    break;
                case char c:
                    _charValue = c;
                    break;
                case short s:
                    _shortValue = s;
                    break;
                case float f:
                    _floatValue = f;
                    break;
                case double d:
                    _doublevalue = d;
                    break;
                case int i:
                    _intValue = i;
                    break;
                default:
                    _objectValue = response;
                    break;
            }
            
        }

        public object Get(Type paramType)
        {
            if (paramType == typeof(bool))
                return _boolValue;
            if (paramType == typeof(char))
                return _charValue;
            if (paramType == typeof(short))
                return _shortValue;
            if (paramType == typeof(float))
                return +_floatValue;
            if (paramType == typeof(double))
                return _doublevalue;
            if (paramType == typeof(int))
                return _intValue;
            return _objectValue;
        }
    }
}
