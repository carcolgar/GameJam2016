using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameplayController : MonoBehaviour {
    public GameObject[] activeEndings;

    GameObject gameOverPanel;
    Text time;

    void Start()
    {
        time = transform.FindChild("Time").GetComponent<Text>();
        gameOverPanel = transform.FindChild("GameOverPanel").gameObject;
    }

    public void ActivePanel(string time) {
        gameOverPanel.SetActive(true);
        this.time.text = time;
        ActiveUnlockedEndings();
    }

    public void ActiveUnlockedEndings() {
        for (int i = 0; i < activeEndings.Length; i++)
        {
            activeEndings[i].SetActive(PlayerPrefs.GetInt("Ending" + i) == 1 ? true : false);
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
}
