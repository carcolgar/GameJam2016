using UnityEngine;
using System.Collections;

public class Grandma : InteractableObject
{
    public Sprite doorOpen;
    public Sprite doorClose;
    public GameObject grandma;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        base.Start();
        spriteRenderer = image.GetComponent<SpriteRenderer>();
        grandma.SetActive(false);
        StartConflict();
    }

    public override void StartConflict()
    {
        base.StartConflict();
        spriteRenderer.sprite = doorOpen;
        grandma.SetActive(true);
    }

    public override void EndConflict()
    {
        base.EndConflict();
        spriteRenderer.sprite = doorClose;
        grandma.SetActive(false);
    }
}