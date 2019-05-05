using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DomainCore;
using Frenetik.Fabric.Remoting.Protobuf;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Remoting.V2.FabricTransport.Client;
using Microsoft.ServiceFabric.Services.Runtime;

namespace Sender
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class Sender : StatelessService
    {
        public Sender(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[0];
        }

        /// <summary>
        /// This is the main entry point for your service instance.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following sample code with your own logic 
            //       or remove this RunAsync override if it's not needed in your service.

            long iterations = 0;

            var proxyFactory = new ServiceProxyFactory((c) =>
            {
                return new FabricTransportServiceRemotingClientFactory(
                    serializationProvider: new ProtobufSerializationProvider());
            });

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    var service =
                        proxyFactory.CreateServiceProxy<IReceiverService>(
                            new Uri("fabric:/InterfaceSerialization/Receiver"));

                    var vehicle = await service.GetVehicle(iterations);

                    switch (vehicle)
                    {
                        case Car c:
                            ServiceEventSource.Current.ServiceMessage(this.Context,
                                $"I got a car: {c.Hull.Value}.  It has {c.Doors} doors, is it waterproof: {c.Hull.WaterProof}");
                            break;
                        case Boat b:
                            ServiceEventSource.Current.ServiceMessage(this.Context,
                                $"I got a boat: {b.Hull.Value}.  It has {b.Propellers} propellers, is it waterproof: {b.Hull.WaterProof}");
                            break;
                    }


                }
                catch (Exception e)
                {
                    ServiceEventSource.Current.ServiceMessage(this.Context, $"Experienced Exception: {0}", e.Message);
                }
                finally
                {
                    iterations++;
                }


                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
    }
}
