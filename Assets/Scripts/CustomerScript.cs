using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    public float moodMeter = 100;
    public enum Personalities
    {
        Chill, Normal, Angry, Karen
    }
    public enum ReceptionTasks
    {
        BookIn, BookOut, BuyRoom
    }

    public SpriteRenderer renderer;
    public Sprite[] CustomerSprites;

    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;

    private ReceptionTasks currentTask;
    private Personalities personality;

    void Awake()
    {
        renderer.sprite = CustomerSprites[Random.Range(0, CustomerSprites.Length)];
        audioSource = GetComponent<AudioSource>();
        moodMeter -= Random.Range(0.1f, 60f);
        int index = Random.Range(0, 3);

        // Setter hvilken ting du må gjøre for kunden
        switch (index)
        {
            case 0: currentTask = ReceptionTasks.BookIn; break;
            case 1: currentTask = ReceptionTasks.BookOut; break;
            case 2: currentTask = ReceptionTasks.BuyRoom; break;
        }

        //Bestemmer hvor fort moodMeter går ned
        index = Random.Range(0, 4);
        switch (index)
        {
            case 0: personality = Personalities.Chill; break;
            case 1: personality = Personalities.Normal; break;
            case 2: personality = Personalities.Angry; break;
            case 3: personality = Personalities.Karen; break;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Skal gjøre sånn at dette blir styrt av queueManager eller noe
        //playRandomVoiceLine();
    }

    // Update is called once per frame
    void Update()
    {
        switch (personality)
        {
            case Personalities.Chill: moodMeter -= 1 * Time.deltaTime; break;
            case Personalities.Normal: moodMeter -= 2 * Time.deltaTime; break;
            case Personalities.Angry: moodMeter -= 4 * Time.deltaTime; break;
            case Personalities.Karen: moodMeter -= 6 * Time.deltaTime; break;
        }
    }

    public void playRandomVoiceLine()
    {
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
    }
}
