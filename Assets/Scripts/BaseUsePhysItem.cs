using Unity.VisualScripting;
using UnityEngine;

public class BaseUsePhysItem : MonoBehaviour
{
    private bool bisOverlapping;
    private int count;
    public Camera cam;
    public TextMesh text;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        text.text = count.ToString();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Phys"))
        {
            bisOverlapping = true;
            count++;
            Destroy(collision.gameObject);
        }
        else
        {
            bisOverlapping = false;
        }
    }
}
