
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField usernameField;
    Score scoreStruct;
    private void Update()
    {
        Debug.Log(usernameField.text.ToString());
        scoreStruct.name = usernameField.text.ToString(); 
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
