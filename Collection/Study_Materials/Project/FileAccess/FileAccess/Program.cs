using System.IO;

namespace FileAccess
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileExists = File.Exists(@"\\aspire886\CAWebService\Cache.txt");
            var fileExists1 = File.Exists(" ");
        }
    }
}
