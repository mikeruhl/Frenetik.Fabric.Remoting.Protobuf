
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

        public async Task<IThing> GetThing(string value)
        {
            var thing = new Thing { OtherThing = new OtherThing() };
            thing.OtherThing.Value = $"Response: {value}";
            return thing;
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
