using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OpenALPR_Xamarin.Android_Library.Models
{
    public class OpenALPR_Results
    {
        public double EpochTime { get; set; }
        public double ProcessingTimeInMilliseconds { get; set; }
        public List<OpenALPR_Result> FoundLicensePlates { get; set; }
        public bool DidErrorOccur { get; set; }
        public OpenALPR_Error Error { get; set; }

        public OpenALPR_Results() { }

        public OpenALPR_Results(OpenALPR_Error error)
        {
            Error = error;
            DidErrorOccur = true;
        }

        public static OpenALPR_Results Parse(string json)
        {
            try
            {
                var results = JsonConvert.DeserializeObject<ANPRResults>(json);

                var parsedResults = new OpenALPR_Results
                {
                    DidErrorOccur = false,
                    EpochTime = results.epoch_time,
                    ProcessingTimeInMilliseconds = results.processing_time_ms,
                    FoundLicensePlates = new List<OpenALPR_Result>()
                };

                foreach (var anprResult in results.results)
                {
                    parsedResults.FoundLicensePlates.Add(new OpenALPR_Result(
                        anprResult.plate,
                        anprResult.confidence,
                        anprResult.matches_template,
                        anprResult.region,
                        anprResult.region_confidence,
                        anprResult.processing_time_ms,
                        anprResult.coordinates,
                        anprResult.candidates
                    ));
                }

                return parsedResults;
            }
            catch (Exception e)
            {
                return new OpenALPR_Results(new OpenALPR_Error("OpenALPR_Results: Couldn't Parse JSON (" + e.Message + ")", e.StackTrace));
            }
        }
    }
}