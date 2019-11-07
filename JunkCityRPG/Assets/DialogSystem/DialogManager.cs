using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour, IPointerClickHandler
{

    private static DialogManager _instance;

    public static DialogManager Instance { get { return _instance; } }

    private bool askQ;

    [SerializeField]
    private Image image;

    private PlayerController PController;

    [SerializeField]
    private GameObject grid;
    [SerializeField]
    private Button[] buttons;
    [SerializeField]
    private Text dialogText;

    Dialog dialog;


    

    public void show(Dialog dialog1) {
        this.dialog = dialog1;
        this.dialog.SetManager(this);
        askQ = false;
        image.gameObject.SetActive(true);
        dialog.NextLine();
    }

    private void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private void Start() {
        if(Gamemanager.Instance.Player != null)
            PController = Gamemanager.Instance.Player.GetComponent<PlayerController>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        if(!askQ && dialog != null)
            dialog.NextLine();
    }

    public void ST(string text) {//SetText
        this.dialogText.text = text;
    }

    public void endConvo() {
        image.gameObject.SetActive(false);
        dialog = null;
        if(PController != null)
            PController.UninitiateDialog();
    }

    public void Question(int amount,string[] answers) {
        askQ = true;
        for(int i = 0; i < amount; i++) {
            buttons[i].gameObject.SetActive(true);
            buttons[i].GetComponentInChildren<Text>().text = answers[i];
        }
    }

    public void AnsQues(int ans) {
        askQ = false;
        foreach(Button button in buttons) {
            button.gameObject.SetActive(false);
        }
        dialog.HandleQuestion(ans);
        //dialog.NextLine();
    }

}