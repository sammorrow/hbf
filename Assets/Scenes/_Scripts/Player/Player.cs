using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Singleton<Player>
{
    public const float MAX_HEALTH = 100;
    public float health;
    public int[] ammo = new int[3]; // player has 3 types of ammo
    public int[] maxAmmo = new int[3];
    public int ammoType; // 0, 1, or 2
    public int killCount;

    public bool IsDead;

    // Movement
    public float Speed = 18f;

    [SerializeField] private CharacterController _selfController;
    [SerializeField] private CharacterController _characterController;

    // Shoot
    public float FIRE_RATE;

    public Transform creatureSpawnTransform;
    public GameObject creaturePrefab, worldObject;

    // Switch ammo
    public GameObject selectedAmmoHighlight1;
    public GameObject selectedAmmoHighlight2;
    public GameObject selectedAmmoHighlight3;

    [SerializeField] private GameObject prefabShot1;
    [SerializeField] private GameObject prefabShot2;
    [SerializeField] private GameObject prefabShot3;

    // Recharge ammo
    public GameObject rechargeZone;
    public UIAmmo uiAmmo;
    public float RECHARGE_RATE = .25f;
    public float rechargeTimer;

    public AudioSource bodyDamageSound;
    public AudioSource reloadSound;
    public AudioSource switchAmmoSound;

    public void Initialize()
    {
        health = MAX_HEALTH;
        ammo[0] = 10;
        ammo[1] = 10;
        ammo[2] = 8;
        maxAmmo[0] = 10; // use these in ammo refill
        maxAmmo[1] = 10;
        maxAmmo[2] = 8;
        ammoType = 0;
        creaturePrefab = prefabShot1;
        killCount = 0;
        uiAmmo.UpdateUIAmmo();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == rechargeZone)
            rechargeTimer = 1;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == rechargeZone)
        {
            rechargeTimer -= RECHARGE_RATE * Time.deltaTime;
            if (rechargeTimer <= 0)
            {
                rechargeTimer = 1;
                bool reloaded = false;
                for (int i = 0; i < 3; i++)
                {
                    if (ammo[i] < maxAmmo[i])
                    {
                        ammo[i]++;
                        reloaded = true;
                    }
                }

                if (reloaded)
                    reloadSound.Play();

                uiAmmo.UpdateUIAmmo();
            }
        }
    }

    void Start()
    {
        health = MAX_HEALTH;
        ammoType = 0;
    }

    // no fixedupdate, uses time.deltatime
    private void Update()
    {
        if (Time.timeScale <= 0)
            return;

        Move();
        SwitchAmmo();
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    void Shoot()
    {
        if (ammo[ammoType] <= 0)
        {
            // TODO: make error sound effect (red highlight ammo icon)
            Debug.Log("no ammo!");
            return;
        }
        ammo[ammoType]--;
        uiAmmo.UpdateUIAmmo();
        Instantiate(creaturePrefab, creatureSpawnTransform.position, new Quaternion(0, 180, 180, 0), worldObject.transform);
    }

    private void SwitchAmmo()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            switchAmmoSound.Play();
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
                    Debug.Log("switching Ammo bug!");
                    break;
            }
        }
    }

    public void DamagePlayer(float damageValue)
    {
        health -= damageValue;
        bodyDamageSound.Play();
        if (health <= 0)
            GameManager.Instance.EndGame();
    }

    private void Move()
    {
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        _selfController.Move(movementVector * Speed * Time.deltaTime);
        _characterController.Move(movementVector * Speed * Time.deltaTime);

    }
}
