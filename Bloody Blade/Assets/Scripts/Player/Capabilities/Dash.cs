using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private inputController input = null;
    [SerializeField, Range(0f, 100f)] private float dashSpeed;
    private bool isDashing = false;
    public float dashLength = .2f, dashCooldown = .2f;
    public float activeMoveSpeed;
    private float dashCounter;
    private float coolDashCounter;
    private float maxSpeed;

    Move move;

    void Awake(){
        move = GetComponent<Move>();
    }
    void Start(){
        activeMoveSpeed = move.maxSpeed;
    }
    void Update(){
        isDashing = input.retrieveDashInput();

        if(isDashing){
            if(coolDashCounter <= 0 && dashCounter <= 0){
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if(dashCounter > 0){
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0){
                activeMoveSpeed = move.maxSpeed;
                coolDashCounter = dashCooldown;
            }
        }

        if(coolDashCounter > 0){
            coolDashCounter -= Time.deltaTime;
        }
    }
}
