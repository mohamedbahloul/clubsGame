using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMvt : MonoBehaviour
{
    public GameManager gameManager;
    private void OnEnable()
    {
        gameManager.changebackSpeed += setSpeed;
    }
    private void OnDisable()
    {
        gameManager.changebackSpeed -= setSpeed;
    }
    [SerializeField] float MoveSpeed=0.05f;
    // Start is called before the first frame update
    public void setSpeed(float s)
    {
        MoveSpeed += s;
        print(MoveSpeed);
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
            if (transform.position.x <= -17.85f)
            {
                transform.position = new Vector2(17.85f, 0);
            }
        }
        
    }
}
