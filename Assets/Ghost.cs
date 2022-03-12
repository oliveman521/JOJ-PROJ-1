using UnityEngine;

using Pathfinding;

public class Ghost : MonoBehaviour
{
    GameObject player;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
