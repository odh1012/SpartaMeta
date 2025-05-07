using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highposy = 1f;
    public float lowposy = -1f;

    public float holesizemin = 1f;
    public float holesizemax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    FlappyGameManager flappygameManager;
    private void Start()
    {
        flappygameManager = FlappyGameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstaclCount)
    {
        float holeSize = Random.Range(holesizemin, holesizemax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowposy, highposy);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
            flappygameManager.AddScore(1);
    }
}
