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
    
    public float removeclothtime = 20f;
    public float washtime = 15f;

    public int CleanClothing = 3;
    private bool bDone;

    private bool iswaitingremove;
    
    public InteractWashingMachine InwashingMachine;


    IEnumerator WahingMachineCycle()
    {
        yield return new WaitForSeconds(washtime);
        sprite.sprite = OpenOff;
        bDone = true;
        text.text = CleanClothing.ToString();
    }
    IEnumerator RemoveCleanClothing()
    {
        yield return new WaitForSeconds(removeclothtime);
        iswaitingremove = false;
        Mathf.Clamp(CleanClothing -= 1, 0,5);
        text.text = CleanClothing.ToString();
    }
    
    void Start()
    {
        text.text = CleanClothing.ToString();
        sprite.sprite = Closed;
    }

    void Update()
    {
        //text.text = count.ToString();
    }

    public void OpenWashingMachine()
    {
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
            InwashingMachine.GetComponent<InteractWashingMachine>().startwash = true;
            sprite.sprite = Closed;
            bDone = false;
            count = 0;
        }

        if (!iswaitingremove)
        {
            iswaitingremove = true;
            StartCoroutine(RemoveCleanClothing());
        }
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Physics");
        
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
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
        
    }
}
