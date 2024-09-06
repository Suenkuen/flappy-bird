using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 2f;
    public float highOffset = 2f;
    public float lowOffset = -2f;

    // Update is called once per frame
    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 0, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(lowOffset, highOffset);
    }
}
