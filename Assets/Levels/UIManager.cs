using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.GetUIManager += GetUIManager;
    }
    private void OnDisable()
    {
        EventManager.GetUIManager -= GetUIManager;

    }
    UIManager GetUIManager()
    {
        return GetComponent<UIManager>();
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void restLevel()
    {
        SceneManager.LoadScene(0);
    }
}
