using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public Transform PlayerTransform;
    Vector3 CorrectionVector = new Vector3(0, 0, 10);

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerTransform.position - CorrectionVector;
    }
}
