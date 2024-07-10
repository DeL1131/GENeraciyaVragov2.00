using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Enemy _target;

    [Tooltip("Интервал спавна противников")]
    [SerializeField] private float _timeSpawn;

    private bool _isWork = true;

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_timeSpawn);

        while (_isWork)
        {
            yield return waitForSeconds;
            Enemy spawnedEnemy = Instantiate(_prefab, transform.position, Quaternion.identity);
            Enemy target = _target;

            spawnedEnemy.GetTarget(target);
        }
    } 
}
