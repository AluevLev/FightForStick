using UnityEngine;

public class TemporaryObject
{
    private readonly GameObject _prefab;
    public void Destroy()
    {
        _prefab.SetActive(false);
    }
}
