using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftManager : MonoBehaviour
{
    public List<Sprite> GiftSprites;
    public GameObject Gift;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;
    public GameManager gameManager; 
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer =Gift.GetComponent<SpriteRenderer>();
        circleCollider2D = Gift.GetComponent<CircleCollider2D>();
        StartCoroutine(waitToMakeGift());
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gift")
        {
            gameManager.StopAllCoroutines();
            spriteRenderer.enabled = false;
            circleCollider2D.enabled = false;
            print(i);
            switch (i)
            {
                case 0:
                    gameManager.setJumpSpeed(2);
                    StartCoroutine(stopMagic4());

                    break;
                case 1:
                    transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
                    StartCoroutine(stopMagicOne());
                    break;
                case 2:
                    //  gameManager.disableObstacles();
                    //  StartCoroutine(stopMagicTwo());
                    gameManager.addLife();
                    break;
                case 3:
                    gameManager.magic3 = true;
                    StartCoroutine(stopMagicTrois());
                    break;
             
            }
        }
    }
    IEnumerator stopMagicOne() {
        yield return new WaitForSeconds(5);
        transform.localScale = new Vector3(0.21f, 0.21f, 0.21f);
    } 
    IEnumerator stopMagic4() {
        yield return new WaitForSeconds(5);
        gameManager.setJumpSpeed(6);
    }
    IEnumerator stopMagicTrois() {
        yield return new WaitForSeconds(5);
        gameManager.magic3 = false;
    }
    IEnumerator waitToMakeGift()
    {
        yield return new WaitForSeconds(Random.Range(5,7));
        i = Random.Range(0, 4);
        spriteRenderer.sprite = GiftSprites[i];
        Gift.transform.position = new Vector2(14.5f, Random.Range(-2.30f, 2.30f));
        spriteRenderer.enabled = true;
        circleCollider2D.enabled = true;
        StartCoroutine(waitToMakeGift());
    }
}
