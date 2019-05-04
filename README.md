# Frenetik.Fabric.Remoting.Protobuf

## Overview
This library offers a serialization provider for Service Fabric implementing Protobuf.  This replaces the default Data Contract serializer.  You'll typically find this more flexible and faster, but I encourage you to do your own benchmarking before adopting this.

### To use

There is an example project highlighting Protobuf's ability to serialize interfaces, something Data Contract Serializer wasn't build for.  This is located in example/InterfaceSerialization.sln.

To get started in an existing project, there are two changes to make:

To your calling service, you need to create a service proxy factory with the right serializer:

```
var service =
    proxyFactory.CreateServiceProxy<IReceiverService>(
    new Uri("fabric:/Application/ServiceName"));
```

In your target service, you'll create a listener with the Protobuf serializer:

```
protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners() => new[]
{
    new ServiceInstanceListener(c => new FabricTransportServiceRemotingListener(c, this,
        serializationProvider: new ProtobufSerializationProvider()))
};

```

And that's it!

### Additional Notes

Tests are coming, I slapped this together for a SO question.