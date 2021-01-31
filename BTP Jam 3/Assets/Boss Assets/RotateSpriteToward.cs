using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpriteToward : MonoBehaviour
{
	public Transform player;

	void Update()
	{
		if(!player)
        {
            return;
        }
		Vector3 vectorToTarget = player.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle + 90f, Vector3.forward);//the angle + 90f is due to the downward original rotation
		transform.rotation = q;//Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10f);
	}
}