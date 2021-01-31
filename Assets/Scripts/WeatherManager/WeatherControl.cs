using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation.Samples;
using TMPro;

public class WeatherControl : MonoBehaviour
{
    public GameObject[] weatherArray;
    public Transform spawnPositionTransform;

    private GameObject spawnedEffect;


    public GameObject spawnWeatherEmote(string weatherCondition)
    {        
        foreach(GameObject se in weatherArray)
        {
            if(se.name.Equals(weatherCondition))
            {
                spawnedEffect = se;

                if (spawnedEffect != null)
                {
                    print(spawnedEffect.name);

                    spawnPositionTransform = GameObject.Find("WEATHERHOLDER").transform;
                    spawnedEffect = Instantiate(spawnedEffect, spawnPositionTransform.transform.position, Quaternion.identity, GameObject.Find("ARCity").transform);

                    
                    //GameObject.Find("AR Session Origin").GetComponent<PlaceOnPlane>().placedPrefab = spawnedEffect;                
                    return spawnedEffect;
                }
            }          
        }
        Debug.LogError("Condition not found!");
        return null;

    }

    public void RemoveSpawnedEffect()
    {
        //GameObject.Find("AR Session Origin").GetComponent<PlaceOnPlane>().placedPrefab = null;
        //GameObject temp = GameObject.Find("AR Session Origin").GetComponent<PlaceOnPlane>().spawnedObject;
        Destroy(spawnedEffect);
        GameObject.Find("WeatherText(TMP)").GetComponent<TextMeshPro>().text = "";
        GameObject.Find("CityText(TMP)").GetComponent<TextMeshPro>().text = "";
    }
}
