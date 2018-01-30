using System.Collections.Generic;

namespace OpenALPR_Xamarin.Android_Library.Models
{
    public class ANPRResults
    {
        public double epoch_time { get; set; }
        public double processing_time_ms { get; set; }
        public List<ANPRResult> results { get; set; }
    }

    public class ANPRResult
    {
        public string plate { get; set; }
        public double confidence { get; set; }
        public double matches_template { get; set; }
        public string region { get; set; }
        public double region_confidence { get; set; }
        public double processing_time_ms { get; set; }
        public List<ANPRCoordinate> coordinates { get; set; }
        public List<ANPRCandidate> candidates { get; set; }
    }

    public class ANPRCoordinate
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class ANPRCandidate
    {
        public string plate { get; set; }
        public double confidence { get; set; }
        public int matches_template { get; set; }
    }

    public class ANPRError
    {
        public bool error { get; set; }
        public string msg { get; set; }
    }
}