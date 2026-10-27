using UnityEngine;
using static UnityEngine.UI.Image;

public class UnitRanged : Unit
{
    public Projectile projectile;
    public Transform projectileOrigin;

    public override void hitEnemy()
    {
        if (!targetEnemy) { return; }
        Projectile myProjectile = Instantiate(projectile, projectileOrigin.position, Quaternion.identity);
        myProjectile.setProjectileDamage(damage);
        myProjectile.setProjectileTeam(team);
        myProjectile.setProjectileDirection(direction);
        if (audioData != null) AudioManager.Instance.PlaySFX(audioData.attack, audioData.volumeUnit);
    }

}
