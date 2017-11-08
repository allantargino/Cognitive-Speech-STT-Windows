
using Newtonsoft.Json;

namespace SpeechToTextWPFSample.Model
{


    public partial class NuanceStatus
    {
        [JsonProperty("channels")]
        public ChannelsStatus Channels { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("operating_mode")]
        public string OperatingMode { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("statistics")]
        public PurpleStatistics Statistics { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class PurpleStatistics
    {
        [JsonProperty("audio_analysis_time")]
        public long AudioAnalysisTime { get; set; }

        [JsonProperty("content_fetch_time")]
        public long[] ContentFetchTime { get; set; }

        [JsonProperty("diarization_time")]
        public long DiarizationTime { get; set; }

        [JsonProperty("formatting_time")]
        public long FormattingTime { get; set; }

        [JsonProperty("job_preparation_time")]
        public long JobPreparationTime { get; set; }

        [JsonProperty("merge_time")]
        public long MergeTime { get; set; }

        [JsonProperty("request_processing_time")]
        public long RequestProcessingTime { get; set; }

        [JsonProperty("segmentation_time")]
        public long SegmentationTime { get; set; }

        [JsonProperty("transcription_time")]
        public long TranscriptionTime { get; set; }
    }

    public class ChannelsStatus
    {
        [JsonProperty("firstChannelLabel")]
        public FirstChannelLabel FirstChannelLabel { get; set; }
    }

    public class FirstChannelLabel
    {
        [JsonProperty("errors")]
        public object[] Errors { get; set; }

        [JsonProperty("statistics")]
        public FluffyStatistics Statistics { get; set; }

        [JsonProperty("transcript")]
        public Transcript[] Transcript { get; set; }
    }

    public class Transcript
    {
        [JsonProperty("end")]
        public double End { get; set; }

        [JsonProperty("speaker")]
        public string Speaker { get; set; }

        [JsonProperty("start")]
        public double Start { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class FluffyStatistics
    {
        [JsonProperty("audio_analysis_time")]
        public long AudioAnalysisTime { get; set; }

        [JsonProperty("audio_channels")]
        public long AudioChannels { get; set; }

        [JsonProperty("audio_length")]
        public double AudioLength { get; set; }

        [JsonProperty("content_fetch_time")]
        public long ContentFetchTime { get; set; }

        [JsonProperty("diarization_time")]
        public long DiarizationTime { get; set; }

        [JsonProperty("execution_time")]
        public long ExecutionTime { get; set; }

        [JsonProperty("formatting_time")]
        public long FormattingTime { get; set; }

        [JsonProperty("merge_time")]
        public long MergeTime { get; set; }

        [JsonProperty("segmentation_time")]
        public long SegmentationTime { get; set; }

        [JsonProperty("transcription_time")]
        public long TranscriptionTime { get; set; }
    }

    public partial class NuanceStatus
    {
        public static NuanceStatus FromJson(string json) => JsonConvert.DeserializeObject<NuanceStatus>(json, Converter.Settings);
    }

}
