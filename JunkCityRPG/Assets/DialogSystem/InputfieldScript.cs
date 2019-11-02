using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputfieldScript : MonoBehaviour
{
    [SerializeField]
    private InputField mainInputField;

    private void Start()
    {
        mainInputField.characterLimit = 16;
    }

}
