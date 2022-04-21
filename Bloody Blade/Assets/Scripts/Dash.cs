
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("Dashing")]
    [SerializeField] private float dashingVelocity = 14f;
    [SerializeField] private float dashingTime = 0.5f;
    private Vector2 dashingDirection;
    private bool isDashing;
    Rigidbody2D rb;
    private bool canDash = true;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var dashInput = Input.GetButtonDown("Dash");
        if (dashInput && canDash)
        {
            isDashing = true;
            canDash = false;
            dashingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (dashingDirection == Vector2.zero)
            {
                dashingDirection = new Vector2(transform.localScale.x, y: 0);
            }
            StartCoroutine(StopDashing());

        }
        if (isDashing)
        {
            rb.velocity = dashingDirection.normalized * dashingVelocity;
            return;
        }
    }
    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
    }
}