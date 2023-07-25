using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChoices : MonoBehaviour
{
    [SerializeField] private string[] levelNames;

    public void LoadLevel(int choiceIndex)
    {
        if (choiceIndex >= 0 && choiceIndex < levelNames.Length)
        {
            SceneManager.LoadScene(levelNames[choiceIndex]);
        }
        else
        {
            Debug.LogWarning("Invalid choice index: " + choiceIndex);
        }
    }
}