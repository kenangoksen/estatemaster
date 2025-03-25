using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers
{

    public class ZipBuilder: IDisposable
    {

        private string filePath { get; set; }

        private System.IO.Compression.ZipArchive zip { get; set; }

        private CompressionLevel compressionLevel { get; set; }

        public ZipBuilder(string filePath, CompressionLevel compressionLevel = CompressionLevel.Optimal)
        {
            this.filePath = filePath;
            this.compressionLevel = compressionLevel;
            zip = ZipFile.Open(filePath, ZipArchiveMode.Create);
        }

        public ZipBuilder AddFileContent(string fileName, string content)
        {
            ZipArchiveEntry entry = zip.CreateEntry(fileName, compressionLevel);
            using (StreamWriter writer = new StreamWriter(entry.Open()))
            {
                writer.WriteLine(content);
            }
            return this;
        }

        public ZipBuilder AddFile(string path, string name)
        {
            zip.CreateEntryFromFile(path, name, compressionLevel);
            return this;
        }

        public void Save()
        {
            zip.Dispose();
        }

        public FileStream GetAsFileStream()
        {
            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }

        public StreamContent GetAsStreamContent()
        {
            return new StreamContent(GetAsFileStream());
        }

        public void Dispose()
        {
            zip.Dispose();
        }

    }

}
