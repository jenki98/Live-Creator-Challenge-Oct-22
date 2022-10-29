
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField usernameField;
    string username;
    private void Update()
    {
        Debug.Log(usernameField.text.ToString());
        username = usernameField.text.ToString();
       
    }
    public void PlayGame()
    {
        PlayerPrefs.SetString("Username", username);
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = PlayerPrefs.GetString("Username")
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    private void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Display Name created");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error Logging in/Creating Account");
        Debug.Log(error.GenerateErrorReport());
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
