// OSC Jack - Open Sound Control plugin for Unity
// https://github.com/keijiro/OscJack

using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using System.Collections.Generic;

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

        //public void Send(string address, float element1, float element2, float element3, float element4, float element5, float element6)
        //{
        //    clientSetup();
        //    _encoder.Clear();
        //    _encoder.Append(address);
        //    _encoder.Append(",ffffff");
        //    _encoder.Append(element1);
        //    _encoder.Append(element2);
        //    _encoder.Append(element3);
        //    _encoder.Append(element4);
        //    _encoder.Append(element5);
        //    _encoder.Append(element6);
        //    if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        //}

        public void Send(string address, string data)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",s");
            _encoder.Append(data);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, string data1, string data2)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",ss");
            _encoder.Append(data1);
            _encoder.Append(data2);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, string data1, string data2, string data3)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",sss");
            _encoder.Append(data1);
            _encoder.Append(data2);
            _encoder.Append(data3);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, string data1, string data2, float data3)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",ssf");
            _encoder.Append(data1);
            _encoder.Append(data2);
            _encoder.Append(data3);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, string str, float data1)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",sf");
            _encoder.Append(str);
            _encoder.Append(data1);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, string str, float data1, float data2)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",sff");
            _encoder.Append(str);
            _encoder.Append(data1);
            _encoder.Append(data2);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }


        public void Send(string address, string str, float data1, float data2, float data3)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);
            _encoder.Append(",sfff");
            _encoder.Append(str);
            _encoder.Append(data1);
            _encoder.Append(data2);
            _encoder.Append(data3);
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        // optimized for update messages up to 7 floats long
        public void Send(string address, string name, float[] floatVec)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);

            switch (floatVec.Length)
            {
                case 5:
                    _encoder.Append(",sfffff");
                    break;
                case 6:
                _encoder.Append(",sffffff");
                    break;
                case 7:
                    _encoder.Append(",sfffffff");
                    break;
                case 3:
                    _encoder.Append(",sfff");
                    break;
                case 2:
                    _encoder.Append(",sff");
                    break;
                case 1:
                    _encoder.Append(",sf");
                    break;
                case 4:
                    _encoder.Append(",sffff");
                    break;

                default:
                    return;  // do not handle vectors longer than 7 elements
            }

            _encoder.Append(name);

            foreach (float value in floatVec)
            {
                _encoder.Append(value);
            }
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        // optimized for setvec messages up to 7 floats long
        public void Send(string address, string name, string paramName, float[] floatVec)
        {
            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);

            switch (floatVec.Length)
            {
                case 5:
                    _encoder.Append(",ssfffff");
                    break;
                case 6:
                    _encoder.Append(",ssffffff");
                    break;
                case 7:
                    _encoder.Append(",ssfffffff");
                    break;
                case 3:
                    _encoder.Append(",ssfff");
                    break;
                case 2:
                    _encoder.Append(",ssff");
                    break;
                case 1:
                    _encoder.Append(",ssf");
                    break;
                case 4:
                    _encoder.Append(",ssffff");
                    break;

                default:
                    return;  // do not handle vectors longer than 7 elements
            }

            _encoder.Append(name);
            _encoder.Append(paramName);
            foreach (float value in floatVec)
            {
                _encoder.Append(value);
            }
            if (_socket.Connected) _socket.Send(_encoder.Buffer, _encoder.Length, SocketFlags.None);
        }

        public void Send(string address, List<object> data)
        {
            if (data.Count == 0)
            {
                Send(address);
                return;
            }

            List<char> formatList = new List<char>();
            string formatStr;
            formatList.Add(',');

            clientSetup();
            _encoder.Clear();
            _encoder.Append(address);

            // calculate format string
            foreach (object obj in data)
            {
                Type t = obj.GetType();

                if (t.Equals(typeof(int)))
                    formatList.Add('i');
                else if (t.Equals(typeof(float)))
                    formatList.Add('f');
                if (t.Equals(typeof(double)))
                    formatList.Add('f');
                else if (t.Equals(typeof(string)))
                    formatList.Add('s');
            }

            formatStr = new string(formatList.ToArray());

            _encoder.Append(formatStr);

            foreach (object obj in data)
            {
                Type t = obj.GetType();

                if (t.Equals(typeof(int)))
                    _encoder.Append((int)obj);

                else if (t.Equals(typeof(float)))
                    _encoder.Append((float)obj);

                if (t.Equals(typeof(double)))
                    _encoder.Append((float)obj);

                else if (t.Equals(typeof(string)))
                    _encoder.Append((string)obj);
            }
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
        #region public functions
        public bool isConnected()
        {
            if (_socket == null) return false;
            else return _socket.Connected;
        }

        #endregion

    }
}
