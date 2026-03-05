using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public GameObject spritePrefab;

    public int antallKunda;
    public Vector2 offset;
    
    private Vector3 SpawnPoint;
    
    
    private int i = 0;
    
    void Start()
    {
        SpawnPoint = transform.position;
        //lage like mange kunder som antall kunder si
        for (i=0;i <= antallKunda; i++)
        {
            Debug.Log(SpawnPoint);
            Instantiate(spritePrefab, SpawnPoint, transform.rotation);
            SpawnPoint = new (SpawnPoint.x+offset.x, SpawnPoint.y, SpawnPoint.z+offset.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
