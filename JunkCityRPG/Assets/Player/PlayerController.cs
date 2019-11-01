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

    private bool attacking;

    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        playerDiagonal = playerSpeed / Mathf.Sqrt(2);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        GetInput();

        Vector3 moveVector = new Vector3(forward,0,strafe);

        if(moveVector != Vector3.zero) 
            animator.SetBool("Moving", true);
        else
            animator.SetBool("Moving",false);

        playerGO.transform.position += moveVector;

        RotatePlayer();

    }


    private void RotatePlayer() {
        Vector3 facingRotation = new Vector3(forward,0,strafe).normalized;

        if(facingRotation != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(facingRotation),0.15F);
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

        if(Input.GetMouseButtonDown(0))
            animator.SetTrigger("Attack");

    }

}
