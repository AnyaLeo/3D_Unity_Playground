using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyManager : Singleton<FireflyManager>
{
    public GameObject[] fireflies;
    int totalFireflies;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        totalFireflies = fireflies.Length;
        for (int i = 0; i < totalFireflies; i++)
        {
            if (i == 0)
            {
                fireflies[i].SetActive(true);
            } 
            else
            {
                fireflies[i].SetActive(false);
            }
        }
    }

    public IEnumerator StartNextFirefly()
    {
        yield return new WaitForSeconds(5);

        fireflies[count % totalFireflies].SetActive(false);
        count += 1;
        fireflies[count % totalFireflies].SetActive(true);
        // modulo operator
    }
}
