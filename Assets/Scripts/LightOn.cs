using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    Light spotLight;
    [SerializeField]
    GameObject lightOBJ;

    // Start is called before the first frame update
    void Start()
    {
        spotLight = GetComponent<Light>();
        Invoke("StartGame", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        spotLight.enabled = true;
        lightOBJ.SetActive(true);


    }
}
