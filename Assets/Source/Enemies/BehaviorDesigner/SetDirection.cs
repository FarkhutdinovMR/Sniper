using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetDirection : Action
{
    public SharedVector3 Direction;
    public SharedTransform Target;

    public override TaskStatus OnUpdate()
    {
        Direction.Value = (Target.Value.position - transform.position).normalized;
        return TaskStatus.Success;
    }
}