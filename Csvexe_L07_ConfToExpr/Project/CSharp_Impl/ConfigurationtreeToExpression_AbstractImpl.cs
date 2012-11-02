using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.ConfToExpr
{
    public abstract class ConfigurationtreeToExpression_AbstractImpl : ConfigurationtreeToExpression
    {



        #region アクション
        //────────────────────────────────────────

        public static void ParseChild_InAnotherLibrary(
            Configurationtree_Node cur_Cf,
            Expression_Node_String parent_Expr,//nAcase,nFelemの両方の場合がある。
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, "SToE_AbstractImpl", "ParseChild_InAnotherLibrary",log_Reports);

            ConfigurationtreeToExpression_F14n16 dammy = new ConfigurationtreeToExpression_F14_FncImpl_();//メソッドが使いたいだけなので、何でもいい。
            dammy.ParseChild_InConfigurationtreeToExpression(
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

        public void ParseChild_InConfigurationtreeToExpression(
            Configurationtree_Node cur_Conf,//S_NodeList s_curNodeList,
            Expression_Node_String parent_Expr,//nAcase,nFelemの両方の場合がある。
            MemoryApplication memoryApplication,
            Log_TextIndented_ConfigurationtreeToExpression pg_ParsingLog,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_ConfigurationtreeToExpression.Name_Library, this, "ParseChild_InSToE",log_Reports);
            //
            //

            if (null == parent_Expr)
            {
                goto gt_Error_NullNFAelem;
            }


            //
            // 親ノード名、親ファンク名
            //
            string parent_SName_Node = parent_Expr.Cur_Configuration.Name;
            string parent_SName_Fnc = "";
            {
                EnumHitcount enumHitcount;
                if (NamesNode.S_FNC == parent_SName_Node)
                {
                    //todo: enumHitcount = EnumHitcount.One;
                    enumHitcount = EnumHitcount.One_Or_Zero;
                }
                else
                {
                    enumHitcount = EnumHitcount.One_Or_Zero;
                }



                log_Reports.Log_Callstack.Push(log_Method, "①");
                bool bHit = parent_Expr.TrySelectAttribute(out parent_SName_Fnc, PmNames.S_NAME.Name_Pm, enumHitcount, log_Reports);
                log_Reports.Log_Callstack.Pop(log_Method, "①");
            }

            if (log_Method.CanDebug(1))
            {
                log_Method.WriteDebug_ToConsole( "開始┌──┐　s_Curノード名=[" + cur_Conf.Name + "]　子要素数=[" + cur_Conf.List_Child.Count + "]");
            }



            //
            //
            //
            // 子
            //
            //
            //
            Configurationtree_Node err_Configurationtree_Node2 = null;
            cur_Conf.List_Child.ForEach(delegate(Configurationtree_Node s_Child, ref bool bBreak)
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
                    s_Child.Dictionary_Attribute.TryGetValue(PmNames.S_NAME, out sName_MyFnc, bRequired, log_Reports);
                    log_Reports.Log_Callstack.Pop(log_Method, "②");
                }



                if (this.Dictionary_ConfigurationtreeToExpression.ContainsKey(sName_MyNode))
                {
                    if (log_Method.CanDebug(1))
                    {
                        log_Method.WriteDebug_ToConsole( "親「S■[" + parent_SName_Fnc + "]　ｎａｍｅ＝”[" + parent_SName_Fnc + "]”」　自「S■[" + sName_MyNode + "]　ｎａｍｅ＝”[" + sName_MyFnc + "]”」");
                    }


                    this.Dictionary_ConfigurationtreeToExpression[sName_MyNode].Translate(
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
                    err_Configurationtree_Node2 = s_Child;
                    bBreak = true;
                }
            });
            //
            if (null != err_Configurationtree_Node2)
            {
                goto gt_Error_UndefinedElement;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullNFAelem:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToText_Configuration(parent_Expr.Cur_Configuration), log_Reports);//設定位置パンくずリスト

                memoryApplication.CreateErrorReport("Er:7010;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedElement:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_Configurationtree_Node2.Name, log_Reports);//設定ノード名
                tmpl.SetParameter(2, err_Configurationtree_Node2.GetType().Name, log_Reports);//設定ノードのクラス名
                tmpl.SetParameter(3, this.Dictionary_ConfigurationtreeToExpression.Count.ToString(), log_Reports);//キーの個数

                StringBuilder s1 = new StringBuilder();
                foreach (string sKey in this.Dictionary_ConfigurationtreeToExpression.Keys)
                {
                    s1.Append(sKey);
                    s1.Append(System.Environment.NewLine);
                }
                tmpl.SetParameter(4, s1.ToString(), log_Reports);//キーのリスト

                //設定親ノード名
                if (null != parent_Expr)
                {
                    tmpl.SetParameter(5, parent_Expr.Cur_Configuration.Name, log_Reports);
                }
                else
                {
                    tmpl.SetParameter(5, "ヌル", log_Reports);
                }

                tmpl.SetParameter(6, Log_RecordReportsImpl.ToText_Configuration(err_Configurationtree_Node2), log_Reports);//設定位置パンくずリスト

                memoryApplication.CreateErrorReport("Er:7011;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
            //
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

        private static Dictionary<string, ConfigurationtreeToExpression_F14n16> dictionary_ConfigurationtreeToExpression;
        private Dictionary<string, ConfigurationtreeToExpression_F14n16> Dictionary_ConfigurationtreeToExpression
        {
            get
            {
                if (null == dictionary_ConfigurationtreeToExpression)
                {
                    ConfigurationtreeToExpression_AbstractImpl.dictionary_ConfigurationtreeToExpression = new Dictionary<string, ConfigurationtreeToExpression_F14n16>();

                    //
                    // 子要素
                    // 「S■ｆ－ｓｔｒ」
                    dictionary_ConfigurationtreeToExpression.Add(NamesNode.S_F_STR, new ConfigurationtreeToExpression_F14_FstrImpl_());

                    //
                    // 子要素
                    // 「S■ｆ－ｖａｒ」
                    dictionary_ConfigurationtreeToExpression.Add(NamesNode.S_F_VAR, new ConfigurationtreeToExpression_F14_FvariableImpl_());

                    //
                    // 子要素
                    // 「S■ｆ－ｐａｒａｍ」
                    dictionary_ConfigurationtreeToExpression.Add(NamesNode.S_F_PARAM, new ConfigurationtreeToExpression_F14_FparamImpl_());


                    //
                    // 「S■ｆｎｃ」要素を追加。
                    dictionary_ConfigurationtreeToExpression.Add(NamesNode.S_FNC, new ConfigurationtreeToExpression_F14_FncImpl_());



                    // 「S■ａｒｇ」要素を追加。（2012-06-02）
                    dictionary_ConfigurationtreeToExpression.Add(NamesNode.S_ARG, new ConfigurationtreeToExpression_F14_FArgImpl());

                    // 「S■ｄｅｆ－ｐａｒａｍ」要素を追加。（2012-07-20）
                    dictionary_ConfigurationtreeToExpression.Add(NamesNode.S_DEF_PARAM, new ConfigurationtreeToExpression_F14_DefParamImpl_());

                }

                return ConfigurationtreeToExpression_AbstractImpl.dictionary_ConfigurationtreeToExpression;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
