using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace SpeechToTextWPFSample.Model
{

    public partial class Reference
    {
        [JsonProperty("reference")]
        public string PurpleReference { get; set; }
    }

    public partial class Reference
    {
        public static Reference FromJson(string json) => JsonConvert.DeserializeObject<Reference>(json, Converter.Settings);
    }

}
