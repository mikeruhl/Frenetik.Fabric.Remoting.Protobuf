
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;
using DomainCore;
using Frenetik.Fabric.Remoting.Protobuf;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.V2.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace Receiver
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class Receiver : StatelessService, IReceiverService
    {
        public Receiver(StatelessServiceContext context)
            : base(context)
        { }

        public async Task<IVehicle> GetVehicle(long id)
        {
            var random = new Random();
            if (id % 2 == 0)
            {
                return new Car { Hull = new Hull { Value = $"Car Shell: {id}" }, Doors = random.Next(6) };
            }
            return new Boat { Hull = new Hull { Value = $"Boat Shell: {id}", WaterProof = true }, Propellers = random.Next(1,3)};
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners() => new[]
        {
            new ServiceInstanceListener(c => new FabricTransportServiceRemotingListener(c, this,
                serializationProvider: new ProtobufSerializationProvider()))
        };

    }

}
