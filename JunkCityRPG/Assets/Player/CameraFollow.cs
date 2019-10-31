using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private GameObject GOToFollow;

    [SerializeField]
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0,5,-6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GOToFollow.transform.position + offset;
    }
}
