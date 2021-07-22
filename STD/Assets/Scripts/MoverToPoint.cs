using UnityEngine;

public class MoverToPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private float _speed;
    private int _pointIndex = 0;

    private void Awake()
    {
        Initializtion();
    }

    private void Update()
    {
        Vector3 pointPosition = EnemyPath.Instance.MovePoints[_pointIndex].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, pointPosition, Time.deltaTime * _speed);

        if (transform.position == pointPosition)
        {
            int pointCount = EnemyPath.Instance.MovePoints.Count;

            if (_pointIndex < pointCount - 1)
            {
                _pointIndex++;
            }
        }
    }

    private void Initializtion()
    {
        if (!_enemy)
        {
            _enemy = GetComponent<Enemy>();

            if (!_enemy)
            {
                Debug.LogError($"{transform.name} has no Enemy script on it!");
                return;
            }
        }

        _speed = _enemy.Speed;
    }
}