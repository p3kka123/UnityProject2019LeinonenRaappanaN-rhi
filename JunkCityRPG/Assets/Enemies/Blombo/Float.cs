using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{

    float angle;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Mathf.Sin(angle) / 100, 0);
        angle += 0.01f;

    }
}
