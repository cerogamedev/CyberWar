using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanBasicLogic : MonoBehaviour
{
    public bool isBattery;
    private GameObject[] batteryStation, healthStation;
    public float speed;
    public GameObject target;

    public int Health = 3;

    private void Awake()
    {
        if (Random.Range(0, 2) == 1)
            isBattery = true;
        batteryStation = GameObject.FindGameObjectsWithTag("BatteryStation");
        healthStation = GameObject.FindGameObjectsWithTag("HealthStation");
    }
    void Start()
    {
        int random = Random.Range(0, batteryStation.Length);
        int random_ = Random.Range(0, healthStation.Length);

        if (isBattery)
            target = batteryStation[random];
        else
            target = healthStation[random_];
    }

    void Update()
    {
 
        if (target!= null)
        {
            GoLive(target);
        }
        Death();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BatteryStation"))
        {
            int random = Random.Range(0, batteryStation.Length);

            target = healthStation[random];
        }
        if (collision.CompareTag("HealthStation"))
        {
            int random_ = Random.Range(0, batteryStation.Length);

            target = batteryStation[random_];
        }
        if (collision.CompareTag("Bullet"))
        {
            Health -= 1;
        }
    }
    void GoLive(GameObject target_)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target_.transform.position, step);
    }

    void Death()
    {
        if (Health <= 0)
            Destroy(this.gameObject);
    }
}
