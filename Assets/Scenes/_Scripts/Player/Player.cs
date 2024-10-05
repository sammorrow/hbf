using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Singleton<Player>
{
    public float maxHealth = 100;
    public float health;
    public float[] ammo = new float[3]; // player has 3 types of ammo
    public float ammoType; // 0, 1, or 2

    public bool IsDead;


    // Movement
    public float Speed = 7f;

    private float _horizontalInput;
    private float _verticalInput;


    [SerializeField] private CharacterController _characterController;

    // Shoot
    public float FIRE_RATE;

    public Transform creatureSpawnTransform;
    public GameObject creaturePrefab, worldObject;

    [SerializeField] private GameObject prefabShot1;
    [SerializeField] private GameObject prefabShot2;
    [SerializeField] private GameObject prefabShot3;

    void Start()
    {
        health = maxHealth;
        ammoType = 0;
    }

    void FixedUpdate()
    {

        SwitchAmmo();
        Move();

    }

    // no fixedupdate, uses time.deltatime
    private void Update()
    {
        if (GameManager.Instance.GunCooldown > 0)
        {
            GameManager.Instance.GunCooldown -= Time.deltaTime / FIRE_RATE;
        }

        if (Input.GetMouseButtonDown(0) && GameManager.Instance.GunCooldown <= 0)
        {
            GameManager.Instance.GunCooldown = GameManager.GUN_COOLDOWN;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(creaturePrefab, creatureSpawnTransform.position, new Quaternion(0, 180, 180, 0), worldObject.transform);
    }

    private void SwitchAmmo()
    {
        if (Input.GetButton("X"))
        {
            ammoType = (ammoType + 1) % 3;
        }
    }

    public void DamagePlayer(float damageValue)
    {
        health -= damageValue;
    }

    private void Move()
    {
        _horizontalInput = _horizontalInput < 0 ? -1 : Mathf.Ceil(_horizontalInput);
        _verticalInput = _verticalInput < 0 ? -1 : Mathf.Ceil(_verticalInput);

        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));



        _characterController.Move(movementVector * Speed * Time.deltaTime);

    }
}
