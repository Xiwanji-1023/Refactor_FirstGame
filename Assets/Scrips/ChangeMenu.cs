using UnityEngine;
using TMPro;

// 玩家靠近自动显示UI面板，离开自动关闭
public class AutoShowBillboardUI : MonoBehaviour
{
    [Header("UI配置")]
    public GameObject billboardUIPanel; // 拖拽场景中的BillboardUIPanel
    public TextMeshProUGUI uiText; // 拖拽Panel下的UIText组件
    public string uiContent = "欢迎来到新手村！\n请前往铁匠铺领取任务。";

    void Start()
    {
        // 初始化文字内容
        if (uiText != null)
        {
            uiText.text = uiContent;
        }
        // 初始隐藏UI
        billboardUIPanel.SetActive(false);
    }

    // 玩家进入范围，显示UI
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            billboardUIPanel.SetActive(true);
        }
    }

    // 玩家离开范围，关闭UI
    private void OnTriggerExit2D(Collider2D other)
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        if (!BaseSetting.isMenuAnimation) { BaseSetting.isMenuAnimation = true; StartCoroutine(ChangeMenu()); }

=======
=======
>>>>>>> Stashed changes
        if (other.CompareTag("Player"))
        {
            billboardUIPanel.SetActive(false);
        }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

    // 防止UI残留
    private void OnDisable()
    {
        billboardUIPanel.SetActive(false);
    }
}