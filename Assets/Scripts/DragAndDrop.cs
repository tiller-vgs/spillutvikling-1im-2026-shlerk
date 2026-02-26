using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LayerMask LayerMask;
    public float Damping = 1;
    public float Frequency = 5;
    private TargetJoint2D TargetJoint;
    public Camera cam;
    public float PhysZ;
    
    private bool isDragging = false;

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        isDragging = true;
    }

   /*
    private void OnMouseUp()
    {
        isDragging = false;
        Debug.Log("OnMouseUp");
    }

    void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
    }
    */
    
   
    void Update()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        Vector2 MouseWPO = cam.ScreenToWorldPoint(MousePos);

        RaycastHit2D hit = Physics2D.Raycast(MouseWPO, Vector2.zero);


        if (hit.collider)
        {
            Debug.Log("Collided");
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                isDragging = true;
                Debug.Log("OnMouseDown");
            }
            
            if (!Mouse.current.leftButton.IsPressed())
            {
                isDragging = false;
                Debug.Log("OnMouseUp");
            }
        }
        else
        {
            Debug.Log("Not dragging");
            isDragging = false;
        }

        

        if (isDragging)
        {
            transform.position = (new Vector3(MouseWPO.x,MouseWPO.y,0));
        }
        
        
        
        
        
        
        /*
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        var WorldPos = cam.ScreenToWorldPoint(MousePos);
        //Debug.Log(WorldPos);
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log(MousePos);
            var collider = Physics2D.OverlapPoint(WorldPos, LayerMask);
            if (!collider)
                return;
            
            Rigidbody2D body = collider.attachedRigidbody;
            if (!body)
                return;

            TargetJoint = body.gameObject.AddComponent<TargetJoint2D>();
            TargetJoint.dampingRatio = Damping;
            TargetJoint.frequency = Frequency;
            TargetJoint.anchor = body.transform.InverseTransformPoint (WorldPos);
        }
        else if (!Mouse.current.leftButton.isPressed)
        {
            if (TargetJoint != null)
            {
                Destroy(TargetJoint);
                TargetJoint = null;
            }
        }
        
        
        if (TargetJoint)
        {
            TargetJoint.target = WorldPos;
        }
        */
        
    }
}
