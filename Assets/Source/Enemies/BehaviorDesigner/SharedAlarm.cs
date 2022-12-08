using BehaviorDesigner.Runtime;
using System;

[Serializable]
public class SharedAlarm : SharedVariable<Alarm>
{
    public static implicit operator SharedAlarm(Alarm value) => new SharedAlarm { Value = value };
}