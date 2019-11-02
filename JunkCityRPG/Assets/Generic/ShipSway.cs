using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSway : MonoBehaviour
{

    public float perlinScale;
    public float step;



    private float x;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler((Mathf.PerlinNoise(x,z) - 0.5f) * perlinScale,0,(Mathf.PerlinNoise(z+1000,x+1000) - 0.5f) * perlinScale);
        z += step;
        x += step;
    }
}
