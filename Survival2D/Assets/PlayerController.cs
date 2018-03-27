﻿using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 10f;

    private PlayerMotor playerMotor;
    
	void Start () {
        playerMotor = GetComponent<PlayerMotor>();
    }
	
	void Update () {
        //Calculate movement player
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        Vector2 _movHorizontal = -transform.up * _xMov;
        Vector2 _movVertical = transform.right * _yMov;

        Vector2 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        playerMotor.Move(_velocity);

        //Calculate rotation player
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float _zAngle = Vector2.Dot(transform.right,mousePos);
        //playerMotor.Rotate(_zAngle);


        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mousePos.y,mousePos.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,100 * Time.deltaTime);
    }
}