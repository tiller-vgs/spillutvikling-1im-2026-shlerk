using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class QueueManager : MonoBehaviour
{
    public GameObject customerPrefab;

    public int antallKunda;
    public float moveSpeed = 2f;
    public Vector2 offset;
    public Camera Cam;

    public Queue<GameObject> customers;
    
    private Vector3 SpawnPoint;

    private float timer = 0;
    private float timeUntilVoiceActivation = 0;
    private Keyboard keyboard = Keyboard.current;
    
    // Hvem gjorde dette her 😭
    private int i = 0;

    void Awake()
    {
        customers = new Queue<GameObject>();
    }

    void Start()
    {
        AddCustomer(antallKunda);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateQueuePos();

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

        if (customers.Count > 0)
        {
            CustomerScript firstCustomer = customers.Peek().GetComponent<CustomerScript>();

            float moodDrain = 0;

            switch (firstCustomer.GetPersonality())
            {
                case CustomerScript.Personalities.Chill: moodDrain = 1; break;
                case CustomerScript.Personalities.Normal: moodDrain = 2; break;
                case CustomerScript.Personalities.Angry: moodDrain = 4; break;
                case CustomerScript.Personalities.Karen: moodDrain = 6; break;
            }

            firstCustomer.DecreaseMood(moodDrain);
        }

        if(customers.Peek().GetComponent<CustomerScript>().moodMeter <= 0)
        {
            RemoveCustomer();
        }

        if (keyboard.oKey.wasPressedThisFrame)
        {
            AddCustomer(1);
        }
        
        if (keyboard.pKey.wasPressedThisFrame)
        {
            RemoveCustomer();
        }
    }

    private IEnumerator Voicelines()
    {
        yield return new WaitForSeconds(2);
    }

    void UpdateQueuePos()
    {
        int index = 0;
        Vector3 pos = transform.position;

        foreach(GameObject customer in customers)
        {
            Vector3 targetpos = new Vector3(
                pos.x + offset.x * index,
                pos.y,
                pos.z + offset.y * index
            );

            customer.transform.position = Vector3.Lerp(
                customer.transform.position,
                targetpos,
                moveSpeed * Time.deltaTime
            );
            index++;
        }
    }

    public void RemoveCustomer()
    {
        if (customers.Count > 0)
        {
            GameObject removedCustomer = customers.Dequeue();
            StartCoroutine(SlideOffScreen(removedCustomer));
        }
    }

    public void AddCustomer(int amount)
    {
        SpawnPoint = new Vector3(transform.position.x - 20, transform.position.y, transform.position.z + 8);
        //lage like mange kunder som antall kunder si
        for (i=0; i < amount; i++)
        {
            Debug.Log(SpawnPoint);
            
            customers.Enqueue(Instantiate(customerPrefab, SpawnPoint, transform.rotation));
            SpawnPoint = new (SpawnPoint.x+offset.x, SpawnPoint.y, SpawnPoint.z+offset.y);
        }
    }

    private IEnumerator SlideOffScreen(GameObject customer)
    {
        Vector3 startPos = customer.transform.position;

        // Move off screen (adjust direction if needed)
        Vector3 endPos = startPos + new Vector3(15, 0, 0);

        float duration = 1.0f;
        float time = 0;

        while (time < duration)
        {
            customer.transform.position = Vector3.Lerp(
                startPos,
                endPos,
                time / duration
            );

            time += Time.deltaTime;
            yield return null;
        }

        // Ensure final position
        customer.transform.position = endPos;

        Destroy(customer);
    }
}
