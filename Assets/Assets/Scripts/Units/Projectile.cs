using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damage = 1;
    public float speed = 1.4f;
    public int direction = 1;
    public int team = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.fixedDeltaTime * direction, 0, 0);
    }

    public void setProjectileDamage(float damage)
    {
        this.damage = damage;
    }

    public void setProjectileDirection(int direction)
    {
        this.direction = direction;
    }

    public void setProjectileTeam(int team)
    {
        this.team = team;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Unit>(out Unit unit) && unit.team!=team)
        {
            unit.getHit(damage);
            DestoyProjectile();
        }
    }

    public void DestoyProjectile()
    {
        Destroy(gameObject);
    }

}
