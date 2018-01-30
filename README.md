# OpenALPR Xamarin
A Open-source Xamarin integration for [OpenALPR](https://github.com/openalpr/openalpr). (Only supports Android at the moment. Anyone is welcome to port it to Xamarin.iOS) 

<img alt="OpenALPR Xamarin Android Sample App" src="http://kevinjp.dk/xamarin.png" width=200 height=350 /> 

## Introduction
Ever wanted to use OpenALPR with Xamarin but never could? Look no further! After tons of research and testing, I've developed a solution that uses the Native JNI Libraries in combination with Android AAR libraries to create a Xamarin Library that can be used to execute OpenALPR recognition.

## Contents of this Repository
- **OpenALPR Xamarin.Android Binding** which is used to bind the .AAR file generated from [SandroMachado's](https://github.com/SandroMachado/openalpr-android) Android Project. This creates a bindable DLL to use in the next bullet.

- **OpenALPR Xamarin.Android Library** which is used to bind the previous Binding into a neat and easy assembly for management and execution.

- **OpenALPR Xamarin.Android Sample App** which is used for testing purposes and showing a sample of how the solution works. 

- **Releases** which contains all the nercessary files to use OpenALPR in your project (taking into consideration that you've followed the below guide)

## Requirements
- Android 4.1+
- Latest version of Xamarin (Not tested on older versions)
- Newtonsoft.Json

## Installation / How to use
To use OpenALPR in your Xamarin project, here's a guide on how to do it.

### Xamarin.Android
1. First off, reference the ```OpenALPR Xamarin.Android Library``` file which is located in the Releases folder
2. Now reference these 2 files also (Both can be retrieved from ```C:\Windows\Microsoft.NET\Framework\v4.0.30319```:
    - System.Drawing.dll
    - System.Configuration.dll
3. You also need to reference Newtonsoft.Json which you can get from NuGet
4. Copy the folder "lib" from the Releases folder and place it (with it's libraries) in your Project Folder. Mark ALL of them as ```AndroidNativeLibrary```
5. Go to your **Project Properties -> Android Options** and uncheck ```Use Shared Runtime``` and set the **Linking** property to ```None```
6. Copy the **runtime_data** folder from OpenALPR into your **Assets** folder of your Project, together with the **openalpr.conf** file.

Now that the Installation part is done, let's see how it actually is used.
1. Create an instance of the ```OpenALPR``` class and fill out the paths of where you placed your OpenALPR data.
```csharp
OpenALPRInstance = new OpenALPR(this, AndroidDataDir, OpenALPRConfigFile, "eu");
```
2. After this, you are able to execute the the Recognize function.
```csharp
OpenALPR_Results results = OpenALPRInstance.Recognize(ImagePath);

if(results.DidErrorOccur == false)
{
	string output = "";

	foreach (var flp in results.FoundLicensePlates)
	{
		output += "Best: " + flp.BestLicensePlate + "(" + flp.Confidence + "%)\n";
		foreach (var oc in flp.OtherCandidates)
		{
			output += "- " + oc.LicensePlate + "(" + oc.Confidence + "%)\n";
		}
	}
	
	//Show output
} else
{
	// Handle error scenario..
}

```

    
### Xamarin.iOS 
- Not supported at the moment, anyone is welcome to port it



## Further Development / Want to help?
Feel free to make a Pull Request and further develop this! An iOS version of this would be very cool to see!
I will however be making updates and changes to the Android version of the library to increase recognition speed, reduce file size, etc.

## Contact
If you want to reach out to me, you can do so by multiple ways:
- [Twitter (@KevinJPetersen)](http://twitter.com/kevinjpetersen)
- Email: kevingeeken@gmail.com
- LinkedIn (http://linkedin.com/in/publicvoid/)
- Or simply by posting an "Issue" on this Github :)

## Credits
- Java code from SandroMachado (https://github.com/SandroMachado/openalpr-android) which was used to create an AAR library
- OpenALPR (for making the core functionality behind the Recognition technology) (https://github.com/openalpr/openalpr)
