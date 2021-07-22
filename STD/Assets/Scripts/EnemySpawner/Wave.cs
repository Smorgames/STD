using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Wave
{
    public string Name = "Wave";

    [SerializeField] private int _numberInSequence;
    [SerializeField] private List<Subwave> _subwaves;
}