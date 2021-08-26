using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMvt : MonoBehaviour
{
    public GameManager gameManager;
    private bool isTranslating=false;
    private float nextPos=2.56f;
    [SerializeField] float moveYSpeed;
    private void OnEnable()
    {
        gameManager.changeObstaclesSpeed += setSpeed;
    }
    private void OnDisable()
    {
        gameManager.changeObstaclesSpeed -= setSpeed;
    }
    [SerializeField] float MoveSpeed = 0.05f;
    // Start is called before the first frame update
    public void setSpeed(float s)
    {
        MoveSpeed += s;
    }
    public float getSpeed()
    {
        return MoveSpeed;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.GameStarted)
        {
            transform.Translate(-MoveSpeed, 0, 0);
            if (transform.position.x <= -9.65f)
            {
                transform.position = new Vector2(9.65f, Random.Range(-2.5f, 2.5f));
                transform.localScale = new Vector2(Random.Range(1, 2), 1);
            }
            if ((gameManager.magic3))
            {
                transform.Translate(new Vector2(0, moveYSpeed));
                if (Mathf.Abs(transform.position.y) >= 2.56f)
                {
                    moveYSpeed *= -1;
                }
            }
        }

    }
}
