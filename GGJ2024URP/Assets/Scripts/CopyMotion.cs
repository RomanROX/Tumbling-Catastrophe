using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    /*
     Uzimam transform kostiju od animiranog lika i postavljam ga na ragdollanog playera.
        I uzimam poèetnu LOKALNU rotaciju kostiju kako bi se rotirali po dobroj osi.
     */

    [Header("Parameters")]
    [SerializeField] private Transform targetLimb;
    [SerializeField] private bool mirror;

    
    private Quaternion startRot;
    private ConfigurableJoint configJoint;

    void Start()    {
        configJoint = GetComponent<ConfigurableJoint>();
        startRot = transform.localRotation;
    }

    void Update()    {        
        if (!mirror) configJoint.targetRotation = targetLimb.localRotation * startRot;
        else configJoint.targetRotation = Quaternion.Inverse(targetLimb.localRotation) * startRot;
    }
}
