namespace OpenALPR_Xamarin.Android_Library.Models
{
    public class OpenALPR_Candidate
    {
        public string LicensePlate { get; set; }
        public double Confidence { get; set; }
        public int MatchesTemplate { get; set; }

        public OpenALPR_Candidate(string licensePlate, double confidence, int matchesTemplate)
        {
            LicensePlate = licensePlate;
            Confidence = confidence;
            MatchesTemplate = matchesTemplate;
        }
    }
}