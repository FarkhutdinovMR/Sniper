using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    [TaskCategory("Movement")]
    [TaskIcon("Assets/Behavior Designer Movement/Editor/Icons/{SkinColor}RotateTowardsIcon.png")]
    public class RotateTowards : Action
    {
        public SharedTransform Target;
        public SharedFloat MaxLookAtRotationDelta = 1;

        public override TaskStatus OnUpdate()
        {
            Vector3 direction = Target.Value.position - transform.position;
            direction.y = 0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), MaxLookAtRotationDelta.Value);
            if (Vector3.Angle(transform.forward, direction) < 1f)
                return TaskStatus.Success;

            return TaskStatus.Running;
        }
    }
}