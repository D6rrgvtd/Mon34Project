using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLaneMovement : MonoBehaviour
{
    public float laneDistance = 3.0f;
    public float moveSpeed = 10f;
    public float forwardSpeed = 10f;

    private int currentLane = 0;

    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            currentLane--;
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            currentLane++;
        }

        currentLane = Mathf.Clamp(currentLane, -1, 1);

        float targetX = currentLane * laneDistance;
        float newX = Mathf.Lerp(transform.position.x, targetX, moveSpeed * Time.deltaTime);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}