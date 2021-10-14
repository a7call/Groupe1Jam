using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shield : MonoBehaviour
{
    [SerializeField] private List< GameObject>  enemy = new List<GameObject> ();
    [SerializeField] private GameObject Explode;
    public GameObject ShieldText;
    private AudioSource m_audioSource;
    public AudioClip m_audioClip;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        foreach (var EN in enemy.ToArray())
        {
            if (!EN.activeSelf)
            {
                enemy.Remove(EN);
            }
        }
        if (enemy.Count <= 0)
            {
            if(ShieldText!= null)
                ShieldText.SetActive(true);
            Destroy(gameObject);
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_audioSource.time = 0.1f;
        m_audioSource.Play();
    }

    private void OnDestroy()
    {
        if (Explode != null)
        {
            Instantiate(Explode, transform.position, Quaternion.identity);
        }
    }
}
