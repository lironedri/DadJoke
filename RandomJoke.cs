using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace GlassixAssignment
{
    class RandomJoke
    {
        private readonly string text = "text";
        private readonly string attachments = "attachments";
        private string _siteUrl;

        public RandomJoke(string siteUrl)
        {
            _siteUrl = siteUrl;
        }

        public string GetJoke()
        {
            WebClient client = new WebClient();
            string randomJokeJson = client.DownloadString(_siteUrl);
            Dictionary<string, JsonElement> jsonModel = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(randomJokeJson);
            jsonModel.TryGetValue(attachments, out JsonElement attach);
            JsonElement joke = attach.EnumerateArray().FirstOrDefault();
            joke.TryGetProperty(text, out JsonElement jokeStr);
            return jokeStr.ToString();
        }
    }
}