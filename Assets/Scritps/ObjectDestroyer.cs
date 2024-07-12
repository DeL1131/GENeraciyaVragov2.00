using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public void DestroyObject()
    {
        GameObject.Destroy(gameObject);
    }
}
