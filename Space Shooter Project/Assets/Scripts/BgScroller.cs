using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizedZ;

    private Vector3 startPosition;
    private float currentScrollSpeed;

    // Speed up when game is won
    public GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        currentScrollSpeed = scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizedZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        SkySpeed();
    }

    void SkySpeed()
    {
        if (gameController.gameOver == true)
        {
            scrollSpeed = currentScrollSpeed - 5.0f;
        }
    }
}
