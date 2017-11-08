using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Microsoft.CognitiveServices.SpeechRecognition;
//
//    var data = Nuance.FromJson(jsonString);
//

namespace SpeechToTextWPFSample.Model
{

    public partial class Nuance
    {
        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty("channels")]
        public Channels Channels { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("model")]
        public Model Model { get; set; }

        [JsonProperty("operating_mode")]
        public string OperatingMode { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }
    }

    public class Model
    {
        //[JsonProperty("addwords")]
        //public Addwords Addwords { get; set; }

        //[JsonProperty("domainLM")]
        //public Addwords DomainLM { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }


    public class Channels
    {
        [JsonProperty("firstChannelLabel")]
        public ChannelLabel FirstChannelLabel { get; set; }

        //[JsonProperty("secondChannelLabel")]
        //public ChannelLabel SecondChannelLabel { get; set; }
    }

    public class ChannelLabel
    {
        [JsonProperty("diarize")]
        public bool Diarize { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("num_speakers")]
        public long NumSpeakers { get; set; }

        [JsonProperty("result_format")]
        public string ResultFormat { get; set; }

        [JsonProperty("result_version")]
        public long ResultVersion { get; set; }
    }

    public partial class Nuance
    {
        public static Nuance FromJson(string json) => JsonConvert.DeserializeObject<Nuance>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Nuance self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}


