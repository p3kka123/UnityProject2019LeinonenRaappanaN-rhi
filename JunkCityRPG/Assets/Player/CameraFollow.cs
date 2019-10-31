using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private GameObject GOToFollow;

    [SerializeField]
    private float offset;

    

    // Update is called once per frame
    void Update()
    {
        offset -= Input.mouseScrollDelta.y;

        offset = Mathf.Clamp(offset, 4, 20);

        Vector3 offsetVector = new Vector3(0, offset, -offset * 1.1f);

        //transform.position = GOToFollow.transform.position + offsetVector;
        //transform.Translate((GOToFollow.transform.position + offsetVector) * Time.deltaTime);
        transform.position = Vector3.Slerp(transform.position,GOToFollow.transform.position + offsetVector, 0.2f);
    }




}
