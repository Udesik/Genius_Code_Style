using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _pathContainer;
    [SerializeField] private float _speed = 5f;

    private Transform[] _points;
    private int _currentPointIndex;

    private void Awake()
    {
        _points = new Transform[_pathContainer.childCount];
        
        for (int i = 0; i < _pathContainer.childCount; i++)
        {
            _points[i] = _pathContainer.GetChild(i);
        }
    }

    private void Update()
    {
        if (_points.Length == 0) 
            return;

        Transform target = _points[_currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (Vector3.SqrMagnitude(transform.position - target.position) < 0.001f)
        {
            SwitchToNextPoint();
        }
    }

    private void SwitchToNextPoint()
    {
        _currentPointIndex = (_currentPointIndex + 1) % _points.Length;
        transform.LookAt(_points[_currentPointIndex]);
    }
}