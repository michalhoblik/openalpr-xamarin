using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace OpenALPR_Xamarin.Android_Library.Models
{
    public class OpenALPR_Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public OpenALPR_Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}