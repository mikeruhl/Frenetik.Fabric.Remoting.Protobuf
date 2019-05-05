using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    [ProtoContract]
    public class Car : IVehicle
    {
        [ProtoMember(1)]
        private Hull _hull;

        public Hull Hull { get => _hull; set => _hull = value; }
        [ProtoMember(3)]
        public int Doors { get; set; }
    }
}
