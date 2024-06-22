using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour
{
    [SerializeField] private Image myImage;
    [SerializeField] private Color myColor;

    void Start()
    {
        myColor.a = 1;
        myImage.color = myColor;
    }

}
