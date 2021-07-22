using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Wave", menuName = "SpawnSystem/Wave")]
public class Wave : ScriptableObject
{
    public string Name = "Wave";

    public int NumberInSequence;
    public List<Subwave> Subwaves;
    public List<float> DelayBeforeSpawnSubwave;
}