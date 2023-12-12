using UnityEngine;
using UnityEngine.Profiling;

public class DisplayStats : MonoBehaviour
{
    GUIStyle style = new GUIStyle();
    float deltaTime = 0.0f;

    void Start()
    {
        // Set up GUIStyle for text display
        style.fontSize = 20;
        style.normal.textColor = Color.white;
    }

    void Update()
    {
        // Calculate frame rate
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        // Display frame rate and memory usage
        int fps = Mathf.RoundToInt(1.0f / deltaTime);
        float memoryUsage = Profiler.GetTotalAllocatedMemoryLong() / (1024f * 1024f); // in megabytes

        string text = $"FPS: {fps}\nMemory: {memoryUsage:F2} MB";
        GUI.Label(new Rect(10, 10, 200, 50), text, style);
    }
}