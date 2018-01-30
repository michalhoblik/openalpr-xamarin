using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.Openalpr;
using Android.Content;
using OpenALPR_Xamarin.Android_Library.Models;
using Newtonsoft.Json;

namespace OpenALPR_Xamarin.Android_Library
{
    public class OpenALPR
    {
        private IOpenALPR _instance;
        private string androidDataDirPath;
        private string openAlprConfigFilePath;
        private string country;
        private string region;

        public void SetCountry(string country)
        {
            this.country = country;
        }

        public void SetRegion(string region)
        {
            this.region = region;
        }

        public OpenALPR(Context context, string androidDataDirPath, string openAlprConfigFilePath, string country = "eu", string region = "")
        {
            try
            {
                this.androidDataDirPath = androidDataDirPath;
                this.openAlprConfigFilePath = openAlprConfigFilePath;
                this.country = country;
                this.region = region;

                _instance = OpenALPRFactory.Create(context, this.androidDataDirPath);
            } catch(Exception error)
            {
                throw new Exception("OpenALPR: Couldn't create instance of OpenALPRFactory because of following error: " + error.Message + ", " + error.StackTrace, error.InnerException);
            }
        }

        public OpenALPR_Results Recognize(string imageFilePath, int topResults = 10)
        {
            try
            {
                string json = _instance.RecognizeWithCountryRegionNConfig(country, region, imageFilePath, openAlprConfigFilePath, topResults);

                try
                {
                    OpenALPR_Results results = OpenALPR_Results.Parse(json);
                    return results;
                }
                catch
                {
                    OpenALPR_Error error = OpenALPR_Error.Parse(json);
                    return new OpenALPR_Results(error);
                }

            } catch(Exception error)
            {
                return new OpenALPR_Results(new OpenALPR_Error("OpenALPR: Couldn't recognize (" + error.Message + ")", error.StackTrace));
            }
        }
        
    }
}
