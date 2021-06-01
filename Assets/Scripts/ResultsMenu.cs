using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultsMenu : MonoBehaviour
{
    public Text scoreUI;
    public Text comboUI;
    public Text leaksUI;
    public Text timeUI;
    public Text knivesUI;
    public Text finalUI;

    void Start(){
        double percent_powered = (double)ScoreManager.timePowered/(double)ScoreManager.TotalGameTime;
        scoreUI.text = "Base Score: " + ScoreManager.score.ToString();
        comboUI.text = "Highest Combo: "+ ScoreManager.highestCombo.ToString();
        leaksUI.text = "Leaks: "+ ScoreManager.leaks.ToString();
        knivesUI.text = "Knives Used: "+ ScoreManager.knivesUsed.ToString();
        timeUI.text = "Time Spent\nPowered-Up: "+ ((int)(percent_powered*100)).ToString()+"%";
        int result = ((int)((ScoreManager.score - ScoreManager.knivesUsed + (ScoreManager.highestCombo * ScoreManager.highestCombo * 2)) * (1 - percent_powered) - (ScoreManager.leaks * 50)));
        if (result < 0) {
            result = 0;
        }
        finalUI.text = "Final Score:\n"+ result.ToString();
        ScoreManager.score = 0;
        ScoreManager.highestCombo = 0;
        ScoreManager.leaks = 0;
        // Formula: 
        // Score = 1 for each hit + (# of targets each knife hits) ^ 2
        // { Score + (Highest Combo ^ 2 x 2) - Knives Used } x Percent Time Not Powered Up - (# of Leaks * 50)
        // Combos get you TONS of points
    }

    public void BackToTitle() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Debug.Log("Exiting.");
        Application.Quit();
    }
}
