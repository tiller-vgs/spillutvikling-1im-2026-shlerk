using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class WashingMachineScript : MonoBehaviour
{
    
    public LayerMask LayerMask;
    private bool bisOverlapping;
    private int count;
    public Camera cam;
    public TextMesh text;
    public SpriteRenderer sprite;
    public Sprite Closed;
    public Sprite OpenOff;
    public Sprite OpenOn;

    private bool bDone = false;


    IEnumerator WahingMachineCycle()
    {
        yield return new WaitForSeconds(5f);
        sprite.sprite = OpenOff;
        bDone = true;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite.sprite = Closed;
    }

    void Update()
    {
        text.text = count.ToString();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Phys") && count == 0)
        {
            bisOverlapping = true;
            count = 1;
            sprite.sprite = OpenOn;
            Destroy(collision.gameObject);
            StartCoroutine(WahingMachineCycle());
        }
        else
        {
            bisOverlapping = false;
        }
        
        /*
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        Vector2 MouseWPO = cam.ScreenToWorldPoint(MousePos);
        RaycastHit2D hit = Physics2D.Raycast(MouseWPO, Vector2.zero);
        
        Vector3 WorldPos = cam.ScreenToWorldPoint(MousePos);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("SIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMA");
        }
        if (bDone && Mouse.current.leftButton.wasPressedThisFrame)
        {
            sprite.sprite = Closed;
            bDone = false;
            count = 0;
        }
        */
    }
}
