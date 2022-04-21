using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private inputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    
    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D body;
    private Wall wall;

    private float maxSpeedChange;
    private float acceleration;
    private bool isColliding;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        wall = GetComponent<Wall>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = input.retrieveHorizontalMoveInput();
        direction.y = input.retrieveVerticalMoveInput();    
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - wall.GetFriction(), 0f);
        desiredVelocity = new Vector2(0F, direction.y) * Mathf.Max(maxSpeed - wall.GetFriction(), 0f);
    }
}
