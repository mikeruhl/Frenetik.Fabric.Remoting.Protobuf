using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace DomainCore
{
    [ProtoContract]
    public interface IVehicle
    {
        [ProtoMember(1)]
        Hull Hull { get; set; }
    }
}
