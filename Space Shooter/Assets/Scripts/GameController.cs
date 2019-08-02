using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
 private float timeLeft = 30.0f; // set ur desired game time
 public static int difficulty;
 private static int timeAttack;
public GameObject[] hazards;

public Vector3 spawnValues;
public int hazardCount;
public float spawnWait;
public float startWait;
public float waveWait;
public Text ScoreText;
public Text restartText;
public Text GameOverText;

private bool gameOver;
private bool restart;
private bool winGame;

private int score;
public Text timeText;
public Text diffText;
public AudioSource WinSource;
     public AudioClip WinClip;
     public AudioSource LoseSource;
     public AudioClip LoseClip;

public static int winSpeed;


void Start()
{
 int width = 600; // or something else
     int height= 900; // or something else
     bool isFullScreen = false; // should be windowed to run in arbitrary resolution
     int desiredFPS = 60; // or something else
 
     Screen.SetResolution (width , height, isFullScreen, desiredFPS );
gameOver = false;
winSpeed = 1;
restart = false;
restartText.text = "";
GameOverText.text = "";
timeText.text = "";
if (difficulty == 2){
    diffText.text = "Hard Mode, Press 'E' for Easy";
}
else{diffText.text = "Easy Mode, Press 'H' for Hard";}

if (timeAttack != 2){
   
   
timeText.text = "Normal Mode, Press 'T' for Time Attack";
    timeAttack = 1;}
score = 0;
UpdateScore();
StartCoroutine(SpawnWaves());

}

IEnumerator SpawnWaves()
{
yield return new WaitForSeconds(startWait);
while (true)
{
for (int i = 0; i < hazardCount; i++)
{
GameObject hazard = hazards[Random.Range (0,hazards.Length)];
Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
Quaternion spawnRotation = Quaternion.identity;
Instantiate(hazard, spawnPosition, spawnRotation);
yield return new WaitForSeconds(spawnWait);
}
yield return new WaitForSeconds(waveWait);
    if (gameOver)
    {
       restartText.text = "Press 'P' for Restart"; 
       restart = true;
       break;
    }
}
}

public void AddScore(int newScoreValue)
{
score += newScoreValue;
UpdateScore();
}
void Update() {
     if(timeAttack == 2){
         timeLeft -= Time.deltaTime;
    timeText.text = "" + timeLeft.ToString ("00:00") + "\n  Press 'N' for normal mode";
         if (timeLeft <= 0){
GameOverText.text = "GAME CREATED BY MONTANA BARKER";
gameOver = true;
winGame=true;
winSpeed=80;
WinSource.Play();
restart = true;
        }}

if (Input.GetKeyDown (KeyCode.T))
    {timeAttack = 2;
    SceneManager.LoadScene("main");
    
    }

if (Input.GetKeyDown (KeyCode.N)){
        timeAttack = 1;
         timeText.text = "Normal Mode, Press 'T' for Time Attack";
         SceneManager.LoadScene("main");
    }

{
 if (Input.GetKeyDown (KeyCode.H)){ //hard
          difficulty = 2;
          print("hard");
          diffText.text = "Hard Mode, Press 'E' for Easy";
          SceneManager.LoadScene("main");}

if (Input.GetKeyDown (KeyCode.E)){ //easy
          difficulty = 1;
          print("easy");
          diffText.text = "Easy Mode, Press 'H' for Hard";
          SceneManager.LoadScene("main");}


}








    if (restart)
    {
        if (Input.GetKeyDown (KeyCode.P)){
            SceneManager.LoadScene("main"); //
        }
    }
    if (Input.GetKey("escape"))
                     Application.Quit();
}
void UpdateScore()
{
ScoreText.text = "Points: " + score;
    if((score >= 100) && (timeAttack!= 2))
    {
GameOverText.text = "GAME CREATED BY MONTANA BARKER";
timeText.text = "";
gameOver = true;
winGame=true;
winSpeed = 80;
restart = true;
WinSource.Play();
    }
}


public void GameOver()
{   
    if (winGame =! false){
        timeText.text = "";
         LoseSource.Play();
    GameOverText.text = "Game Over!";
    gameOver = true;}
}

}

