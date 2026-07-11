using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private Transform firePoint;
    public override void Shoot()
    {
        Bullet bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        bullet.Shoot(firePoint.up);
    }
}