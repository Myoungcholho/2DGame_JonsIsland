using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 누르는 스위치 기능입니다.
/// 
/// #object used(부착 오브젝트)#
/// Sprite Render,
/// BoxCollider2D가 포함된
/// 스위치로 사용할 게임오브젝트
/// 
/// #Method#
/// -OnTrigerEnter()
/// 스위치가 눌렸을 때의 로직이 구현되어 있습니다.
/// 
/// -OnTriggerExit()
/// 스위치를 땠을 때의 로직이 구현되어 있습니다.
/// 
/// 
/// </summary>
public class PushSwitchTile : MonoBehaviour
{
    public Sprite beforeSprite;
    public Sprite afterSprite;

    public delegate void OnSwitchActive();
    public OnSwitchActive onSwitchActive;
    public delegate void OffSwitchActive();
    public OffSwitchActive offSwitchActive;

    private char semaphore;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        semaphore = '\0';
    }

    /*
     박스나 플레이어가 해당 발판에 올라온 경우
    작동 상태로 변경하고
     눌린 스위치 이미지로 변경합니다.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            if (semaphore == 0)
                AfterRender();
        ++semaphore;
        }
    }
    /*
     박스나 플레이어가 해당 발판에서 떨어진 경우
    비작동 상태로 변경하고
    눌리지 않은 스위치 이미지로 변경합니다.
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            --semaphore;
            if (semaphore == 0)
                BeforeRender();
        }
    }


    private void BeforeRender()
    {
        spriteRenderer.sprite = beforeSprite;
        offSwitchActive.Invoke();
    }

    private void AfterRender()
    {
        spriteRenderer.sprite = afterSprite;
        onSwitchActive.Invoke();
    }

}
