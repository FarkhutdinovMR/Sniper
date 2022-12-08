namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    public class IsAlarm : Conditional
    {
        public SharedAlarm Alarm;

        public override TaskStatus OnUpdate()
        {
            if (Alarm.Value.IsActive)
                return TaskStatus.Success;
            else
                return TaskStatus.Failure;
        }
    }
}