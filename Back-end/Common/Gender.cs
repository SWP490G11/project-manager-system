﻿using System.Text.Json.Serialization;

namespace Back_end.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Male,Female,Other
    }
}
