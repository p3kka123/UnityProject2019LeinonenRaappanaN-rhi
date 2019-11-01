using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private GameObject GOToFollow;

    [SerializeField]
    private float offset;

    private float zoomspeed = 2f;

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseInput = -Input.mouseScrollDelta.y * zoomspeed;

        if(mouseInput != 0) 
            StartCoroutine(LerpFromTo(offset, offset + mouseInput, 0.15f));


        offset = Mathf.Clamp(offset, 4, 20);

        Vector3 offsetVector = new Vector3(0, offset, -offset * 1.1f);

        transform.position = GOToFollow.transform.position + offsetVector;
        //transform.Translate((GOToFollow.transform.position + offsetVector) * Time.deltaTime);
        //transform.position = Vector3.Slerp(transform.position,GOToFollow.transform.position + offsetVector, 0.2f);
    }


    IEnumerator LerpFromTo(float pos1, float pos2,float duration) {
        for(float t = 0f; t < duration; t += Time.deltaTime) {
            offset = Mathf.Lerp(pos1,pos2,t / duration);
            yield return 0;
        }
        offset = pos2;
    }

 }
