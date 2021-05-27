using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectd : MonoBehaviour
{
    public GameObject Car2;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Car2, new Vector3(0, 0, 10), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1000);
    }
}
