using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITodaysScore : MonoBehaviour
{
    public Text txtScore;           //���ھ� (0/100)
    public Text txtSalesCnt;        //���� �Ǹż���(���������)
    public Text txtTotalStf;        //�� ������(��Ʈ������)
    public Text txtSalesAmt;        //�� �Ǹž�(���������)
    public Text txtTotalTip;        //�� ��(+TIP)
    public Text txtTotalMoney;      //������ �� �����

    public Button btnClose;         //�ݱ�


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
