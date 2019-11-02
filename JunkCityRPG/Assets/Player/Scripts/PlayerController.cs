using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerGO;

    [SerializeField]
    private GameObject attackHitBox;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private GameObject reticlePrefab;

    private Transform lockTargetTransform;
    private bool lockedToTarget;
    private GameObject reticle;

    private float playerSpeed = 10f;
    private float playerDiagonal;
    private float strafe;
    private float forward;

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

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            attackHitBox.SetActive(true);
        } else {
            attackHitBox.SetActive(false);
        }


        InitiateDialog();

        GetInput();

        TargetObject();

        Vector3 moveVector = new Vector3(forward,0,strafe);

        if(moveVector != Vector3.zero) 
            animator.SetBool("Moving", true);
        else
            animator.SetBool("Moving",false);

        playerGO.transform.position += moveVector * Time.deltaTime;

        RotatePlayer();

    }

    private void InitiateDialog() {
        if(!lockedToTarget && Gamemanager.Instance.CurrentState == Gamemanager.GameState.Dialog) {
            UninitiateDialog();
        }
        if(!lockTargetTransform) return;

        if(Input.GetKeyDown(KeyCode.E) && lockTargetTransform.gameObject.tag == "NPC" && lockTargetTransform.gameObject.GetComponent<Dialog>() != null) {
            lockTargetTransform.gameObject.GetComponent<Interactable>().Interact();
            Gamemanager.Instance.CurrentState = Gamemanager.GameState.Dialog;
            Camera.main.GetComponent<CameraFollow>().SetGOToFollow(lockTargetTransform.gameObject);
        }
    }

    public void UninitiateDialog()
    {
        Camera.main.GetComponent<CameraFollow>().SetGOToFollow(gameObject);
        Gamemanager.Instance.CurrentState = Gamemanager.Instance.LastState;
        UnlockFromTarget();
    }

    private void TargetObject() {

        if(lockTargetTransform == null) {
            Destroy(reticle);
            lockedToTarget = false;
        }

        if (Input.GetMouseButtonDown(2) && Gamemanager.Instance.CurrentState != Gamemanager.GameState.Dialog) { // if middle button pressed...
            Destroy(reticle);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)) {
                // the object identified by hit.transform was clicked
                if(hit.transform.gameObject.tag == "Enemy") {                  
                    SetTarget(hit);
                } else if(hit.transform.gameObject.tag == "NPC") {                    
                    SetTarget(hit);
                    reticle.GetComponent<TargetReticle>().SetColor(Color.white);
                } else {
                    UnlockFromTarget();
                }
            } else {
                UnlockFromTarget();
            }
        }
    }

    private void SetTarget(RaycastHit hit) {
        print("targeted: " + hit.transform.gameObject);
        lockedToTarget = true;
        lockTargetTransform = hit.transform;
        reticle = Instantiate(reticlePrefab);
        reticle.GetComponent<TargetReticle>().SetTarget(lockTargetTransform);
    }


    private void UnlockFromTarget() {
        print("unlocked target");
        lockedToTarget = false;
        lockTargetTransform = null;
    }

    private void RotatePlayer() {
        Vector3 facingRotation = new Vector3(forward,0,strafe).normalized;

        if(lockedToTarget) {
            Vector3 targetPos = new Vector3(lockTargetTransform.position.x, transform.position.y,lockTargetTransform.position.z);

            Vector3 relativePos = targetPos - transform.position;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos,Vector3.up);
            transform.rotation = rotation;
            return;
        }
            

        if(facingRotation != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(facingRotation),0.15F);
    }

    private void GetInput() {

        if(Gamemanager.Instance.CurrentState == Gamemanager.GameState.Dialog) return;

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

        if(Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("Attack");
        }
    }

}
