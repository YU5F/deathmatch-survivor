using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool isColliding;
    private float friction;

    private void OnCollisionEnter2D(Collision2D collision){
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionStay2D(Collision2D collision){
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionExit2D(Collision2D collision){
        isColliding = false;
        friction = 0;
    }
    
    private void EvaluateCollision(Collision2D collision){
        for(int i = 0; i < collision.contactCount; i++){
            Vector2 normal = collision.GetContact(i).normal;
            isColliding |= normal.y >= 0.9f;
        }
    }

    private void RetrieveFriction(Collision2D collision){
        PhysicsMaterial2D material = collision.rigidbody.sharedMaterial;
        friction = 0;
        if(material != null){
            friction = material.friction;
        }
    }

    public bool GetIsColliding(){
        return isColliding;
    }

    public float GetFriction(){
        return friction;
    }
}
