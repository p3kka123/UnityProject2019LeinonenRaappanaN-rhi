using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImageAlpha : MonoBehaviour
{

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetAlpha(float alpha)
    {
        Color newColor = image.color;
        newColor.a = alpha;
        image.color = newColor;
    }

    public void SetActive()
    {
        Color newColor = image.color;
        newColor.a = 1f;
        image.color = newColor;
    }

    public void SetInactive()
    {
        Color newColor = image.color;
        newColor.a = 0.5f;
        image.color = newColor;
    }

}
