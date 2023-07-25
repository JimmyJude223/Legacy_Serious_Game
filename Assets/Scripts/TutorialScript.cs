using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    public string showtext = "";
    public float displaytimer = 5f;
    public TextMeshProUGUI textComponent;

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textComponent.text = showtext;

            Invoke ("HideTutorial",displaytimer);
        }
    }

    void HideTutorial()
    {
        textComponent.text = "";
    }

}
