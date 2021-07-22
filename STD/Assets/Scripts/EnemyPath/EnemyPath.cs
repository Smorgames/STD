using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public static EnemyPath Instance;

    private List<MovePoint> _movePoints;

    private void Awake()
    {
        Initialization();
        FillMovePoints();
    }

    private void Initialization()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        _movePoints = new List<MovePoint>();
    }

    private void FillMovePoints()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("EnemyPath has 0 move point");
            return;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            MovePoint childMovePoint = child.GetComponent<MovePoint>();

            if (childMovePoint == null)
            {
                Debug.LogError("One of move point has no MovePoint script on it!");
                return;
            }

            _movePoints.Add(childMovePoint);
        }
    }

    public List<MovePoint> MovePoints { get { return _movePoints; } }
}