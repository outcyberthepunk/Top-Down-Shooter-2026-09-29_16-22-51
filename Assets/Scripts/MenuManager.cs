using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
