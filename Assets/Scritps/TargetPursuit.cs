using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent (typeof(Destroy))]

public class NewBehaviourScript : MonoBehaviour
{
    private Enemy _enemy;
    private Destroy _destroy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _destroy = GetComponent<Destroy>();
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
