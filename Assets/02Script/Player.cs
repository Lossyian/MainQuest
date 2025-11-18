using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float playerJump = 5.0f;

    [SerializeField] private float rotatespeed = 10.0f;
    [SerializeField] private float smoothInputspeed = 10.0f;
    [SerializeField] public GameObject spawnPoint;




    CharacterController cc;
    Animator animator;
    [SerializeField] GameManager manager;
    Vector3 dir;
    Vector3 smoothinput = Vector3.zero;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip boomSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        movement();

    }

    void movement()
    {
        if (manager.gameOver == false && manager.gameClear == false)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector3 inputDir = new Vector3(h, 0.0f, v).normalized;
            smoothinput = Vector3.Lerp(smoothinput, inputDir, smoothInputspeed * Time.deltaTime);

            if (smoothinput.sqrMagnitude > 0.01f)
            {
                Quaternion targetrot = Quaternion.LookRotation(smoothinput);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetrot, rotatespeed * Time.deltaTime);
            }

            animator.SetBool("IsGrounded", cc.isGrounded);
            if (cc.isGrounded)
            {
                dir.y = -1f;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetTrigger("Jump");
                    dir.y = playerJump;
                }

            }
            else
            {
                dir.y += Physics.gravity.y * Time.deltaTime;
            }




            Vector3 move = (inputDir * playerSpeed) + new Vector3(0f, dir.y, 0f);
            cc.Move(move * Time.deltaTime);

            float speedvalue = inputDir.magnitude;
            animator.SetFloat("Speed", speedvalue);

        }
    }

    public void ResetPosition()
    {
        Vector3 spawnposition = spawnPoint.transform.position;
        cc.enabled = false;
        transform.position = spawnposition;
        cc.enabled = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            if (audioSource != null && coinSound != null)
            {
                audioSource.PlayOneShot(coinSound);
            }
        }
        if (other.CompareTag("Boom"))
        {
            if (audioSource != null && coinSound != null)
            {
                audioSource.PlayOneShot(boomSound);
            }
        }
    }
}
