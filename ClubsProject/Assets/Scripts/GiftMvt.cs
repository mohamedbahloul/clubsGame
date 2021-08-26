using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMvt : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 0.05f;
    public GameManager gameManager;
    SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider2D;
    private void OnEnable()
    {
        gameManager.changeObstaclesSpeed += setSpeed;
    }
    private void OnDisable()
    {
        gameManager.changeObstaclesSpeed -= setSpeed;
    }
    public void setSpeed(float s)
    {
        MoveSpeed += s;
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.GameStarted)
        {
            if (spriteRenderer.enabled == false)
            {
                return;
            }
            transform.Translate(-MoveSpeed, 0, 0);
            if (transform.position.x <= -8.9f)
            {
                spriteRenderer.enabled = false;
                polygonCollider2D.enabled = false;
            }
        }
        
    }
}
