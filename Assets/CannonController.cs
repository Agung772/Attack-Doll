using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public bool useCannon;
    public Transform cannonBody;
    public float speedRotateCannon;

    public float yDegress, zDegress;

    [Space]

    public GameObject cannonPrefab;
    public Transform shootPoint;
    public float shootForce;

    void Update()
    {
        RotateBodyCannon();
        ShootCannon();
    }

    void RotateBodyCannon()
    {
        if (!useCannon) return;

        float inputZ = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        zDegress += inputZ * speedRotateCannon * Time.deltaTime;
        yDegress += inputY * speedRotateCannon * Time.deltaTime;

        cannonBody.localEulerAngles = new Vector3(0, yDegress, zDegress);

        yDegress = Mathf.Clamp(yDegress, -5, 35);
        zDegress = Mathf.Clamp(zDegress, -50, 50);
    }

    void ShootCannon()
    {
        if (!useCannon) return;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject Cannon = Instantiate(cannonPrefab, shootPoint.position, shootPoint.rotation);
            Cannon.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        }
    }
}
