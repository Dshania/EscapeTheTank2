using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 movementVector;
    public float maxSpeed;
    public float rotationSpeed;
    public float turretRotationSpeed;

    public Transform turretParent;

    public float acceleration;
    public float deacceleration;
    public float currentSpeed;
    public float currentFrwdDir;

    public AimTurret aimTurret;
    public Turret[] turrets;
    public TankMover tankMover;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (aimTurret == null)
            aimTurret = GetComponentInChildren<AimTurret>();
        if (turrets == null || turrets.Length == 0)
        {
            turrets = GetComponentsInChildren<Turret>();
        }
        if (tankMover == null)
            tankMover = GetComponentInChildren<TankMover>();
    }
    public void HandleShoot()
    {
        foreach (var turret in turrets)
        {
            turret.Shoot();
        }
    }
    public void HandleMoveBody(Vector2 movementVector)
    {
        tankMover.Move(movementVector);
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        if (movementVector.y > 0)
            currentFrwdDir = 1;
        else if (movementVector.y < 0)
            currentFrwdDir = -1;
    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        var turretDirection =
              (Vector3)pointerPosition - turretParent.position;
        var desireAngle =
            Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
        var rotationStep =
            turretRotationSpeed * Time.deltaTime;
        turretParent.rotation =
            Quaternion.RotateTowards(turretParent.rotation, Quaternion.Euler(0, 0, desireAngle - 90), rotationStep);
    }
    private void FixedUpdate()
    {
        rb.velocity = (Vector2)transform.up * currentSpeed * currentFrwdDir * Time.fixedDeltaTime;
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
