using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetileDoll : MonoBehaviour
{
    
    public Vector3 playerTarget;
    bool stopFollow;

    private void Start()
    {
        Destroy(gameObject, 5);
    }
    void Update()
    {
        if (stopFollow) return;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerTarget.x, playerTarget.y, playerTarget.z), 10 * Time.deltaTime);
        if (Vector3.Distance(transform.position, playerTarget) <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
