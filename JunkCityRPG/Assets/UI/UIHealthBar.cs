using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{

    TextMeshProUGUI textMesh;

    private void Start() {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Health " + PlayerManager.Instance.Stats.CurrHealth + "/" + PlayerManager.Instance.Stats.Health;
    }
}
