using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnOnWeather : MonoBehaviour
{
    WeatherManager myWeather;
    public string CitySearch;

    // Start is called before the first frame update
    void Start()
    {
        myWeather = GameObject.Find("WeatherManager").GetComponent<WeatherManager>();

        myWeather.cityName = CitySearch;

        myWeather.GetJsonData();

        print(myWeather.location);
        print(myWeather.weather);
        print(myWeather.geoLocation);
        print("JOBS DONE!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
