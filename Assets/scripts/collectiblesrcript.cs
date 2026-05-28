using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public int collectibleScore = 0;
    AudioSource collectibleAudio;

    void Start()
    {
        collectibleAudio = GetComponent<AudioSource>();
    }

    public void collect()
    {
        if (collectibleAudio != null)
        {
            collectibleAudio.Play();
            Destroy(gameObject, collectibleAudio.clip.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}