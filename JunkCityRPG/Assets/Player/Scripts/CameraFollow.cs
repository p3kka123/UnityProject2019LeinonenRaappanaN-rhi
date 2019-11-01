using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private GameObject GOToFollow;

    [SerializeField]
    private float offset = 8;

    private float zoomspeed = 2f;

    [SerializeField]
    private bool indoorsCamera;



    void Start() {
        transform.rotation = Quaternion.Euler(35, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
      ScrollCamera();

        offset = Mathf.Clamp(offset, 4, 20);

        Vector3 offsetVector = new Vector3(0, offset, -offset * 1.1f);

        transform.position = GOToFollow.transform.position + offsetVector;
    }

    private void ScrollCamera() {
        if(indoorsCamera) return;

        float mouseInput = -Input.mouseScrollDelta.y * zoomspeed;

        if(mouseInput != 0)
            StartCoroutine(LerpFromTo(offset,offset + mouseInput,0.15f));
    }

    public void SetGOToFollow(GameObject go) {
        GOToFollow = go;
    }

    IEnumerator LerpFromTo(float pos1, float pos2,float duration) {
        for(float t = 0f; t < duration; t += Time.deltaTime) {
            offset = Mathf.Lerp(pos1,pos2,t / duration);
            yield return 0;
        }
        offset = pos2;
    }


 }
