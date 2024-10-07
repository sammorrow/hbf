using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Singleton<Player>
{
    public const float MAX_HEALTH = 100;
    public float health;
    public float[] ammo = new float[3]; // player has 3 types of ammo
    public float ammoType; // 0, 1, or 2
    public int killCount;

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

    // it's gross but it works
    public GameObject selectedAmmoHighlight1;
    public GameObject selectedAmmoHighlight2;
    public GameObject selectedAmmoHighlight3;

    [SerializeField] private GameObject prefabShot1;
    [SerializeField] private GameObject prefabShot2;
    [SerializeField] private GameObject prefabShot3;

    public void Initialize()
    {
        health = MAX_HEALTH;
        ammo[0] = 0; // TODO: change starting ammo counts if necessary
        ammo[1] = 0;
        ammo[2] = 0;
        ammoType = 0;
        creaturePrefab = prefabShot1;
        killCount = 0;
        // TODO: change position to be center of body?
    }

    void Start()
    {
        health = MAX_HEALTH;
        ammoType = 0;
    }

    // no fixedupdate, uses time.deltatime
    private void Update()
    {
        Move();
        SwitchAmmo();
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            ammoType = (ammoType + 1) % 3;
            selectedAmmoHighlight1.SetActive(false);
            selectedAmmoHighlight2.SetActive(false);
            selectedAmmoHighlight3.SetActive(false);

            switch (ammoType)
            {
                case 0: 
                    creaturePrefab = prefabShot1;
                    selectedAmmoHighlight1.SetActive(true);
                    break;
                case 1:
                    creaturePrefab = prefabShot2;
                    selectedAmmoHighlight2.SetActive(true);
                    break;
                case 2:
                    creaturePrefab = prefabShot3;
                    selectedAmmoHighlight3.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

    public void DamagePlayer(float damageValue)
    {
        health -= damageValue;
        if (health <= 0)
            GameManager.Instance.EndGame();
    }

    private void Move()
    {
        _horizontalInput = _horizontalInput < 0 ? -1 : Mathf.Ceil(_horizontalInput);
        _verticalInput = _verticalInput < 0 ? -1 : Mathf.Ceil(_verticalInput);

        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));



        _characterController.Move(movementVector * Speed * Time.deltaTime);

    }
}
