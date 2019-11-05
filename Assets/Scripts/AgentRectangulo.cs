using UnityEngine;

public class AgentRectangulo : SBAgent
{
   	public Transform target;
    public Vector3 targetPosition;

	public Vector3 centerRect;
    public float rectangleWidth;
    public float rectangleHeight;



	private void Start()
	{			
		maxSpeed = 5f;
		maxSteer = 3f;

        rectangleWidth =5f;
        rectangleHeight =5f;
		centerRect = GameObject.Find("centerRect").GetComponent<Transform>().transform.position;
		
	}

	private void Update()
	{
		float distance = (transform.position - centerRect).magnitude;
		target = GameObject.Find("Target").GetComponent<Transform>();
        targetPosition = target.transform.position;
		
        //velocity += SteeringBehaviours.Seek(this, target);
		velocity += SteeringBehaviours.InsideRectangle(this , targetPosition, centerRect , rectangleWidth,rectangleHeight) * Time.deltaTime;

		transform.position +=velocity*Time.deltaTime;

	}

	void OnDrawGizmos()
	{
        Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(centerRect, new Vector3(rectangleWidth, rectangleHeight, 0));
	}
}
