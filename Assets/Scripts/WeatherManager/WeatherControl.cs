using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherControl : MonoBehaviour
{
    public GameObject[] weatherArray;
    public Transform spawnPositionTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject spawnWeatherEmote(string weatherCondition)
    {
        GameObject spawnedEffect = null;

        foreach(GameObject se in weatherArray)
        {
            if(se.name.Equals(weatherCondition))
            {
                spawnedEffect = se;

                if (spawnedEffect != null)
                {
                    print(spawnedEffect.name);
                    return Instantiate(spawnedEffect, spawnPositionTransform.transform.position, Quaternion.identity);
                }
            }          
        }
        Debug.LogError("Condtion not found!");
        return null;

        /*
        if (weatherCondition == "Clear")
        {
            spawnedEffect = weatherArray[0];
        }
        else if (weatherCondition == "Clouds")
        {
            spawnedEffect = weatherArray[0];
        }
        else if (weatherCondition == "Snow")
        {
            spawnedEffect = weatherArray[0];
        }
        else if (weatherCondition == "Drizzle")
        {
            spawnedEffect = weatherArray[0];
        }
        else if (weatherCondition == "Rain")
        {
            spawnedEffect = weatherArray[0];
        }
        else if (weatherCondition == "Thunderstorm")
        {
            spawnedEffect = weatherArray[0];
        }
        else
        {
            Debug.LogError("Condtion not found!");
        }
        */
    }
}
