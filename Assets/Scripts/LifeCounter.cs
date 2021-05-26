using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;

    public void LoseLife()
    {
        //If no lives remaining do nothing
        if (livesRemaining == 0)
            return;
        //Decrease the value of livesRemaining
        livesRemaining--;
        //Hide one of the life images
        lives[livesRemaining].enabled = false;

        //If we run out of lives we lose the game
        //if (livesRemaining == 0)
        //{
        //    FindObjectOfType<Hero>().Die();
        //}
    }

    //private void Update()
    //{
    //    //if (Input.GetKeyDown(KeyCode.Backspace))
    //    //    LoseLife();

    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        OnCollisionEnter2D();
    //    }
    //}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Dragon")
        {
            LoseLife();
        }
    }
}
