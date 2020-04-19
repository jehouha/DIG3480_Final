using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpeed : MonoBehaviour
{
    public ParticleSystem starPS;
    public GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        starPS = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpeed();
    }

    void ChangeSpeed()
    {
        if (gameController.gameOver == true)
        {
            var main = starPS.main;
            main.startSize = 0.5f;
            main.startSpeed = 2.0f;
        }
    }
}
