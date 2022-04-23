using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private inputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 15f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 100f;
    [SerializeField, Range(0f, 100f)] private float dashSpeed;
    
    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D body;
    private Wall wall;
    
    private float activeMoveSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    private float dashCounter;
    private float coolDashCounter;

    private float maxSpeedChange;
    private float acceleration;
    private bool isColliding;
    private bool isDashing = false;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        wall = GetComponent<Wall>();
    }

    void Start(){
        activeMoveSpeed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = input.retrieveHorizontalMoveInput();
        direction.y = input.retrieveVerticalMoveInput();
        isDashing = input.retrieveDashInput();
        desiredVelocity = new Vector2(direction.x, direction.y) * Mathf.Max(activeMoveSpeed - wall.GetFriction(), 0f);
        
        if(isDashing){
            if(coolDashCounter <= 0 && dashCounter <= 0){
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if(dashCounter > 0){
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0){
                activeMoveSpeed = maxSpeed;
                coolDashCounter = dashCooldown;
            }
        }

        if(coolDashCounter > 0){
            coolDashCounter -= Time.deltaTime;
        }
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
