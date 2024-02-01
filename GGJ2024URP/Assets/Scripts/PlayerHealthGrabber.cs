using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerHealthGrabber : MonoBehaviour
{
    [SerializeField] HealthSystem healthSystem;

    //private ConfigurableJoint joint;

    //[SerializeField] bool isPlayer;
    //[SerializeField] Transform hipsTransfrom;

    private void Start()
    {
        //joint = GetComponent<ConfigurableJoint>();
       // if (isPlayer) hipsTransfrom = transform;
        
    }

    public void SendDamage(float damage)
    {
        healthSystem.DealDamage(damage);
        //if(healthSystem.health <= 0)
        //{
            
            //joint.angularXDrive.positionSpring = 20f;
            // joint.angularYZDrive.positionSpring = 20;

            //joint.xMotion = 0;
            //joint.yMotion = 0;
            //joint.zMotion = 0;
            //if (isPlayer == true)
            //{
            //    gameObject.AddComponent<ConstantForce>();
            //    Debug.Log("sjkhklsdflsdfjgldfkjhlfsdkjlèsdzhjlèkjgldkshjslkklfgjhglsikhjgfshklgfsdjhgslhkshjgkhlgsfd");
            //    //constantForce.force = new Vector3(0, 300, 0);
            //}
            //constantForce.relativeForce = new Vector3(0, 100, 0);
            //constantForce.torque = new Vector3(0, -100, 0);
        //}
    }
}
