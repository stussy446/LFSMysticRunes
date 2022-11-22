using UnityEngine;

public class TestBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Vector3 startingPos;
    [SerializeField] private Vector3 endingPos;
    
    float positionPercent;
    private float direction = 1;

    void Start()
    {
        transform.position = startingPos;
    }

    void Update()
    {
        Move();
    }

    /// <summary>
    /// Uses lerp functionality to bounce cube back and forth between
    /// startingPos and endingPos
    /// </summary>
    void Move()
    {
        float distance = Vector3.Distance(startingPos, endingPos);
        float speedForDistance = moveSpeed / distance;

        positionPercent += Time.deltaTime * direction * moveSpeed;
        SwitchDirectionsIfNeeded();

        transform.position = Vector3.Lerp(startingPos, endingPos, positionPercent);
    }

    /// <summary>
    /// If the object reaches the position it is moving towards, switch the
    /// cubes direction and head towards the other position
    /// </summary>
    private void SwitchDirectionsIfNeeded()
    {
        if (positionPercent >= 1 && direction == 1)
        {
            direction = -1;
        }
        else if (positionPercent <= 0 && direction == -1)
        {
            direction = 1;
        }
    }
}
