using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 구조체 , 리스트 설계방법이 더 좋을 것 같기는 하다 */

public class StatusManager : MonoBehaviour
{
    #region Singleton
    public static StatusManager instance;

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

    //테스트 모드 ON/OFF , ON인경우에는 피로도 배고픔 감소 없음.
    [Header("테스트 모드 [감소효과 없음]")]
    public bool testMode = false;

    public Dictionary<string, int> FatigueDict;
    public Dictionary<string, int> HungerDict;

    [Header("피로도 최대 수치 조절")]
    public float[] FatigueMaxData = new float[] { 15, 15, 15, 15 };
    [Header("피로도 현재 수치 조절")]
    public float[] FatigueData = new float[] { 15, 15, 15, 15 };

    private int FatigueIndex = 0;

    [Header("배고픔 최대 수치 조절")]
    public float[] HungerMaxData = new float[] { 2 };
    [Header("배고픔 현재 수치 조절")]
    public float[] HungerData = new float[] { 2 };


    private int HungerIndex = 0;

    void Start()
    {
        FatigueDict = new Dictionary<string, int>();
        FatigueDict.Add("CameraPos1", 0); // 1-1
        FatigueDict.Add("CameraPos2", 1); // 1-2
        FatigueDict.Add("CameraPos3", 2); // 1-3
        FatigueDict.Add("CameraPos4", 3); // 1-4

        HungerDict = new Dictionary<string, int>();
        HungerDict.Add("CameraPos1", 0); // 1
        HungerDict.Add("CameraPos2", 0); // 1
        HungerDict.Add("CameraPos3", 0); // 1
        HungerDict.Add("CameraPos4", 0); // 1


        // 현재 맵에 따른 피로도 인덱스 가져오기
        if(FatigueDict.ContainsKey(GameManager.instance.currentMapName))
            FatigueIndex = FatigueDict[GameManager.instance.currentMapName];

        // 현재 맵에 따른 배고픔 인덱스 가져오기
        if(HungerDict.ContainsKey(GameManager.instance.currentMapName))
            HungerIndex = HungerDict[GameManager.instance.currentMapName];


        // 현재 맵 정보에 따라서 배고픔 피로도 첫 초기화 
<<<<<<< Updated upstream
        if (!PlayerStatus.instance.InitStatus(HungerMaxData[HungerIndex],
            FatigueMaxData[FatigueIndex], HungerData[HungerIndex], FatigueData[FatigueIndex]))
        {
            Debug.Log("초기화 실패");
        }
=======
        // MAX값과 현재 값을 그대로 가져가고 있다. -> 수정
        if(!PlayerStatus.instance.InitStatus(HungerMaxData[HungerIndex],
            FatigueMaxData[FatigueIndex], HungerData[HungerIndex], FatigueData[FatigueIndex]))
                Debug.Log("초기화 실패");
>>>>>>> Stashed changes

    }

    //맵 바뀔 때 마다 피로도 셋팅
    public void FatigueSetting()
    {
        // 테스트 모드라면 감소 없음
        if (testMode)
            return;

        if (!FatigueDict.ContainsKey(GameManager.instance.currentMapName))
        {
            Debug.Log("Fatigue Key 없음.");
            return;
        }

        FatigueIndex = FatigueDict[GameManager.instance.currentMapName];
        PlayerStatus.instance.InitFatigueMax(FatigueMaxData[FatigueIndex]);
        PlayerStatus.instance.InitFatigue(FatigueData[FatigueIndex]);
    }
    
    public void Substitution()
    {
        //FatigueData = FatigueMaxData; // 이러면 주소값 참조된다.
        //HungerData = HungerMaxData; 

        // 테스트 모드라면 감소 없음
        if (testMode)
            return;

        for (int i=0; i<HungerMaxData.Length; ++i)
        {
            HungerData[i] = HungerMaxData[i];
        }

        for(int i=0; i<FatigueMaxData.Length; ++i)
        {
            FatigueData[i] = FatigueMaxData[i];
        }
    }

    public void FDChange(float value)
    {
        // 테스트 모드라면 감소 없음
        if (testMode)
            return;

        FatigueData[FatigueIndex] -= value;
    }

}
