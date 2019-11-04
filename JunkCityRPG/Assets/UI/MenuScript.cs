using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    private Text[] texts;

    // Start is called before the first frame update
    void Start()
    {
        texts = gameObject.GetComponentsInChildren<Text>();
        UpdateFields();
    }

    public void UpdateFields()
    {
        foreach(Text text in texts)
        {
            if(text.name == "NameText")
            {
                text.text = "slobodan";
            }else if(text.name == "StatText")
            {
                text.text = "Strength: " + PlayerManager.Instance.Stats.GetStrength() + "\n\n gona";
            }
        }
    }
}
