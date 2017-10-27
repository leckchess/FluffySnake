using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour {


    public GameObject food;
    public float XBounds, ZBounds;
    public static FoodGenerator instance;

    public GameObject obstical;
    public int obsticalInterval;
    int _obsticalcounter = 1; 

    private void Awake()
    {
        instance = this;
    }

    void Update () {

	}

    public void GenerateFood()
    {
        float xpos = Random.Range(-XBounds, XBounds);
        float zpos = Random.Range(-ZBounds, ZBounds);
        GameObject.Instantiate(food,new Vector3(xpos,transform.position.y,zpos),Quaternion.identity);
        _obsticalcounter++;
        if (_obsticalcounter % obsticalInterval == 0)
        {
            xpos = Random.Range(-XBounds, XBounds);
            zpos = Random.Range(-ZBounds, ZBounds);
            GameObject.Instantiate(obstical, new Vector3(xpos, transform.position.y, zpos), Quaternion.Euler(new Vector3(0,Random.Range(0,360),0)));
        }
    }
}
