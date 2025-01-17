﻿using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Tau.Config;

// todo, seperate slash command groups (not [slashcommandgroup] they suck) into seperate files, basically abstract a lil.
namespace Tau.Commands
{
    public class General : ApplicationCommandModule
    {
        [SlashCommand("about", "Displays information about Tau.")]
        public async Task AboutCommand(InteractionContext ctx)
        {
            var eb = new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Aquamarine)
                .WithTitle("Tau")
                .WithDescription("Tau is a general purpose bot written in C# using [DSharpPlus](https://dsharpplus.github.io/)!")
                .AddField("Developers", "[hawk](https://github.com/hawwwwwk)")
                .AddField("Very special thanks:", "A huge thank you to everyone in the [DSharpPlus Discord Server](https://discord.gg/dsharpplus) for helping me learn this library, and thanks to [Nimrod](https://discord.gg/vSmKPNd4) for letting me host on their servers.")
                .AddField("Questions? Comments?", "If you're having any issues with Tau or have a suggestion, join our [Support Server](https://discord.gg/EatSTE2u)!")
#if DEBUG
                .WithFooter($"Tau v0.0.4, Beta Branch") // todo: automate the changing of this lol
#else
                .WithFooter("Tau v0.0.4")
#endif
                .Build();
            await ctx.CreateResponseAsync(eb, false);
        }

        [SlashCommand("uptime", "Shows how long Tau has been online.")]
        public async Task UptimeCommand(InteractionContext ctx)
        {
            var delta = DateTime.Now - Bot.startTime;
            var eb = new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Aquamarine)
                .AddField("Uptime", $"Tau has been online for `{delta} (h:m:s:ms)`")
                .Build();
            await ctx.CreateResponseAsync(eb, false);
        }
    }
}
