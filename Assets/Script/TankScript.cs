using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    [SerializeField] Transform attackPos;

    [SerializeField] Transform turret;

    [SerializeField] Transform tankBarrel;


    float rSpeed = 10;

    bool attacked = false;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void FixedUpdate()
    {

        Vector3 targetDir = attackPos.position - tankBarrel.position;

        float aPAgle = Vector3.Angle(targetDir, transform.forward);

        agent.SetDestination(attackPos.position);

        if (aPAgle > 10)
        {
            agent.speed = 1;
        }
        else
        {
            agent.speed = 5;
        }
        float cAgle = Vector3.Angle(turret.position, transform.forward);

        if(cAgle != 0)
        {
            RotateBarriel();
        }

    }


    private void RotateBarriel()//xoay nòng súng của xe tăng về hướng turret
    {
        Vector3 targetDir = turret.position - tankBarrel.position;

        float rotateSpeed = rSpeed * Time.deltaTime;

        Vector3 RotateDir = Vector3.RotateTowards(tankBarrel.forward, targetDir, rotateSpeed, 0f);

        tankBarrel.rotation = Quaternion.LookRotation(RotateDir);
    }
}
