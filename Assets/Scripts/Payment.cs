using UnityEngine;
using System.Collections;

public class Payment : MonoBehaviour
{

    public int Amount = 0;
    public TextMesh text;
    public bool bSwipedCard;

    private bool bIsText;
    
    void Update()
    {
        if (!bIsText)
        {
            text.text = Amount.ToString();
        }
        
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        bIsText = false;
    }

    public void NoCard()
    {
        bIsText = true;
        text.text = "Error!";
        StartCoroutine(Delay());
        
    }
}
