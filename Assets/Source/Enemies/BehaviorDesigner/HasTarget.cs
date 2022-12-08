namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    public class HasTarget : Conditional
    {
        public SharedTransform Target;

        public override TaskStatus OnUpdate()
        {
            if (Target != null && Target.Value != null)
                return TaskStatus.Success;
            else
                return TaskStatus.Failure;
        }
    }
}