using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Orion_Bot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            Program program = new Program();

            program.RunBotAsync();

            program.StartServerWorker.DoWork += program.StartServer;


            //if (Console.ReadLine() == "write")
            //{
            //    program.WriteInMC("lol");
            //}

            //if (Console.ReadLine() == "start minecraft server")
            //{
            //   program.StartServerWorker.RunWorkerAsync();
            //}
            if (Console.ReadLine() == "start ui")
            {
                Main mainUI = new Main();
                mainUI.Show();
            }
            Console.ReadLine();
        }

        public void StartServer(object sender, DoWorkEventArgs e)
        {
                Process Minecraft = new Process();
                Minecraft.StartInfo.FileName = "CMD.exe";
                Minecraft.StartInfo.CreateNoWindow = false;
                Minecraft.StartInfo.RedirectStandardInput = true;
                Minecraft.StartInfo.RedirectStandardOutput = true;
                Minecraft.StartInfo.RedirectStandardError = true;
                Minecraft.StartInfo.UseShellExecute = false;
                Minecraft.OutputDataReceived += OutputDataReceived;
                Minecraft.ErrorDataReceived += Minecraft_ErrorDataReceived;
                Minecraft.Start();
                Minecraft.BeginOutputReadLine();
                Minecraft.BeginErrorReadLine();
                WriteCommands = Minecraft.StandardInput;
                WriteCommands.WriteLineAsync(@"java -Xmx" + MaxRam + "M -Xms" + MinRam + "M -jar " + server + " " + "nogui");
        }

        void Minecraft_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("Error: " + e.Data);
        }

        void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            WriteInMC(e.Data);
        }



        /////////////////////////////////////////////////////
        DiscordSocketClient _client;
        CommandService _commands;
        IServiceProvider _services;

        public ulong mcChannelID = 432947016298004490;
        public ulong mcServerID = 432945835828051979;

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            string botToken = "NDMyOTQyNDYyOTQwNDc5NDk4.Da1Hpg.7gv-Uop9zOr8bt8TnHT6B1yU0DA";

            //await RegisterCommandAsync();

            await _client.LoginAsync(TokenType.Bot, botToken);

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        void WriteInMC(string text)
        {
            _client.GetGuild(mcServerID).GetTextChannel(mcChannelID).SendMessageAsync(text);
        }

        //public async Task RegisterCommandAsync()
        //{
        //    _client.MessageReceived += HandleCommandAsync;

        //    await _commands.AddModuleAsync(Assembly.GetEntryAssembly());
        //}

        //private async Task HandleCommandAsync(SocketMessage arg)
        //{
        //    var message = arg as SocketMessage;

        //    if (message is null || message.Author.IsBot)
        //        return;
        //}
        /////////////////////////////////////////////////////
    }
}
