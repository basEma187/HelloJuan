using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    private float _distance;
    private Animator _animator;
    


    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        var enemy = GameObject.Find("Enemy");
        if (enemy)
            _distance = Vector3.Distance(enemy.transform.position, transform.position);
        CharacterController controller = GetComponent<CharacterController>();

        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");

        ManageMovementAnimation();
        controller.SimpleMove(forward * curSpeed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Punch");

            StartCoroutine(Pippo());
            if (_distance <= 2.0f && enemy)
            {
                enemy.GetComponent<LifeManager>().AddLife(-5);
                Debug.Log("pugno");
            }
        }
    }

    private IEnumerator Pippo()
    {
        Debug.Log("prima");
        
        yield return new WaitForSeconds(0.25f);
        
        Debug.Log("dopo");
    }

    private void ManageMovementAnimation()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            _animator.SetBool("RunBack", false);
            _animator.SetBool("Run", true);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("RunBack", true);
        }
        else
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("RunBack", false);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            _animator.SetBool("LeftRun", false);
            _animator.SetBool("RightRun", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            _animator.SetBool("RightRun", false);
            _animator.SetBool("LeftRun", true);
        }
        else
        {
            _animator.SetBool("RightRun", false);
            _animator.SetBool("LeftRun", false);
        }
    }
}