using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    private GameObject _player;
    private float _distance;
    private NavMeshAgent _enemy;
    private float _currentInterval;

    public float interval;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");

        _enemy =  GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(_player.transform.position, transform.position);
        Debug.DrawLine(transform.position,_player.transform.position,Color.green);

        if (_distance <= 5.0f)
            _enemy.destination = _player.transform.position;
        else
            _enemy.destination = transform.position;

        _currentInterval -= Time.deltaTime;
        if (_currentInterval <= 0.0f && _distance <= 2.0f  && _player.activeInHierarchy)
        {
            Debug.Log(_player.GetComponent<LifeManager>().life);
            _player.GetComponent<LifeManager>().AddLife(-5);
            _currentInterval = interval;
        }
           

    }
    
}
