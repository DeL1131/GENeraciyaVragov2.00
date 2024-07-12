using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent (typeof(ObjectDestroyer))]

public class TargetPursuit : MonoBehaviour
{
    private Enemy _enemy;
    private ObjectDestroyer _destroy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _destroy = GetComponent<ObjectDestroyer>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _enemy.Target.transform.position, _enemy.Speed * Time.deltaTime);

        if(transform.position == _enemy.Target.transform.position)
        {
            _destroy.DestroyObject();
        }
    }
}
