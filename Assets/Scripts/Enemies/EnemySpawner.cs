using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _container;
    [SerializeField] private float _radius;
    [SerializeField] private float _rate;
    [SerializeField] private Transform _player;
    [SerializeField] private RewardCalculate _scoreCalculate;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, _rate);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void Spawn()
    {
        Vector2 pointInCircle = UnityEngine.Random.insideUnitCircle.normalized * _radius;
        Vector3 position = new Vector3(pointInCircle.x, transform.position.y, pointInCircle.y);

        Enemy enemy = Instantiate(_enemy, position, Quaternion.identity, _container);
        enemy.Init(_player);

        enemy.GetComponent<Reward>().Init(_scoreCalculate);
    }
}