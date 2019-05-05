using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace DomainCore
{
    [ProtoContract]
    public class Hull
    {
        [ProtoMember(1)]
        public string Value { get; set; }

        [ProtoMember(2)]
        public bool WaterProof { get; set; }

    }
}
