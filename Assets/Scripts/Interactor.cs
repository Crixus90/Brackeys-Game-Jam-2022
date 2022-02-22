using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// this component goes on main camera
public class Interactor : MonoBehaviour
{
    public Image cursor;
    Transform selectedOBJ;

    // cursor vars 
    public float cursorSmallSize = 10;
    public float cursorBigSize = 30;
    public float cursorGrowSpeed;

    //private bool interacting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2, layerMask))
        {
            //Debug.Log("Did Hit");
            selectedOBJ = hit.transform;
            
        }
        else
        {
            //Debug.Log("Did not Hit");
            selectedOBJ = null;
        }
    }
    void Update()
    {
        if (selectedOBJ != null)
        {
            float lerpNum = Mathf.Lerp(cursor.rectTransform.sizeDelta.x, cursorBigSize, cursorGrowSpeed);
            cursor.rectTransform.sizeDelta =  new Vector2(lerpNum,lerpNum);

            if (Input.GetMouseButtonDown(0))
            {
                //hit.transform.gameObject.SetActive(false);
                
                GameObject obj = selectedOBJ.gameObject;
                obj.GetComponent<Interactable>().interactEvent.Invoke();
                print("test");
               
            }
        }else
        {
            float lerpNum = Mathf.Lerp(cursor.rectTransform.sizeDelta.x, cursorSmallSize, cursorGrowSpeed);
            cursor.rectTransform.sizeDelta =  new Vector2(lerpNum,lerpNum);
        }
    }
}
