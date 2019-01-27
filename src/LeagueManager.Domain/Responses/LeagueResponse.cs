﻿using System;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Responses
{
    public class LeagueResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
