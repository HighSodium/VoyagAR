using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using TMPro;
using UnityEngine.Networking;

public class WeatherManager : MonoBehaviour
{ 

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

    public IEnumerator RequestWeatherData()
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
                    //var response = JSON.Parse(webData.downloadHandler.text);
                    JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString(webData.downloadHandler.data));

                    if (jsonData == null)
                    {
                        print("NO DATA");
                    }
                    else
                    {
                        location = jsonData["name"];
                        weather = jsonData["main"];
                        geoLocation = jsonData["coord"]["lon"]["lat"];
                    }
                }
            }
         
        }
    }
}
