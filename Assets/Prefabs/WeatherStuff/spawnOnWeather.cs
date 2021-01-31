using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spawnOnWeather : MonoBehaviour
{
    WeatherManager myWeather;
    WeatherControl weatherC;
    //public CitySearch;

    // Start is called before the first frame update

    public void StartWeatherFinder()
    {
        StartCoroutine(WeatherFinder());
        print("Starting WeatherFinder...");
    }
    public IEnumerator WeatherFinder()
    {
        print("Preparing...");
        GameObject manager = GameObject.Find("WeatherManager");
        myWeather = manager.GetComponent<WeatherManager>();
        weatherC = manager.GetComponent<WeatherControl>();


        //myWeather.cityName = CitySearch;

        //myWeather.GetJsonData();
        yield return StartCoroutine(GetCityData());

        weatherC.spawnWeatherEmote(myWeather.weather);

        GameObject.Find("WeatherText(TMP)").GetComponent<TextMeshPro>().text = myWeather.weather;
        GameObject.Find("CityText(TMP)").GetComponent<TextMeshPro>().text = myWeather.location;
        print(myWeather.location);
        print(myWeather.weather);
        print(myWeather.geoLat);
        print(myWeather.geoLon);
        print(myWeather.geoLocation);

        print("WEATHER FOUND!");
    }
  
    IEnumerator GetCityData()
    {
        myWeather.GetJsonData();
        print("Searching for weather...");
        yield return new WaitForSeconds(1);

    }
}
