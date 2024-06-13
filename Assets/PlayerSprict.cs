using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprict : MonoBehaviour
{
    public Rigidbody rb;
    const float moveSpeed = 5.0f;
    const float jumpSpeed = 11.0f;
    private bool isBlock = true;
    private AudioSource audioSource;
    public GameObject bombParticle;
    public Animator animator;
    public GameObject playerparticle;
    int waittimer = 0;
    bool isParticle_ = false;
    Vector3 particleposition;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        transform.rotation = Quaternion.Euler(0, 90, 0);
        waittimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;
        Vector3 rayPosition = transform.position+new Vector3(0.0f,0.8f,0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);
        float distance = 0.9f;
        waittimer += 1;
      
       
        isBlock = Physics.Raycast(ray, distance);

        float stick = Input.GetAxis("Horizontal");
        if (GoalSprict.isGameClear == false)
        {
            if (Input.GetKey(KeyCode.RightArrow) && isParticle_ == false || stick>0&&isParticle_==false)
            {
                v.x = moveSpeed;
                transform.rotation = Quaternion.Euler(0, 90, 0);
                particleposition = transform.position + new Vector3(0.6f, 0.0f, 0.0f);
                animator.SetBool("mode", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && isParticle_ == false || stick<0 && isParticle_ == false)
            {
                v.x = -moveSpeed;
                transform.rotation = Quaternion.Euler(0, -90, 0);
                particleposition = transform.position + new Vector3(-0.6f, 0.0f, 0.0f);
                animator.SetBool("mode", true);
            }
            else
            {
                v.x = 0;
                animator.SetBool("mode", false);
            }
          
            if (Input.GetKeyDown(KeyCode.UpArrow)&&isBlock==true && isParticle_ == false || Input.GetButton("Jump")&&isBlock==true && isParticle_ == false)
            {
                v.y = jumpSpeed;
              
                
            }
           
            if(Input.GetKeyDown(KeyCode.B)||Input.GetButton("Fire2"))
            {
                animator.SetBool("wait", true);
                isParticle_ = true;
                Instantiate(playerparticle, particleposition, Quaternion.identity);
            }
            else
            {
                animator.SetBool("wait", false);
                isParticle_ = false;
            }
           
            if(isBlock==false)
            {
                animator.SetBool("jump", true);
            }
            else if(isBlock==true)
            {
                animator.SetBool("jump", false);
            }
            rb.velocity = v;
        }
        else
        {
            v.x = 0;
            rb.velocity = Vector3.zero;
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
            Instantiate(bombParticle, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
       
    }
}
