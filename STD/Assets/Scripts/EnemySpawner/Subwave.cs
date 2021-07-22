using UnityEngine;

[CreateAssetMenu(fileName = "New Subwave", menuName = "SpawnSystem/Subwave")]
public class Subwave : ScriptableObject
{
    public string Name = "Subwave";

    public int NumberInSequence;

    public GameObject Enemy;
    public int EnemyAmount;
    public float DelayBeforeSpawnEnemy;
}