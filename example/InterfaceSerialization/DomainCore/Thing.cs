using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    [ProtoContract]
    public class Thing : IThing
    {
        [ProtoMember(1)]
        private OtherThing _otherThing;

        public OtherThing OtherThing { get => _otherThing; set => _otherThing = value; }
    }
}
