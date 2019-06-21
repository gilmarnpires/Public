using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public AudioClip saw;
    public GameObject gameOver;
    public int Damage1 = 1;
    public int Damage = 4;
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = saw;
        gameOver.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Enemy")) ;

        {
            GetComponent<AudioSource>().Play();
            Damage -= Damage1;
        }
    }

    void Update()
    {
        health = Damage;

        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            
                if(i < health)
                {
                    hearts[i].sprite = fullHeart;
                }

                else
                {
                    hearts[i].sprite = emptyHeart;
                }

                if (i < numOfHearts)
                {
                    hearts[i].enabled = true;
                }

            else
            {
                hearts[i].enabled = false;
            }
        }

        if(health <= 0)
        {
            gameOver.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           // Time.timeScale = 0;
        }
    }
}
