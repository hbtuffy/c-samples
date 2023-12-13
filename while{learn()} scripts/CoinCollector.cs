using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private AudioSource collectorSound;
    private int coinCount = 0;
    private string levelName;
    private string collectableName;
    private string totalCollectable;

    //get the scene name on awake
    private void Awake()
    {
        levelName = SceneManager.GetActiveScene().name;
    }

    //constract the coin counter on trigger for displaying
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            if (levelName == "mars")
            {
                collectableName = "Gems";
                totalCollectable = "41";
            }
            if (levelName == "lab")
            {
                collectableName = "Coins";
                totalCollectable = "35";
            }
            if (levelName == "intro")
            {
                collectableName = "Coins";
                totalCollectable = "12";
            }

            coinCount++;
            Destroy(collision.gameObject);

            collectorSound.Play();
            coinText.text = $"{collectableName}: {coinCount.ToString()}/{totalCollectable}";
        }
    }
}
