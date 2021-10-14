using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject Player1, Player2;
    private bool Play1, Play2;
    [SerializeField] private bool niv4;

    [SerializeField] private List<GameObject> enemy = new List<GameObject>();

    [SerializeField] private GameObject etincelle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1)
        {
            Play1 = true;
            print("Play1 on");
        }

        if (other.gameObject == Player2)
        {
            Play2 = true;
            print("Play2 on");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player1)
        {
            Play1 = false;
            print("Play1 off");
        }

        if (other.gameObject == Player2)
        {
            Play2 = false;
            print("Play2 off");
        }
    }

    private void Update()
    {
        if (Play1 && Play2 && !niv4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Play1 && Play2 && niv4)
        {
            StartCoroutine("Fin");
        }
    }

    private IEnumerator Fin ()
    {
        CameraController.GetInstance().StartShakeG(1, 0.3f);
        foreach (var EN in enemy.ToArray())
        {
            Instantiate(etincelle, EN.transform.position, Quaternion.identity);
            Rigidbody rb = EN.AddComponent(typeof(Rigidbody)) as Rigidbody;
            if(rb   != null)
                rb.AddForce(Vector3.up* 30, ForceMode.Impulse);            
        }
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }
}
