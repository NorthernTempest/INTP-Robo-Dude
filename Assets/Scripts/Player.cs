using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Animator animator;

	public float speed = 1;
	public float rotationSpeed = 1;

    // Update is called once per frame
    void Update()
    {
		Move();
    }

	void Move()
	{
		Turn();

		float strafe = Input.GetAxis( "Horizontal" );
		float forward = Input.GetAxis( "Vertical" );
		
		transform.Translate(new Vector3(strafe, 0, forward ) * Time.deltaTime * speed );

		animator.SetFloat( "Forward", forward );
		animator.SetFloat( "Left", -strafe );
		animator.SetFloat( "Move", Mathf.Abs( forward ) + Mathf.Abs( strafe ) );
	}

	void Turn()
	{
		float rotation = Input.GetAxis( "Mouse X" ) * Time.deltaTime * rotationSpeed;

		transform.rotation *= Quaternion.Slerp(Quaternion.identity, Quaternion.LookRotation(rotation < 0 ? Vector3.left : Vector3.right), Mathf.Abs(rotation));
	}
}
