using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BoatRandomMovement : MonoBehaviour
{
    public float moveSpeed = 2f;           // speed of the boat
    public float changeTargetTime = 3f;    // time before picking a new random target
    public float moveRange = 10f;          // area in which the boat moves

    private Vector3 targetPosition;
    private float timer = 0f;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // If we reach close to the target or time is up, pick a new target
        timer += Time.deltaTime;
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f || timer >= changeTargetTime)
        {
            PickNewTarget();
            timer = 0f;
        }

        // Optional: make the boat face the direction it's moving
        Vector3 direction = targetPosition - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2f);
        }
    }

    void PickNewTarget()
    {
        // Random point within the moveRange around the boat's starting point
        Vector3 randomOffset = new Vector3(
            Random.Range(-moveRange, moveRange),
            0f, // keep it flat on water surface
            Random.Range(-moveRange, moveRange)
        );
        targetPosition = transform.position + randomOffset;
    }
}
