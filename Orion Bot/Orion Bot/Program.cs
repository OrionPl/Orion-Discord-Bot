using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot__McServer_
{
    class Program
    {
        StreamWriter WriteCommands;
        BackgroundWorker StartServerWorker = new BackgroundWorker();

        delegate void SetTextCallBack(string text);

        string MaxRam = "1024";
        string MinRam = "1024";
        string server = @"C:\Servers\MC Servers\1.12.2 Vanilla\server.jar";

        static void Main(string[] args)
        {
            if (Console.ReadLine() == "start server")
            {
                StartServer();
            }
        }

        void StartServer()
        {
                Process Minecraft = new Process();
                Minecraft.StartInfo.FileName = "CMD.exe";
                Minecraft.StartInfo.CreateNoWindow = false;
                Minecraft.StartInfo.RedirectStandardInput = true;
                Minecraft.StartInfo.RedirectStandardOutput = true;
                Minecraft.StartInfo.RedirectStandardError = true;
                Minecraft.StartInfo.UseShellExecute = false;
                Minecraft.OutputDataReceived += Minecraft_OutputDataReceived;
                Minecraft.ErrorDataReceived += Minecraft_ErrorDataReceived;
                Minecraft.Start();
                Minecraft.BeginOutputReadLine();
                Minecraft.BeginErrorReadLine();
                WriteCommands = Minecraft.StandardInput;
                WriteCommands.WriteLineAsync(@"java -Xmx" + MaxRam + "M -Xms" + MinRam + "M -jar " + server + " " + "nogui");
        }
    }
}
