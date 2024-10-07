using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
	public bool justSplit = false;
	[SerializeField] private float health;
	private float splitHealthThreshold = 100; // amount of health enemy needs to be able to split and reproduce
	private float damageHealthThreshold = 25; // min amount of health enemy needs to be able to start attacking body
	private float deadTime = 30; // how long the enemy will remain dead/removable for
	private float deadTimer;
	public float ATTACK_RATE = 0.5f;
	public float DAMAGE_VALUE = 1;
	public float REGENERATION = .5f;
	private float attackCooldown;

	public float ATTACK_COOLDOWN = 5f;

	[SerializeField] private Animator _animator;

	[SerializeField] private SpriteRenderer _spriteRenderer;
	public Sprite babySprite;
	public Sprite adultSprite;
    public Sprite deadSprite;


    [SerializeField] GameObject selfPrefab; // used when enemy splits/duplicates

    private void OnTriggerStay(Collider other)
    {
        
    }

    public float GetHealth()
	{
		return health;
	}

	public void DamageVirus(float damageValue)
	{
		health -= damageValue;
		if (health <= 0)
			_spriteRenderer.sprite = deadSprite;
			deadTimer = 0;
	}

	void SetHealth(float newHealthValue)
	{
		health = newHealthValue;
	}

	void Split()
	{
		GameObject newEnemy = Instantiate(selfPrefab, transform.position, Quaternion.Euler(90, 0, 0)); // split the enemy (create new copy) and set its health = damageHealthThreshold
		newEnemy.GetComponent<EnemyBehavior>().justSplit = true;
		SetHealth(damageHealthThreshold);
	}

	// Start is called before the first frame update
	void Start()
	{
		health = 1;
		_animator.enabled = false;
		_spriteRenderer.sprite = babySprite;
	}

	// Update is called once per frame
	void Update()
	{
		if (justSplit)
		{
			health = damageHealthThreshold;
			justSplit = false;
		}

		if (health > 0)
		{
			// if not dead (health > 0), increase health every few game ticks, then change size
			health += REGENERATION * Time.deltaTime;
			float enemySize = (2 * health / splitHealthThreshold) + .5f;
			transform.localScale = new Vector3(enemySize, enemySize, 1);
		}
        if (health > damageHealthThreshold)
		{
			if (_spriteRenderer.sprite != adultSprite)
			{
				_animator.enabled = true;
				_spriteRenderer.sprite = adultSprite;
			}
			// if (health > damageHealthThreshold), deal damage to body (player) every damage interval
			if (attackCooldown <= 0)
			{
				_animator.SetTrigger("Biting");
				Zone affectedZone = ZoneManager.Instance.GetZoneByPos(gameObject.transform.position);
				Player.Instance.DamagePlayer(DAMAGE_VALUE * affectedZone.damageMultiplier);
				attackCooldown = ATTACK_COOLDOWN;
			}

			attackCooldown -= Time.deltaTime * ATTACK_RATE;
		}
		if (health <= 0)
		{
			if (deadTime > deadTimer)
				deadTimer += Time.deltaTime; // if dead AND deadTime > deadTimer, increment deadTimer
			else
				health = 1; // if dead AND deadTime <= deadTimer, set health to 1 (resurrect)
				_spriteRenderer.sprite = babySprite;
        }

        if (health >= splitHealthThreshold)
			Split();
	}
}
