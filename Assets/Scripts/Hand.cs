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
            var symbolObj = other.gameObject.transform.parent.gameObject;

            var symbol = symbolObj.GetComponent<Symbol>();

            // 如果TouchArea组件的类型为Miss，则延迟0.5秒销毁游戏对象
            if (area.Type == TouchAreaType.Miss)
            {
                Destroy(symbolObj, 0.5f);
            }
            // 否则，激活游戏对象的FX效果，并延迟1秒销毁FX效果和游戏对象
            else
            {
                symbol.FX.SetActive(true);

                symbol.FX.transform.SetParent(null);

                Destroy(symbol.FX, 1f);

                Destroy(symbolObj);
            }
        }
    }
}