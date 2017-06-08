using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public float CameraSpeed = 1;
    public float MoveSpeed = 1;
    public float DashSpeed = 1.5f;
    public float JumpPower = 1;

	private Transform playerCamera;
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        playerCamera = transform.Find("PlayerCamera");
        rigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * CameraSpeed);
        playerCamera.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * CameraSpeed);
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * (Input.GetKey(KeyCode.LeftShift) ? DashSpeed : MoveSpeed));
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * (Input.GetKey(KeyCode.LeftShift) ? DashSpeed : MoveSpeed));
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * (Input.GetKey(KeyCode.LeftShift) ? DashSpeed : MoveSpeed));
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * (Input.GetKey(KeyCode.LeftShift) ? DashSpeed : MoveSpeed));
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }
}
