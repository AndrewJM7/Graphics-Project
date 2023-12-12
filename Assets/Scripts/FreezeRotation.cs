using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    void Update()
    {
        // Freeze rotation for the parent object
        transform.rotation = Quaternion.identity;

        // Iterate through child objects and freeze their rotations
        foreach (Transform child in transform)
        {
            child.rotation = Quaternion.identity;
        }
    }
}

