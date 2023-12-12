using UnityEngine;

public class WaterFloat : MonoBehaviour
{
    public Vector3 MovingDistances = new Vector3(0.002f, 0.001f, 0f);
    public float speed = 1f;

    public Vector3 WaveRotations;
    public float WaveRotationsSpeed = 0.3f;

    public Vector3 AxisOffsetSpeed;

    private Transform initialTransform;

    void Start()
    {
        initialTransform = transform;
    }

    void Update()
    {
        // Change axis
        Vector3 mov = new Vector3(
            initialTransform.position.x + Mathf.Sin(speed * Time.time) * MovingDistances.x,
            initialTransform.position.y + Mathf.Sin(speed * Time.time) * MovingDistances.y,
            initialTransform.position.z + Mathf.Sin(speed * Time.time) * MovingDistances.z
        );

        // Change rotations
        transform.rotation = Quaternion.Euler(
            initialTransform.rotation.eulerAngles.x + WaveRotations.x * Mathf.Sin(Time.time * WaveRotationsSpeed),
            initialTransform.rotation.eulerAngles.y + WaveRotations.y * Mathf.Sin(Time.time * WaveRotationsSpeed),
            initialTransform.rotation.eulerAngles.z + WaveRotations.z * Mathf.Sin(Time.time * WaveRotationsSpeed)
        );

        // Inject the changes
        transform.position = mov;

        // Offset
        var tran = transform.position;

        tran.x += AxisOffsetSpeed.x * Time.deltaTime;
        tran.y += AxisOffsetSpeed.y * Time.deltaTime;
        tran.z += AxisOffsetSpeed.z * Time.deltaTime;

        transform.position = tran;
    }
}
