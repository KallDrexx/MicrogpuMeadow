﻿using System.Net.Sockets;
using MicrogpuMeadow.Common.Operations;

namespace MicrogpuMeadow.Tcp;

public class MicrogpuTcpClient : IDisposable
{
    private readonly Socket _socket = new(SocketType.Stream, ProtocolType.Tcp);
    private readonly string _host;
    private readonly int _port;
    private readonly List<byte> _buffer = new();
    
    public MicrogpuTcpClient(string host, int port)
    {
        _host = host;
        _port = port;
    }
    
    public async Task ConnectAsync()
    {
        await _socket.ConnectAsync(_host, _port);
    }
    
    public async Task SendOperationAsync(IOperation operation)
    {
        if (!_socket.Connected)
        {
            await ConnectAsync();
        }
        
        operation.Serialize(_buffer);
        
        var lengthByte1 = (byte)(_buffer.Count >> 8);
        var lengthByte2 = (byte)(_buffer.Count & 0xFF);
        
        _buffer.Insert(0, lengthByte1);
        _buffer.Insert(1, lengthByte2);
        
        await _socket.SendAsync(_buffer.ToArray(), SocketFlags.None);
    }

    public void Dispose()
    {
        _socket.Dispose();
    }
}