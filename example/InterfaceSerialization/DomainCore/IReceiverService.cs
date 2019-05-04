using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    public interface IReceiverService: IService
    {
        Task<IThing> GetThing(string value);
    }
}
