using UnityEngine;

public class AgentCircle : SBAgent
{
	public Transform target;
	public float radio;
	public Vector3 center;



	private void Start()
	{		
		
		maxSpeed = 5f;
		maxSteer = 2f;
		radio= 3;
		center = GameObject.Find("center").GetComponent<Transform>().transform.position;
		
	}

	private void Update()
	{
		float distance = (transform.position - center).magnitude;
		target = GameObject.Find("Target").GetComponent<Transform>();

		
		velocity += SteeringBehaviours.InsideCircle(this, center , radio);

		if(distance<=3)
		{
		velocity += SteeringBehaviours.Seek(this, target);
		}

		transform.position += velocity*Time.deltaTime;

	}


	public void OnDrawGizmos()
	{
		Gizmos.color= Color.red;
		Gizmos.DrawWireSphere(center,radio);
		

	}
}
