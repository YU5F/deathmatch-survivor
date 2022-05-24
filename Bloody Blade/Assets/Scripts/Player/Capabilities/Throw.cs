using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] private inputController input = null;
    [SerializeField] private GameObject throwableObject;
    [SerializeField] private Transform firePoint;
    [SerializeField, Range(0f, 50f)] private float throwForce = 20.0f;
    private bool canThrow = false;
    private bool isThrowing;

    void Update(){
        isThrowing = input.retrieveThrowInput();
        if(isThrowing && canThrow){
            canThrow = false;
            ThrowObject();
        }
    }

    void ThrowObject(){
        GameObject throwable = Instantiate(throwableObject, firePoint.position, firePoint.rotation);
        Rigidbody2D throwableRb = throwable.GetComponent<Rigidbody2D>();
        throwableRb.AddForce(firePoint.right * throwForce, ForceMode2D.Impulse);
        throwableRb.AddTorque(5f, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("throwable")){
            canThrow = true;
            Destroy(collider.gameObject);
        }
    }
}
