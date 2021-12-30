using System;

public interface IReloader
{
    public event Action<IShooter> Reloaded;
    public void Reload();
}