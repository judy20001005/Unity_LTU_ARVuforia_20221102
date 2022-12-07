using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSystem : MonoBehaviour
{
    [SerializeField, Header("�n���Y����")]
    private GameObject prefabFireObject;
    [SerializeField, Header("���Y���󪺤O�D")]
    private Vector3 powerFire = new Vector3(0, 50, 500);
    [SerializeField, Header("�ͦ����Y�����m")]
    private Transform pointToSpawn;
    [SerializeField, Header("���Y���󶡹j"), Range(0, 5)]
    private float intervalFire = 3;

    [SerializeField, Header("�����d��ؤo"), Range(0, 10)]
    private float radiusAttack = 5.5f;

    //ø�s�ϥܨƥ� : ����ø�s�ϥܡA�Ȧb unity ����ܡA�C���ݤ���
    private void OnDrawGizmos()
    {
        //�M�w�C��
        Gizmos.color = new Color(0.8f, 0, 0.4f, 0.5f);
        //ø�s�ϥܧΪ�
        Gizmos.DrawSphere(transform.position, radiusAttack);
    }

    private void CheckAttackArea()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radiusAttack);
        print($"<color=#44ff00>�i�J�����d�򪺲Ĥ@�Ӫ��� : {hits[0]}</color>");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        CheckAttackArea();
    }


}
