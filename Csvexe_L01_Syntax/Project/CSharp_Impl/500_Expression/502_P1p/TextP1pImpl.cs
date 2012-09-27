using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Xenon.Syntax
{
    /// <summary>
    /// 「%1%:%2%」といった文字列（ピーワンピー_テキスト）をセットしておき、
    /// リスト[1]=101
    /// リスト[2]=赤
    /// といったリスト（parametersリストと呼ぶ）を渡した後、
    /// Performすると、
    /// 「101:赤」
    /// といった文字列を返すクラスです。
    /// </summary>
    public class TextP1pImpl : TextP1p
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public TextP1pImpl()
        {
            this.sText = "";

            this.dicS_P1p = new Dictionary<int, string>();

            ////
            //// 最初に追加した要素を 0、
            //// 次に追加した要素を 1、
            //// といった具合に、必ず要素を追加した順の連番で利用すること。
            ////
            //this.parameters = new List<string>();
            //this.parameters.Add("");//要素[0]は、使わないようにして、[1]から使うようにします。
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 「%1%」、「%2%」といった記号を探し、リストに「1」、「2」といった数字に置き換えて返します。
        /// </summary>
        /// <returns></returns>
        public List<int> GetP1pNumbers(
            DicExpression_Node_String ecDic_Attr,
            Log_Reports log_Reports
            )
        {

            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "GetP1pNumbers",log_Reports);

            //
            //
            //
            //

            List<int> list = new List<int>();


            Dictionary<string,Expression_Node_String>.KeyCollection ecDic_Key = ecDic_Attr.Keys(log_Reports);

            foreach (string sKey in ecDic_Key)
            {
                //
                //
                //
                // p1p,p2p,p3p...といった名前かどうかを判定。
                //
                //
                //
                int nParamNameMatchedCount = 0;
                int nP1pNumber = 0;
                {
                    //正規表現
                    System.Text.RegularExpressions.Regex regexp =
                        new System.Text.RegularExpressions.Regex(
                            @"p([0-9])+p",
                        //                            @"p[0-9]+p",
                            System.Text.RegularExpressions.RegexOptions.IgnoreCase
                            );

                    //文字列検索を1回する。
                    System.Text.RegularExpressions.Match match = regexp.Match(sKey);

                    while (match.Success)
                    {
                        nParamNameMatchedCount++;

                        bool parsedSuccessful = int.TryParse( match.Groups[1].Value, out nP1pNumber);

                        match = match.NextMatch();
                    }
                }

                if (1 == nParamNameMatchedCount)
                {
                    //
                    //
                    //
                    // p1p,p2p,p3p...といった名前。
                    //
                    //
                    //
                    list.Add(nP1pNumber);
                }
                else
                {
                }
            }


            //
            //
            log_Method.EndMethod(log_Reports);
            return list;
        }

        //────────────────────────────────────────

        public Expression_Node_String Compile(
            Log_Reports log_Reports
            )
        {

            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Syntax.SName_Library, this, "Compile",log_Reports);

            //
            //
            //
            //

            String sTxtTmpl = this.SText;
            //.WriteLine("★★★★★★★★" + this.GetType().Name + "#Compile: txtTmpl＝[" + txtTmpl + "]");
            //essageBox.Show("★★★★★★★★" + this.GetType().Name + "#Compile: txtTmpl＝[" + txtTmpl + "]", this.GetType().Name + "#Compile:(TextTemplate)");




            Givechapterandverse_Node parent_Gcav = new Givechapterandverse_NodeImpl("!ハードコーディング_TextTemplateImpl#Compile", null);
            Expression_Node_StringImpl result = new Expression_Node_StringImpl(null,parent_Gcav);

            int nCur = 0;

            while (nCur < sTxtTmpl.Length)
            {
                int nPreCur = nCur;

                // 開き%記号（open percent）
                int nOp = sTxtTmpl.IndexOf('%', nCur);

                if (nOp != -1)
                {
                    // 開き%記号があった。

                    nCur = nOp + 1;//「開き%」の次へ。

                    // 閉じ%記号（close percent）
                    int cp = sTxtTmpl.IndexOf('%', nCur);

                    if (cp != -1)
                    {
                        // 閉じ%記号があれば。

                        nCur = cp + 1;//「閉じ%」の次へ。

                        // 「%」と「%」の間に数字があるはず。
                        // 「開き%」の次から、「閉じ% - 開き% - 1」文字分。（-1しないと、終了%を含んでしまう）
                        string sMarker = sTxtTmpl.Substring(nOp + 1, cp - nOp - 1);


                        // 「%1%」といった記号の数字部分。
                        int nParameterIndex;


                        try
                        {
                            nParameterIndex = Int32.Parse(sMarker);


                            // 開き「%」までを、まず文字列化。
                            int nPreLen = nOp - nPreCur;
                            string sPre = sTxtTmpl.Substring(nPreCur, nPreLen);
                            result.AppendTextNode(
                                sPre,
                                parent_Gcav,
                                log_Reports
                                );



                            // 引数から値を取得。

                            // %数字%を、HData化して追加。
                            Expression_P1pImpl ec_P1p = new Expression_P1pImpl(null,parent_Gcav);
                            ec_P1p.NP1p = nParameterIndex;
                            ec_P1p.DicS_P1p = this.DicS_P1p;

                            result.ListExpression_Child.Add(
                                ec_P1p,
                                log_Reports
                                );

                            // 続行。
                        }
                        catch (Exception)
                        {
                            // 数字でないようなら。

                            // 今回の判定は失敗したものとして、残りの長さ全て
                            int nRestLen = sTxtTmpl.Length - nPreCur;

                            result.AppendTextNode(
                                sTxtTmpl.Substring(nPreCur, nRestLen),
                                parent_Gcav,
                                log_Reports
                                );


                            nCur = sTxtTmpl.Length;//終了（最後の文字の次へカーソルを出す）
                        }
                    }
                    else
                    {
                        // 閉じ%がなければ。

                        // 今回の判定は失敗したものとして、残りの長さ全て
                        int nRestLen = sTxtTmpl.Length - nPreCur;

                        result.AppendTextNode(
                            sTxtTmpl.Substring(nPreCur, nRestLen),
                            parent_Gcav,
                            log_Reports
                            );

                        nCur = sTxtTmpl.Length;//終了（最後の文字の次へカーソルを出す）
                    }
                }
                else
                {
                    // 開き%がなければ。

                    // 残りの長さ全て
                    int nRestLen = sTxtTmpl.Length - nCur;

                    result.AppendTextNode(
                        sTxtTmpl.Substring(nCur, nRestLen),
                        parent_Gcav,
                        log_Reports
                        );

                    nCur = sTxtTmpl.Length;//終了（最後の文字の次へカーソルを出す）
                }
            }


            //
            //
            log_Method.EndMethod(log_Reports);
            return result;
        }

        //────────────────────────────────────────

        public String Perform()
        {
            String sTxtTmpl = this.SText;

            StringBuilder sb = new StringBuilder();

            int nCur = 0;

            while (nCur < sTxtTmpl.Length)
            {
                int nPreCur = nCur;
                //.WriteLine(this.GetType().Name + "#Perform: ループ開始 cur＝[" + cur + "] preCur＝[" + preCur + "] txtTmpl.Length＝[" + txtTmpl.Length + "]");

                // 開き%記号（open percent）
                int nOp = sTxtTmpl.IndexOf('%', nCur);
                //.WriteLine(this.GetType().Name + "#Perform: op＝[" + op + "]");
                if (nOp != -1)
                {
                    // 開き%記号があった。
                    //.WriteLine(this.GetType().Name + "#Perform: 開き%記号があった。");

                    nCur = nOp+1;//「開き%」の次へ。
                    //.WriteLine(this.GetType().Name + "#Perform: cur＝[" + cur + "]");

                    // 閉じ%記号（close percent）
                    int nCp = sTxtTmpl.IndexOf('%', nCur);
                    //.WriteLine(this.GetType().Name + "#Perform: cp＝[" + cp + "]");

                    if (nCp != -1)
                    {
                        // 閉じ%記号があれば。
                        //.WriteLine(this.GetType().Name + "#Perform: 閉じ%記号があった。");

                        nCur = nCp+1;//「閉じ%」の次へ。
                        //.WriteLine(this.GetType().Name + "#Perform: cur＝[" + cur + "]");

                        // 「%」と「%」の間に数字があるはず。
                        // 「開き%」の次から、「閉じ% - 開き% - 1」文字分。（-1しないと、終了%を含んでしまう）
                        string sMarker = sTxtTmpl.Substring(nOp+1, nCp - nOp -1);

                        //.WriteLine(this.GetType().Name + "#Perform: marker＝[" + marker + "]");
                        int nParameterIndex;

                        try
                        {
                            nParameterIndex = Int32.Parse(sMarker);
                            //.WriteLine(this.GetType().Name + "#Perform: parameterIndex＝[" + parameterIndex + "]");


                            // %数字%を、引数の内容に置換。
                            //.WriteLine(this.GetType().Name + "#Perform: %数字%を、引数の内容に置換。");


                            // 開き「%」までを、まず文字列化。
                            int nPreLen = nOp - nPreCur;
                            //.WriteLine(this.GetType().Name + "#Perform: preLen[" + preLen + "]　＝　（　op[" + op + "]　－　preCur[" + preCur + "]　）");
                            string sPre = sTxtTmpl.Substring(nPreCur, nPreLen);
                            //.WriteLine(this.GetType().Name + "#Perform: preStr＝[" + preStr + "]");
                            sb.Append(sPre);
                            //.WriteLine(this.GetType().Name + "#Perform: resultTxt＝[" + resultTxt.ToString() + "]");


                            //if (this.Parameters.Count <= parameterIndex)
                            //{
                            //    // 添字が、配列の要素数と同じか、超えている場合。

                            //    dt.Append("[out of index " + parameterIndex + "]");
                            //}
                            //else
                            //{
                                // 引数から値を取得。

                            //string paramValue = this.Parameters[parameterIndex];
                            string sParamValue = this.DicS_P1p[nParameterIndex];

                                //.WriteLine(this.GetType().Name + "#Perform: paramValue＝[" + paramValue + "]");
                                sb.Append(sParamValue);
//                            }


                            // 続行。
                            //.WriteLine(this.GetType().Name + "#Perform: resultTxt＝[" + resultTxt.ToString() + "]");


                        }
                        catch (Exception)
                        {
                            // 数字でないようなら。
                            //.WriteLine(this.GetType().Name + "#Perform: 数字でないようなら。");

                            // 今回の判定は失敗したものとして、残りの長さ全て
                            int nRestLen = sTxtTmpl.Length - nPreCur;
                            //.WriteLine(this.GetType().Name + "#Perform: restLen＝[" + restLen + "]");
                            sb.Append(sTxtTmpl.Substring(nPreCur, nRestLen));
                            //.WriteLine(this.GetType().Name + "#Perform: resultTxt＝[" + resultTxt.ToString() + "]");
                            nCur = sTxtTmpl.Length;//終了（最後の文字の次へカーソルを出す）
                            //.WriteLine(this.GetType().Name + "#Perform: cur＝[" + cur + "]");
                        }
                    }
                    else
                    {
                        // 閉じ%がなければ。
                        //.WriteLine(this.GetType().Name + "#Perform: 閉じ%がなければ。");

                        // 今回の判定は失敗したものとして、残りの長さ全て
                        int nRestLen = sTxtTmpl.Length - nPreCur;
                        //.WriteLine(this.GetType().Name + "#Perform: restLen＝[" + restLen + "]");
                        sb.Append(sTxtTmpl.Substring(nPreCur, nRestLen));
                        //.WriteLine(this.GetType().Name + "#Perform: resultTxt＝[" + resultTxt.ToString() + "]");
                        nCur = sTxtTmpl.Length;//終了（最後の文字の次へカーソルを出す）
                        //.WriteLine(this.GetType().Name + "#Perform: cur＝[" + cur + "]");
                    }
                }
                else
                {
                    // 開き%がなければ。
                    //.WriteLine(this.GetType().Name + "#Perform: 開き%がなければ。");

                    // 残りの長さ全て
                    int nRestLen = sTxtTmpl.Length - nCur;
                    //.WriteLine(this.GetType().Name + "#Perform: restLen＝[" + restLen + "]");
                    sb.Append(sTxtTmpl.Substring(nCur, nRestLen));
                    //.WriteLine(this.GetType().Name + "#Perform: resultTxt＝[" + resultTxt.ToString() + "]");
                    nCur = sTxtTmpl.Length;//終了（最後の文字の次へカーソルを出す）
                    //.WriteLine(this.GetType().Name + "#Perform: cur＝[" + cur + "]");
                }
            }

            

            return sb.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string sText;

        /// <summary>
        /// 「%1%:%2%」といった文字列（テキスト_テンプレートと呼ぶ）。
        /// </summary>
        public string SText
        {
            get
            {
                return sText;
            }
            set
            {
                sText = value;
            }
        }

        //────────────────────────────────────────

        private Dictionary<int, string> dicS_P1p;

        /// <summary>
        /// [1]=101
        /// [2]=赤
        /// といったディクショナリー。
        /// 
        /// 数字は %1%や、p1pの名前の中の数字。[1]から始める。
        /// Xn_L05_E:E_FtextTemplate#E_ExecuteでAddされます。
        /// </summary>
        public Dictionary<int, string> DicS_P1p
        {
            get
            {
                return dicS_P1p;
            }
            set
            {
                dicS_P1p = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
