using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kid
{
	public class EnemySystem : MonoBehaviour
	{
		[SerializeField, Header("§ðÀ»¤O"), Range(0, 1000)]
		private float attack = 50;
		[SerializeField, Header("§ðÀ»¶ZÂ÷"), Range(0, 10)]
		private float attackDistance = 3.5f;
		[SerializeField, Header("§ðÀ»§N«o®É¶¡"), Range(0, 5)]
		private float attackInterval = 3;

		private string nameTarget = "DogPolyart";
		private Transform pointTarget;
		private PlayerDataSystem playDataSystem;
		private Animator ani;
		private string parAttack = "Ä²µo§ðÀ»";
		private float attackTimer;

		private void Awake()
		{
			attackTimer = attackInterval;
			ani = GetComponent<Animator>();
			pointTarget = GameObject.Find(nameTarget).transform;
			playDataSystem = pointTarget.GetComponent<PlayerDataSystem>();
		}

		private void Update()
		{
			Attack();
		}

		private void Attack()
		{
			float dis = Vector3.Distance(transform.position, pointTarget.position);

			if (dis <= attackDistance)
			{
				if (attackTimer >= attackInterval)
				{
					ani.SetTrigger(parAttack);
					attackTimer = 0;
					playDataSystem.GetDamage(attack);
				}
				else
				{
					attackTimer += Time.deltaTime;
				}
			}
		}
	}
}