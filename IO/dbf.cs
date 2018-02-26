using System; 
using System.IO; 
using System.Runtime.InteropServices;
using System.Threading; 

namespace core
{
    public class dbf
    {
        public const int key_LEN = 19;

        #region // SERIALIZE - DESERIALIZE

        // This code requires unsafe switch but should be fast ...

        // [StructLayout(LayoutKind.Sequential, Pack = 1)]
        // public struct datastruct
        // {
        //     [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)] // Max length of string
        //     public string str;
        //     public float x;
        //     public float y;
        // }

        // datastruct info = new datastruct();
        // info.str= "hej";
        // info.x = 2;
        // info.y = 4;
        // byte[] bytearray = Serialize<datastruct>(info);

        // byte[] data = bytearray; // from above code
        // object d = Deserialize<datastruct>(data);
        // datastruct ds = (datastruct)d;

        public static Byte[] Serialize<T>(T msg) where T : struct
        {
            int objsize = Marshal.SizeOf(typeof(T));
            Byte[] ret = new Byte[objsize];
            IntPtr buff = Marshal.AllocHGlobal(objsize);
            Marshal.StructureToPtr(msg, buff, true);
            Marshal.Copy(buff, ret, 0, objsize);
            Marshal.FreeHGlobal(buff);
            return ret;
        }

        public static T Deserialize<T>(Byte[] data) where T : struct
        {
            int objsize = Marshal.SizeOf(typeof(T));
            IntPtr buff = Marshal.AllocHGlobal(objsize);
            Marshal.Copy(data, 0, buff, objsize);
            T retStruct = (T)Marshal.PtrToStructure(buff, typeof(T));
            Marshal.FreeHGlobal(buff);
            return retStruct;
        }

        // [StructLayout(LayoutKind.Sequential)]
        // public struct Demo
        // {
        //     public double X;
        //     public double Y;
        // }

        // private static void Main()
        // {
        //     Demo[] array = new Demo[2];
        //     array[0] = new Demo { X = 5.6, Y = 6.6 };
        //     array[1] = new Demo { X = 7.6, Y = 8.6 };

        //     byte[] bytes = ToByteArray(array);
        //     Demo[] array2 = FromByteArray<Demo>(bytes);
        // }

        public static byte[] Serialize<T>(T[] source) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(source, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                byte[] destination = new byte[source.Length * Marshal.SizeOf(typeof(T))];
                Marshal.Copy(pointer, destination, 0, destination.Length);
                return destination;
            }
            finally
            {
                if (handle.IsAllocated)
                    handle.Free();
            }
        }

        public static T[] DeserializeArray<T>(byte[] source) where T : struct
        {
            T[] destination = new T[source.Length / Marshal.SizeOf(typeof(T))];
            GCHandle handle = GCHandle.Alloc(destination, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Marshal.Copy(source, 0, pointer, source.Length);
                return destination;
            }
            finally
            {
                if (handle.IsAllocated)
                    handle.Free();
            }
        }

        public static byte[] SerializeArray<T>(T[] colors)
        {
            if (colors == null || colors.Length == 0)
                return null;

            int lengthOfColor32 = Marshal.SizeOf(typeof(T));
            int length = lengthOfColor32 * colors.Length;
            byte[] bytes = new byte[length];

            GCHandle handle = default(GCHandle);
            try
            {
                handle = GCHandle.Alloc(colors, GCHandleType.Pinned);
                IntPtr ptr = handle.AddrOfPinnedObject();
                Marshal.Copy(ptr, bytes, 0, length);
            }
            finally
            {
                if (handle != default(GCHandle))
                    handle.Free();
            }

            return bytes;
        }

        #endregion

        #region // KEY ...

        public static long key_Create_Random(bool isNone = false)
        {
            Thread.Sleep(1);
            long _key = 0;
            int rid = new Random().Next(1000, 9999);
            string id = DateTime.Now.ToString("yyMMddHHmmssfff") + (isNone ? "0000" : rid.ToString());
            long.TryParse(id, out _key);
            return _key;
        }

        public static bool key_Check_Is_None(string key)
        {
            return key.EndsWith("0000");
        }

        #endregion

        #region // FILE ...


        public static void file_CreateBlank(string file, int SizeDesired_MB)
        {
            if (SizeDesired_MB < 1) SizeDesired_MB = 1;

            //string file = @"e:\ifc.db";
            //long length_add = 1024L * 1024L * 1L; // 1MB
            long length_add = 1024L * 1024L * SizeDesired_MB; // SizeDesired_MB MB

            // create blank file of desired size (nice and quick!)
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            fs.Seek(length_add, SeekOrigin.Begin);
            fs.WriteByte(0);
            fs.Close();
        }

        #endregion
    }

    ////    public class MemCopyUtils
    ////    {
    ////        unsafe delegate void MemCpyDelegate(byte* dst, byte* src, int len);
    ////        static MemCpyDelegate MemCpy;

    ////        static MemCopyUtils()
    ////        {
    ////            InitMemCpy();
    ////        }

    ////        static void InitMemCpy()
    ////        {
    ////            var mi = typeof(Buffer).GetMethod(
    ////                name: "Memcpy",
    ////                bindingAttr: BindingFlags.NonPublic | BindingFlags.Static,
    ////                binder: null,
    ////                types: new Type[] { typeof(byte*), typeof(byte*), typeof(int) },
    ////                modifiers: null);
    ////            MemCpy = (MemCpyDelegate)Delegate.CreateDelegate(typeof(MemCpyDelegate), mi);
    ////        }

    ////        public unsafe static T[] DeserializeArray<T>(byte[] bytes)
    ////        {
    ////            int objsize = Marshal.SizeOf(typeof(T));
    ////            //T[] colors = new T[bytes.Length / sizeof(T)];
    ////            T[] colors = new T[bytes.Length / objsize];

    ////            fixed (void* tempC = & colors[0])
    ////            fixed (byte* pBytes = bytes)
    ////            {
    ////                byte* pColors = (byte*)tempC;
    ////                MemCpy(pColors, pBytes, bytes.Length);
    ////            }
    ////            return colors;
    ////        }
    ////    }
}