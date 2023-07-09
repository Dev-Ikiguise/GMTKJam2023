using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SheepMass : MonoBehaviour
{
    public GameObject[] Sheeps;

    void Start()
    {
        UpdateSheepMass();
        InvokeRepeating("CheckForSheep", 0, 0.1f);
    }

    void Update()
    {

    }

    public void UpdateSheepMass()
    {
        Sheeps = GameObject.FindGameObjectsWithTag("Sheep");
    }

    public void AddSheepMass(GameObject sheep)
    {
        List<GameObject> SheepList = new List<GameObject>();

        for (int i = 0; i < Sheeps.Length; i++)
        {
            SheepList.Add(Sheeps[i]);
        }
        SheepList.Add(sheep);

        Sheeps = SheepList.ToArray();
    }

    public void RemoveSheepMass(GameObject sheep)
    {
        List<GameObject> SheepList = new List<GameObject>();

        for (int i = 0; i < Sheeps.Length; i++)
        {
            SheepList.Add(Sheeps[i]);
        }
        SheepList.Remove(sheep);

        Sheeps = SheepList.ToArray();
    }

    public void CheckForSheep()
    {
        for (int i = 0; i < Sheeps.Length; i++)
        {
            Transform m = Sheeps[i].transform;
            if (Vector2.Distance(transform.position, m.position) <= transform.localScale.x /2)
            {
                RemoveSheepMass(m.gameObject);
                PlayerEat();

                Destroy(m.gameObject);
            }
        }
    }

    public void PlayerEat()
    {
        transform.localScale += new Vector3(0.08f, 0.08f, 0.08f);
    }
}
