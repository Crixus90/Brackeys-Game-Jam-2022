// this script is there to handle things that happen in a level
// 2/25/2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject playerObj;
    void Start()
    {
        
    }

    void Update()
    {
        if(playerObj != null){

            if(playerObj.transform.position.y < - 5)
            {
                print("fallen");
                LoadLevel(2);
            }
        }
    }

    public void LoadLevel(int scene = -1)
    {
        if(scene == -1){
            scene = SceneManager.GetActiveScene().buildIndex + 1;
        }
        SceneManager.LoadScene(scene);
    }
}
