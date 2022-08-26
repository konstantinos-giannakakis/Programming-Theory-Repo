using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayerUIHandler : MonoBehaviour
{
    private List<string> usernames;
    public GameObject buttonPrefab;
    public GameObject panelToAttachButtonsTo;

    public void Start()
    {
        usernames = MenuManager.Instance.userNames;
        foreach (string name in usernames)
        {
            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.transform.SetParent(panelToAttachButtonsTo.transform);//Setting button parent
            button.transform.GetChild(0).GetComponent<Text>().text = name;//Changing text
            button.GetComponent<Button>().onClick.AddListener(() => ButtonOnClick(name));//Setting what button does when clicked
                                                                       //Next line assumes button has child with text as first gameobject like button created from GameObject->UI->Button
        }
    }

    void ButtonOnClick(string name)
    {
        MenuManager.Instance.selectedUser = name;
        SceneManager.LoadScene(0);
    }

}
