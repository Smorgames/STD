using UnityEngine;
using System.Collections.Generic;

public class TargetRotator : MonoBehaviour
{
    [SerializeField] private Collider2D _attackRangeCollider;
    [SerializeField] private float _rotationSpeed;

    private List<Enemy> _enemies;

    private void Awake()
    {
        Initialization();
    }

    private void Update()
    {
        if (_enemies.Count > 0)
        {
            Vector3 enemyPosition = _enemies[_enemies.Count - 1].GetComponent<Transform>().position;

            Vector3 direction = enemyPosition - transform.position;
            direction.Normalize();

            float zRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion needRotation = Quaternion.Euler(0f, 0f, zRotation);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, needRotation, Time.deltaTime * _rotationSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.transform.GetComponent<Enemy>();

        if (enemy && !_enemies.Contains(enemy))
        {
            _enemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemy enemy = collision.transform.GetComponent<Enemy>();

        if (enemy && _enemies.Contains(enemy))
        {
            _enemies.Remove(enemy);
        }
    }

    private void Initialization()
    {
        if (!_attackRangeCollider)
        {
            _attackRangeCollider = GetComponent<Collider2D>();

            if (!_attackRangeCollider)
            {
                Debug.LogError($"No collider2D on {transform.name}");
                return;
            }

            _attackRangeCollider.isTrigger = true;
        }

        _enemies = new List<Enemy>();
    }
}