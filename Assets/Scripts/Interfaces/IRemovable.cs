using System;

public interface IRemovable
{
    public event Action<IRemovable> OnRemove;

    public void Remove();
}
