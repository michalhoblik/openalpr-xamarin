using System.Collections.Generic;

namespace OpenALPR_Xamarin.Android_Library.Models
{
    public class OpenALPR_Result
    {
        public string BestLicensePlate { get; set; }
        public double Confidence { get; set; }
        public double MatchesTemplate { get; set; }
        public string Region { get; set; }
        public double RegionConfidence { get; set; }
        public double ProcessingTimeInMilliseconds { get; set; }
        public List<OpenALPR_Coordinate> CoordinatesOfLicensePlate { get; set; }
        public List<OpenALPR_Candidate> OtherCandidates { get; set; }

        public OpenALPR_Result(string bestLicensePlate, double confidence, double matchesTemplate, string region, double regionConfidence, double processingTimeInMilliseconds, List<ANPRCoordinate> coordinates, List<ANPRCandidate> candidates)
        {
            BestLicensePlate = bestLicensePlate;
            Confidence = confidence;
            MatchesTemplate = matchesTemplate;
            Region = region;
            RegionConfidence = regionConfidence;
            ProcessingTimeInMilliseconds = processingTimeInMilliseconds;
            CoordinatesOfLicensePlate = new List<OpenALPR_Coordinate>();
            OtherCandidates = new List<OpenALPR_Candidate>();

            foreach(ANPRCoordinate anprCoordinate in coordinates)
            {
                CoordinatesOfLicensePlate.Add(new OpenALPR_Coordinate(anprCoordinate.x, anprCoordinate.y));
            }

            foreach(ANPRCandidate anprCandidate in candidates)
            {
                OtherCandidates.Add(new OpenALPR_Candidate(anprCandidate.plate, anprCandidate.confidence, anprCandidate.matches_template));
            }
        }
    }
}