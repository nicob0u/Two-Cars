using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class MainMenuController : MonoBehaviour
{
    public void OnStartClick()
    {
        DOTween.Clear(true);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
    public void OnExitClick()
    {
#if UNITY_EDITOR
UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
