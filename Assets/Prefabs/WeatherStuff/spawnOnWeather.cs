using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnOnWeather : MonoBehaviour
{
    WeatherManager myWeather;
    WeatherControl weatherC;
    public string CitySearch;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        GameObject manager = GameObject.Find("WeatherManager");
        myWeather = manager.GetComponent<WeatherManager>();
        weatherC = manager.GetComponent<WeatherControl>();


        myWeather.cityName = CitySearch;

        //myWeather.GetJsonData();
        yield return StartCoroutine(GetCityData());

        weatherC.spawnWeatherEmote(myWeather.weather);
        print(myWeather.location);
        print(myWeather.weather);
        print(myWeather.geoLat);
        print(myWeather.geoLon);
        print(myWeather.geoLocation);
        print("JOBS DONE!");



    }
  

    IEnumerator GetCityData()
    {
        myWeather.GetJsonData();
        print("Searching for weather...");
        yield return new WaitForSeconds(2);

    }
}
