using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCursor : MonoBehaviour
{

    public float followstrength = 1;
    public Camera cam;
    
    void Update()
    {
        // roterer kameraet til muse posisjonen in view
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        var ViewPos = cam.ScreenToWorldPoint(MousePos);
        transform.rotation = Quaternion.Euler((ViewPos.y*-1)*followstrength,((ViewPos.x-68)/2)*followstrength, 0);
        
        //Debug.Log(ViewPos);
    }
}
