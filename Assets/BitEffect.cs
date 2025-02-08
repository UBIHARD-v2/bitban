using Unity.VisualScripting;
using UnityEngine;

public class BitEffect : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        Destroy(gameObject,10f);
    }
    void Update()
    {
        transform.Translate(transform.forward * speed *Time.deltaTime );
    }
}
