using System;
using System.IO;
using System.Text;

namespace Strategy
{
    // STRATEGY COMPRESSION
    public interface ICompressor
    {
        void compress(string filename, string formatedMessage);
    }

    public class RAR_Compression: ICompressor
    {
        public void compress(string filename, string formatedMessage)
        {
            using (var sw = new StreamWriter(filename, false, Encoding.Unicode))
            {
                string text = ">>>RAR COMPRESSION<<<\n";
                text += formatedMessage;
                text += "<<<RAR COMPRESSION>>>\n";

                sw.Write(text);
            }
        }
    }

    public class ZIP_Compression: ICompressor
    {
        public void compress(string filename, string formatedMessage)
        {
            using (var sw = new StreamWriter(filename, false, Encoding.Unicode))
            {
                string text = "~~>ZIP COMPRESSION<~~\n";
                text += formatedMessage;
                text += "<~~ZIP COMPRESSION~~>\n";

                sw.Write(text);
            }
        }
    }

    // STRATEGY FORMATE FILE
    public interface IFormate
    {
        string formate(string message);
    }

    public class JSON_Formate: IFormate
    {
        public string formate(string message)
        {
            string json = "{\n";
            json += $"    \"message\": {message}\n";
            json += "}\n";

            return json;
        }
    }

    public class XML_Formate : IFormate
    {
        public string formate(string message)
        {
            string xml = "<article lang = \"\">\n";
            xml += $"<para>Message: {message}</para>\n";
            xml += "</article>\n";

            return xml;
        }
    }

    public class User
    {
        private ICompressor _strategyCompress;
        private IFormate _strategyFormate;

        private string username;
        private string password;

        public User(string username, string password, ICompressor compressor, IFormate formator)
        {
            this.username = username;
            this.password = password;

            this._strategyCompress = compressor;
            this._strategyFormate = formator;
        }

        public void CompressFormatedFile(string filename, string fileFormat)
        {
            var text = _strategyFormate.formate(this.ToString());
            var file = $"{filename}.{fileFormat}";
            _strategyCompress.compress(file, text);
            Console.WriteLine($"File: {file} has compressed\n");
        }

        public override string ToString()
        {
            return $"Username: {username}, Password: {password}";
        }

        public void SetStrategy(ICompressor compressor)
        {
            if (compressor == null)
            {
                throw new ArgumentNullException(nameof(compressor));
            }

            this._strategyCompress = compressor;
        }

        public void SetStrategy(IFormate formator)
        {
            if (formator == null)
            {
                throw new ArgumentNullException(nameof(formator));
            }

            this._strategyFormate = formator;
        }

        public void SetStrategy(ICompressor compressor, IFormate formator)
        {
            if (compressor == null)
            {
                throw new ArgumentNullException(nameof(compressor));
            }

            if (formator == null)
            {
                throw new ArgumentNullException(nameof(formator));
            }

            this._strategyCompress = compressor;
            this._strategyFormate = formator;
        }
    }
}
