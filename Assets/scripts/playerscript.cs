using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    CollectibleScript currentCollectible;

    int playerScore = 0;

    [SerializeField]
    int targetScore = 0;

    [SerializeField]
    TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Score: " + playerScore;
    }

    void OnInteract()
    {
        if (currentCollectible != null)
        {
            playerScore += currentCollectible.collectibleScore;
            scoreText.text = "Score: " + playerScore;
            currentCollectible.collect();
            currentCollectible = null;
        }
        else
        {
            print("Error: No CollectibleScript found");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            currentCollectible = other.GetComponentInParent<CollectibleScript>();
        }

        if (other.gameObject.tag == "GoalArea" && playerScore >= targetScore)
        {
            print("Player entered trigger zone with " + playerScore + " points");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (currentCollectible != null && other.gameObject == currentCollectible.gameObject)
        {
            currentCollectible = null;
        }
    }
}