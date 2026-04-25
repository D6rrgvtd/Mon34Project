using UnityEngine;

public class PlayerLaneMovement : MonoBehaviour
{
    public float laneDistance = 3.0f; 
    public float moveSpeed = 10f;

    private int currentLane = 0;
    public float forwardSpeed = 10f;
    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        // 入力（PCなら）
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > -1)
                currentLane--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < 1)
                currentLane++;
        }

        // 目標位置
        Vector3 targetPosition = new Vector3(currentLane * laneDistance, transform.position.y, transform.position.z);

        // スムーズ移動
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
