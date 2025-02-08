using Unity.VisualScripting;
using UnityEngine;

public class BitSpawner : MonoBehaviour
{
    public GameObject bits;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        for (int i = 0; i < 5; i++)
        {
            Invoke("ActualSpawn", Random.Range(1f,3f));
            
        }
    }
    void ActualSpawn()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-5f , 5f), transform.position.y,transform.position.z);
        Instantiate(bits,randomPosition,Quaternion.identity);

    }
}
