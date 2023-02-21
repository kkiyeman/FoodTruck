using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITodaysScore : MonoBehaviour
{
    public Text txtScore;           //스코어 (0/100)
    public Text txtSalesCnt;        //피자 판매수량(사람아이콘)
    public Text txtTotalStf;        //총 만족도(하트아이콘)
    public Text txtSalesAmt;        //총 판매액(지폐아이콘)
    public Text txtTotalTip;        //총 팁(+TIP)
    public Text txtTotalMoney;      //팁포함 총 매출액

    public Button btnClose;         //닫기


    public void SetTodayInfo(int score, int salesCount, int totalStf, int salesAmt, int totalTip, int totalMoney)
    {
        txtScore.text = $"{score.ToString()}/100";
        txtSalesCnt.text = salesCount.ToString();
        txtTotalStf.text = totalStf.ToString();
        txtSalesAmt.text = $"${salesAmt.ToString()}";
        txtTotalTip.text = $"${totalTip.ToString()}";
        txtTotalMoney.text = $"${totalMoney.ToString()}";
    }
}
