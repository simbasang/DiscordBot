﻿using DSharpPlus.CommandsNext;
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
            var quiz = await ApiCalls.GetQuiz();
            var participiantsAndPoints = new Dictionary<string, int>();
            int counter = 0;
            foreach (var item in quiz.results)
            {
                counter++;
                var awnserString = "";
                var awnsers = new List<string> { item.correct_answer, item.incorrect_answers[0], item.incorrect_answers[1], item.incorrect_answers[2] };
                foreach (var awnser in awnsers)
                {
                    awnserString += awnser + "\n";
                }

                var question = item.question;
                question = await QuestionAndAnswer.ReplaceHtmlChars(question);

                await ctx.Channel.SendMessageAsync($"question number: {counter}\n{question}").ConfigureAwait(false);
                
                await ctx.Channel.SendMessageAsync(awnserString).ConfigureAwait(false);
                var interactivity = ctx.Client.GetInteractivity();
                var userAwnser = await interactivity.WaitForMessageAsync(x => x.Content.ToLower() == item.correct_answer.ToLower());
                await ctx.Channel.SendMessageAsync($"{userAwnser.Result.Author.Username} delivered the right answer: {item.correct_answer}");

                if (participiantsAndPoints.ContainsKey(userAwnser.Result.Author.Username))
                {
                    participiantsAndPoints[userAwnser.Result.Author.Username] += 1;

                }
                else
                {
                    participiantsAndPoints.Add(userAwnser.Result.Author.Username, 1);
                }
                awnsers.Clear();
                Thread.Sleep(1000);
            }
            foreach (var kvp in participiantsAndPoints)
            {
                await ctx.Channel.SendMessageAsync($"{kvp.Key} got: {kvp.Value} points");

            }
        }


    }
}
