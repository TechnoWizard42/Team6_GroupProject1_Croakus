using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public List<Transform> points;
    public Transform enemy;
    int goalPoint = 0;
    public float moveSpeed = 3;

    public Animator animator;

    Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveToNextPoint();

        Vector2 position = rigidbody2D.position;

        rigidbody2D.MovePosition(position);
    }

    void MoveToNextPoint()
    {
        //change the position of the platform (move towards the goal point)

        enemy.position = Vector2.MoveTowards(enemy.position, points[goalPoint].position, Time.deltaTime * moveSpeed);

        //check if we are in very close proximity to the next point
        if (Vector2.Distance(enemy.position, points[goalPoint].position) < 0.1f)
        {

            //if so change goal point to the next one
            if (goalPoint == points.Count - 1)

                goalPoint = 0;
            else
                goalPoint++;
        }
    }
}
