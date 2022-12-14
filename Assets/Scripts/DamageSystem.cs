using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

namespace kid
{
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField, Header("血量"), Range(0, 5000)]
        private float hp;
        [SerializeField, Header("血條")]
        private Image imgHP;

        private float maxHP;
        private Animator ani;
        private string parDamage = "受傷";
        private string parDead = "開關死亡";
        private NavMeshAgent nma;
        private TowerSystem towerSystem;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();

            //透過類型尋找物件<泛型>(); - 該類型只有一個在場景上
            towerSystem = FindObjectOfType<TowerSystem>();
            maxHP = hp;

        }

        /// <summary>
        /// 造成傷害
        /// </summary>
        /// <param name="damage">傷害值</param>
        public void GetDamage(float damage)
        {
            hp -= damage;
            imgHP.fillAmount = hp / maxHP;
            ani.SetTrigger(parDamage);

            if (hp <= 0) Dead();

        }

        /// <summary>
        /// 死亡
        /// </summary>
        private void Dead()
        {
            ani.SetBool(parDamage, true);
            nma.isStopped = true;
            towerSystem.targetInAttackArea = null; // 塔系統目標 為空值
        }
    }

}
