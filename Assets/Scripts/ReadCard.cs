using UnityEngine;
using System.Collections;
public class ReadCard : MonoBehaviour
{

    private Collider2D card;
    private float currentTime = 0f;
    public GameObject obj;
    
    public SpriteRenderer spriteRenderer;
    public Sprite neutral;
    public Sprite did; 
    public Sprite didnot; 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Card")
        {
            card = collision;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.6f);
        spriteRenderer.sprite = neutral;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        card = null;
    }

    void Update()
    {
        if (!obj.GetComponent<Payment>().bSwipedCard && card != null)
        {
            Debug.Log(Mathf.Abs(card.GetComponent<Rigidbody2D>().linearVelocity.y));
            Debug.Log(currentTime);
                if (Mathf.Abs(card.GetComponent<Rigidbody2D>().linearVelocity.y) >= 1.5 &&
                    Mathf.Abs(card.GetComponent<Rigidbody2D>().linearVelocity.y) <= 2)
                {
                    
                    currentTime += Time.deltaTime;
                    Debug.Log(currentTime);
                }
                else
                {
                    if (currentTime >= 0.01f)
                    {
                        spriteRenderer.sprite = didnot;
                        StartCoroutine(Delay());
                    }
                    currentTime = 0;
                }

                if (currentTime >= 0.12f)
                {
                    obj.GetComponent<Payment>().bSwipedCard = true;
                    Debug.Log("Swiped Card");
                    spriteRenderer.sprite = did;
                    StartCoroutine(Delay());
                }
        }
    }
}
