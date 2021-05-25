using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsChoice : MonoBehaviour
{
    public void FirstLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }

    public void SecondLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }

    public void ThirdLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    }

    public void FourthLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);

    }

    public void FifthLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);

    }
}
