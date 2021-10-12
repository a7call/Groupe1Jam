using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTogether : MonoBehaviour
{
    [SerializeField] private GameObject Other;
    [SerializeField] private int hp = 40;
    private bool TTD;
    public bool TimeToDie;

    private void Update()
    {
        TTD = Other.GetComponent<DieTogether>().TimeToDie;
        print(TTD + "  " + TimeToDie);
        if (TTD && TimeToDie)
        {
            Destroy(gameObject);
        }


        if (hp == 0)
        {
            StartCoroutine("timetodie");
        }
     }

    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag ("BulletPlayer"))
        {
            hp = 0;
        }
    }

    IEnumerator timetodie ()
    {
        TimeToDie = true;
        yield return new WaitForSeconds(3f);
        TimeToDie = false;
        hp = 40;
        yield return null;
    }
}
