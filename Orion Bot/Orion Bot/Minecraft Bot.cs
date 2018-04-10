using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot__McServer_
{
    class Minecraft_Bot
    {
        DiscordSocketClient _client;
        CommandService _commands;
        IServiceProvider _services;

        public ulong mcChannelID = 432947016298004490;
        public ulong mcServerID = 432945835828051979;

        public Minecraft_Bot()
        {

        }

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

        public void WriteInMC(string text)
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
    }
}
