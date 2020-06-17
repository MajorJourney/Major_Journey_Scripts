using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{

    private float shakeTimeRemaining, shakePower, shakeFadeTime;

    public GameObject palanca;
    public GameObject palanca2;

    private Palanca2Script palancaScript;
    private Palanca1Script palancaScript2;

    // Start is called before the first frame update
    void Start()
    {

        palancaScript = palanca.gameObject.GetComponent<Palanca2Script>();
        palancaScript2 = palanca2.gameObject.GetComponent<Palanca1Script>();

    }

    // Update is called once per frame
    void Update()
    {
        if (palancaScript.isOpen || palancaScript2.secondDoor)
        {
            StartShake(.5f, 1f);
        }
    }

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

        }
    }

    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

        shakeFadeTime = power / length;
    }

}
