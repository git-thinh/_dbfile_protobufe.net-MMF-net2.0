using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace core
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [ProtoContract]
    public struct oUser
    {
        [ProtoMember(1)]
        public long userid;

        [ProtoMember(2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)] // Max length of string
        public string username;

        [ProtoMember(3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)] // Max length of string
        public string password;

        [ProtoMember(4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)] // Max length of string
        public string fullname;

        [ProtoMember(5)]
        public byte status;

        public override string ToString()
        {
            return string.Format("{0}; {1}; {2}; {3}; {4}", userid, fullname, username, password, status);
        }
    }
}
