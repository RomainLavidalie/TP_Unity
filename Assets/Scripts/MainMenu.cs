using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayCharacter()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayIsland()
    {
        SceneManager.LoadScene(2);
    }
    public void PlaySound()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayController()
    {
        SceneManager.LoadScene(4);
    }
    public void PlayPatrick()
    {
        SceneManager.LoadScene(5);
    }
    
    public void PlayIG()
    {
        SceneManager.LoadScene(6);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
