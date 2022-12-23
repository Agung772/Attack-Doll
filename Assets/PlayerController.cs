using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    bool cannon1, cannon2;
    bool isCannon1, isCannon2;
    public bool isJumping;
    int changePosisiPlayer;
    public Transform cannonPoint1, cannonPoint2;
    public CannonController cannonController1, cannonController2;

    public Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
        MoveControl();
    }

    void MoveControl()
    {
        if (isJumping) return;

        if (Input.GetKeyDown(KeyCode.Space) && !cannon1 && changePosisiPlayer == 0)
        {
            if (isCannon1) return;

            animator.SetTrigger("Jump");

            transform.eulerAngles = new Vector3(0, -90, 0);
            StartCoroutine(DelayJumpCoroutine());
            IEnumerator DelayJumpCoroutine()
            {
                yield return new WaitForSeconds(0.5f);
                rb.velocity = Vector3.up * 7;
                cannon1 = true;
                isCannon2 = false;
                cannonController2.useCannon = false;

                isJumping = true;
                changePosisiPlayer = 1;
            }
 
        }

        else if (Input.GetKeyDown(KeyCode.Space) && !cannon2 && changePosisiPlayer == 1)
        {
            if (isCannon2) return;

            animator.SetTrigger("Jump");

            transform.eulerAngles = new Vector3(0, 90, 0);
            StartCoroutine(DelayJumpCoroutine());
            IEnumerator DelayJumpCoroutine()
            {
                yield return new WaitForSeconds(0.5f);
                rb.velocity = Vector3.up * 7;
                cannon2 = true;
                isCannon1 = false;
                cannonController1.useCannon = false;

                isJumping = true;
                changePosisiPlayer = 0;
            }
     
        }
    }

    void Move()
    {
        if (cannon1)
        {
            transform.position = Vector3.MoveTowards(transform.position, cannonPoint1.position, 20 * Time.deltaTime);
            if (Vector3.Distance(transform.position, cannonPoint1.position) < 0.1f)
            {
                cannon1 = false;
                isCannon1 = true;

                cannonController1.useCannon = true;





                StartCoroutine(DelayFlipCoroutine());
                IEnumerator DelayFlipCoroutine()
                {
                    yield return new WaitForSeconds(0.5f);
                    transform.eulerAngles = Vector3.zero;
                    yield return new WaitForSeconds(0.5f);
                    isJumping = false;

                }
            }
        }

        if (cannon2)
        {
            transform.position = Vector3.MoveTowards(transform.position, cannonPoint2.position, 20 * Time.deltaTime);
            if (Vector3.Distance(transform.position, cannonPoint2.position) < 0.1f)
            {
                cannon2 = false;
                isCannon2 = true;

                cannonController2.useCannon = true;





                StartCoroutine(DelayFlipCoroutine());
                IEnumerator DelayFlipCoroutine()
                {
                    yield return new WaitForSeconds(0.5f);
                    transform.eulerAngles = Vector3.zero;
                    yield return new WaitForSeconds(0.5f);
                    isJumping = false;

                }
            }
        }
    }
}
