using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace GlassixAssignment
{
    class ValidateEmail
    {
    
        private readonly string valid = "valid";
        private string _siteUrl;

        public ValidateEmail(string siteUrl)
        {
            _siteUrl = siteUrl;
        }

        public bool IsValid(string emailAddress)
        {
            WebClient client = new WebClient();
            string validateEmailJson = client.DownloadString(_siteUrl + emailAddress + "/mass");

            Dictionary<string, object> jsonModel = JsonSerializer.Deserialize<Dictionary<string, object>>(validateEmailJson);
            if (jsonModel[valid].ToString() == "1")
            {
                return true;
            }
            return false;
        }


    }
}