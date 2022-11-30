#region previous assignments
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion
#region GameStates
public enum GameState{
    inGame, pause, gameOver
}
#endregion

public class GameManager : MonoBehaviour{
    
#region Asignaciones previas
    public static GameManager gameManager;
    public static GameManager GM_Lives;
    public static float _Musicvol,_SFXvol;
    public static int lives=10,Points=0, Coins=0,Hearts=100;
    public float Musicvol,SFXvol;
    [SerializeField] SoundFXManagerv FXManager;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject []PrefabPlayer;
    int prefabPlayer=0;
    [SerializeField]  string Tag_Seguir="player";

    public static int HighScore;
    public string MainMenu="MainMenu";
    public GameState currentGameState;
    [SerializeField]private int Life,Healt, Colectables;
    [SerializeField]float volMusic, volSFX;

    [Header ("Sound Efects")]    
    public AudioClip Dead;
    public AudioClip Danger;
    

    private bool _IsCoin=false;
    public bool IsCoin{
        get=>_IsCoin;
        set=>_IsCoin=value;
        }
    
     
#endregion
#region Metodos Unity
    void Awake() {
         Singleton();
         SearchManagers();
    }
    void Update(){
        livesCount();
        UpdateInts();
        HeartsCount();
        HealtScore();
        SearchManagers();
        UpdateSound();        
    }

#endregion

#region metodos extras

    public void StartGame(){
        currentGameState=GameState.inGame;
        Time.timeScale = 1;
    }
    public void PauseGame(){
        currentGameState=GameState.pause;
        Time.timeScale = 0;
    }
    public void GameOver(string SceneToLoad){
        currentGameState=GameState.gameOver;
        Time.timeScale = 0;     
        
	   SceneManager.LoadScene (SceneToLoad);
       if(SceneToLoad==MainMenu){
           if(HighScore<=Points){
            HighScore=Points;
            Debug.Log("gameOver");
        }
           ResetGame();
       }
        
	}
    public void HealtScore(){
     if (Hearts >= 300){
         Hearts=100;
        lives++;        
        }
    }
    public void DeadMain() {
        ResetGame();
         SceneManager.LoadScene (MainMenu);

    }
    public void UpdateSound() {
        _Musicvol=Musicvol;        
        _SFXvol=SFXvol;
         Debug.Log(_SFXvol);
         Debug.Log(_Musicvol);
         }


    public void ResetGame(){
        lives=8;
        Hearts=100;
        Points=0;
        Coins=0;     
        Time.timeScale =
        Time.timeScale == 0 ? 1: 0;
    }
    void NextLive(){    
        Time.timeScale = 1;
    }
    void livesCount(){
        if(lives==0){
            GameOver(MainMenu);
        }        
    }
    void HeartsCount(){
        if(Hearts<=0){
            FXManager.SoundPlay(Dead, 3);
            Destroy(Player);
            lives-=1;
            Hearts=100;
            Instantiate(PrefabPlayer[prefabPlayer]);
            prefabPlayer++;
            
           Time.timeScale = 0;
            Invoke("NextLive", 10f);
        }
    }
    void UpdateInts(){
        Life=lives;
        Healt=Hearts;
        
        
        Colectables=Coins;
    }

    void SearchManagers() {
        if(prefabPlayer==6){
            prefabPlayer=0;
        }
        if(FXManager==null){
        FXManager=FindObjectOfType<SoundFXManagerv>();
        }
        if (Player == null){
            Player = GameObject.FindWithTag(Tag_Seguir);
    }
        }
#endregion

#region singleton
        
    void Singleton(){
        if (gameManager!=null){
    Destroy(this.gameObject);      
    }else{ 
        gameManager=this;
    DontDestroyOnLoad(this.gameObject);
    }
}
#endregion    
}    

