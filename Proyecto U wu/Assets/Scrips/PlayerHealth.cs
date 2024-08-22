using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int MaxHealth;
    public int scenceBuildIndex;

    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
    }

 
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            
            SceneManager.LoadScene(scenceBuildIndex, LoadSceneMode.Single);

        }
    }

}
