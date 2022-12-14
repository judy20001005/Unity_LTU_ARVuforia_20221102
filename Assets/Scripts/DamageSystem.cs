using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

namespace kid
{
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField, Header("��q"), Range(0, 5000)]
        private float hp;
        [SerializeField, Header("���")]
        private Image imgHP;

        private float maxHP;
        private Animator ani;
        private string parDamage = "����";
        private string parDead = "�}�����`";
        private NavMeshAgent nma;
        private TowerSystem towerSystem;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();

            //�z�L�����M�䪫��<�x��>(); - �������u���@�Ӧb�����W
            towerSystem = FindObjectOfType<TowerSystem>();
            maxHP = hp;

        }

        /// <summary>
        /// �y���ˮ`
        /// </summary>
        /// <param name="damage">�ˮ`��</param>
        public void GetDamage(float damage)
        {
            hp -= damage;
            imgHP.fillAmount = hp / maxHP;
            ani.SetTrigger(parDamage);

            if (hp <= 0) Dead();

        }

        /// <summary>
        /// ���`
        /// </summary>
        private void Dead()
        {
            ani.SetBool(parDamage, true);
            nma.isStopped = true;
            towerSystem.targetInAttackArea = null; // ��t�Υؼ� ���ŭ�
        }
    }

}
