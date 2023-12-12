using Unity.VisualScripting;
using UnityEngine;

public class MoveComet : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position + new Vector3(0f, -500f, 0f);
        Invoke("StartMoving", 30f);
    }

    void FixedUpdate()
    {
        // FixedUpdate can remain empty or be used for physics-related updates
    }

    void StartMoving()
    {
        InvokeRepeating("MoveTowardsTarget", 0f, 0.1f); // Invokes MoveTowardsTarget every 0.1 seconds
    }

    void MoveTowardsTarget()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.position = newPosition;

        // Optionally, you can stop invoking after reaching the target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            CancelInvoke("MoveTowardsTarget");
        }
    }
}
