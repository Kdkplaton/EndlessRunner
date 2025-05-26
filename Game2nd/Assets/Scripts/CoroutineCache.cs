using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCache
{
    static Dictionary<float, WaitForSeconds> dict_WFS = new Dictionary<float, WaitForSeconds>();

    // 생성할 시간(키)의 WFS(WaitForSeconds) 생성
    public static WaitForSeconds WaitForSecond(float sec)       // 성공시 딕셔너리에 추가, 실패시 에러
    {
        WaitForSeconds WFS;
        if (!dict_WFS.TryGetValue(sec, out WaitForSeconds found))
        {
            WFS = new WaitForSeconds(sec);
            dict_WFS.Add(sec, WFS);
            return WFS;
        }
        else { Debug.Log("이미 존재하는 키!"); return found; }
    }

}
