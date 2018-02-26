
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace core
{
    class main
    {
        static void Main(string[] args)
        {
            demo1();

            Console.WriteLine("======================================");
            Console.ReadKey();
        }

        static void demo1()
        {
            oUser u1 = new oUser()
            {
                userid = dbf.key_Create_Random(),
                username = Guid.NewGuid().ToString(),
                password = Guid.NewGuid().ToString(),
                fullname = "Nguyễn Văn Thịnh",
                status = 0
            };

            oUser u2 = new oUser()
            {
                userid = dbf.key_Create_Random(),
                username = Guid.NewGuid().ToString(),
                password = Guid.NewGuid().ToString(),
                fullname = "Nguyễn Cẩm Tú",
                status = 0
            };

            byte[] b11 = dbf.Serialize<oUser>(u1);
            byte[] b22 = dbf.Serialize<oUser>(u2);
            oUser _u = dbf.Deserialize<oUser>(b11);


            MemoryStream ms = new MemoryStream();
            Serializer.Serialize(ms, u1);
            byte[] bf = ms.GetBuffer();
            Console.WriteLine(ms.Length);

            var model = ProtoBuf.Meta.TypeModel.Create();
            Type type = typeof(oUser);

            ms.Position = 0;
            var o11 = model.Deserialize(ms, null, type);

            //var compiled = model.Compile();

            //ms.Position = 0;
            //var o2 = compiled.Deserialize(ms, null, type);

            ms.Position = 0;
            var o3 = Serializer.Deserialize<oUser>(ms);

            ms.Position = 0;
            //var o4 = Serializer.Deserialize<object>(ms);


            MemoryStream ms2 = new MemoryStream();
            Serializer.Serialize(ms2, u2);
            byte[] bf2 = ms2.GetBuffer();
            Console.WriteLine(ms2.Length);

            var model2 = ProtoBuf.Meta.TypeModel.Create();
            Type type2 = typeof(oUser);

            ms2.Position = 0;
            var o22 = model.Deserialize(ms2, null, type2);

            var clone = Serializer.DeepClone(o3);
        }
    }
}
