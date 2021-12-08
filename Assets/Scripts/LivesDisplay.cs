using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesDisplay : MonoBehaviour
{
    static int lives = 5;
    Text livesText;


    // Start is called before the first frame update
    void Start()
    {
        // if we are starting a new game, set lives to full amount
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            lives = 5;
        }

        
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void LoseLife()
    {
        lives -= 1;
        UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

    
}
