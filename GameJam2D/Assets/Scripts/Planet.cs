using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public GameObject GameOverPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {            
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
      
    }
}
