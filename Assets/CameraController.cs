using UnityEngine;

//namespace CoreProjectGame.CameraController
//{
//}

public class CameraController : Singleton<CameraController>
{
    #region Variables

    // Shake
    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;
    private bool isShakingG = false;
    [SerializeField] private float rotationMultiplier;
    private Vector3 direction;

    private Vector3 pos;

    // Follow

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        pos = this.gameObject.transform.position;
    }
    void Update()
    {
        // Shake 
        if (shakeTimeRemaining > 0 && isShakingG) GlobalShake();
    }

    #endregion

    #region Shake

    public void StartShakeG(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

        shakeFadeTime = power / length;

        shakeRotation = power * rotationMultiplier;

        isShakingG = true;
    }


    private void GlobalShake()
    {
        shakeTimeRemaining -= Time.deltaTime;

        float x = Random.Range(-1f, 1f) * shakePower;
        float y = Random.Range(-1f, 1f) * shakePower;

        transform.position = transform.position + new Vector3(x, y);
        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));

        shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

        shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);

        if (shakeTimeRemaining <= 0)
        {
            transform.rotation = Quaternion.identity;
            isShakingG = false;
            gameObject.transform.position = pos;
        }
    }

  
    #endregion
}