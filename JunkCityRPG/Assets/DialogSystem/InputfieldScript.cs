using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputfieldScript : MonoBehaviour
{
    private InputField mainInputField;

    private void OnEnable()
    {
        mainInputField = GetComponent<InputField>();
        mainInputField.characterLimit = 16;
        //mainInputField.Select();
        mainInputField.ActivateInputField();
    }
    private void LateUpdate()
    {
        if (mainInputField.IsActive()) mainInputField.ActivateInputField();
    }
}
