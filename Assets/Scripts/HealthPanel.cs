using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    [SerializeField]
    private int health;

    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHealth, halfHealth, emptyHealth;

    public int Health { 
        get => health; 
        set { 
            health = value;

            bool empty = false;

            int i = 0;
            foreach (Image image in hearts)
            {
                if (empty)
                {
                    image.sprite = emptyHealth;
                }
                else
                {
                    i++;
                    if (health >= i * 2)
                    {
                        image.sprite = fullHealth;
                    }
                    else
                    {
                        image.sprite = health % 2 == 0 ? emptyHealth : halfHealth;
                        empty = true;
                    }
                }
            }
        } 
    }
}
