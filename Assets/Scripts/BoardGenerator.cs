using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    // 存储生成位置的列表
    public List<Transform> GeneratePoses;

    // 存储木板对象的列表
    public List<GameObject> Boards;

    // 定义木板移动的方向，默认为向前
    public Vector3 MoveDirection = Vector3.forward;
    
    public int IntervalFrame = 300;

    // Update方法每帧被调用
    void Update()
    {
        // 每180帧执行一次生成逻辑
        if (Time.frameCount % IntervalFrame == 0)
        {
            // 随机选择一个木板索引
            var index = Random.Range(0, Boards.Count);

            // 获取选中的木板对象
            var obj = Boards[index];

            // 实例化木板对象
            var inst = Instantiate(obj);

            // 设置实例化木板的位置为生成位置列表中的随机一个位置
            inst.transform.position = GeneratePoses[Random.Range(0, GeneratePoses.Count)].position;

            // 激活实例化的木板对象
            inst.SetActive(true);

            // 设置实例化木板的向前方向为MoveDirection
            inst.transform.forward = MoveDirection;
        }
    }
}