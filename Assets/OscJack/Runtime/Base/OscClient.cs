// OSC Jack - Open Sound Control plugin for Unity
// https://github.com/keijiro/OscJack

using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace OscJack
{
    public sealed class OscClient : IDisposable
    {
        #region Object life cycle

        [SerializeField]
        private string targetIP;

        [SerializeField]
        private int targetPort;

        public OscClient(string destination, int port)
        {
            targetIP = destination;
            targetPort = port;

            //Debug.Log("***************************** OscClient");

            clientSetup();
        }

        // makes sure that needed state has been defined
        void clientSetup()
        {
            if (_encoder == null) _encoder = new OscPacketEncoder();

            if (_socket != null) return;

            //Debug.Log("******************************* clientSetup");
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            if (targetIP == "255.255.255.255")
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);

            var dest = new IPEndPoint(IPAddress.Parse(targetIP), targetPort);
            _socket.Connect(dest);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Packet sender methods

        public void Send(string address)
        {
            clientSetup();

             
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",");
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, int data)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",i");
            _encoder.Append(data);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, string element1, int element2)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",si");
            _encoder.Append(element1);
            _encoder.Append(element2);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, int element1, int element2)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",ii");
            _encoder.Append(element1);
            _encoder.Append(element2);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, int element1, int element2, int element3)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",iii");
            _encoder.Append(element1);
            _encoder.Append(element2);
            _encoder.Append(element3);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, float data)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",f");
            _encoder.Append(data);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, float element1, float element2)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",ff");
            _encoder.Append(element1);
            _encoder.Append(element2);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, float element1, float element2, float element3)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",fff");
            _encoder.Append(element1);
            _encoder.Append(element2);
            _encoder.Append(element3);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, float element1, float element2, float element3, float element4)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",ffff");
            _encoder.Append(element1);
            _encoder.Append(element2);
            _encoder.Append(element3);
            _encoder.Append(element4);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, string data)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",s");
            _encoder.Append(data);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        #endregion

        #region IDispose implementation

        bool _disposed;

        void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;

            if (disposing)
            {
                if (_socket != null)
                {
                    _socket.Close();
                    _socket = null;
                }

                _encoder = null;
            }
        }

        ~OscClient()
        {
            Dispose(false);
        }

        #endregion

        #region Private variables

        OscPacketEncoder _encoder = new OscPacketEncoder();
        Socket _socket;

        #endregion
    }
}
