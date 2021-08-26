using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMvt : MonoBehaviour
{
    public AudioSource ScoreSound;
    public Sprite isimsSprite;
    public Sprite EnetcomSprite;
    public PolygonCollider2D IsimsCollider;
    public PolygonCollider2D EnetcomCollider;
    public List<GameObject> scoreList;
    public GameObject ScoreImg;
    public Image ScorePanel;
    private int score;
    public GameManager gameManager;
    [SerializeField] float rotSpeed;
    [SerializeField] float jumpSpeed;
    private Rigidbody2D rb;
    public int getScore()
    {
        return score;
    }
    public void setJumpSpeed(float f)
    {
        jumpSpeed = f;
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        gameManager.setJumpSpeed += setJumpSpeed;
        gameManager.getScore += getScore;
    }
    private void OnDisable()
    {
        gameManager.setJumpSpeed -= setJumpSpeed;
        gameManager.getScore -= getScore;
    }

    void Start()
    {
        scoreList = new List<GameObject>();
        scoreList.Add(ScorePanel.transform.GetChild(0).gameObject);
        Time.timeScale = 1;
        score = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector2(0, jumpSpeed);
                rotSpeed *= -1;
            }
            if ((transform.position.y >= 5.34f) || (transform.position.y <= -5.43f))
            {
                Time.timeScale = 0;
                gameManager.OnLose();
            }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (gameManager.Lives == 0)
            {
                Time.timeScale = 0;
                gameManager.OnLose();
            }
            else
            {
                gameManager.LoseLife();
            }
        }
        else if(collision.gameObject.tag=="ScoreCollider")
        {
            ScoreSound.Play();
            score += 1;
            SetScore(score);
            if (score % 10 == 0)
            {
                gameManager.changeObstaclesSpeed(0.02f);
                gameManager.changebackSpeed(0.001f);
            }
        }
    }
    private void SetScore(float s)
    {
        int scoretest = score;


        foreach(GameObject obj in scoreList)
        {
            Destroy(obj);
        }
        scoreList.Clear();
        while(scoretest.ToString().Length >= 1)
        {
            GameObject go = Instantiate(ScoreImg, ScorePanel.transform);
            scoreList.Add(go);
            go.GetComponent<Image>().sprite = gameManager.ScoreSprites[scoretest % 10];
            go.transform.SetAsFirstSibling();
            if(scoretest.ToString().Length == 1)
            {
                break;
            }
            scoretest = scoretest / 10;
        }
    }
}
