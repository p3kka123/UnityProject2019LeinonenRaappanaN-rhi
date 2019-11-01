using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour, IPointerClickHandler
{

    private bool askQ;

    [SerializeField]
    private Image image;

    [SerializeField]
    private PlayerController PController;

    [SerializeField]
    private GameObject grid;
    [SerializeField]
    private Button[] buttons;
    [SerializeField]
    private Text text;

    Dialog dialog;

    public void show(Dialog dialog1) {
        this.dialog = dialog1;
        this.dialog.SetManager(this);
        askQ = false;
        image.gameObject.SetActive(true);
        dialog.NextLine();
    }

    public void OnPointerClick(PointerEventData eventData) {
        if(!askQ)
            dialog.NextLine();
    }

    public void ST(string text) {//SetText
        this.text.text = text;
    }

    public void endConvo() {
        image.gameObject.SetActive(false);
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
        dialog.NextLine();
    }

}