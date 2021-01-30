using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using TMPro;
using UnityEngine.Networking;

public class WeatherManager : MonoBehaviour

    //public TextMeshProUGUI location;
    public string location;
    //public TextMeshProUGUI weather;
    public string weather;
    //public TextMeshProUGUI geoLocation;
    public string geoLocation;

    //public TMP_InputField cityName; // User input in UI
    public string cityName;



    public void GetJsonData()
    {
        StartCoroutine(RequestWeatherData());
    }

    IEnumerator RequestWeatherData()
    {
        string weatherAPI = "api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=16b632699a5b299cfd0723abf35b5b3a"; //cityName.text
        print(weatherAPI);

        using (UnityWebRequest webData = UnityWebRequest.Get(weatherAPI))
        {
            yield return webData.SendWebRequest();
            if (webData.isNetworkError || webData.isHttpError)
            {
                print("ERROR");
                print(webData.error);
            }
            else
            {
                if (webData.isDone)
                {
                    var response = JSON.Parse(webData.downloadHandler.text);

                    if (response == null)
                    {
                        print("NO DATA");
                    }
                    else
                    {
                        location = response["name"];
                        weather = response["main"];
                        geoLocation = response["coord"]["lon"]["lat"];
                    }
                }
            }
         
        }
    }
}
