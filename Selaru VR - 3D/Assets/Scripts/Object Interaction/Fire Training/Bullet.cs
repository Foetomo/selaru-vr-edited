using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField, Tooltip("Destroy Time")] float timeToDestroy = 3f;
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        if (time >= timeToDestroy)
        {
            Destroy(this.gameObject);
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
