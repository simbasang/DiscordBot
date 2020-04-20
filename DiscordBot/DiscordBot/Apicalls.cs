﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    class ApiCalls
    {
        public async static Task<string> GetCatFact()
        {
            var client = new RestClient("https://cat-fact.herokuapp.com/facts/random");
            var request = new RestRequest("", DataFormat.Json);
            var response = client.Get<CatFact>(request);
            return response.Data.text;
        }

        public async static Task<string> GetFoxPic()
        {
            var client = new RestClient("https://randomfox.ca/floof/");
            var request = new RestRequest("", DataFormat.Json);
            var response = client.Get<FoxPic>(request);
            return response.Data.image;
        }

        public async static Task<string> GetDonaldThrumpQuote()
        {
            var client = new RestClient("https://www.tronalddump.io/random/quote");
            var request = new RestRequest("", DataFormat.Json);
            var response = client.Get<DonaldThrumpQuote>(request);
            return response.Data.value;
        }

        public async static Task<Joke> GetJoke()
        {
            var client = new RestClient("https://official-joke-api.appspot.com/jokes/random");
            var request = new RestRequest("", DataFormat.Json);
            var response = client.Get<Joke>(request);
            return response.Data;
        }

        public async static Task<Quiz> GetQuiz()
        {
            var client = new RestClient("https://opentdb.com/api.php?amount=10");
            var request = new RestRequest("", DataFormat.Json);
            var response = client.Get<Quiz>(request);
            return response.Data;
        }
    }
}