using UnityEngine;

public class WhiteLight : MonoBehaviour
{
    public Light light;

    void Start()
    {
        light = GetComponent<Light>();
        Invoke("LightUp", 39f);
    }

    void LightUp()
    {
        light.enabled = true;
    }
}
