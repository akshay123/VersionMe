using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Version.UnitTests
{
    class Base64Serializer
    {
        public static string SerializeBase64<T>(T o) where T:class
        {
            // Serialize to a base 64 string
            byte[] bytes;
            long length = 0;
            MemoryStream ws = new MemoryStream();
            BinaryFormatter sf = new BinaryFormatter();
            sf.Serialize(ws, o);
            length = ws.Length;
            bytes = ws.GetBuffer();
            string encodedData = bytes.Length + ":" + Convert.ToBase64String(bytes, 0, bytes.Length, Base64FormattingOptions.None);
            return encodedData;
        }

        public static T DeserializeBase64<T>(string s) where T:class
        {
            // We need to know the exact length of the string - Base64 can sometimes pad us by a byte or two
            T obj;
            int p = s.IndexOf(':');
            int length = Convert.ToInt32(s.Substring(0, p));

            // Extract data from the base 64 string!
            byte[] memorydata = Convert.FromBase64String(s.Substring(p + 1));
            MemoryStream rs = new MemoryStream(memorydata, 0, length);
            BinaryFormatter sf = new BinaryFormatter();

            obj = sf.Deserialize(rs) as T;

            return obj;
        }
    }
}
