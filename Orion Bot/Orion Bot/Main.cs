using Discord_Bot__McServer_;
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
using System.Windows.Forms;

namespace Orion_Bot
{
    public partial class Main : Form
    {

        private Minecraft_Bot mcBot = new Minecraft_Bot();
        private Program p = new Program();


        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        void consoleSendButton_Click(object sender, EventArgs e)
        {
            mcBot.WriteInMC(inputTB.Text);
        }
    }
}
