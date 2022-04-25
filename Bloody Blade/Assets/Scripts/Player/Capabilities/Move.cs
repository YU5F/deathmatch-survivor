using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private inputController input = null;
    [SerializeField, Range(0f, 100f)] public float maxSpeed = 15f;
    [SerializeField, Range(0f, 150f)] private float maxAcceleration = 100f;
    
    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D body;
    private Wall wall;

    private float maxSpeedChange;
    private float acceleration;
    private bool isColliding;

    Dash dash;
    // Start is called before the first frame update
    void Awake()
    {
        dash = GetComponent<Dash>();
        body = GetComponent<Rigidbody2D>();
        wall = GetComponent<Wall>();
    }

    void Start(){
        dash.activeMoveSpeed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = input.retrieveHorizontalMoveInput();
        direction.y = input.retrieveVerticalMoveInput();
        desiredVelocity = new Vector2(direction.x, direction.y) * Mathf.Max(dash.activeMoveSpeed - wall.GetFriction(), 0f);
    }

    private void FixedUpdate(){
        isColliding = wall.GetIsColliding();
        velocity = body.velocity;

        acceleration = maxAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.y = Mathf.MoveTowards(velocity.y, desiredVelocity.y, maxSpeedChange);

        body.velocity = velocity;
    }
}
