using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace DomainCore
{
    [ProtoContract]
    public interface IThing
    {
        [ProtoMember(1)]
        OtherThing OtherThing { get; set; }
    }
}
