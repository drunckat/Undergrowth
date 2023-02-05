using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource gameOverMusic;
    public Text text;
    public void GameOver()
    {
        backgroundMusic.Stop();
        gameOverMusic.PlayOneShot(gameOverMusic.clip);
        //text.fontSize = 50;
        text.text = "You rotted! \nYour score: " + (int)Capsule.score;
        
        Invoke("GoToMenu", 3.0f);
                //GameManager.Restart();
    }

    private void GoToMenu() {
                SceneManager.LoadScene("Menu");
    }
    
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
