using System.IO;

namespace Scoz.Func {

    public class LogFile {
        public static void AppendWrite(string _path, string _msg) {
            string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string log = $"{timestamp}: {_msg}\n";
            string filePath = $"Logs/{_path}.log";
            File.AppendAllText(filePath, log);
        }
    }
}