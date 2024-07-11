using UnityEngine;

[RequireComponent (typeof(Enemy))]

public class NPCPatrul : MonoBehaviour
{
    [SerializeField] private Transform[] _allPlacesPoint;

    private Transform _target;
    private Enemy _enemy;

    private int _numberPoint;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _target = _allPlacesPoint[_numberPoint];       
    }

    private void Update()
    {
        Vector3 targetPoint = _target.position;
        Vector3 direction = (targetPoint - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _enemy.Speed);

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _enemy.Speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        _numberPoint++;

        if (_numberPoint == _allPlacesPoint.Length)
            _numberPoint = 0;

        _target = _allPlacesPoint[_numberPoint].transform;
    }
}
