using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyTag : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            return;
        }

        if (other.CompareTag("Pickup"))
        {
            return;
        }
    }
}
