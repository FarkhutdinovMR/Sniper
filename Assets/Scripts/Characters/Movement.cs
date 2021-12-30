using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action<float> Moved;

    public void Move(Vector3 target)
    {
        transform.LookAt(new Vector3(target.x, 0, 0));
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        Moved?.Invoke(_speed);
    }
}