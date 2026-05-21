using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class zombie_dead_effet : MonoBehaviour
{
    [SerializeField] public List<deadLimbs> limbs = new List<deadLimbs>();
    [SerializeField] public GameObject limbPrefab;
    [SerializeField] public float force = 1f;
    [SerializeField] public GameObject blood_dead_effect;
    
    public void play_dead_effect()
    {
        foreach (deadLimbs limb in limbs)
        {
            GameObject obj = Instantiate(limbPrefab, transform.position, Quaternion.identity);
            SpriteRenderer obj_sprite =  obj.GetComponent<SpriteRenderer>();
            Rigidbody2D obj_rb = obj.GetComponent<Rigidbody2D>();

            obj_sprite.sprite = limb.limbsSprite;

            Vector2 dir = Random.insideUnitCircle.normalized;

            obj_rb.linearVelocity = dir * force;
            obj_rb.AddTorque(Random.Range(-7f, 7f), ForceMode2D.Impulse);
            obj.transform.localScale *= limb.scale;

        }

        Instantiate(blood_dead_effect, transform.position, Quaternion.identity);
    }
}
