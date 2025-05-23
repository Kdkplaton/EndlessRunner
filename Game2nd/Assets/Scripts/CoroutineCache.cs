using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCache
{
    Dictionary<float, WaitForSeconds> dict_WFS = new Dictionary<float, WaitForSeconds>();

    void Start()
    {
        dict_WFS.Add(1f, new WaitForSeconds(1f));   // 대기시간 1초짜리 WFS(WaitForSeconds)생성
        dict_WFS.Add(2f, new WaitForSeconds(2f));   // 대기시간 2초짜리 WFS 생성
        dict_WFS.Add(3f, new WaitForSeconds(3f));   // 대기시간 3초짜리 WFS 생성
        dict_WFS.Add(4f, new WaitForSeconds(4f));   // 대기시간 4초짜리 WFS 생성
        dict_WFS.Add(5f, new WaitForSeconds(5f));   // 대기시간 5초짜리 WFS 생성
    }

}
