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
        [SerializeField, Header("�e�����")]
        private GameObject goCanvasHp;

        private float maxHP;
        private Animator ani;
        private string parDamage = "����";
        private string parDead = "�}�����`";
        private NavMeshAgent nma;
        private TowerSystem towerSystem;
        private CapsuleCollider col;
        private PlayerDataSystem playerDataSystem;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();
            col = GetComponent<CapsuleCollider>();

            //�z�L�����M�䪫��<�x��>(); - �������u���@�Ӧb�����W
            towerSystem = FindObjectOfType<TowerSystem>();
            playerDataSystem = FindObjectOfType<PlayerDataSystem>();
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
            gameObject.layer += 0;
            towerSystem.targetInAttackArea = null; // ��t�Υؼ� ���ŭ�
            col.enabled = false;
            goCanvasHp.SetActive(false);
            Destroy(gameObject, 1.5f);
            playerDataSystem.UpdateCoin(30);
        }
    }

}
