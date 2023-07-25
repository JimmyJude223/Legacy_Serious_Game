using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Choices : MonoBehaviour
{
    public Button ChoicesButton;
    // Start is called before the first frame update
    void Start()
    {
        ChoicesButton = GetComponent<Button>();
        ChoicesButton.onClick.AddListener(playLegacy);

    }
    void playLegacy()
    {
        Debug.Log("Button clicked,game started");
        SceneManager.LoadSceneAsync("Scenes/Choices");
    }
}
