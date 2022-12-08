using BehaviorDesigner.Runtime.Tasks;

public class Shoot : Action
{
    public SharedWeapon SharedWeapon;

    public override TaskStatus OnUpdate()
    {
        if (SharedWeapon.Value.CanShoot == false)
            return TaskStatus.Running;

        SharedWeapon.Value.Shoot();
        return TaskStatus.Success;
    }
}