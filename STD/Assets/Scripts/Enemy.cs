using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed { get { return _speed; } }
}