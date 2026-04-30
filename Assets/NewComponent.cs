
using UnityEngine;
using UnityEngine.UIElements;

public class NewComponent : MonoBehaviour
{

    Vector3 newPosition = new Vector3(0.05f, 0f, 0f);
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print(transform.position.x);
        print(transform.position.y);
        print(transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += newPosition;
        transform.Rotate (10,0,5);
        if (transform.position.x > 5f || transform.position.x < -5f)
        {
            newPosition = -newPosition;
        }
    }
}
