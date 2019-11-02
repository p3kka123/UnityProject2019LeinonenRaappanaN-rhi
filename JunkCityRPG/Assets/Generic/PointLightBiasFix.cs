using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightBiasFix : MonoBehaviour
{
    
    private Light thisLight;

    [SerializeField]
    private float bias;

    // Start is called before the first frame update
    void Awake()
    {
        thisLight = GetComponent<Light>();
        thisLight.shadowBias = -bias;
    }

    // Update is called once per frame
    void Update()
    {
        thisLight.shadowBias = -bias;
    }
}
