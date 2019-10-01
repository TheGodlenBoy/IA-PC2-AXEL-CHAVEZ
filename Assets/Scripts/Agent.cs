using UnityEngine;

public class Agent : SBAgent
{
	public Transform target;
	public float radio;
	public Vector3 center;
	public Transform centroObjeto;

	void Start()
	{		
		
		maxSpeed = 10f;
		maxSteer = 0.5f;
		radio= 3;
		center = centroObjeto.transform.position;
		
	}

	void Update()
	{
		velocity += SteeringBehaviours.Seek(this, target);
		velocity += SteeringBehaviours.InsideCircle(this, center , radio);
		transform.position += velocity*Time.deltaTime;
	}


		void OnDrawGizmos()
	{
		Gizmos.color= Color.red;
		Gizmos.DrawWireSphere(center,radio);
		

	}
}
