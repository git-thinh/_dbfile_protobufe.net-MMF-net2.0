https://code.google.com/archive/p/protobuf-remote/
==================================================================

RPC implementation for C# and C++ using Protocol Buffers

ProtoBufRemote is an RPC implementation for C# and C++ using Google's Protocol Buffers as the transport mechanism.

Guides

C#: * Getting started guide * Manual * Building guide C++: * Getting started guide * Manual * Building guide

Features: 

- Using protocol buffers as the transport mechanism allows a multi-platform, multi-language implementation
- Uses the official protobuf implementation for C++, uses protobuf-net for C#
- Automatic handling of simple parameter types, no need to define protocol buffer messages for every RPC call
- Protocol buffer messages can be used for complex parameters and return values
- Both asynchronous and blocking programming models are available when making RPC calls
- Full two way communication, both ends of the channel can make and receive RPC calls
- C#: Reflection Emit implementation for maximum performance
- C#: Dynamic proxy type support using the DLR
- C++: Optional service and proxy code generation using Boost Preprocessor library


Creating the service definition

An interface can optionally be used to define the service. It can then be used by both the server and the client.

public interface ISampleService { int GetSquare(int x); string GetDate(); }

Creating a RPC server:

First the service should be implemented: ``` 

public class SampleService : ISampleService { 

public int GetSquare(int x) { return x*x; }

public string GetDate()
{
    return DateTime.Now.ToLongDateString();
}

Then the server can be created to handle requests to this service: ``` 

//create the server var controller = new RpcController(); 
server = new RpcServer(controller);

//register the service with the server. We must specify the interface explicitly since we did not use attributes server.RegisterService(new SampleService());

//create and start the channel which will receive requests 

var channel = new NetworkStreamRpcChannel(controller, networkStream); 
channel.Start(); ```

Creating a RPC client:

First we create the client which will be used to send the requests: ``` 

//create the client 
var controller = new RpcController(); 
client = new RpcClient(controller);

//create and start the channel which will receive requests 
var channel = new NetworkStreamRpcChannel(controller, networkStream); 
channel.Start(); ```

Now a proxy can be created to make calls to a particular service: ``` 
ISampleService service = client.GetProxy();

//now calls can be made, they will block until a result is received 

int x = service.GetSquare(10); 
string date = service.GetDate(); ```