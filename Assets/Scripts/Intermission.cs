using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intermission : MonoBehaviour
{
    public Button StartButton;
    // Start is called before the first frame update
    void Start()
    {
        StartButton = GetComponent<Button>();
        StartButton.onClick.AddListener(playLegacy);

    }
    void playLegacy()
    {
        Debug.Log("Button clicked,game started");
        SceneManager.LoadSceneAsync("Scenes/Level_23a");
    }

}
