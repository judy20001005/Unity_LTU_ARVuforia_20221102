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
		private string parDead = "�}�����`";
		private TowerSystem towerSystem;


		private void Awake()
		{
			ani = GetComponent<Animator>();

			hpMax = hp;
			imgHp = GameObject.Find("���").GetComponent<Image>();
			textAttack = GameObject.Find("��r�����O").GetComponent<TextMeshProUGUI>();
			textCoin = GameObject.Find("��r����").GetComponent<TextMeshProUGUI>();
			btnUpdateAttack = GameObject.Find("���s�ɯ�").GetComponent<Button>();
			btnUpdateAttack.onClick.AddListener(UpdateAttack);

			towerSystem = FindObjectOfType<TowerSystem>();

		}


		///�ɯŧ����O

		private void UpdateAttack()
		{
			if (coin >= updateCoast)
			{
				coin -= updateCoast;
				attack += attackUpdateValue;

				textCoin.text = "����:" + coin;
				textAttack.text = "�����O:" + attack;
			}
		}

		/// <summary>
		/// ��s����
		/// </summary>
		/// <param name="coinAdd"></param>
		public void UpdateCoin(int coinAdd)
		{
			coin += coinAdd;
			textCoin.text = "����:" + coin;
		}

		/// <summary>
		/// �y���ˮ`
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