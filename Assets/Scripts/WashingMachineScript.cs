using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

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

    public List<GameObject> clothing;
    
    public float removeclothtime = 5f;
    public float washtime = 3f;

    public int CleanClothing = 10;
    private bool bDone;

    private bool iswaitingremove;
    
    private int i = 0;
    
    public InteractWashingMachine InwashingMachine;
    public CreateGrabableItem CreateGrabItem;
    
    public SpriteRenderer spriteRenderer;
    public Vector3 cleanclothpos;
    public GameObject cleancloth;

    IEnumerator WahingMachineCycle()
    {
        yield return new WaitForSeconds(washtime);
        sprite.sprite = OpenOff;
        bDone = true;
        text.text = CleanClothing.ToString();
    }
    IEnumerator RemoveCleanClothing()
    {
        if (CleanClothing >= 1)
        {
            yield return new WaitForSeconds(removeclothtime);
            iswaitingremove = false;
            //Mathf.Clamp(CleanClothing -= 1, 0,5);
            CleanClothing -= 1;
            text.text = CleanClothing.ToString();
            //GameObject newsprite = ];
            Debug.Log(clothing.Count);
            Destroy(clothing[clothing.Count -1]);
            clothing.RemoveAt(clothing.Count -1 );
            cleanclothpos = new Vector3(cleanclothpos.x, cleanclothpos.y - (0.2f), cleanclothpos.z);
            Debug.Log(clothing);
        }
    }
    
    void Awake()
    {
        //clothing = new List<GameObject>();
        cleanclothpos = spriteRenderer.transform.position;
        text.text = CleanClothing.ToString();
        sprite.sprite = Closed;
        AddClothing(CleanClothing);
    }
    
    public void AddClothing(int amount)
    {
        //lage like mange kunder som antall kunder si
        for (i=0; i < amount; i++)
        {
            clothing.Add(Instantiate(cleancloth, cleanclothpos, transform.rotation));
            cleanclothpos = new Vector3(cleanclothpos.x, cleanclothpos.y + (0.2f), cleanclothpos.z);
        }
    }

    void Update()
    {
        //text.text = count.ToString();
        if (!iswaitingremove)
        {
            iswaitingremove = true;
            StartCoroutine(RemoveCleanClothing());
        }
    }

    public void OpenWashingMachine()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        Vector2 MouseWPO = cam.ScreenToWorldPoint(MousePos);
        RaycastHit2D hit = Physics2D.Raycast(MouseWPO, Vector2.zero);
        
        Vector3 WorldPos = cam.ScreenToWorldPoint(MousePos);
        
        if (bDone && Mouse.current.leftButton.wasPressedThisFrame)
        {
            InwashingMachine.GetComponent<InteractWashingMachine>().startwash = true;
            sprite.sprite = Closed;
            bDone = false;
            count = 0;
            Mathf.Clamp(CleanClothing++, 0,5);
            AddClothing(1);
            Instantiate(cleancloth, new Vector3(cleanclothpos.x, cleanclothpos.y + (CleanClothing*10), cleanclothpos.z), Quaternion.identity);
            text.text = CleanClothing.ToString();
            CreateGrabItem.GetComponent<CreateGrabableItem>().CanInteract = true;
        }
        
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Phys");
        
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
            InwashingMachine.GetComponent<InteractWashingMachine>().startwash = false;
            bisOverlapping = true;
            count = 1;
            sprite.sprite = OpenOn;
            Destroy(collision.gameObject);
            StartCoroutine(WahingMachineCycle());
            CreateGrabItem.GetComponent<CreateGrabableItem>().CanInteract = false;
        }
        else
        {
            bisOverlapping = false;
        }
    }
}
