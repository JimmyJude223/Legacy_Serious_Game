using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Back : MonoBehaviour
{
    
        public Button BackButton;
        // Start is called before the first frame update
        void Start()
        {
            BackButton = GetComponent<Button>();
            BackButton.onClick.AddListener(playLegacy);

        }
        void playLegacy()
        {
            Debug.Log("Button clicked,game started");
            SceneManager.LoadSceneAsync("Scenes/End");
        }


}
