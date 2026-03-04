using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class InteractButtonNumber : MonoBehaviour
{
    public int nr;

    public Sprite off;
    public Sprite on;
    public SpriteRenderer mainSprite;
    public TextMesh mainText;
    public GameObject obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool isPressed;
    void Start()
    {
        if (nr >= 10)
        {
            if (nr == 10)
            {
                mainText.text = "*";
            }
            else
            {
                mainText.text = "#";
            }
        }
        else
        {
            mainText.text = nr.ToString();
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
        mainSprite.sprite = on;
        isPressed = false;
    }
    
    public void InteractNumPad()
    {
        if (!isPressed)
        {
            Debug.Log("TestFunc");
            mainSprite.sprite = off;
            isPressed = true;
            
            if (nr >= 10)
            {
                if (nr == 10)
                {
                    if (!obj.GetComponent<Payment>().bSwipedCard)
                    {
                        obj.GetComponent<Payment>().NoCard();
                    }
                    
                    
                    // put ka som skjer når man skriv man trykke betal her!!!!
                }
                else
                {
                    obj.GetComponent<Payment>().Amount = 0;
                }
            }
            else
            {
                if (!(obj.GetComponent<Payment>().Amount >= 1000))
                {
                    // legg te et nytt tall bak det gamle
                    obj.GetComponent<Payment>().Amount = obj.GetComponent<Payment>().Amount*10+nr;
                }
            }
            StartCoroutine(Delay());
        }
    }
}
