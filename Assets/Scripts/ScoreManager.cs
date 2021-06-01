using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// thanks u/mchts
public class ScoreManager: MonoBehaviour { 

   public static int TotalGameTime = 2000;
 
   public static int score;
   public static int highestCombo;
   public static int leaks;
   public static int timePowered;
   public static int knivesUsed;
   private int displayScore;
   private int displayCombo;
   public Text scoreUI;
   public Text comboUI;

   void Start(){
      score = 0;
      displayScore = 0;
      highestCombo = 0;
      displayCombo = 0;
      timePowered = 0;
      knivesUsed = 0;
   }

   void FixedUpdate(){
      if(score != displayScore){
         displayScore = score;
         scoreUI.text = "Score: " + displayScore.ToString(); 
      }
      if (displayCombo != highestCombo) {
          displayCombo = highestCombo;
          comboUI.text = "Highest Combo: "+highestCombo.ToString();
      }
   }
} 