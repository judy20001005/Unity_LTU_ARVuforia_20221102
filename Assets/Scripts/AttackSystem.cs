using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kid
{
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField, Header("�n����������W��")]
        private string nameTarget;
        [SerializeField, Header("�����O"), Range(0, 5000)]
        private float attack;

        private void OnCollisionEnter(Collision collision)
        {
            //�p�G �I�쪫��W�� �]�t �n����������W��
            if (collision.gameObject.name.Contains(nameTarget))
            {
                //�I�쪫����o�ˮ`�t�� �éI�s �y���ˮ`
                collision.gameObject.GetComponent<DamageSystem>().GetDamage(attack);
            }
        }
    }

}


