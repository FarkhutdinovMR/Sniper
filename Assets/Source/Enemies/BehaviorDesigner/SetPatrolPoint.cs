using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetPatrolPoint : Action
{
    public SharedTransform Target;
    public SharedTransformList Points;

    private int _currentPoint;

    public override TaskStatus OnUpdate()
    {
        Target.Value = Points.Value[_currentPoint];
        _currentPoint = _currentPoint + 1 < Points.Value.Count ? _currentPoint + 1 : 0;
        return TaskStatus.Success;
    }
}