using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Animator anim;

	public float speed = 6;
	public float turnSpeed = .1f;

    // Update is called once per frame
    void Update()
    {
		float strafe = Input.GetAxis("Horizontal");
		float forward = Input.GetAxis("Vertical");

		transform.Translate( new Vector3( strafe, 0, forward ) * speed * Time.deltaTime );

		float turn = Input.GetAxis("Mouse X");

		transform.rotation *= Quaternion.Slerp(Quaternion.identity, Quaternion.LookRotation(turn < 0 ? Vector3.left : Vector3.right), Mathf.Abs(turn) * turnSpeed);

		anim.SetFloat( "Right", strafe );
		anim.SetFloat( "Forward", forward );
    }
}
