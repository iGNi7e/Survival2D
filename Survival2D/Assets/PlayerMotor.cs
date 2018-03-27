using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour {

    private Vector2 velocity = Vector2.zero;
    //private float rotation;

    private Rigidbody2D rb;
    
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    public void Move(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    //public void Rotate(float _rotation)
    //{
    //    rotation = _rotation;
    //}

    void FixedUpdate () {
        PerformMovement();
        //PerformRotation();
    }

    void PerformMovement()
    {
        if(velocity != Vector2.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    //void PerformRotation()
    //{
    //    rb.MoveRotation(rb.rotation - rotation * 100f * Time.fixedDeltaTime);
    //}
}
