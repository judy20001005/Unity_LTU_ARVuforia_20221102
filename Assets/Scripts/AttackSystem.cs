using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kid
{
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField, Header("要攻擊的物件名稱")]
        private string nameTarget;
        [SerializeField, Header("攻擊力"), Range(0, 5000)]
        private float attack;

        private void OnCollisionEnter(Collision collision)
        {
            //如果 碰到物件名稱 包含 要攻擊的物件名稱
            if (collision.gameObject.name.Contains(nameTarget))
            {
                //碰到物件取得傷害系統 並呼叫 造成傷害
                collision.gameObject.GetComponent<DamageSystem>().GetDamage(attack);
            }
        }
    }

}


