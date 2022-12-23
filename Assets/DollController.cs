using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DollController : MonoBehaviour
{
    public float healthDoll;
    float maxHealthDoll;
    public Image barHpDoll;

    public GameObject projectileDoll;
    public Transform shootPoint;
    public Transform playerTarget;
    public float speedDoll;
    float flip = 1;



    private void Start()
    {
        StartCoroutine(ShootDollCoroutine());

        maxHealthDoll = healthDoll;
    }
    void Update()
    {
        MoveDoll();

        
    }

    void MoveDoll()
    {
        if (transform.position.x > 15)
        {
            flip = -1;
        }

        if (transform.position.x < -15)
        {
            flip = 1;
        }
        transform.Translate(Vector3.right * speedDoll * flip * Time.deltaTime);
    }

    IEnumerator ShootDollCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(2, 6));
        ShootDoll();
        StartCoroutine(ShootDollCoroutine());

    }
    void ShootDoll()
    {

        GameObject projectile = Instantiate(projectileDoll, shootPoint.position, shootPoint.rotation);
        //projectile.GetComponent<Rigidbody>().AddForce(shootPoint.forward * -5, ForceMode.Impulse);

        projectile.GetComponent<ProjetileDoll>().playerTarget = playerTarget.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ProjectilePlayer"))
        {
            healthDoll--;
            barHpDoll.fillAmount = healthDoll / maxHealthDoll;
        }
    }
}
