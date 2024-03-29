using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyParallax : MonoBehaviour
{

    public static float JumpCompletion = 0; // percentage from 0.0 to 1.0
    private Camera Camera;
    private Vector2 startSize = new Vector2(1920, 3240);
    private SpriteRenderer Sprite;
    float SpriteHeight, _SpriteMaxMove;
    float WidestAspect = 16f / 9f;
    float ExpectedCamSize = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponentInParent<Camera>();
        Sprite = GetComponent<SpriteRenderer>();
        SpriteHeight = Sprite.localBounds.extents.y;
        _SpriteMaxMove = SpriteHeight * 0.66f;
    }

    // Update is called once per frame
    void Update()
    {
        float currentAspect = Camera.aspect;
        float yScale = Camera.orthographicSize / ExpectedCamSize;
        float xScale = Mathf.Max(1f, currentAspect / WidestAspect) * yScale;
        Vector3 scale = transform.localScale;
        scale.x = xScale;
        scale.y = yScale;
        transform.localScale = scale;

        Vector3 pos = transform.localPosition;
        pos.y = Mathf.Lerp(-SpriteMaxMove(), SpriteMaxMove(), JumpCompletion);
        transform.localPosition = pos;
    }

    float SpriteMaxMove()
    {
        return Sprite.localBounds.extents.y * transform.lossyScale.y * 0.66f;
    }
}
