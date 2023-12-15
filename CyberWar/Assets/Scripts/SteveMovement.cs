using System.Collections;
using UnityEngine;

public class SteveMovement : MonoBehaviour
{
    public float hareketHizi = 5f;
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    public float startingX, startingY;


    void Start()
    {
        StartCoroutine(RastgeleHareketEt());
        startingX = this.transform.position.x;
        startingY = this.transform.position.y;
    }

    IEnumerator RastgeleHareketEt()
    {
        while (true)
        {
            Vector2 hedefNokta = GetRastgeleNokta();
            while ((Vector2)transform.position != hedefNokta)
            {
                transform.position = Vector2.MoveTowards(transform.position, hedefNokta, hareketHizi * Time.deltaTime);
                yield return null;
            }
        }
    }

    Vector2 GetRastgeleNokta()
    {
        float x = Random.Range(startingX - minX, startingX + maxX);
        float y = Random.Range(startingY - minY, startingY + maxY);
        return new Vector2(x, y);
    }
}
