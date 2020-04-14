using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaCheck : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float alpha;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AlphaChecker();
    }

    public float AlphaChecker()
    {
        alpha = spriteRenderer.color.a;

        return alpha;
    }

    public string DefaultName()
    {
        SpriteRenderer spriteObject = gameObject.GetComponent<SpriteRenderer>();

        Debug.Log(spriteObject.sprite);
        Debug.Log(spriteObject.sprite.name);

        return spriteObject.sprite.name;
    }
}
