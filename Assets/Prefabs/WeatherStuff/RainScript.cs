using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RainScript : MonoBehaviour
{

    public ParticleSystem rainParticles;
    public bool isRaining = true;

    // Start is called before the first frame update
    void Start()
    {
        rainParticles.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        rainParticles.Stop();
        
    }

    
}
