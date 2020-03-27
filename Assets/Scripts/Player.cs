using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 1;
	public float rotationSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Move();
    }

	void Move()
	{
		Turn();

		float strafe = Input.GetAxis( "Horizontal" ) * Time.deltaTime * speed;
		float forward = Input.GetAxis( "Vertical" ) * Time.deltaTime * speed;

		transform.Translate(new Vector3(strafe, 0, forward));
	}

	void Turn()
	{
		float rotation = Input.GetAxis( "Mouse X" ) * Time.deltaTime * rotationSpeed;

		transform.rotation *= Quaternion.Slerp(Quaternion.identity, Quaternion.LookRotation(rotation < 0 ? Vector3.left : Vector3.right), Mathf.Abs(rotation));
	}
}
