using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] heartArray;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        // Make sure player does not have more health than number of heart containers 
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < heartArray.Length; i++)
        {
            // Checks whether i is smaller than amount of health, which if it is, will dislpay full heart 
            if (i < health)
            {
                heartArray[i].sprite = fullHeart;
            }
            else
            {
                heartArray[i].sprite = emptyHeart;
            }
       
        }
    }
}
