using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace DomainCore
{
    [ProtoContract]
    public class Boat : IVehicle
    {
        [ProtoMember(1)]
        private Hull _hull;

        public Hull Hull { get => _hull; set => _hull = value; }

        [ProtoMember(2)]
        public int Propellers { get; set; }
    }
}
