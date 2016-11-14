using UnityEngine;
using System.Collections;

public class LaserMovement : MonoBehaviour {

    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float distanceY = 0.007f;

    private bool isPlaying;

    void Start()
    {
        Play();
    }

    private void TranslateBetween()
    {
        if(transform.localPosition.y <= minY || transform.localPosition.y >= maxY)
        {
            distanceY = -distanceY;
        }

        transform.localPosition = new Vector2(transform.localPosition.x,
                                              transform.localPosition.y + distanceY);
    }

    void Update()
    {
        if (isPlaying)
        {
            TranslateBetween();
        }
    }

    public void Play()
    {
        isPlaying = true;
    }
}
