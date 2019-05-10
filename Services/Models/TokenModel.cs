using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class TokenModel
    {
        [JsonProperty("access_token")]
        public String AccessToken { get; set; }
    }
}