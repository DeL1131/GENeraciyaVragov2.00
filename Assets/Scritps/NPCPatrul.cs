using UnityEngine;

[RequireComponent (typeof(Enemy))]

public class NPCPatrul : MonoBehaviour
{
    [SerializeField] private Transform[] _allPlacesPoint;

    private Transform _target;
    private Enemy _enemy;

    private int _numberOfPlaceInArrayPlaces;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _target = _allPlacesPoint[_numberOfPlaceInArrayPlaces];       
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
            NextPlaceTakerLogic();
        }
    }

    private void NextPlaceTakerLogic()
    {
        _numberOfPlaceInArrayPlaces++;

        if (_numberOfPlaceInArrayPlaces == _allPlacesPoint.Length)
            _numberOfPlaceInArrayPlaces = 0;

        _target = _allPlacesPoint[_numberOfPlaceInArrayPlaces].transform;
    }
}
