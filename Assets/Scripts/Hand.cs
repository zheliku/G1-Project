using System;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 当与其他对象碰撞且该对象标记为"TouchArea"时
        if (other.CompareTag("TouchArea"))
        {
            // 获取碰撞对象的TouchArea组件
            var area = other.GetComponent<TouchArea>();
            
            // 更新全局分数，增加TouchArea组件定义的分数
            Global.Score += area.Score;
        
            // 设置全局性能指标为TouchArea组件的类型
            Global.Performance = area.Type.ToString();
            
            // 销毁TouchArea组件所属的整个游戏对象
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
