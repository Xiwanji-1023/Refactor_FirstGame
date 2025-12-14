using UnityEngine;
using UnityEngine.UI; // 引入UI命名空间（Text组件需要）

/// <summary>
/// 2D告示牌核心逻辑：
/// 1. 检测角色进入/离开触发器
/// 2. 控制文字显示/隐藏
/// 3. 可选：平滑淡入淡出
/// </summary>
public class Signboard : MonoBehaviour
{
    [Header("==== 基础配置 ====")]
    [Tooltip("要显示的文字内容（\\n换行）")]
    public string noticeText = "欢迎来到新手村！\n按方向键移动靠近/离开";
    [Tooltip("文字显示的UI对象（拖入场景中的NoticeText）")]
    public GameObject noticeTextObj;
    [Tooltip("角色的标签（必须和角色标签一致）")]
    public string playerTag = "Player";

    [Header("==== 进阶配置（可选） ====")]
    [Tooltip("是否开启淡入淡出效果")]
    public bool useFade = true;
    [Tooltip("淡入淡出的速度（值越大越快）")]
    public float fadeSpeed = 3f;

    // 私有变量：标记角色是否在触发器范围内
    private bool isPlayerNear = false;
    // 私有变量：CanvasGroup组件（用于控制透明度）
    private CanvasGroup canvasGroup;

    // 初始化（游戏启动时执行）
    void Start()
    {
        // 1. 检查文字对象是否赋值
        if (noticeTextObj == null)
        {
            Debug.LogError("请给告示牌绑定文字显示对象！", this);
            return; // 未赋值则停止执行
        }

        // 2. 初始化文字内容
        Text textComponent = noticeTextObj.GetComponent<Text>();
        if (textComponent != null)
        {
            textComponent.text = noticeText; // 给Text组件赋值
        }
        else
        {
            Debug.LogWarning("文字对象没有Text组件！请检查是否用了TextMeshPro", this);
        }

        // 3. 初始化淡入淡出（如果开启）
        if (useFade)
        {
            // 获取CanvasGroup组件，没有则自动添加
            canvasGroup = noticeTextObj.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = noticeTextObj.AddComponent<CanvasGroup>();
            }
            canvasGroup.alpha = 0; // 初始透明度为0（完全透明）
        }
        else
        {
            noticeTextObj.SetActive(false); // 初始隐藏
        }
    }

    // 每帧更新（实时检测）
    void Update()
    {
        // 如果文字对象未赋值，直接返回
        if (noticeTextObj == null) return;

        // 逻辑1：普通显示/隐藏（无淡入淡出）
        if (!useFade)
        {
            noticeTextObj.SetActive(isPlayerNear); // 角色在范围内则显示，否则隐藏
        }
        // 逻辑2：平滑淡入淡出（有透明度过渡）
        else
        {
            if (canvasGroup != null)
            {
                // 目标透明度：角色在范围内=1（不透明），否则=0（透明）
                float targetAlpha = isPlayerNear ? 1f : 0f;
                // 平滑插值计算当前透明度（Time.deltaTime保证帧率无关）
                canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, fadeSpeed * Time.deltaTime);
            }
        }
    }

    #region 2D触发器回调函数（Unity内置）
    /// <summary>
    /// 角色进入触发器范围时调用
    /// </summary>
    /// <param name="other">碰撞到的对象</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查碰撞对象是否是玩家（通过标签判断）
        if (other.CompareTag(playerTag))
        {
            isPlayerNear = true; // 标记玩家靠近
            Debug.Log("玩家进入告示牌范围，显示文字");
        }
    }

    /// <summary>
    /// 角色离开触发器范围时调用
    /// </summary>
    /// <param name="other">碰撞到的对象</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        // 检查碰撞对象是否是玩家
        if (other.CompareTag(playerTag))
        {
            isPlayerNear = false; // 标记玩家离开
            Debug.Log("玩家离开告示牌范围，隐藏文字");
        }
    }
    #endregion

   
   
}