using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public SpriteRenderer spritePrefab;
    public Vector3 SpawnPoint;
    public int antallKunda;
    public Vector2 offset;
    
    private int i = 0;
    
    void Start()
    {
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
