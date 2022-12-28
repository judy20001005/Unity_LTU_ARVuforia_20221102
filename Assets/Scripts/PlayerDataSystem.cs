using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace kid
{
	public class PlayerDataSystem : MonoBehaviour
	{

		public static float attack = 50;

		private float attackUpdateValue = 50;
		private int coin = 0;
		private int updateCoast = 100;
		private TextMeshProUGUI textAttack;
		private TextMeshProUGUI textCoin;
		private Button btnUpdateAttack;

		private float hp = 1000;
		private float hpMax;
		private Image imgHp;
		private Animator ani;
		private string parDead = "開關死亡";
		private TowerSystem towerSystem;


		private void Awake()
		{
			ani = GetComponent<Animator>();

			hpMax = hp;
			imgHp = GameObject.Find("血條").GetComponent<Image>();
			textAttack = GameObject.Find("文字攻擊力").GetComponent<TextMeshProUGUI>();
			textCoin = GameObject.Find("文字金幣").GetComponent<TextMeshProUGUI>();
			btnUpdateAttack = GameObject.Find("按鈕升級").GetComponent<Button>();
			btnUpdateAttack.onClick.AddListener(UpdateAttack);

			towerSystem = FindObjectOfType<TowerSystem>();

		}


		///升級攻擊力

		private void UpdateAttack()
		{
			if (coin >= updateCoast)
			{
				coin -= updateCoast;
				attack += attackUpdateValue;

				textCoin.text = "金幣:" + coin;
				textAttack.text = "攻擊力:" + attack;
			}
		}

		/// <summary>
		/// 更新金幣
		/// </summary>
		/// <param name="coinAdd"></param>
		public void UpdateCoin(int coinAdd)
		{
			coin += coinAdd;
			textCoin.text = "金幣:" + coin;
		}

		/// <summary>
		/// 造成傷害
		/// </summary>
		/// <param name="damage"></param>
		public void GetDamage(float damage)
		{
			hp -= damage;
			imgHp.fillAmount = hp / hpMax;
		}

		private void Dead()
		{
			ani.SetBool(parDead, true);
			towerSystem.enabled = false;
		}
	}
}