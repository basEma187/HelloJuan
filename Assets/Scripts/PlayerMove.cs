using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    private float _distance;

    void Update()
    {
        var enemy = GameObject.Find("Enemy");
        if(enemy)
            _distance = Vector3.Distance(enemy.transform.position, transform.position);
        CharacterController controller = GetComponent<CharacterController>();

        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ( _distance <= 2.0f && enemy)
            {
                enemy.GetComponent<LifeManager>().AddLife(-5);
                Debug.Log("pugno");
            }
            
        }
    }
}
