using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int life;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
            gameObject.SetActive(false);
    }

    public void AddLife(int delta)
    {
        life += delta;
    }
    
    
}
