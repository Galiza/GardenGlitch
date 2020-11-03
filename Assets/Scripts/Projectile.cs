using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0f, 20f)]
    [SerializeField] float projectileSpeed = 10f;

    [Range(0f, 90f)]
    [SerializeField] float spinSpeed = 90f;

    Damage damage;

    private void Start()
    {
        damage = GetComponent<Damage>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
        //transform.Rotate(-Vector3.forward * spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage.GetDamage());
            Destroy(gameObject);
        }
    }
}