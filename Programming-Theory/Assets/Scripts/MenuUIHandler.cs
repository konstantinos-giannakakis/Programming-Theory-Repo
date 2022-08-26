using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text selectedPlayer;

    private void Start()
    {

    }

    private void Update()
    {
        if (MenuManager.Instance.selectedUser == null)
        {
            Debug.Log("Name is null");
        }
        else
        {
            selectedPlayer.text = "Selected Player: " + MenuManager.Instance.selectedUser;
        }
    }

    public void ChoosePlayer()
    {
        // Abstraction
        MenuManager.Instance.ChoosePlayer();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity player
#endif
    }

    public void SaveName(InputField userField)
    {
        // Abstraction
        MenuManager.Instance.SaveName(userField.text);
    }

}
