using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace DomainCore
{
    [ProtoContract]
    public class OtherThing
    {
        [ProtoMember(1)]
        public string Value { get; set; }

    }
}
