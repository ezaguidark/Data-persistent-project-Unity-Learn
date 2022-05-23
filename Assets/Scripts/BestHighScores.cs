using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BestHighScores : MonoBehaviour
{
    public TextMeshProUGUI user_1;
    public TextMeshProUGUI user_2;
    public TextMeshProUGUI user_3;
    public TextMeshProUGUI user_4;
    public TextMeshProUGUI user_5;

    public TextMeshProUGUI score_1;
    public TextMeshProUGUI score_2;
    public TextMeshProUGUI score_3;
    public TextMeshProUGUI score_4;
    public TextMeshProUGUI score_5;

    

    // Start is called before the first frame update
    void Start()
    {
        BestScores();
    }

    public void BestScores()
    {
        user_1.text = GameManager.instance.player_1;
        user_2.text = GameManager.instance.player_2;
        user_3.text = GameManager.instance.player_3;
        user_4.text = GameManager.instance.player_4;
        user_5.text = GameManager.instance.player_5;

        score_1.text = GameManager.instance.score_1.ToString();
        score_2.text = GameManager.instance.score_2.ToString();
        score_3.text = GameManager.instance.score_3.ToString();
        score_4.text = GameManager.instance.score_4.ToString();
        score_5.text = GameManager.instance.score_5.ToString();
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("main menu");
        BestScores();
    }
}
