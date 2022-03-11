using UnityEngine;

public class Ghost : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
