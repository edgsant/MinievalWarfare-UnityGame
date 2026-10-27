using UnityEngine;
using static UnityEngine.UI.Image;

public class Unit : MonoBehaviour
{
    [Tooltip("Vida de la tropa, deberia definirse en la especializacion y no en esta clase")]
    public float health=10;
    [Tooltip("Velocidad de la tropa, X es la velocidad base")]
    public float speed=2;
    [Tooltip("Multiplicador de daño de la tropa, cada ataque diferente tendra un multiplicador")]
    public float damage=1;
    [Tooltip("Multiplicador de reduccion de daño de la tropa\n " +
        "Es decir, 1 sería un 10% menos de daño (recibe el 90%)")]
    public float armor=0;
    [Tooltip("Rango de ataque de la tropa, 1 es CaC")]
    public float range=1;
    [Tooltip("Direccion a la que se mueve la tropa, decidido por el equipo al que pertenece")]
    public int direction;
    [Tooltip("Equipo al que pertenece la tropa, 0 es izquierda y 1 derecha")]
    public int team;
    [Tooltip("Multiplicador a la velocidad de ataque")]
    public float attackSpeed = 1;
    [Tooltip("Segundos que tienen que pasar desde que hace un ataque hasta que puede volver a atacar")]
    public float attackCooldown = 1;
    [Tooltip("Coste de la tropa")]
    public int cost = 1;
    [Tooltip("Cantidad que anade al medidor cuando llega a la base enemiga")]
    public int victoryScore = 10;
    [Tooltip("Spawn cooldown")]
    public float spawnCooldown = 0.2f;
    [Tooltip("Que tan peligrosa la considera el sistema")]
    public int dangerScore = 1;




    public Unit targetEnemy;
    public Unit targetAlly;
    public bool canAttack=true;
    public LayerMask enemyMask;
    public LayerMask allyMask;

    public Rigidbody2D rb2d;
    public SpriteRenderer rb;
    public Animator animator;
   
    public UnitAudioData audioData;
    public UnitData unitData;
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb = GetComponent<SpriteRenderer>();
        if (audioData != null) AudioManager.Instance.PlaySFX(audioData.spawn, audioData.volumeUnit);
    }

    public void setTeam(int unitTeam)
    {
        team = unitTeam;
        setMasks();
    }

    private void setMasks()
    {
        if (team == 0)
        {
            direction = 1;
            gameObject.layer = 10;
            enemyMask = LayerMask.GetMask("Team1");
            allyMask = LayerMask.GetMask("Team0");

        }
        else
        {
            direction = -1;
            rb.flipX = true;
            gameObject.layer = 11;
            enemyMask = LayerMask.GetMask("Team0");
            allyMask = LayerMask.GetMask("Team1");
        }
    }

    public void getHit(float damageReceived)
    {
        if (audioData != null) AudioManager.Instance.PlaySFX(audioData.hit, audioData.volumeUnit-0.45f);
        health -= (damageReceived/armor);
        rb.color = Color.red;
        Invoke("changeSpriteColor", 0.15f);
        if (health < 0)
        {
            if (audioData != null) AudioManager.Instance.PlaySFX(audioData.death, audioData.volumeUnit);
            animator.SetBool("IsDead", true);
        }
    }

    void changeSpriteColor()
    {
        rb.color = Color.white;
    }

    public void killUnit()
    {
        Destroy(gameObject);
    }

    public void attack()
    {
        if (!canAttack || !targetEnemy) { return; }
        canAttack = false;
        animator.SetBool("IsAttacking", true);
        Invoke("resetAttackCooldown", (attackCooldown / attackSpeed));
 
    }

    public virtual void hitEnemy()
    {
        if (!targetEnemy) { return; }
        if (audioData != null) AudioManager.Instance.PlaySFX(audioData.attack, audioData.volumeUnit - 0.2f);
        targetEnemy.getHit(damage);
    }

    public void finishAttackAnim()
    {
        animator.SetBool("IsAttacking", false);
    }

    private void resetAttackCooldown()
    {
        canAttack = true;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right*direction, range, enemyMask);
        RaycastHit2D ally = Physics2D.Raycast(transform.position, Vector2.right * direction, 0.6f, allyMask);

        Debug.DrawRay(transform.position, Vector2.right * range * direction, Color.red);   
        Debug.DrawRay(transform.position, Vector2.right * 0.5f * direction, Color.green); 



        if (hit.collider)
        {
            targetEnemy = hit.collider.GetComponent<Unit>();
            attack();
        }
        else
        {
            targetEnemy = null;
        }


        if (ally.collider)
        {
            targetAlly = ally.collider.GetComponent<Unit>();
        }
        else
        {
            targetAlly = null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!targetEnemy && !targetAlly)
        {
            rb2d.linearVelocityX = speed * direction;
            animator.SetFloat("movement", 1);
        }
        else
        {
            rb2d.linearVelocityX = 0;
            animator.SetFloat("movement", 0);
        }
         
    }

}
