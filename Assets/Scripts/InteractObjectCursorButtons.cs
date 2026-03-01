using UnityEngine;
using UnityEngine.InputSystem;

public class InteractObjectCursorButtons : MonoBehaviour
{
    
    public LayerMask LayerMask;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        Vector2 MouseWPO = cam.ScreenToWorldPoint(MousePos);
        RaycastHit2D hit = Physics2D.Raycast(MouseWPO, Vector2.zero);
        Vector3 WorldPos = cam.ScreenToWorldPoint(MousePos);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Collider2D collider = Physics2D.OverlapPoint(WorldPos, LayerMask);
            if (collider)
            {
                //Debug.Log(collider.name);
                // sjekke om gameobejcten man interacte med har taggen numbers og vis det har kjøre InteractNumPad Funksjonen
                if (collider.gameObject.CompareTag("numbers"))
                {
                    //Debug.Log("DetSkaHaFunkaellerno");
                    collider.GetComponent<InteractButtonNumber>().InteractNumPad();
                }
            }
        }
    }
}
