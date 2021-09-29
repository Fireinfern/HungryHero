using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    void Awake() {
        instance = this;
    }

    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void GoAbout() {
        SceneManager.LoadScene("AboutScene");
    }

    public void GoLose() {
        SceneManager.LoadScene("LostScene");
    }
}
