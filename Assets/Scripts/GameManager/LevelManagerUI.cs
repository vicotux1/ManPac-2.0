using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManagerUI: MonoBehaviour{
    [Header("Game Datos")]
    [SerializeField]int Life;  
    int Score, Heart, coins;//highScore ;
    
    int lifeGameOver=0;
    [Header("textos")]
    [SerializeField]TextMeshProUGUI Points;

     [SerializeField]TextMeshProUGUI Lives,HeartText,HighScore;
     [Header("Dependencias")]
     
     [SerializeField] LevelManagerText ManagerText;

    [SerializeField] GameManager gamanager;

    
#region Funtion Unity
    void Update(){
        Life=GameManager.lives;
        Score=GameManager.Points;
        Heart=GameManager.Hearts;
        coins=GameManager.Coins;
        //highScore=GameManager.HighScore;
        Lives.text=Life.ToString();
        Points.text= Score.ToString();
        HeartText.text=Heart.ToString();
        //HighScore.text=highScore.ToString();
        LifeCoint();
    }
    void Start(){
        Life=GameManager.lives;
        Lives.text=Life.ToString();
        Points.text= Score.ToString();
        gamanager = FindObjectOfType<GameManager>();
        ManagerText.Dead(100);
    }
    public void StartOtro(){
        if (GameManager.Coins==0){
            gamanager.PauseGame();                
        }else{
            gamanager.StartGame();  
    }
    }
#endregion

#region Funtion publics Creates
public void LifeCoint(){
        if(Life==lifeGameOver){
           // ManagerText.Perdiste();
       
        }else if(Life>=0){
         //StartCoroutine(NewBall(1.0f));   
        }
    }

#endregion


}  
