using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    public UnityEvent interactEvent;
    // Start is called before the first frame update
    public void Test()
    {
        Debug.Log("testing interact");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
