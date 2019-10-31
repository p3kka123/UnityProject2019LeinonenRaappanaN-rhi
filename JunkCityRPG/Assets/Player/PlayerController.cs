using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    [SerializeField]
    private GameObject playerGO;

    private float playerSpeed = 0.1f;
    private float playerDiagonal;

    private float strafe;
    private float forward;

    // Start is called before the first frame update
    void Awake()
    {
            playerDiagonal = playerSpeed / Mathf.Sqrt(2);
    }

    // Update is called once per frame
    void Update()
    {

        GetInput();

        playerGO.transform.position += new Vector3(forward, 0, strafe);

        RotatePlayer();


    }


    private void RotatePlayer() {
        //transform.position = Vector3.Lerp(transform.position,transform.position + new Vector3(forward,0,strafe), Time.deltaTime * 10);

        Vector3 facingRotation = new Vector3(forward,0,strafe).normalized;

        //Quaternion targetRotation = Quaternion.LookRotation(transform.position - facingRotation);
        //float turnSpeed = 90; //or whatever

        //if(facingRotation != Vector3.zero)
        //transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,Time.deltaTime * turnSpeed);

        if(facingRotation != Vector3.zero)
            transform.forward = facingRotation;
    }

    private void GetInput() {
        if(Input.GetKey(KeyCode.W)) {
            strafe = 1;
        } else if(Input.GetKey(KeyCode.S)) {
            strafe = -1;
        } else {
            strafe = 0;
        }

        if(Input.GetKey(KeyCode.A)) {
            forward = -1;
        } else if(Input.GetKey(KeyCode.D)) {
            forward = 1;
        } else {
            forward = 0;
        }

        if(forward != 0 && strafe != 0) {
            forward *= playerDiagonal;
            strafe *= playerDiagonal;
        } else {
            forward *= playerSpeed;
            strafe *= playerSpeed;
        }
    }

}
