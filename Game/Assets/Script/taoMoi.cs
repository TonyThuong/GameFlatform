using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class taoMoi : MonoBehaviour
{
    public InputField ID;
    public InputField USER;
    public InputField PASS;
    public InputField LEVEL;
    public InputField POINT;

    string php_dangKy="http://localhost/PHP/dangKy.php";

    public void themMoi(){

        StartCoroutine(connect());
        
    }

    IEnumerator connect(){
        //B1: Khai bao from
        WWWForm wf = new WWWForm();
        
        //B2: Them 5 textbox vao ten form wf
        wf.AddField("id_chuyen",ID.text);
        wf.AddField("user_chuyen",USER.text);
        wf.AddField("pass_chuyen",PASS.text);
        wf.AddField("level_chuyen",LEVEL.text);
        wf.AddField("point_chuyen",POINT.text);

        //B3: Chuyen 5 thanh phan cua form den dangKy.php
        WWW w = new WWW(php_dangKy,wf);

        yield return w;

        string tam=w.text;
        //cat khoang trang ben trai
        string tam1=tam.TrimStart();
        //cat khoang trang ben phai
        string tam2=tam1.TrimEnd();


        if(tam2 == "Them Thanh Cong"){
            print("Them Thanh Cong!!");
        }else{
            print("Them That Bai!!");
        }
    }
}
