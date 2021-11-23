using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAttackBox : MonoBehaviour
{
    public SpriteRenderer zombieColor;

    public string playerTag;
    public string barricadeTag;
    public float damageUnit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            zombieColor.color = new Color(255.0f, 0.0f, 0.0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag | collision.gameObject.tag == barricadeTag)
        {
            zombieColor.color = new Color(255.0f, 255.0f, 255.0f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == barricadeTag)
        {
            barricadeHealth b = collision.GetComponent<barricadeHealth>();

            b.health -= damageUnit;
            if (b.health <= 0.0f)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
