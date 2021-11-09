using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace AffineTransforms_3D
{
    [Serializable]
    class FileWorker
    {
        public string fname;
        public Projection proj;
        public Figure fig;
        public List<(Transform, List<double>)> transforms;
        public FileWorker(Figure f, List<(Transform, List<double>)> l, Projection pr,string fn)
        {
            fname = fn;
            fig = f;
            transforms = l;
            proj = pr;
        }


    }


    static class FileHelper
    {

        public static FileWorker Load(string FileName)
        {
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(FileWorker));
                return serializer.Deserialize(stream) as FileWorker;
            }
        }

        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

    }
}
