using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text cavalryText;
    [SerializeField] private GameObject GameOverScreen;

    public bool diceBonus;
    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
        diceBonus = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCalvaryText(float no)
    {
        cavalryText.text = no.ToString();

    }

    public void RestartGame()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void EndGame()
    {
        Debug.Log("END GAME");
        GameOverScreen.SetActive(true);
    }

}
