using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    Vector3 localScale;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = PlayerControls.health;
        transform.localScale = localScale;
        spriteRenderer.color = getColor(PlayerControls.health);
    }

    private Color getColor(float health){
        if(health > 0.5f) return Color.green;
        else return Color.red;
    }
}
