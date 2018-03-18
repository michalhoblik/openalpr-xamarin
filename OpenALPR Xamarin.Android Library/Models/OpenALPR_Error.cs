using Newtonsoft.Json;
using System;

namespace OpenALPR_Xamarin.Android_Library.Models
{
    public class OpenALPR_Error
    {
        public string Message { get; set; }
        public string Stacktrace { get; set; }

        public OpenALPR_Error(string message, string stacktrace)
        {
            Message = message;
            Stacktrace = stacktrace;
        }

        public static OpenALPR_Error Parse(string json)
        {
            try
            {
                var error = JsonConvert.DeserializeObject<ANPRError>(json);
                return new OpenALPR_Error("OpenALPR_Error: Error has happened when using Recognize method", error.msg);
            }
            catch (Exception error)
            {
                return new OpenALPR_Error($"OpenALPR_Error: Couldn't parse JSON", error.Message + ", " + error.StackTrace);
            }
        }
    }
}