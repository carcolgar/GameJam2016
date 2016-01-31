using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGameplayController : MonoBehaviour {
    public Text time;

    public void RestartGame() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu() {
        Application.LoadLevel(0);
    }
}
