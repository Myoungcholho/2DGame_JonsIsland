using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //new version URP

public class PlayerLight2DController : MonoBehaviour
{
    #region Singleton
    public static PlayerLight2DController instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    private Light2D playerLight2D;
    private float currentLightValue;
    private int expansionSpeed;

    private void Start()
    {
        playerLight2D = GetComponent<Light2D>();
        currentLightValue = playerLight2D.pointLightOuterRadius;
        expansionSpeed = 5;
    }

    public void playerLight2DCoroutine(float eyeSightValue)
    {
        StartCoroutine(AddEyesight(eyeSightValue));
    }


    public void SetActive(bool mValue)
    {
        gameObject.SetActive(mValue);
    }


    // �þ� ����
    private IEnumerator AddEyesight(float eyeSightValue)
    {
        while(true)
        {
            yield return StartCoroutine(OnEyesight(eyeSightValue));
            yield return StartCoroutine(OffEyesight());

            break;
        }
    }

    private IEnumerator OnEyesight(float eyeSightValue)
    {
        while (currentLightValue >= eyeSightValue)
        {
            currentLightValue += Time.deltaTime;
            currentLightValue -= Time.deltaTime * expansionSpeed;
            playerLight2D.pointLightOuterRadius = currentLightValue;

            yield return null;
        }

        while (currentLightValue <= eyeSightValue)
        {
            currentLightValue += Time.deltaTime * expansionSpeed;
            playerLight2D.pointLightOuterRadius = currentLightValue;

            yield return null;
        }

        yield return null;
    }
    private IEnumerator OffEyesight()
    {
        yield return null;
    }
}
