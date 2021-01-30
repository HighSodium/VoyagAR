using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using TMPro;
using UnityEngine.Networking;

public class WeatherManager : MonoBehaviour
{
    //public string weatherAPI = "api.openweathermap.org/data/2.5/weather?q=London,uk&appid=16b632699a5b299cfd0723abf35b5b3a";
    public TextMeshProUGUI location;
    public TextMeshProUGUI weather;
    //public TextMeshProUGUI mainWeather;
    //public TextMeshProUGUI description;
    public TextMeshProUGUI geoLocation;

    public TMP_InputField cityName; // User input in UI

    public void GetJsonData()
    {
        StartCoroutine(RequestWeatherData());
    }

    IEnumerator RequestWeatherData()
    {
        string weatherAPI = "api.openweathermap.org/data/2.5/weather?q=" + cityName.text + "&appid=16b632699a5b299cfd0723abf35b5b3a";
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
                        location.text = response["name"];
                        weather.text = response["main"];
                        geoLocation.text = response["coord"]["lon"]["lat"];
                    }
                }
            }
         
        }
    }
}
