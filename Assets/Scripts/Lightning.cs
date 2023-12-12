using Unity.VisualScripting;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    private LineRenderer lineRenderer;

    void Start()
    {
        foreach (Transform child in transform)
        {
            lineRenderer = child.GetComponent<LineRenderer>();
            lineRenderer.enabled = false;
        }

        // Invoke the ActivateChildren method after 10 seconds
        Invoke("ActivateChildren", 20f);
    }

    void ActivateChildren()
    {
        // Loop through all the children of the GameObject
        foreach (Transform child in transform)
        {
            lineRenderer = child.GetComponent<LineRenderer>();
            lineRenderer.enabled = true;   
        }

        Invoke("DeactivateChildren", 3f);
    }

    void DeactivateChildren()
    {
        // Loop through all the children of the GameObject
        foreach (Transform child in transform)
        {
            lineRenderer = child.GetComponent<LineRenderer>();
            lineRenderer.enabled= false;

            foreach (Transform grandchild in child)
            {
                if (grandchild.gameObject.name == "Fire")
                {
                    grandchild.gameObject.SetActive(true);
                }
            }
        }
    }
}
