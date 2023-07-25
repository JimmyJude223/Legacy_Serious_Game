using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeTrigger : MonoBehaviour
{
    [Header("Visual cue")]
    [SerializeField] private GameObject visualcue;

    [Header("PC Screen")]
    [SerializeField] private GameObject computerscreen;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool speechrange;

    private void Awake()
    {
        speechrange = false;
        visualcue.SetActive(false);
        computerscreen.SetActive(false);
    }

    private void Update()
    {

        if (speechrange && !ChoicesManager.GetInstance().Dialogueisplaying)
        {
            visualcue.SetActive(true);
            computerscreen.SetActive(true);
            if (Input.GetKey(KeyCode.Space))
            {
                ChoicesManager.GetInstance().EnterSpeechMode(inkJSON);
            }
        }
        else
        {
            visualcue.SetActive(false);
            computerscreen.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            speechrange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            speechrange = false;


        }
    }
}
