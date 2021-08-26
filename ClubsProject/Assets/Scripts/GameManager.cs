using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int Lives;
    public GameObject tapToPlay;
    public GameObject Player;
    public bool GameStarted;
    public GameObject ScoreInPanel;
    public GameObject LosePanel;
    public GameObject[] ObstacleList;
    public bool hideObstacles=false;
    public Sprite[] ScoreSprites;

    public delegate void ChangeBackGroundMvtSpeed(float f);
    public ChangeBackGroundMvtSpeed changebackSpeed;
    
    public delegate void ChangeObstaclesSpeed(float f);
    public ChangeObstaclesSpeed changeObstaclesSpeed;
    
    public delegate int GetScore();
    public GetScore getScore;
    
    public delegate void SetJumpSpeed(float f);
    public SetJumpSpeed setJumpSpeed;

    public bool magic3=false;
    public GameObject LifeImage;
    public GameObject LivesPanel;
    // Start is called before the first frame update
    void Start()
    {
        Lives = 0;
        ObstacleList = GameObject.FindGameObjectsWithTag("Obstacle");
        GameStarted = false;
        tapToPlay.SetActive(true);
        Player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((!GameStarted)&&(Input.GetMouseButtonDown(0)))
        {
            GameStarted = true;
            Player.SetActive(true);
            tapToPlay.SetActive(false);
        }
    }
    public void addLife()
    {
        Lives++;
        Instantiate(LifeImage, LivesPanel.transform);

    }
    public void LoseLife()
    {
        Lives--;
        Destroy(LivesPanel.transform.GetChild(0).gameObject);
    }
    public void disableObstacles()
    {
        foreach(GameObject go in ObstacleList)
        {
            go.SetActive(false);
        }
    }
    public void enableObstacles()
    {
        foreach(GameObject go in ObstacleList)
        {
            if (go.transform.parent.position.x > 9.65f)
            {
                
                go.SetActive(true);
            }
            else
            {
                StartCoroutine(waitToActivate(go));
            }
                
        }
    }
    public void StopCoroutines()
    {
        StopAllCoroutines();
    }
    IEnumerator waitToActivate(GameObject go)
    {
        yield return new WaitForSeconds(0.01f);
        if (go.transform.parent.position.x >= 9.6f)
        {

            go.SetActive(true);
        }
        else
        {
            StartCoroutine(waitToActivate(go));
        }
    }
    public void OnLose()
    {
        LosePanel.SetActive(true);
        ScoreInPanel.GetComponent<TextMeshProUGUI>().text = getScore().ToString();
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(0);
    }
}
