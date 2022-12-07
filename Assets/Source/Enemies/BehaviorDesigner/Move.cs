using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Move : Action
{
    public SharedVector3 Direction;
    public SharedMovement Movement;

    public override TaskStatus OnUpdate()
    {
        Movement.Value.Move(new Vector2(Direction.Value.x, Direction.Value.z));
        return TaskStatus.Running;
    }
}