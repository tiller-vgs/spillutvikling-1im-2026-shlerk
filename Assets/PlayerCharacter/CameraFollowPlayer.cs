using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public float smoothness = 0.3f;
    public Vector3 camoffset;
    // Update is called once per frame
    
    private Vector3 velocity = Vector3.zero;
    void FixedUpdate()
    {
        Vector3 targetpos = player.transform.position + camoffset;
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        transform.position = Vector3.SmoothDamp(transform.position,targetpos, ref velocity, smoothness);
    }
}
