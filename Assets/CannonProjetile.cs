using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjetile : MonoBehaviour
{
    public ParticleSystem efectDestroy, efectTrail;
    MeshRenderer meshRenderer;
    SphereCollider sphereCollider;
    Rigidbody rb;
    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        sphereCollider.enabled = false;
        rb.isKinematic = true;
        efectDestroy.Play();
        efectTrail.Stop();
        meshRenderer.enabled = false;
        Destroy(gameObject, 2);
    }
}
