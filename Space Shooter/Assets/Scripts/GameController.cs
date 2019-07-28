using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
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

void Start()
{
 int width = 600; // or something else
     int height= 900; // or something else
     bool isFullScreen = false; // should be windowed to run in arbitrary resolution
     int desiredFPS = 60; // or something else
 
     Screen.SetResolution (width , height, isFullScreen, desiredFPS );
gameOver = false;
restart = false;
restartText.text = "";
GameOverText.text = "";
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
    if(score >= 200)
    {
GameOverText.text = "GAME CREATED BY MONTANA BARKER";
gameOver = true;
winGame=true;
restart = true;
    }
}


public void GameOver()
{   
    if (winGame =! false){
    GameOverText.text = "Game Over!";
    gameOver = true;}
}

}

