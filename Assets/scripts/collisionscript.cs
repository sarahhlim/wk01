using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    GameObject currentCollectible;
    int collCount = 0;
    int totalScore = 0; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectibles")
        {
            currentCollectible = collision.gameObject;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == currentCollectible)
        {
            currentCollectible = null;
        }
    }

    void OnInteract()
    {
        if (currentCollectible != null)
        {
            scoreboard scoreComp = currentCollectible.GetComponent<scoreboard>();

            if (scoreComp != null)
            {
                totalScore += scoreComp.score; 
            }

            collCount++;
            print("Player has collected " + collCount + " collectibles | Total Score: " + totalScore);
            Destroy(currentCollectible);
            currentCollectible = null; 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "goalarea" && collCount >= 7)
        {
            print("Player entered trigger zone with " + collCount + " collectibles | Final Score: " + totalScore);
        }
    }
}

