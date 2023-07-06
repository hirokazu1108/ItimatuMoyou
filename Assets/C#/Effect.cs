using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Effect : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
 
    void OnMouseDown()
    {
        Instantiate (explosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}