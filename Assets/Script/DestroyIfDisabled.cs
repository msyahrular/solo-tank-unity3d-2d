using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfDisabled : MonoBehaviour
{
    public bool SelfDestructionEnabled { get; set;} = false;

    private void OnDisabled()
    {
        if (SelfDestructionEnabled)
        {
            Destroy(gameObject);
        }
    }
}
