using System.Net.Sockets;
using MicrogpuMeadow.Common.Operations;

var buffer = new List<byte>();

var client = new Socket(SocketType.Stream, ProtocolType.Tcp);
await client.ConnectAsync("127.0.0.1", 9123);

var initializeOperation = new InitializeOperation
{
    FrameBufferScale = 1
};

initializeOperation.Serialize(buffer);
var lengthByte1 = (byte)(buffer.Count >> 8);
var lengthByte2 = (byte)(buffer.Count & 0xFF);

buffer.Insert(0, lengthByte1);
buffer.Insert(1, lengthByte2);
await client.SendAsync(buffer.ToArray(), SocketFlags.None);

while(true) {}