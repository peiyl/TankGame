using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 游戏管理脚本
/// 存放游戏管理相关方法
/// </summary>
public class UIManager : MonoBehaviour {
    public static UIManager Instance;
    /// <summary>
    /// 游戏结束ui物体
    /// </summary>
    private GameObject gameOverPanel;
    /// <summary>
    /// 成绩ui物体
    /// </summary>
    private Text ScoreText;
    /// <summary>
    /// 击杀敌方坦克计数
    /// </summary>
    private int ScoreNum;
    /// <summary>
    /// 最终成绩UI
    /// </summary>
    private Text TotalScoreText;
    /// <summary>
    /// 屏幕上方计算击杀数的ui物体
    /// </summary>
    private GameObject ScoreBGImage;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ScoreBGImage = GameObject.Find("ScoreBGImage");
        TotalScoreText = GameObject.Find("TotalScoreText").GetComponent<Text>();
        gameOverPanel = GameObject.Find("GameOverPanel");
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        ScoreNum = 0;
        gameOverPanel.SetActive(false);
        ScoreText.text = ScoreNum.ToString();
    }
    /// <summary>
    /// 显示游戏结束面板
    /// </summary>
    public void ShowGOPanel()
    {
        ScoreBGImage.SetActive(false);
        gameOverPanel.SetActive(true);
        TotalScoreText.text = "你击杀了" + ScoreNum + "架坦克";
    }
    /// <summary>
    /// 敌人每死亡一次，计数加一,更新显示
    /// </summary>
    public void AddScoreNum()
    {
        ScoreNum++;
        ScoreText.text = ScoreNum.ToString();
    }
}
