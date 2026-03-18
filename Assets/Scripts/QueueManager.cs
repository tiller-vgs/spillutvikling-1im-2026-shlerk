using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public GameObject customerPrefab;

    public int antallKunda;
    public Vector2 offset;
    public Camera Cam;

    public Queue<GameObject> customers;
    
    private Vector3 SpawnPoint;

    private float timer = 0;
    private float timeUntilVoiceActivation = 0;
    
    // Hvem gjorde dette her 😭
    private int i = 0;

    void Awake()
    {
        customers = new Queue<GameObject>();
    }

    void Start()
    {
        SpawnPoint = transform.position;
        //lage like mange kunder som antall kunder si
        for (i=0; i < antallKunda; i++)
        {
            Debug.Log(SpawnPoint);
            
            customers.Enqueue(Instantiate(customerPrefab, SpawnPoint, transform.rotation));
            SpawnPoint = new (SpawnPoint.x+offset.x, SpawnPoint.y, SpawnPoint.z+offset.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Cam.targetDisplay == 0)
        {
            timer += Time.deltaTime;
            if (timer >= timeUntilVoiceActivation)
            {
                timeUntilVoiceActivation = Random.Range(3f, 10f);
                if (customers.Count > 0){
                    customers.Peek().GetComponent<CustomerScript>().playRandomVoiceLine();
                }
                timer = 0;
            }
        }
    }

    private IEnumerator Voicelines()
    {
        yield return new WaitForSeconds(2);
    }

    void UpdateQueuePos()
    {
        
    }
}
