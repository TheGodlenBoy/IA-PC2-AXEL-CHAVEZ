using UnityEngine;

public class SteeringBehaviours
{
    static public Vector3 Seek(SBAgent agent, Transform target)
    {
        // cálculo del vector deseado
        Vector3 desired = (target.position - agent.transform.position).normalized * agent.maxSpeed;

        // cálculo de los demás vectores
        Vector3 steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);

        return steer;
    }

    static public Vector3 Flee(SBAgent agent, Transform target)
    {
        // cálculo del vector deseado
        Vector3 desired = -(target.position - agent.transform.position).normalized * agent.maxSpeed;

        // cálculo de los demás vectores
        Vector3 steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);

        return steer;
    }

    static public Vector3 Arrive(SBAgent agent, Transform target, float range)
    {
        // cálculo del vector deseado
        Vector3 desired;
        Vector3 difference = (target.position - agent.transform.position);
        float distance = difference.magnitude;

        desired = difference.normalized * agent.maxSpeed;

        if (distance < range)
        {
            desired *= distance / range;
        }

        // cálculo de los demás vectores
        Vector3 steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);

        return steer;
    }



    static public Vector3 InsideCircle(SBAgent agent, Vector3 center, float radio)
    {
        // cálculo del vector deseado
        Vector3 desired;
        Vector3 steer;


        float distance = (agent.transform.position - center).magnitude;



        if (distance > radio)
        {
            desired = (center - agent.transform.position).normalized * agent.maxSpeed;

            //desired *= radio / distance;
        }
        else
        {
            desired = Vector3.zero;

        }

        // cálculo de los demás vectores

        steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
        return steer;
    }




}
