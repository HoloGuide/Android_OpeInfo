using UnityEngine;
using System.Text;
using System.Collections;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using Sgml;
using System.Xml.XPath;
using System.Net;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Operate_Info : MonoBehaviour
{

    private Text targetText;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetOperateInfo());
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*public void OnClick()
     {
         StartCoroutine(GetOperateInfo());
     }
     */

    private IEnumerator GetOperateInfo()
    {
        this.targetText = this.GetComponent<Text>();

        //1.UnityWebRequestを生成
        UnityWebRequest request = UnityWebRequest.Get("https://transit.yahoo.co.jp/traininfo/detail/18/0/");

        //2.SendWebRequestを実行し、送受信開始
        yield return request.SendWebRequest();

        //3.isNetworkErrorとisHttpErrorでエラー判定
        if (request.isHttpError || request.isNetworkError)
        {
            //4.エラー確認
            Debug.Log(request.error);
        }
        else
        {
            //4.結果確認
            Debug.Log(request.downloadHandler.text);
        }

        XDocument document = Parse(request.downloadHandler.text);

        //運行状況の取得
        XElement Operate_info = document.XPathSelectElement("//meta[@property='og:description']");

        //タグを外す操作
        string info = Operate_info.ToString();

        //前部分
        string OutputData = info.Remove(0, 41);

        //後ろ部分
        OutputData = OutputData.Remove((OutputData.Length - 43));

        //出力
        //Debug.Log(OutputData);
        this.targetText.text = OutputData;

    }

    //HTMLをXMLに変換
    public static XDocument Parse(string content)
    {
        using (var reader = new StringReader(content))
        using (var sgmlReader = new SgmlReader { DocType = "HTML", CaseFolding = CaseFolding.ToLower, IgnoreDtd = true, InputStream = reader })
        {
            return XDocument.Load(sgmlReader);
        }
    }
}

