using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public float damamge = 50f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);


    }

    void HitTarget() 
    {
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        } else 
        {
            Damage (target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            Debug.Log(collider);
            if (collider.gameObject.tag == "Enemy")
            {   
                Debug.Log("Explosion Damage");
                Damage (collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        EnemyHealth e = enemy.GetComponent<EnemyHealth>(); 

        if ( e != null)
        {
            e.TakeDamage(damamge);
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
