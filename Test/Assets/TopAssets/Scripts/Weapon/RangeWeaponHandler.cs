using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RangeWeaponHandler : WeaponHandler
{
    [Header("Range Attack Data")]
    [SerializeField] private Transform projectileSpawnPoint;

    [SerializeField] private int bulletIndex;

    public int BulletIndex { get { return bulletIndex; } }

    [SerializeField] private float bulletSize = 1f;

    public float BulletSize { get { return bulletSize; } }

    [SerializeField] private float duration;

    public float Duration { get { return duration; } }

    [SerializeField] private float spread;

    public float Spread { get { return spread; } }

    [SerializeField] private int numberofPrejectilePerShot;

    public int NumberOfPrejectilePerShot { get { return numberofPrejectilePerShot; } }

    [SerializeField] private float multipleProjectileAngle;

    public float MultipleProjectileAngle { get { return multipleProjectileAngle; } }

    [SerializeField] private Color projectileColor;

    public Color ProjectileColor { get { return projectileColor; } }

    private ProjectileManager projectileManager;
    protected override void Start()
    {
        base.Start();
        projectileManager = ProjectileManager.Instance;
    }
    

    public override void Attack()
    {
        base.Attack();

        float projectileAngleSpace = multipleProjectileAngle;
        int numberOfPrejectilePerShot = numberofPrejectilePerShot;

        float minAngle = -(numberOfPrejectilePerShot / 2f) * projectileAngleSpace;

        for (int i = 0; i < numberOfPrejectilePerShot; i++)
        {
            float angle = minAngle + projectileAngleSpace * i;
            float randomSpread = Random.Range(-spread, spread);
            angle += randomSpread;
            CreateProjectile(Controller.LookDirection, angle);
        }
    }

     private void CreateProjectile(Vector2 lookDirection, float angle)
    {
        projectileManager.ShootBullet(
            this,
            projectileSpawnPoint.position,
            RotateVector2(lookDirection, angle)
        );
    }

    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }

}
