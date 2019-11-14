using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerGO;

    [SerializeField]
    private GameObject attackHitBox;

    private Camera mainCamera;

    [SerializeField]
    private GameObject reticlePrefab;

    private bool isDodge;

    private UIJournalStatsInvController uiJSIcontroller;
    private GameObject inventory;

    private Transform lockTargetTransform;
    private bool lockedToTarget;
    private GameObject reticle;

    [SerializeField]
    private float playerSpeed = 10f;
    private float playerDiagonal;
    private float strafe;
    private float forward;

    private Animator animator;

    private AudioSource audioSource;

    public void Die()
    {
        gameObject.transform.Rotate(90, 0, 0);
    }


    // Start is called before the first frame update
    void Awake()
    {
        playerDiagonal = playerSpeed / Mathf.Sqrt(2);
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
        Gamemanager.Instance.Player = gameObject;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        uiJSIcontroller = Gamemanager.Instance.UiJSIcontroller;
        inventory = Gamemanager.Instance.Inventory;
        Transform spawnPoint = Gamemanager.Instance.GetPlayerSpawnPosition();
        transform.SetPositionAndRotation(spawnPoint.transform.position, spawnPoint.transform.rotation);
        PlayerManager.Instance.PlayerEquipment.EquipPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.Instance.CurrentState == Gamemanager.GameState.Dead) return;
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            attackHitBox.SetActive(true);
        } else {
            attackHitBox.SetActive(false);
        }


        InitiateDialog();

        GetInput();

        TargetObject();

        Vector3 moveVector = new Vector3(forward,0,strafe);

        if(moveVector != Vector3.zero) {
            animator.SetBool("Moving",true);
            if(!audioSource.isPlaying && !isDodge)
                audioSource.Play();
        }            
        else {
            animator.SetBool("Moving",false);
            audioSource.Stop();
        }
            


        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;

        playerGO.transform.position += moveVector * Time.deltaTime;

        RotatePlayer();

    }

    private void InitiateDialog() {
        //if(!lockedToTarget && Gamemanager.Instance.CurrentState == Gamemanager.GameState.Dialog) {
        //    UninitiateDialog();
        //}
        if(!lockTargetTransform) return;

        if(Input.GetKeyDown(KeyCode.E) && lockTargetTransform.gameObject.tag == "NPC" && Gamemanager.Instance.CurrentState != Gamemanager.GameState.Dialog) {
            forward = 0;
            strafe = 0;
            lockTargetTransform.gameObject.GetComponent<Interactable>().Interact();

            if(lockTargetTransform.gameObject.GetComponent<Dialog>() == null) return;

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

        if(Gamemanager.Instance.CurrentState == Gamemanager.GameState.Menu) return;

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

    private void RemoveDodge()
    {
        isDodge = false;
        forward = 0;
        strafe = 0;
    }

    private void OpenJSI()
    {
        uiJSIcontroller.gameObject.SetActive(!uiJSIcontroller.gameObject.activeInHierarchy);
        if (uiJSIcontroller.gameObject.activeSelf) uiJSIcontroller.PressTab(uiJSIcontroller.Mode);
        if (Gamemanager.Instance.CurrentState != Gamemanager.GameState.Menu) Gamemanager.Instance.CurrentState = Gamemanager.GameState.Menu;
        else Gamemanager.Instance.CurrentState = Gamemanager.Instance.LastState;
    }

    private void OpenJSI(int mode)
    {
        if(!uiJSIcontroller.gameObject.activeSelf || mode == uiJSIcontroller.Mode) uiJSIcontroller.gameObject.SetActive(!uiJSIcontroller.gameObject.activeInHierarchy);
        if (uiJSIcontroller.gameObject.activeSelf) uiJSIcontroller.PressTab(mode);
        if (Gamemanager.Instance.CurrentState != Gamemanager.GameState.Menu) Gamemanager.Instance.CurrentState = Gamemanager.GameState.Menu;
        if (!uiJSIcontroller.gameObject.activeSelf) Gamemanager.Instance.CurrentState = Gamemanager.Instance.LastState;
    }

    private void GetInput() {

        if(Gamemanager.Instance.CurrentState == Gamemanager.GameState.Dialog || isDodge || animator.GetCurrentAnimatorStateInfo(0).IsName("Dodge")) return;


        if (Input.GetKeyDown(KeyCode.N))
            OpenJSI();

        if(Input.GetKeyDown(KeyCode.I)) {
            OpenJSI(2);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            OpenJSI(1);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            OpenJSI(0);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            OpenJSI(3);
        }

        if (Input.GetKey(KeyCode.W)) {
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

        if (Input.GetKey(KeyCode.Space))
            if (forward != 0 ||strafe != 0) {
                {
                    audioSource.Stop();
                    isDodge = true;
                    Invoke("RemoveDodge", 0.6f);
                    forward *= 1.5f;
                    strafe *= 1.5f;
                    animator.SetTrigger("Dodge");
                }
        }

        if(Gamemanager.Instance.CurrentState == Gamemanager.GameState.Menu) return;

        if(Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("Attack");
        }
    }

}
