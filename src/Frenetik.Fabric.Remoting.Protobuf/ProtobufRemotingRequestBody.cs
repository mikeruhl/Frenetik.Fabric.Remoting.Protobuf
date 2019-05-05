using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using Microsoft.ServiceFabric.Services.Remoting.V2;
using ProtoBuf;

namespace Frenetik.Fabric.Remoting.Protobuf
{
    [ProtoInclude(10, typeof(object))]
    [ProtoContract]
    public class ProtobufRemotingRequestBody : IServiceRemotingRequestMessageBody
    {
        public ProtobufRemotingRequestBody()
        {
            
        }
        public ProtobufRemotingRequestBody(Type[] types)
        {
            _types = types;
        }
        [ProtoMember(300)]
        private Type[] _types;

        [ProtoMember(1, DynamicType = true)]
        private readonly Dictionary<string, object> parameters = new Dictionary<string, object>();
        [ProtoMember(3)]
        private readonly Dictionary<string, short> shortParameters = new Dictionary<string, short>();
        [ProtoMember(5)]
        private readonly Dictionary<string, char> charParameters = new Dictionary<string, char>();
        [ProtoMember(7)]
        private readonly Dictionary<string, float> floatParameters = new Dictionary<string, float>();
        [ProtoMember(9)]
        private readonly Dictionary<string, double> doubleParameters = new Dictionary<string, double>();
        [ProtoMember(11)]
        private readonly Dictionary<string, bool> boolParameters = new Dictionary<string, bool>();
        [ProtoMember(13)]
        private readonly Dictionary<string, int> intParameters = new Dictionary<string, int>();
        [ProtoMember(15)]
        private readonly Dictionary<string, long> longParameters = new Dictionary<string, long>();

        public void SetParameter(int position, string parameName, object parameter)
        {
            if (_types[position] == typeof(bool))
                boolParameters.Add(parameName, (bool)parameter);
            else if (_types[position] == typeof(char))
                charParameters.Add(parameName, (char)parameter);
            else if (_types[position] == typeof(short))
                shortParameters.Add(parameName, (short)parameter);
            else if (_types[position] == typeof(float))
                floatParameters.Add(parameName, (float)parameter);
            else if (_types[position] == typeof(double))
                doubleParameters.Add(parameName, (double)parameter);
            else if (_types[position] == typeof(int))
                intParameters.Add(parameName, (int)parameter);
            else if (_types[position] == typeof(long))
                longParameters.Add(parameName, (long)parameter);
            else
            parameters.Add(parameName, parameter);
        }

        public object GetParameter(int position, string parameName, Type paramType)
        {
            if (paramType == typeof(bool))
                return boolParameters[parameName];
            if (paramType == typeof(char))
                return charParameters[parameName];
            if (paramType == typeof(short))
                return shortParameters[parameName];
            if (paramType == typeof(float))
                return floatParameters[parameName];
            if (paramType == typeof(double))
                return doubleParameters[parameName];
            if (paramType == typeof(int))
                return intParameters[parameName];
            if (paramType == typeof(long))
                return longParameters[parameName];
            return parameters[parameName];
        }
    }

}
