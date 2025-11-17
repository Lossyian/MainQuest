using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed  = 5.0f;
    [SerializeField] private float playerJump = 5.0f;
    [SerializeField] private float radius = 5.0f;
    [SerializeField] private float rotatespeed = 10.0f;
    [SerializeField] private float smoothInputspeed = 10.0f;
    [SerializeField] public GameObject spawnPoint;

    
    CharacterController cc;
    Animator animator;
    GameManager manager;
    Vector3 dir;
    Vector3 smoothinput = Vector3.zero;
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
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(h, 0.0f, v).normalized;
        smoothinput = Vector3.Lerp(smoothinput, inputDir, smoothInputspeed * Time.deltaTime);

        if (smoothinput.sqrMagnitude>0.01f)
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

        


        Vector3 move = (inputDir * playerSpeed) + new Vector3 (0f,dir.y,0f);
        cc.Move(move* Time.deltaTime);

        float speedvalue = inputDir.magnitude;
        animator.SetFloat("Speed", speedvalue);
       

    }

    public void ResetPosition()
    {
        Vector3 spawnposition = spawnPoint.transform.position;
        cc.enabled = false;
        transform.position = spawnposition;
        cc.enabled = true;
    }

    void Itmepulling()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position,radius);
        // 해당하는 레이어 혹은 태그의 오브젝트가 범위 안에 들어오면 플레이어의 포지션 - 아이템 포지션 (끌어당긴)한다.
        // 
        
    }
}
