using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    [SerializeField] GameObject particlePrefab;

    public void Emit()
    {
        Instantiate(particlePrefab, transform);
    }
}
