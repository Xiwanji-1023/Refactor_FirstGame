using UnityEngine;

public class BillboardTrigger : MonoBehaviour
{
    [Header("告示牌配置")]
    public GameObject contentSprite; // 牌面内容Sprite（可选）
    public GameObject boardText; // 拖拽2D文字对象BoardText到这里
    public float triggerRange = 2f; // 触发距离

    private Transform player;
    private bool isPlayerInRange = false;

    void Start()
    {
        // 初始隐藏内容和文字
        if (contentSprite != null) contentSprite.SetActive(false);
        boardText.SetActive(false);

        // 找到玩家（需给玩家命名为“Player”）
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        // 计算玩家与告示牌的距离
        float distance = Vector2.Distance(transform.position, player.position);
        isPlayerInRange = distance <= triggerRange;

        // 同步显示/隐藏内容和文字
        if (contentSprite != null) contentSprite.SetActive(isPlayerInRange);
        boardText.SetActive(isPlayerInRange);
    }

    // 可视化触发范围（Scene视图）
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRange);
    }
}