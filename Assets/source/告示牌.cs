using UnityEngine;
using UnityEngine.UI; // 只用原生UI Text，避免TMP依赖问题

public class SimpleNoticeBoard : MonoBehaviour
{
    // 只绑定原生UI Text（不要用TMP，先测试）
    public Text noticeText;

    // 角色进入触发区 → 显示文本
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 打印日志，方便看是否触发
        Debug.Log("检测到物体进入：" + other.gameObject.name);

        // 检测Player标签（必须给角色加Player标签）
        if (other.CompareTag("Player"))
        {
            Debug.Log("是玩家！显示文本");
            noticeText.gameObject.SetActive(true);
        }
    }

    // 角色离开触发区 → 隐藏文本
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("玩家离开！隐藏文本");
            noticeText.gameObject.SetActive(false);
        }
    }

    // 可视化触发范围（调试用）
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        if (col != null)
        {
            Gizmos.DrawWireCube(transform.position + (Vector3)col.offset, col.size);
        }
    }
}