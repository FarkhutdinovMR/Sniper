using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CheckDistance : Conditional
{
    public float StopingDistance = 1f;
    public SharedTransform Target;

    public override TaskStatus OnUpdate()
    {
        if (Vector3.Distance(transform.position, Target.Value.position) <= StopingDistance)
            return TaskStatus.Success;
        else
            return TaskStatus.Running;
    }
}