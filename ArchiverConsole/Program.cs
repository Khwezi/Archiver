using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ArchiverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] file1 = Encoding.ASCII.GetBytes("wdfwoienfowiefn eifnowef nwoefinow f eiwnfoinefwoefih o weihfowiehfowiefoh eihfoweihf oih wefoih wegf");
            byte[] file2 = Encoding.ASCII.GetBytes("doinoierngorghfo owefgoeugf ogufiuq fiug");

            using (MemoryStream ms = new MemoryStream())
            {
                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    var zipArchiveEntry = archive.CreateEntry("file1.txt", CompressionLevel.Fastest);
                    using (var zipStream = zipArchiveEntry.Open()) zipStream.Write(file1, 0, file1.Length);

                    zipArchiveEntry = archive.CreateEntry("file2.txt", CompressionLevel.Fastest);
                    using (var zipStream = zipArchiveEntry.Open()) zipStream.Write(file2, 0, file2.Length);
                }

                Console.WriteLine("Press ENTER to exit.");
                Console.ReadLine();

                File.WriteAllBytes("testzip.zip", ms.ToArray());
            }
        }
    }
}
