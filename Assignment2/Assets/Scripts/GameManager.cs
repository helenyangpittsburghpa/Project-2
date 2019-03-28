using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private Pooler bludgerPooler;

    private int health;
    bool keepLife = false;

    float timeStart = 0f;
    float timer = 0f;
    public Text timeCounter;
    bool keepTime = false;

    public Player player;
    public GameObject gameWin;
    public GameObject gameOver;
    public GameObject particle;

    //timer: https://www.youtube.com/watch?v=x-C95TuQtf0
    // Start is called before the first frame update


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        health = 1;
        timer = timeStart;
        GetReferences();
    }

    void Update()
    {
        if(!keepTime)
        {
            timer += Time.deltaTime;
            timeCounter.text = timer.ToString("0")+ " sec";
        }
    }
    public float getTimer()
    {
        return timer;
    }
    void GetReferences()
    {
        bludgerPooler = GameObject.Find("BludgerPool").GetComponent<Pooler>();
    }
    public Pooler getBludgerPool()
    {
        return bludgerPooler;
    }

    public void minusHealth()
    {
        if (!keepLife)
        {
            health = health - 1;
        }
       
        if (health <= 0)
        {
            particle.SetActive(true);
            EndGame();
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }//https://answers.unity.com/questions/1261937/creating-a-restart-button.html

    public void winGame()
    {//UI for You win would showed up
        gameWin.SetActive(true);
        keepLife = true;
        keepTime = true;
    }//life and time would stay the same
    
    private void EndGame()
    {
        //gameOverUI();
        gameOver.SetActive(true);
        keepTime = true;
        gameObject.GetComponent<AudioSource>().Play();
    }

}