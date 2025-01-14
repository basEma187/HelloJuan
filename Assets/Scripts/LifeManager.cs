using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int life;

    public Image bar;

    private int _maxLife;

    // Start is called before the first frame update
    void Start()
    {
        _maxLife = life;
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
        life += delta;
    }

    private void UpdateBar()
    {
        var lifePercentage = (1.0f * life) / _maxLife;
        bar.fillAmount = lifePercentage;
    }
}