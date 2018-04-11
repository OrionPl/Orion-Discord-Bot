using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
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
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Orion_Bot
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RunBotAsync();

            CommandHandler cmdHandler = new CommandHandler();


            StartMCServerWorker.DoWork += StartMinecraftServer;
            StartKSPServerWorker.DoWork += StartKSPServer;
        }


        void inputConsoleButton_Click(object sender, EventArgs e)
        {
            if (inputConsoleTB.Text.StartsWith("write "))
            {
                WriteInOutput(inputConsoleTB.Text.Remove(0, 6));
            }
            else if (inputConsoleTB.Text == "start minecraft server")
            {
                StartMCServerWorker.RunWorkerAsync();
            }
            else if (inputConsoleTB.Text == "start ksp server")
            {
                StartKSPServerWorker.RunWorkerAsync();
            }

            inputConsoleTB.Text = "";
        }


        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////

        public ulong mcChannelID = 432947016298004490;
        public ulong serverID = 432945835828051979;
        public ulong KSPChannelID = 433741758157815810;
        public ulong mainChannelID = 433740515087745026;
        
        BackgroundWorker StartMCServerWorker = new BackgroundWorker();
        BackgroundWorker StartKSPServerWorker = new BackgroundWorker();

        Process Minecraft = new Process();
        Process KSPServer = new Process();

        delegate void SetTextCallBack(string text);

        

        public void StartMinecraftServer(object sender, DoWorkEventArgs e)
        {
            string MaxRam = "1024";
            string MinRam = "5120";
            string server = @"C:\Servers\MC Servers\1.12.2 Vanilla\";
            Minecraft.StartInfo.FileName = "server.jar";
            Minecraft.OutputDataReceived += OutputDataReceivedMC;
            Minecraft.ErrorDataReceived += OutputDataReceivedMC;
            Minecraft.StartInfo.Arguments = @"java -Xmx" + MaxRam + "M -Xms" + MinRam + "M -jar " + server + " " + "nogui";
            Minecraft.Start();
        }

        public void StartKSPServer(object sender, DoWorkEventArgs e)
        {
            KSPServer.StartInfo.FileName = @"C:\Servers\KSP Server\DMPServer";
            KSPServer.OutputDataReceived += OutputDataReceivedKSP;
            KSPServer.StartInfo.RedirectStandardOutput = true;
            KSPServer.StartInfo.UseShellExecute = false;
            KSPServer.StartInfo.RedirectStandardOutput = true;
            KSPServer.Start();
            KSPServer.BeginOutputReadLine();
        }

        void OutputDataReceivedMC(object sender, DataReceivedEventArgs e)
        {
            _client.GetGuild(serverID).GetTextChannel(mcChannelID).SendMessageAsync(e.Data);
        }

        void OutputDataReceivedKSP(object sender, DataReceivedEventArgs e)
        {
            _client.GetGuild(serverID).GetTextChannel(KSPChannelID).SendMessageAsync(e.Data);
        }

        void WriteInOutput(string text)
        {
            _client.GetGuild(serverID).GetTextChannel(mcChannelID).SendMessageAsync(text);
        }

        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////


        public DiscordSocketClient _client;
        public CommandService _commands;
        public IServiceProvider _services;

        

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            string botToken = "NDMyOTQyNDYyOTQwNDc5NDk4.Da1Hpg.7gv-Uop9zOr8bt8TnHT6B1yU0DA";

            await _client.LoginAsync(TokenType.Bot, botToken);

            await _client.StartAsync();

            await Task.Delay(-1);
        }


        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////


        
    }
}
