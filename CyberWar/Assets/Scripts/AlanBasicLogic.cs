using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanBasicLogic : MonoBehaviour
{
    public bool isBattery;
    private GameObject batteryStation, healthStation;
    public float speed;
    public GameObject target;
    private void Awake()
    {
        if (Random.Range(0, 2) == 1)
            isBattery = true;
        batteryStation = GameObject.Find("BatteryStation");
        healthStation = GameObject.Find("HealthStation");
    }
    void Start()
    {
        if (isBattery)
            target = batteryStation;
        else
            target = healthStation;
    }

    void Update()
    {
 
        if (target!= null)
        {
            GoLive(target);
        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BatteryStation"))
        {
            target = healthStation;
        }
        if (collision.CompareTag("HealthStation"))
        {
            target = batteryStation;
        }
    }
    void GoLive(GameObject target_)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target_.transform.position, step);
    }
}
