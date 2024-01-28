using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEnemy : MonoBehaviour
{
    void Start()
    {
        float randomScale = Random.Range(1f, 1.6f);

        transform.localScale = Vector3.one * randomScale;
    }
}
