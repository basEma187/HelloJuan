using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int life;

    public Image bar;

    private int _maxLife;
    private ParticleSystem _particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        _maxLife = life;
        _particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        _particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBar();
        if (life <= 0)
            gameObject.SetActive(false);
    }

    public void AddLife(int delta)
    {
        if(delta <0)
            _particleSystem.Play();
        life += delta;
    }

    private void UpdateBar()
    {
        var lifePercentage = (1.0f * life) / _maxLife;
        bar.fillAmount = lifePercentage;
    }
}