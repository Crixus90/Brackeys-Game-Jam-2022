using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    bool hasPill = false;

    public void PickUpFunc(GameObject obj)
    {
        StartCoroutine(PickUp(obj));
    }
    public IEnumerator PickUp(GameObject obj)
    {
        Vector3 pos = transform.position;
        pos.y += 1;
        while(Vector3.Distance(obj.transform.position, pos) > .1)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, pos, .02f);
           
            yield return null;
        }

        hasPill = true;
        Destroy(obj);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("EatPill") && hasPill)
        {
            TakePill();
        }
    }

    void TakePill()
    {
        print("ate pill");
        //play eating animation


        // do all the camera warping stuff

    }
}
