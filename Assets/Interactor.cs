using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public Image cursor;

    Vector2 startSize = new Vector2(10, 10);
    Vector2 endSize = new Vector2(30, 30);
    float duration = .3f;
    float elapsedTime;

    Transform selectedOBJ;

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
            Debug.Log("Did Hit");
            elapsedTime += Time.deltaTime;
            float percentage = elapsedTime / duration;
            cursor.rectTransform.sizeDelta = Vector2.Lerp(startSize, endSize, percentage);
            if (Input.GetMouseButtonDown(0))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Did not Hit");
            elapsedTime = 0;
            cursor.rectTransform.sizeDelta = startSize;
        }
    }
}
