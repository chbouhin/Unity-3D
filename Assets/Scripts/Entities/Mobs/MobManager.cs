using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MobManager : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private AIPath _AIPath;

    private void Update()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) < _AIPath.endReachedDistance)
        {
            _AIPath.canMove = false;
        }
    }
}
