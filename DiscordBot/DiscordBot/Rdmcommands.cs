using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Rdmcommands : BaseCommandModule
    {
        [Command("catfact")]
    public async Task CatFact(CommandContext ctx)
    {
        var fact = await ApiCalls.GetCatFact();
        await ctx.Channel.SendMessageAsync(fact).ConfigureAwait(false);
    }

    [Command("foxpic")]
    public async Task FoxPic(CommandContext ctx)
    {
        var foxpic = await ApiCalls.GetFoxPic();
        await ctx.Channel.SendMessageAsync(foxpic).ConfigureAwait(false);
    }
    [Command("Dquote")]
    public async Task DonaldThrumpQuote(CommandContext ctx)
    {
        var quote = await ApiCalls.GetDonaldThrumpQuote();
        await ctx.Channel.SendMessageAsync(quote + "\n/Donald trump").ConfigureAwait(false);
    }
    [Command("joke")]
    public async Task TellAJoke(CommandContext ctx)
    {
        var joke = await ApiCalls.GetJoke();
        await ctx.Channel.SendMessageAsync(joke.setup).ConfigureAwait(false);
        Thread.Sleep(2000);
        await ctx.Channel.SendMessageAsync(joke.punchline).ConfigureAwait(false);

    }
    [Command("quiz")]
    public async Task StartQuiz(CommandContext ctx)
    {
        //var quiz = await ApiCalls.GetQuiz();
        //foreach (var item in quiz.results)
        //{
        //    var list = new Liststring { item.correct_answer, item.incorrect_answers[0], item.incorrect_answers[1], item.incorrect_answers[2] };
        //    await ctx.Channel.SendMessageAsync(item.question).ConfigureAwait(false);

        //    foreach (var awnser in list)
        //    {
        //        await ctx.Channel.SendMessageAsync(awnser).ConfigureAwait(false);

        //    }
        //    var interactivity = ctx.Client.GetInteractivity();
        //    var userAwnser = await interactivity.WaitForMessageAsync(x = x.Channel == ctx.Channel);
        //    list.Clear();
        //}

    }
}
}