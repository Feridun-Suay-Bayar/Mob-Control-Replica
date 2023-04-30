using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }
    private void OnEnable()
    {
        instance = this;
    }
    [SerializeField] GameObject PlayPanel;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject WinPanel;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0;
        PlayPanel.SetActive(true);
        WinPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void Play()
    {
        PlayPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Reset()
    {
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameWinning()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
    }

}
