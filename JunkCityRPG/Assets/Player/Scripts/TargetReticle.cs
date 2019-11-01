using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReticle : MonoBehaviour
{

    private Transform target;


    public void SetTarget(Transform targetTransform) {
        target = targetTransform;
    }

    // Update is called once per frame
    void Update() {
        transform.LookAt(Camera.main.transform.position,-Vector3.up);
        transform.position = target.position;
    }



}
