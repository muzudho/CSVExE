using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.GcavToExpr
{
    public abstract class GivechapterandverseToExpression_AbstractImpl : GivechapterandverseToExpression
    {



        #region アクション
        //────────────────────────────────────────

        public static void ParseChild_InAnotherLibrary(
            Givechapterandverse_Node cur_Cf,
            Expression_Node_String parent_Expr,//nAcase,nFelemの両方の場合がある。
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.Name_Library, "SToE_AbstractImpl", "ParseChild_InAnotherLibrary",log_Reports);

            GivechapterandverseToExpression_F14n16 dammy = new GivechapterandverseToExpression_F14_FncImpl_();//メソッドが使いたいだけなので、何でもいい。
            dammy.ParseChild_InGivechapterandverseToExpression(
                cur_Cf,
                parent_Expr,
                memoryApplication,
                pg_ParsingLog,
                log_Reports
                );

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:

            if (Log_ReportsImpl.BDebugmode_Static)
            {
                //d_ParsingLog.Decrement(s_Cur.Name_Node);
            }
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public void ParseChild_InGivechapterandverseToExpression(
            Givechapterandverse_Node cur_Gcav,//S_NodeList s_curNodeList,
            Expression_Node_String parent_Expr,//nAcase,nFelemの両方の場合がある。
            MemoryApplication memoryApplication,
            Log_TextIndented_GivechapterandverseToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_GivechapterandverseToExpression.Name_Library, this, "ParseChild_InSToE",log_Reports);
            //
            //

            if (null == parent_Expr)
            {
                goto gt_Error_NullNFAelem;
            }


            //
            // 親ノード名、親ファンク名
            //
            string parent_SName_Node = parent_Expr.Cur_Givechapterandverse.Name;
            string parent_SName_Fnc = "";
            {
                bool bRequired;
                if (NamesNode.S_FNC == parent_SName_Node)
                {
                    //todo: bRequired = true;
                    bRequired = false;
                }
                else
                {
                    bRequired = false;
                }



                log_Reports.Log_Callstack.Push(log_Method, "①");
                bool bHit = parent_Expr.Dictionary_Expression_Attribute.TrySelect(out parent_SName_Fnc, PmNames.S_NAME.Name_Pm, bRequired, Request_SelectingImpl.Unconstraint, log_Reports);
                log_Reports.Log_Callstack.Pop(log_Method, "①");
            }

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole( "開始┌──┐　s_Curノード名=[" + cur_Gcav.Name + "]　子要素数=[" + cur_Gcav.List_ChildGivechapterandverse.Count + "]");
            }



            //
            //
            //
            // 子
            //
            //
            //
            Givechapterandverse_Node err_Givechapterandverse_Node2 = null;
            cur_Gcav.List_ChildGivechapterandverse.ForEach(delegate(Givechapterandverse_Node s_Child, ref bool bBreak)
            {

                if (!log_Reports.Successful)
                {
                    // 強制終了。
                    bBreak = true;
                    return;
                }


                string sName_MyNode = s_Child.Name;
                string sName_MyFnc = "";
                {
                    bool bRequired;

                    if (NamesNode.S_ARG == sName_MyNode)
                    {
                        bRequired = true;
                    }
                    else
                    {
                        bRequired = false;
                    }

                    log_Reports.Log_Callstack.Push(log_Method, "②");
                    s_Child.Dictionary_Attribute_Givechapterandverse.TryGetValue(PmNames.S_NAME, out sName_MyFnc, bRequired, log_Reports);
                    log_Reports.Log_Callstack.Pop(log_Method, "②");
                }



                if (this.Dictionary_GivechapterandverseToExpression.ContainsKey(sName_MyNode))
                {
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole( "親「S■[" + parent_SName_Fnc + "]　ｎａｍｅ＝”[" + parent_SName_Fnc + "]”」　自「S■[" + sName_MyNode + "]　ｎａｍｅ＝”[" + sName_MyFnc + "]”」");
                    }


                    this.Dictionary_GivechapterandverseToExpression[sName_MyNode].Translate(
                        s_Child,
                        parent_Expr,
                        memoryApplication,
                        pg_ParsingLog,
                        log_Reports
                        );

                }
                else
                {
                    //
                    // それ以外、エラー。
                    //
                    err_Givechapterandverse_Node2 = s_Child;
                    bBreak = true;
                }
            });
            //
            if (null != err_Givechapterandverse_Node2)
            {
                goto gt_Error_UndefinedElement;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullNFAelem:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー801！", log_Method);

                StringBuilder t = new StringBuilder();
                t.Append("＜？？＞要素の指定が空っぽ（ヌル）でした。プログラムミスの可能性。");
                t.Append(Environment.NewLine);
                // nFAelem はヌルなので、確認できない。

                // ヒント
                t.Append(r.Message_Givechapterandverse(parent_Expr.Cur_Givechapterandverse));

                r.Message = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedElement:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー90317", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("　(Fcnf) 子 ＜f-●●＞要素を書くところに、未定義の要素＜");
                s.Append(err_Givechapterandverse_Node2.Name);
                s.Append("＞が書かれていました。これには未対応です。");
                s.Newline();
                s.Append("クラス=[");
                s.Append(err_Givechapterandverse_Node2.GetType().Name);
                s.Append("]");
                s.Newline();
                s.Newline();

                s.Append("┌────┐書けるキー（個数＝[");
                s.Append(this.Dictionary_GivechapterandverseToExpression.Count);
                s.Append("]）");
                s.Newline();
                foreach (string sKey in this.Dictionary_GivechapterandverseToExpression.Keys)
                {
                    s.Append(sKey);
                    s.Newline();
                }
                s.Append("└────┘");
                s.Newline();

                if (null != parent_Expr)
                {
                    s.Append("親要素は[");
                    s.Append(parent_Expr.Cur_Givechapterandverse.Name);
                    s.Append("]");
                    s.Newline();
                }

                s.Append("]");
                s.Newline();
                s.Newline();

                // ヒント
                s.Append(r.Message_Givechapterandverse(err_Givechapterandverse_Node2));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        gt_EndMethod:
            if (Log_ReportsImpl.BDebugmode_Static)
            {
                //d_ParsingLog.Decrement(s_Cur.Name_Node);
            }
            log_Method.EndMethod(log_Reports);

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole( "終了└──┘");
            }
        }
        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private static Dictionary<string, GivechapterandverseToExpression_F14n16> dictionary_GivechapterandverseToExpression;
        private Dictionary<string, GivechapterandverseToExpression_F14n16> Dictionary_GivechapterandverseToExpression
        {
            get
            {
                if (null == dictionary_GivechapterandverseToExpression)
                {
                    GivechapterandverseToExpression_AbstractImpl.dictionary_GivechapterandverseToExpression = new Dictionary<string, GivechapterandverseToExpression_F14n16>();

                    //
                    // 子要素
                    // 「S■ｆ－ｓｔｒ」
                    dictionary_GivechapterandverseToExpression.Add(NamesNode.S_F_STR, new GivechapterandverseToExpression_F14_FstrImpl_());

                    //
                    // 子要素
                    // 「S■ｆ－ｖａｒ」
                    dictionary_GivechapterandverseToExpression.Add(NamesNode.S_F_VAR, new GivechapterandverseToExpression_F14_FvariableImpl_());

                    //
                    // 子要素
                    // 「S■ｆ－ｐａｒａｍ」
                    dictionary_GivechapterandverseToExpression.Add(NamesNode.S_F_PARAM, new GivechapterandverseToExpression_F14_FparamImpl_());


                    //
                    // 「S■ｆｎｃ」要素を追加。
                    dictionary_GivechapterandverseToExpression.Add(NamesNode.S_FNC, new GivechapterandverseToExpression_F14_FncImpl_());



                    // 「S■ａｒｇ」要素を追加。（2012-06-02）
                    dictionary_GivechapterandverseToExpression.Add(NamesNode.S_ARG, new GivechapterandverseToExpression_F14_FArgImpl());

                    // 「S■ｄｅｆ－ｐａｒａｍ」要素を追加。（2012-07-20）
                    dictionary_GivechapterandverseToExpression.Add(NamesNode.S_DEF_PARAM, new GivechapterandverseToExpression_F14_DefParamImpl_());

                }

                return GivechapterandverseToExpression_AbstractImpl.dictionary_GivechapterandverseToExpression;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
