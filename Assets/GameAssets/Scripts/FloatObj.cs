using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FloatObj : MonoBehaviour {

    public float FloatStrenght;
    public float RandomRotationStrenght;

    private void Start()
    {
        StartCoroutine(FloatToggle());
    }
    void Update()
    {
        print(FloatStrenght);
        transform.GetComponent<Rigidbody>().AddForce(Vector3.up * FloatStrenght);
        transform.Rotate(RandomRotationStrenght, RandomRotationStrenght, RandomRotationStrenght);
    }

    IEnumerator FloatToggle()
    {
        yield return new WaitForSeconds(0.5f);
        FloatStrenght = -FloatStrenght;
        StartCoroutine(FloatToggle());
    }
}
