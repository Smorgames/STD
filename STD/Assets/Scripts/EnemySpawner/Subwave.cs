using UnityEngine;

[System.Serializable]
public class Subwave
{
    public string Name = "Subwave";

    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _amount;
    [SerializeField] private float _spawnRate;
}