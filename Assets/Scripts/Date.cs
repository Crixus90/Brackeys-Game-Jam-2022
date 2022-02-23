using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Date : MonoBehaviour
{
    
    public TextMeshProUGUI time;
    public TextMeshProUGUI date;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string _time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
        time.text = _time;
        string _date = System.DateTime.UtcNow.ToLocalTime().ToString("dddd-dd-MMM");
        date.text = _date;
    }
}
