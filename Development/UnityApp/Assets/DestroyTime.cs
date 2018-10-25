using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour {

    [SerializeField] private float DestroyTimer = 3f;

    private void Awake()
    {
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(DestroyTimer);
        Destroy(this.gameObject);
    }

}
