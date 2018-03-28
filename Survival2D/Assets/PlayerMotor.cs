using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour {

    private Vector2 velocity = Vector2.zero;
    private Vector2 rotation = Vector2.zero;

    private Rigidbody2D rb;
    
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    public void Move(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector2 _rotation)
    {
        rotation = _rotation;
    }

    private void Update()
    {
        PerformRotation();
    }

    void FixedUpdate () {
        PerformMovement();
    }

    void PerformMovement()
    {
        if(velocity != Vector2.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        float angle = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;
        Quaternion endRotation = Quaternion.AngleAxis(angle,Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation,endRotation,100 * Time.deltaTime);
    }
}
