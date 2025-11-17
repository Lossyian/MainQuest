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
    

        if (cc.isGrounded)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dir.y = playerJump;
            }
            
        }

        Vector3 move = inputDir * playerSpeed;
        cc.Move(move* Time.deltaTime);

        float speedvalue = inputDir.magnitude;
        animator.SetFloat("Speed", speedvalue);

        

    }

    void Itmepulling()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position,radius);
        // 해당하는 레이어 혹은 태그의 오브젝트가 범위 안에 들어오면 플레이어의 포지션 - 아이템 포지션 (끌어당긴)한다.
        // 
        
    }
}
