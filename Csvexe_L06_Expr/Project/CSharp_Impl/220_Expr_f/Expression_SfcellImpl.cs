using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Table;//DefaultTable,FldDefinition

namespace Xenon.Expr
{

    /// <summary>
    /// システム関数 ＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｃｅｌｌ；”＞ 要素です。
    /// 
    /// テーブルのセルを１つ特定します。
    /// </summary>
    public class Expression_SfcellImpl : Expression_NodeImpl
    {



        #region 用意
        //────────────────────────────────────────

        public const string S_EQ = "eq";

        public const string S_NEQ = "neq";

        public const string S_LT = "lt";

        public const string S_LTEQ = "lteq";

        public const string S_GT = "gt";

        public const string S_GTEQ = "gteq";

        /// <summary>
        /// TODO 暫定設計。int型のフィールドに空欄を入れるとき。
        /// </summary>
        public static readonly int N_ALT_EMPTY_INT = -1;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param oVariableName="s_ParentNode"></param>
        /// <param oVariableName="moOpyopyo"></param>
        private Expression_SfcellImpl(
            Expression_Node_String parent_Expression, Configurationtree_Node parent_Configurationtree, MemoryApplication owner_MemoryApplication)
            : base(parent_Expression, parent_Configurationtree, owner_MemoryApplication)
        {
        }

        public static Expression_Node_String Create(
            Expression_Node_String parent_Expression, Configurationtree_Node parent_Configurationtree, MemoryApplication owner_MemoryApplication)
        {
            return new Expression_SfcellImpl( parent_Expression,  parent_Configurationtree,  owner_MemoryApplication);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ユーザー定義プログラムの実行。
        /// </summary>
        /// <returns></returns>
        public override string Expression_ExecuteMain(
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Expression_ExecuteMain",log_Reports);
            //
            //

            //
            //
            // 「this」は、＜f-cell＞に当たる。
            //
            // record-set-load-ｆｒｏｍ などを使っている場合は、keyFldName等の情報が足りなくなる場合がある。
            //
            //

            string sResult;

            if (!log_Reports.Successful)
            {
                // エラーが出ていたら、さっさと抜ける。
                sResult = "＜「E■ｆ－ｃｅｌｌ」エラー101＞";
                goto gt_EndMethod;
            }


            //
            //　（１０２）セレクト文の作成。
            //
            Selectstatement selectSt;
            bool bOneCellSelectCondition;//「フィールド名　＝　値」の形のみ true。
            bool bExists_Awhr;
            if (log_Reports.Successful)
            {
                this.E_Execute_P1_CleateSelect(
                    out bOneCellSelectCondition,
                    out selectSt,
                    out bExists_Awhr,
                    this.Cur_Configurationtree,
                    log_Reports
                    );
            }
            else
            {
                // エラーが出ていたら、さっさと抜ける。
                sResult = "＜「E■ｆ－ｃｅｌｌ」エラー102a＞";
                goto gt_EndMethod;
            }

            bool bExists_Into;
            if (log_Reports.Successful)
            {
                // into属性の有無。
                if ("" != selectSt.Expression_Into.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim())
                {
                    bExists_Into = true;
                }
                else
                {
                    bExists_Into = false;
                }
            }
            else
            {
                // エラーが出ていたら、さっさと抜ける。
                sResult = "＜「E■ｆ－ｃｅｌｌ」エラー102b＞";
                goto gt_EndMethod;
            }


            if (!log_Reports.Successful)
            {
                // エラーが出ていたら、さっさと抜ける。
                sResult = "＜「E■ｆ－ｃｅｌｌ」エラー103＞";
                goto gt_EndMethod;
            }


            // ｆｒｏｍ句のテーブルを読み込みます。
            XenonTable o_FromTable = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(selectSt.Expression_From, true, log_Reports);

            if (!log_Reports.Successful)
            {
                // エラーが出ていたら、さっさと抜ける。
                sResult = "＜「E■ｆ－ｃｅｌｌ」エラー104＞";
                goto gt_EndMethod;
            }



            //
            //　（１０５）セレクト文を指定して、レコードセットの絞り込み。
            //
            RecordSet recordSet;
            // 行リスト＜列リスト＞
            List<List<string>> sFieldListList;
            if (
                bOneCellSelectCondition || //「フィールド名＝値」の検索条件があり、セル１件を絞り込む場合。
                selectSt.List_Recordcondition.Count < 1 //無条件な場合。
                )
            {
                // セレクト文を指定することで、レコードセットを取得。
                recordSet = this.E_Execute_P2_Select(
                    bExists_Awhr,
                    selectSt,
                    this.Cur_Configurationtree,
                    log_Reports
                    );

                if (!log_Reports.Successful)
                {
                    // エラーが出ていたら、さっさと抜ける。
                    sResult = "＜「E■ｆ－ｃｅｌｌ」エラー105＞";
                    goto gt_EndMethod;
                }
                else if (null == recordSet)
                {
                    //
                    // エラー。
                    goto gt_Error_NotFoundRecordSet;
                }


                //　（１）「E■ｒｅｃ－ｃｏｎｄ」が１つだけ入っている形式

                // （３００）フィールドから値を取得。
                P5_CellsSelecterImpl sel5 = new P5_CellsSelecterImpl(this.Owner_MemoryApplication);
                sFieldListList = sel5.P5_Select_CellType(
                    recordSet,
                    selectSt,
                    null,//eＷｈｅｒｅ_recordSetSaveTo,
                    this.Cur_Configurationtree,
                    log_Reports
                    );

                if (!log_Reports.Successful)
                {
                    // エラーが出ていたら、さっさと抜ける。
                    sResult = "＜「E■ｆ－ｃｅｌｌ」エラー106＞";
                    goto gt_EndMethod;
                }

            }
            else
            {
                // TODO:それ以外のタイプにも対応したい。
                sFieldListList = new List<List<string>>();

                //　（２）「E■ｒｅｃ－ｃｏｎｄ」が１つ以上入っている形式
                // TODO: 対応したい。現状、into属性が付いている場合、結果を返していない。
                if (bExists_Into)
                {
                }
                else
                {
                    // 仮。動かないと思う。
                    //List<XenonFielddefinition> out_O_NewFldDefList_Dammy = new List<XenonFielddefinition>();
                    //TableUtil.SelectFieldListList(
                    //    out sFieldListList,
                    //    out out_O_NewFldDefList_Dammy,
                    //    selectSt.List_SName_SelectField,//                        sNewFieldNameList,
                    //    selectSt.E_Ｗｈｅｒｅ,
                    //    o_FromTable,
                    //    log_Reports
                    //    );
                }
            }






            //
            // （４００）制約の判定
            //
            this.E_Execute_P4(
                sFieldListList.Count,
                this.EnumHitcount,
                log_Reports
                );
            if (!log_Reports.Successful)
            {
                // エラーが出ていたら、さっさと抜ける。
                sResult = "＜「E■ｆ－ｃｅｌｌ」エラー401＞";
                goto gt_EndMethod;
            }


            //
            // （５００）結果
            StringBuilder sb = new StringBuilder();
            foreach (List<string> sList_Field in sFieldListList)
            {
                // 先頭フィールド
                if (0 < sList_Field.Count)
                {
                    string sChild = sList_Field[0];

                    // TODO:制約を付けたい。
                    //eChild.SetValidation(this.requestItems);

                    sb.Append(sChild);
                }
                else
                {
                    // エラー
                    sResult = "＜「E■ｆ－ｃｅｌｌ」エラー501：該当レコードなし＞";
                    goto gt_Error_ZeroField;
                }
            }
            sResult = sb.ToString();




            // into="" 属性が指定されていれば、結果をテーブルとして保持したい。
            if (bExists_Into)
            {

                // into句のテーブルの、情報を読み込みます。
                XenonTable o_IntoTableInfoOnly;
                //ystem.Console.WriteLine(Info_E.LibraryName + ":E_FcellImpl#Expression_ExecuteMain: into属性が指定されています。e_Into=[" + selectSt.Expression_Into.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]");
                o_IntoTableInfoOnly = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(selectSt.Expression_Into, true, log_Reports);

                if (!log_Reports.Successful)
                {
                    // エラーが出ていたら、さっさと抜ける。
                    sResult = "＜「E■ｆ－ｃｅｌｌ」エラー601＞";
                    goto gt_EndMethod;
                }


                // テーブルから、指定の列だけを抽出したサブ・テーブルを作ります。
                XenonTable o_NewTable = Utility_Table.CreateSubTableBySelect(
                    o_FromTable.Name + "のサブテーブル＜E_FcellImpl.cs＞",
                    selectSt.List_SName_SelectField,
                    o_IntoTableInfoOnly.Expression_Filepath_ConfigStack,
                    selectSt.EnumWherelogic,
                    selectSt.List_Recordcondition,
                    o_FromTable,
                    log_Reports
                    );

                if (!log_Reports.Successful)
                {
                    // エラーが出ていたら、さっさと抜ける。
                    sResult = "＜「E■ｆ－ｃｅｌｌ」エラー602＞";
                    goto gt_EndMethod;
                }




                // 作ったテーブルをセット。
                //
                // 新規なら追加、既存なら上書き。
                this.Owner_MemoryApplication.MemoryTables.Dictionary_XenonTable[selectSt.Expression_Into.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports)] = o_NewTable;

                if (!log_Reports.Successful)
                {
                    // エラーが出ていたら、さっさと抜ける。
                    sResult = "＜「E■ｆ－ｃｅｌｌ」エラー603＞";
                    goto gt_EndMethod;
                }

            }


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotFoundRecordSet:
            sResult = "＜「E■ｆ－ｃｅｌｌ」エラー１９２：該当レコードなし＞";
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToMessage_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6012;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_ZeroField:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, sFieldListList.Count.ToString(), log_Reports);//行数
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToMessage_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6013;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return sResult;
        }


        /// <summary>
        /// 再帰関数。
        /// 
        /// （Ａ）「E■＠ｗｈｅｒｅ」のｒｅｃ－ｃｏｎｄリストを抽出。
        /// （Ｂ）「E■ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｒｅｃ－ｃｏｎｄ；”」のｒｅｃ－ｃｏｎｄリストを抽出。
        /// </summary>
        /// <param name="dst_Recordcondition"></param>
        /// <param name="src_E_ReccondParent"></param>
        /// <param name="log_Reports"></param>
        private void Execute_ParseChildRecordconditionList(
            List<Recordcondition> list_Reccond_Dst,
            Expression_Node_StringImpl parent_Expression_ReccondList_Src,//「E■＠ｗｈｅｒｅ」か、「E■ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｒｅｃ－ｃｏｎｄ；”」。子に「E■ｒｅｃ－ｃｏｎｄ」のリストを持つもの。
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "Execute_ParseChildReccndList",log_Reports);
            //
            //

            string err_SOpe;

            //　「E■＠ｗｈｅｒｅ」の子要素＜ｒｅｃ－ｃｏｎｄ＞。
            //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#Execute_ParseChildReccndList:　src_E_ReccondParent＝[" + src_E_ReccondListParent.Cur_Configurationtree.Name_Node + "]　属性数＝[" + src_E_ReccondListParent.E_AttrDic.Count + "]　子要素数＝[" + src_E_ReccondListParent.CountChildNodes + "]");
            foreach (Expression_Node_String ec_Reccond_Src in parent_Expression_ReccondList_Src.List_Expression_Child.SelectList(EnumHitcount.Unconstraint, log_Reports))
            {
                // logic属性=""
                EnumLogic enumLogic = EnumLogic.None;
                // field属性="" （logic属性の指定がない場合、必須）
                string sField = "";
                // ope属性=""
                string sOpe = "";
                // value属性=""
                string sValue = "";
                // 属性
                Expression_Node_String ec_Description = null;

                //
                //
                //
                //

                bool bRead_Logic = false;
                bool bRead_Field = false;
                bool bRead_Ope = false;
                bool bRead_Value = false;
                bool bRead_Description = false;

                if (NamesNode.S_FNC == ec_Reccond_Src.Cur_Configurationtree.Name)
                {
                    string sFncName;
                    ec_Reccond_Src.TrySelectAttribute(out sFncName, PmNames.S_NAME.Name_Pm, EnumHitcount.One, log_Reports);
                    if (sFncName == NamesFnc.S_REC_COND)
                    {
                        //
                        // 【2012-05-30】
                        // ＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｒｅｃ－ｃｏｎｄ；”＞
                        //

                        //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: 「E■ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｒｅｃ－ｃｏｎｄ；”」を解析したい。 子要素数=[" + src_E_Reccond.CountChildNodes + "] 属性数=[" + src_E_Reccond.E_AttrDic.Count + "]");

                        //
                        //
                        ec_Reccond_Src.Dictionary_Expression_Attribute.ForEach(
                            delegate(string sPmName, Expression_Node_String ec_Attr2, ref bool bBreak)
                            {
                                //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#Execute_ParseChildReccndList:　[属性] " + sAttrName + "＝”" + e_Attr.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "”");

                                if (sPmName == PmNames.S_LOGIC.Name_Pm)
                                {
                                    // 「＠ｌｏｇｉｃ」値
                                    enumLogic = Utility_Table.LogicStringToEnum(ec_Attr2.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
                                    bRead_Logic = true;
                                }
                                else if (sPmName == PmNames.S_FIELD.Name_Pm)
                                {
                                    // field属性="" （logic属性がない場合は必須）
                                    sField = ec_Attr2.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                                    bRead_Field = true;
                                }
                                else if (sPmName == PmNames.S_OPE.Name_Pm)
                                {
                                    // ope属性=""
                                    sOpe = ec_Attr2.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                                    bRead_Ope = true;
                                }
                                else if (sPmName == PmNames.S_VALUE.Name_Pm)
                                {
                                    // #エラー？ todo: valueは属性にせず、子要素にしたい。
                                    throw new Exception("※valueは属性にせず、子要素にしたい。★★★★★★★★★☆★★★★★★★★★☆★★★★★★★★★☆");
                                    System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#Execute_ParseChildReccndList:　※valueは属性にせず、子要素にしたい。★★★★★★★★★☆★★★★★★★★★☆★★★★★★★★★☆");

                                    // value属性=""
                                    sValue = ec_Attr2.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                                    bRead_Value = true;
                                }
                                else if (sPmName == PmNames.S_DESCRIPTION.Name_Pm)
                                {
                                    throw new Exception("使ってる？");
                                    ec_Description = ec_Attr2;
                                    bRead_Description = true;
                                }
                                else
                                {
                                    // todo:未定義の属性
                                }

                            });

                        // 「E■ｆｎｃ」の子要素。
                        //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: 「E■ｆｎｃ」の子要素数＝[" + src_E_Reccond.CountChildNodes + "]");
                        ec_Reccond_Src.List_Expression_Child.ForEach(
                            delegate(Expression_Node_String ec_Child, ref bool bRemove, ref bool bBreak)
                            {
                                //
                                // 「E■ｆｎｃ」の子要素は、次の４種類。
                                //
                                //━━━━━
                                //ｆ－ｓｔｒ
                                //ｆ－ｖａｒ
                                //ｆｎｃ
                                //━━━━━
                                //
                                //
                                if (
                                    NamesNode.S_F_STR == ec_Child.Cur_Configurationtree.Name ||
                                    NamesNode.S_F_VAR == ec_Child.Cur_Configurationtree.Name ||
                                    NamesNode.S_FNC == ec_Child.Cur_Configurationtree.Name
                                    )
                                {
                                    sValue = ec_Child.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);
                                    bRead_Value = true;
                                    //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: 「E■ｆｎｃ」の子要素=[" + e_Child.Cur_Configurationtree.Name_Node + "]　sValue=[" + sValue + "]");
                                }
                                else
                                {
                                    // #エラー？ todo:未定義の子要素。
                                    System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: 「E■ｆｎｃ」の未定義の子要素=[" + ec_Child.Cur_Configurationtree.Name + "]");
                                }
                            }
                        );
                    }
                    else
                    {
                        // #エラー？ todo:エラー
                        System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: ＜ｆｎｃ＞だったが、「Ｓｆ：ｒｅｃ－ｃｏｎｄ；」ではなかった。");
                    }
                }
                else
                {
                    // #エラー todo:エラー
                    System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: 「E■ｆｎｃ」でも、「E■ｒｅｃ－ｃｏｎｄ」でもなかった。　未定義の子要素＜" + ec_Reccond_Src.Cur_Configurationtree.Name + "＞。");
                }




                Recordcondition dst_Recordcondition = null;

                //
                // 
                //

                if (bRead_Logic)
                {
                    if (EnumLogic.None != enumLogic)
                    {
                        // logic属性がある場合
                        //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: ｒｅｃ－ｃｏｎｄに、logic属性が指定されています。解析。[" + logic.ToString() + "]★★★★★★★★★☆★★★★★★★★★☆★★★★★★★★★☆★★★★★★★★★☆");

                        bool bSuccessful = RecordconditionImpl.TryBuild(
                            out dst_Recordcondition,//作られるオブジェクト
                            enumLogic,//andとかorとか。
                            "",//フィールドID指定なし。
                            this.Cur_Configurationtree.Parent,
                            log_Reports
                            );


                        // 再帰。
                        //
                        // 子要素に＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｒｅｃ－ｃｏｎｄ；”＞がある。
                        this.Execute_ParseChildRecordconditionList(
                            dst_Recordcondition.List_Child,
                            (Expression_Node_StringImpl)ec_Reccond_Src,
                            log_Reports
                            );

                        //
                        // ｒｅｃ－ｃｏｎｄの子要素化を終えます。
                        //
                        goto end_recCond;
                    }
                }

                bool bSuccessful2 = false;
                if (bRead_Field)
                {
                    bSuccessful2 = RecordconditionImpl.TryBuild(out dst_Recordcondition, EnumLogic.None, sField, this.Cur_Configurationtree.Parent, log_Reports);
                }


                if (bSuccessful2)
                {

                    if (bRead_Ope)
                    {
                        // ope属性=""
                        //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: ope解析。[" + sOpe + "]");

                        switch (sOpe)
                        {
                            case Expression_SfcellImpl.S_EQ:
                                dst_Recordcondition.EnumOpe = EnumOpe.Eq;
                                break;

                            case Expression_SfcellImpl.S_NEQ:
                                dst_Recordcondition.EnumOpe = EnumOpe.Neq;
                                break;

                            case Expression_SfcellImpl.S_LT:
                                dst_Recordcondition.EnumOpe = EnumOpe.Lt;
                                break;

                            case Expression_SfcellImpl.S_LTEQ:
                                dst_Recordcondition.EnumOpe = EnumOpe.Lteq;
                                break;

                            case Expression_SfcellImpl.S_GT:
                                dst_Recordcondition.EnumOpe = EnumOpe.Gt;
                                break;

                            case Expression_SfcellImpl.S_GTEQ:
                                dst_Recordcondition.EnumOpe = EnumOpe.Gteq;
                                break;

                            default:
                                // エラー
                                err_SOpe = sOpe;
                                goto gt_Error_UndefinedOpe;
                        }
                    }


                    if (bRead_Value)
                    {
                        // value属性="" TODO:子要素としてのvalue値もあるはず。
                        //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: value解析。["+sValue+"]");

                        dst_Recordcondition.Value = sValue;
                    }


                    if (bRead_Description)
                    {
                        dst_Recordcondition.Expression_Description = ec_Description;
                    }
                }


                //
                // ｒｅｃ－ｃｏｎｄの解析終わり、次は親要素の子要素リストに追加するか否か。
                //
            end_recCond:

                // 親要素に、この要素を追加。
                if (
                    bRead_Logic ||
                    bRead_Field ||
                    bRead_Ope ||
                    bRead_Value ||
                    bRead_Description
                    )
                {
                    if (dst_Recordcondition != null)
                    {
                        // 条件指定がある場合。
                        //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: ★★親要素に、この要素を追加します。");
                        list_Reccond_Dst.Add(dst_Recordcondition);
                    }
                    else
                    {
                        // #エラー？
                        System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: 親要素に、この要素できませんでした。");
                    }
                }
                else
                {
                    // #エラー？
                    System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#Execute_ParseChildReccndList: 親要素に、この要素は追加しません。　bRead_Logic＝[" + bRead_Logic + "]　bRead_Field＝[" + bRead_Field + "]　bRead_Ope＝[" + bRead_Ope + "]　bRead_Value＝[" + bRead_Value + "]　bRead_Description＝[" + bRead_Description + "]");
                }
            }//foreach

            goto gt_EndMethod;
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_UndefinedOpe:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_SOpe, log_Reports);//演算子
                tmpl.SetParameter(2, Log_RecordReportsImpl.ToMessage_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6014;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }


        /// <summary>
        /// セレクト文を作成します。
        /// </summary>
        /// <param name="out_bOneCellSelectCondition"></param>
        /// <param name="selectSt"></param>
        /// <param name="out_bExists_Awhr"></param>
        /// <param name="s_Fcell"></param>
        /// <param name="log_Reports"></param>
        private void E_Execute_P1_CleateSelect(
            out bool bOneCellSelectCondition_Out,//「フィールド名　＝　値」の形のみ true。 エラー時もfalse。
            out Selectstatement selectSt,
            out bool bExists_Awhr_Out,//＠ｗｈｅｒｅの有無を返します。エラー時はfalse。
            Configurationtree_Node cf_Fcell,//「S■ｆ－ｃｅｌｌ」。
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "E_Execute_P1_CleateSelect",log_Reports);
            //
            //


            //
            // 空っぽのセレクト文。
            //
            bExists_Awhr_Out = false;
            bOneCellSelectCondition_Out = false;
            selectSt = new SelectstatementImpl(this, cf_Fcell);
            Expression_Node_StringImpl ec_Awhr_Src = null;//子「E■ｗｈｅｒｅ」



            //
            // （１）ｓｅｌｅｃｔ＝”☆”
            //　　　　抽出する列名のリスト。
            //
            Expression_Node_String ec_Aselect = null;//ソース情報利用のE
            if (log_Reports.Successful)
            {
                this.TrySelectAttribute(out ec_Aselect, PmNames.S_SELECT.Name_Pm, EnumHitcount.One, log_Reports);
            }

            if (log_Reports.Successful)
            {
                selectSt.List_SName_SelectField = new CsvTo_ListImpl().Read(ec_Aselect.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports));
            }

            //
            // （２）into 属性
            //
            if (log_Reports.Successful)
            {
                Expression_Node_String ec_Into;//ソース情報利用のE
                bool bHit = this.TrySelectAttribute(out ec_Into, "into", EnumHitcount.One_Or_Zero, log_Reports);
                if (bHit)
                {
                    selectSt.Expression_Into = ec_Into;
                }
            }


            //
            // （３）「E■＠ｗｈｅｒｅ」。無いものもある。
            //
            if (log_Reports.Successful)
            {
                Expression_Node_String ec_Awhr1_Src;
                this.List_Expression_Child.ForEach(delegate(Expression_Node_String e_Child, ref bool bRemove, ref bool bBreak)
                {
                    string sValue;
                    e_Child.TrySelectAttribute(out sValue, PmNames.S_NAME.Name_Pm, EnumHitcount.One, log_Reports);

                    if (NamesNode.S_FNC == e_Child.Cur_Configurationtree.Name &&
                        NamesFnc.S_WHERE == sValue)
                    {
                        ec_Awhr1_Src = e_Child;// Expression_Node_StringImpl である必要がある。E_String_AtomImplではダメ。

                        if (ec_Awhr1_Src is Expression_Node_StringImpl)
                        {
                            ec_Awhr_Src = (Expression_Node_StringImpl)ec_Awhr1_Src;
                        }
                        else
                        {
                            // エラー。
                            goto gt_Error_AtomWhr2;
                        }

                        bBreak = true;
                    }


                    goto gt_EndMethod2;

                // エラー。
                gt_Error_AtomWhr2:
                    {
                        Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();

                        Expression_Leaf_StringImpl ec_Leaf = (Expression_Leaf_StringImpl)ec_Awhr1_Src;
                        tmpl.SetParameter(1, ec_Leaf.List_Expression_Child.Count.ToString(), log_Reports);//子要素の数

                        tmpl.SetParameter(2, Log_RecordReportsImpl.ToMessage_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                        this.Owner_MemoryApplication.CreateErrorReport("Er:6015;", tmpl, log_Reports);
                    }
                    goto gt_EndMethod2;

                    //
                gt_EndMethod2:
                    ;
                });

                if (null != ec_Awhr_Src)
                {
                    // 子「E■ｗｈｅｒｅ」あり。
                    bExists_Awhr_Out = true;
                }
                else
                {
                    // 正常。無いこともあります。
                    bExists_Awhr_Out = false;
                    Configurationtree_Node cf_Node = new Configurationtree_NodeImpl(this + ":Ｗｈｅｒｅ属性該当なし", null);
                    ec_Awhr_Src = new Expression_Node_StringImpl(this, cf_Node);
                }
            }
            else
            {
                // エラーがあるのでさっさと抜ける。
                bOneCellSelectCondition_Out = false;
                bExists_Awhr_Out = false;
                goto gt_EndMethod;
            }




            //
            // （３）ｒｅｑｕｉｒｅｄ＝”★”
            // 　　　レコードが１件以上ヒットすることが必須か。"true","TRUE"等。
            //
            if (log_Reports.Successful)
            {
                // ＜ｆ－ｃｅｌｌ　ｒｅｑｕｉｒｅｄ＝”☆”＞を使う。

                //
                // ＜ｆ－ｃｅｌｌ＞は　ｒｅｑｕｉｒｅｄ属性を持たないはず。
                // ＜ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｗｈｅｒｅ；”＞のｒｅｑｕｉｒｅｄ引数が登録される？
                //
                // 

                string sRequired;
                bool bHit = this.TrySelectAttribute(out sRequired, PmNames.S_REQUIRED.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                if (bHit)
                {
                    selectSt.Required = sRequired;
                }
                else
                {
                    //
                    // ＜ｆ－ｃｅｌｌ＞が　ｒｅｑｕｉｒｅｄ属性を持っていないとき。
                    //
                    //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#E_Execute_P1_CleateSelect: ＜ｆ－ｃｅｌｌ＞が　ｒｅｑｕｉｒｅｄ属性を持っていないとき。");

                    //
                    // ｗｈｅｒｅ属性で「E■ｗｈｅｒｅ」（ｆｎｃ）を持っているはず。（無条件のときは持っていない）
                    //
                    Expression_Node_String ec_Whr;//属性利用
                    bool bHit2 = this.TrySelectAttribute(out ec_Whr, PmNames.S_WHERE.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                    if (bHit2)
                    {
                        bool bHit3 = ec_Whr.TrySelectAttribute(out sRequired, PmNames.S_REQUIRED.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                        if (bHit3)
                        {
                            selectSt.Required = sRequired;
                            //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#E_Execute_P1_CleateSelect: ＜ｆ－ｃｅｌｌ＞が　ｒｅｑｕｉｒｅｄ属性を持っていなかったので、ｗｈｅｒｅのｒｅｑｕｉｒｅｄ属性から取得した。[" + selectSt.Required + "]");
                        }
                        else
                        {
                            // ｗｈｅｒｅのｒｅｑｕｉｒｅｄ設定が未指定。

                            // #エラー
                            System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#E_Execute_P1_CleateSelect: ＜ｆ－ｃｅｌｌ＞が　ｒｅｑｕｉｒｅｄ属性を持っていなかったので、ｗｈｅｒｅのｒｅｑｕｉｒｅｄ属性から取得しようとしたが、ｗｈｅｒｅのｒｅｑｕｉｒｅｄは未設定だった。[" + selectSt.Required + "]");
                        }
                    }
                    else
                    {
                        //
                        // ＜ｆ－ｃｅｌｌ＞が、ｗｈｅｒｅ属性を持っていない。　【正常】
                        //

                        //// ｒｅｑｕｉｒｅｄ設定が未指定。

                        //// #エラー
                        //System.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#E_Execute_P1_CleateSelect: ＜ｆ－ｃｅｌｌ＞が　ｒｅｑｕｉｒｅｄ属性を持っていなかったので、ｗｈｅｒｅのｒｅｑｕｉｒｅｄ属性から取得しようとしたが、ｗｈｅｒｅは未設定だった。[" + selectSt.Required + "]");

                        //if (bDbg1)
                        //{
                        //    System.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#E_Execute_P1_CleateSelect:┌────────┐this.E_AttrDic.Count=[" + this.E_AttrDic.Count + "]");
                        //    this.E_AttrDic.Each_E_Nodes(delegate(string sName, Expression_Node_String e_Child, ref bool bBreak)
                        //    {
                        //        System.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#E_Execute_P1_CleateSelect:　[" + sName + "]＝[" + e_Child.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]");
                        //    });
                        //    System.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#E_Execute_P1_CleateSelect:└────────┘");
                        //}
                    }
                }
            }



            //
            // （４）テーブル名。"Ut:モンスター表"等。
            //
            if (log_Reports.Successful)
            {
                // ＜ｆ－ｃｅｌｌ　ｆｒｏｍ＝”☆”＞を使う。
                Expression_Node_String ec_From;//ソース情報利用
                bool bHit = this.TrySelectAttribute(out ec_From, PmNames.S_FROM.Name_Pm, EnumHitcount.One, log_Reports);
                if (bHit)
                {
                    selectSt.Expression_From = ec_From;
                }

                // テーブル名は必須。
                if ("" == selectSt.Expression_From.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim())
                {
                    //
                    // エラー。
                    //dst_Rs = null;
                    goto gt_Error_EmptyTableName;
                }
            }





            //
            //　「E■ｆ－ｃｅｌｌ」は、子要素を持たない。
            //
            //　「E■ｆ－ｃｅｌｌ」には、次の属性がある。
            //　（１）「E■＠ｗｈｅｒｅ」
            //
            //
            //　「E■＠ｗｈｅｒｅ」は、次の子要素のリストがある。
            //　・「E■ｆｎｃ　ｎａｍｅ＝”Ｓｆ：ｒｅｃ－ｃｏｎｄ；”」
            //

            //
            // ｆ－ｃｅｌｌの子要素の数は、ｗｈｅｒｅ要素１つ、または 0 が正しい。
            //
            if (log_Reports.Successful)
            {
                // 子要素。
                List<Expression_Node_String> ecList = this.List_Expression_Child.SelectList(EnumHitcount.Unconstraint, log_Reports);
                //if (0 < e_List.Count)
                if (1 < ecList.Count)
                {
                    goto gt_Error_ExistsFcellChild;
                }
            }

            //
            // （２）探したいキー値の有無。"1000"等。
            if (log_Reports.Successful)
            {

                // key属性（＠ｗｈｅｒｅ）、record-set-load-ｆｒｏｍ属性のどちらかが書かれているはず。

                if (
                    bExists_Awhr_Out ||
                    "" != selectSt.Expression_Where_RecordSetLoadFrom.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim()
                    )
                {
                    //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#E_Execute_PP1_FcellToSelectSt:　「E■ａ－ｗｈｅｒｅ　keyField＝”☆”」は無かったが、「子E■ｒｅｃ－ｃｏｎｄ」要素はあった場合。");

                    // 次へ進む。
                }
                else
                {
                    // エラー。key値（＠ｗｈｅｒｅ）も、record-set-load-ｆｒｏｍ属性もない。
                    goto gt_Error_EmptyKey;
                }
            }

            //
            //　＜ｆ－ｃｅｌｌ＞が、ｋｅｙＦｉｅｌｄ＝”★”属性（"ID"などの値）を持つのは、R4-100版で廃止されました。
            //







            //
            // （５）あれば、「E■＠ｗｈｅｒｅ」の解析。（2012-02-07）
            //
            if (log_Reports.Successful)
            {
                if (bExists_Awhr_Out)
                {
                    // 「E■＠ｗｈｅｒｅ」条件が付いているとき。


                    // 「E■＠ｗｈｅｒｅ」の ｌｏｇｉｃ属性を取得しておく。
                    {
                        string sLogic;
                        bool bHit = ec_Awhr_Src.TrySelectAttribute(out sLogic, PmNames.S_LOGIC.Name_Pm, EnumHitcount.One_Or_Zero, log_Reports);
                        if (bHit)
                        {
                            selectSt.EnumWherelogic = Utility_Table.LogicStringToEnum(sLogic);
                            //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#E_Execute_P1_SelectSt: ｗｈｅｒｅ要素のlogic属性もきちんと読み取り。[" + sAwhrLogic + "]");
                        }
                    }

                    this.Execute_ParseChildRecordconditionList(
                        selectSt.List_Recordcondition,
                        ec_Awhr_Src,
                        log_Reports
                        );
                }
                else
                {
                    // 「E■＠ｗｈｅｒｅ」条件が無い場合。

                    // #警告。正常。
                    System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#E_Execute_P1_SelectSt: 条件がないタイプ（ｗｈｅｒｅを持たない）です。親ノード=" + this.Cur_Configurationtree.Parent);
                }
            }




            //
            // 「E■＠ｗｈｅｒｅ」は、２種類に判別。
            //　（１）「E■ｒｅｃ－ｃｏｎｄ」が１つだけ入っている形式
            //　（２）「E■ｒｅｃ－ｃｏｎｄ」が１つ以上入っている形式
            //
            if (log_Reports.Successful)
            {
                if (0 == selectSt.List_Recordcondition.Count())
                {
                    //
                    // ０個なら、無条件。
                    //
                }
                else if (1 == selectSt.List_Recordcondition.Count())
                {
                    //
                    // 「フィールド値＝値」の形の条件式かどうかを調べます。
                    //

                    // ・＜ｒｅｃ－ｃｏｎｄ＞が１つ
                    Recordcondition firstReccond = selectSt.List_Recordcondition[0];
                    if (null == firstReccond)
                    {
                        // #エラー？ TODO:エラー？
                        System.Console.WriteLine(Info_Expr.Name_Library + ":" + this.GetType().Name + "#E_Execute_P1_SelectSt: ｒｅｃ－ｃｏｎｄリストにヌルが入っていた。エラー？");

                        // 条件ハズレ。
                        goto end_conditionSpec;
                    }

                    // ・その＜ｒｅｃ－ｃｏｎｄ＞は logic属性を持たない。
                    if (EnumLogic.None != firstReccond.EnumLogic)
                    {
                        // 条件ハズレ。
                        goto end_conditionSpec;
                    }

                    // ｆｉｅｌｄ属性には１つのフィールド名が書かれている。（ｓｅｌｅｃｔではないので、そうでなければエラー）
                    List<string> sList_FieldName = new CsvTo_ListImpl().Read(firstReccond.Name_Field);
                    if (1 != sList_FieldName.Count)
                    {
                        // 条件ハズレ。
                        goto end_conditionSpec;
                    }

                    // ｖａｌｕｅを持つ。
                    if ("" == firstReccond.Value.Trim())
                    {
                        // 条件ハズレ。
                        goto end_conditionSpec;
                    }

                    //「＝」で結ばれている条件のもの。
                    if (EnumOpe.Eq != firstReccond.EnumOpe)
                    {
                        // 条件ハズレ。
                        goto end_conditionSpec;
                    }

                    // 適合。「フィールド名＝値」の形の条件式。セル１つが選ばれる。
                    bOneCellSelectCondition_Out = true;
                }
                else
                {
                    // 条件ハズレ。
                }
            }

        end_conditionSpec:

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_ExistsFcellChild:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, this.Cur_Configurationtree.Name, log_Reports);//設定ノード名

                List<Expression_Node_String> e_List = this.List_Expression_Child.SelectList(EnumHitcount.Unconstraint, log_Reports);
                tmpl.SetParameter(2, e_List.Count.ToString(), log_Reports);//子要素の数

                Log_TextIndented s = new Log_TextIndentedImpl();
                foreach (Expression_Node_String ec_Child in e_List)
                {
                    s.Append("Expr[" + ec_Child.Cur_Configurationtree.Name + "]");
                    s.Newline();
                }
                tmpl.SetParameter(3, s.ToString(), log_Reports);//要素のリスト

                tmpl.SetParameter(4, Log_RecordReportsImpl.ToMessage_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6016;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_EmptyKey:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, bExists_Awhr_Out.ToString(), log_Reports);//Where句の有無
                tmpl.SetParameter(2, selectSt.Expression_Where_RecordSetLoadFrom.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim(), log_Reports);//RecordSetLoadFrom属性
                tmpl.SetParameter(3, this.Dictionary_Expression_Attribute.Count.ToString(), log_Reports);//属性の数

                Log_TextIndented s1 = new Log_TextIndentedImpl();
                this.Dictionary_Expression_Attribute.ForEach(delegate(string sName3, Expression_Node_String e_Attr3, ref bool bBreak)
                {
                    s1.Append("Attribute[" + sName3 + "]=Expr[" + e_Attr3.Cur_Configurationtree.Name + "]　値＝[" + e_Attr3.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]");
                    s1.Newline();
                });
                tmpl.SetParameter(4, s1.ToString(), log_Reports);//属性リスト

                tmpl.SetParameter(5, this.Dictionary_Expression_Attribute.Count.ToString(), log_Reports);//子要素の数

                Log_TextIndented s2 = new Log_TextIndentedImpl();
                this.List_Expression_Child.ForEach(delegate(Expression_Node_String e_Child, ref bool bRemove, ref bool bBreak)
                {
                    s2.Append("子　[" + e_Child.Cur_Configurationtree.Name + "]＝[" + e_Child.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports) + "]");
                    s2.Newline();
                });
                tmpl.SetParameter(6, s2.ToString(), log_Reports);//子要素リスト

                tmpl.SetParameter(7, Log_RecordReportsImpl.ToMessage_Configurationtree(this.Cur_Configurationtree), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6017;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_EmptyTableName:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToMessage_Configurationtree(cf_Fcell), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6018;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }




        /// <summary>
        /// セレクト文を指定することで、レコードセットを取得。
        /// </summary>
        /// <param name="log_Reports"></param>
        /// <returns>該当がなければヌル。</returns>
        private RecordSet E_Execute_P2_Select(
            bool bExists_Awhr,
            Selectstatement selectSt,
            Configurationtree_Node parent_Cf_Query,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "E_Execute_P2_Select",log_Reports);
            //
            //

            RecordSet reslt_Rs;








            bool bLoad = false;

            //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#E_Execute: （＜f-cell＞開始１０）");

            //
            // 一時記憶から、レコードセットのロードをするか否か。
            {
                {
                    Expression_Node_String ec_Awhr_RecordSetLoadFrom;//ソース情報利用
                    bool bHit = this.TrySelectAttribute(
                         out ec_Awhr_RecordSetLoadFrom,
                        NamesNode.S_RECORD_SET_LOAD_FROM,
                        EnumHitcount.One_Or_Zero,
                        log_Reports //null
                        );

                    selectSt.Expression_Where_RecordSetLoadFrom = ec_Awhr_RecordSetLoadFrom;
                }


                if ("" != selectSt.Expression_Where_RecordSetLoadFrom.Execute_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim())
                {
                    bLoad = true;
                }
            }


            // レコードセットの取得。
            if (bLoad)
            {
                //ystem.Console.WriteLine(Info_E.LibraryName + ":" + this.GetType().Name + "#E_Execute: （２０＿＜f-cell＞）【一時記憶から取得】");

                //
                // 一時記憶からロード。
                P1_RecordSetLoader sel1 = new P1_RecordSetLoader(this.Owner_MemoryApplication);
                reslt_Rs = sel1.P1_Load(
                    selectSt.Expression_Where_RecordSetLoadFrom,
                    this.Cur_Configurationtree,
                    log_Reports
                    );

                // ★空になってる。一時記憶から取り出したい。★★★★★★★★★★★★★★★★★★★★
                //p3_Selectstatement = recordSet.Selectstatement;
                // new ＳｅｌｅｃｔＳｔａｔｅＩｍｐｌ(s_ParentNode);

                //
                // データベースからレコード検索。
                //p3_Selectstatement = this.E_Execute_P0(
                //    nＷｈｅｒｅ_recordSetLoadFrom,
                //    s_ParentNode,
                //    log_Reports
                //    );

                // debug: 一時記憶から読み取った、レコードセットの内容。
                //if (false)
                //{
                //    StringBuilder txt = new StringBuilder();

                //    txt.Append(Info_E.LibraryName + ":" + this.GetType().Name + "#E_Execute: （３０＿＜f-cell＞）【一時記憶から読み取った、レコードセットの内容（Ａ）】");
                //    txt.Append("　fld＝[" + recordSet.Selectstatement.E_Field.E_Execute( log_Reports) + "]");
                //    txt.Append("　ｌｏｏｋｕｐ－ｖａｌｕｅ＝[" + recordSet.Selectstatement.E_Value.E_Execute( log_Reports) + "]");
                //    txt.Append("　required＝[" + recordSet.Selectstatement.E_Required.E_Execute( log_Reports) + "]");
                //    txt.Append("　ｆｒｏｍ＝[" + recordSet.Selectstatement.Expression_From.E_Execute( log_Reports) + "]");
                //    txt.Append("　ｄescription＝[" + recordSet.Selectstatement.Expression_Description.E_Execute( log_Reports) + "]");
                //    txt.Append("　Ｓｔｏｒａｇｅ＝[" + recordSet.Selectstatement.Expression_Storage.E_Execute( log_Reports) + "]");
                //    txt.Append("　ヒット件数＝[" + recordSet.O_Items.Count + "]");

                //    // レコードの内容
                //    foreach (Dictionary<string, XenonValue> oRecord in recordSet.O_Items)
                //    {
                //        txt.Append("　フィールド数＝[" + oRecord.Count + "]");
                //        foreach (string sKey in oRecord.Keys)
                //        {
                //            XenonValue oValue = oRecord[sKey];
                //            txt.Append("　要素＝[" + sKey + ":"+ oValue.Humaninput + "]");
                //        }
                //    }


                //    //ystem.Console.WriteLine( txt.ToString() );
                //}

            }
            else
            {


                XenonTable o_Table = this.Owner_MemoryApplication.MemoryTables.GetXenonTableByName(selectSt.Expression_From, true, log_Reports);
                if (null == o_Table)
                {
                    // エラー。
                    reslt_Rs = null;
                    goto gt_Error_NullTable;
                }
                // レコードセットを用意。
                reslt_Rs = new RecordSetImpl(o_Table);


                bool bExpectedValueRequired;
                {
                    bool parseSuccessful = bool.TryParse(selectSt.Required, out bExpectedValueRequired);
                }




                //
                // 検索実行。
                {
                    List<DataRow> dst_Row = new List<DataRow>();

                    //
                    //
                    //
                    // 条件
                    //
                    //
                    //
                    if (0 < selectSt.List_Recordcondition.Count)
                    {
                        // 条件が指定されている場合。

                        string sKeyFieldName;
                        XenonFielddefinition o_KeyFldDef;
                        string sExpectedValue;
                        P2_ReccondImpl sel2 = new P2_ReccondImpl();
                        sel2.GetFirstAwhrReccond(
                            out sKeyFieldName,
                            out o_KeyFldDef,
                            out sExpectedValue,
                            selectSt.List_Recordcondition,
                            o_Table,
                            log_Reports
                            );

                        // TODO:セル型でない場合、キーフィールド名がないこともある。

                        SelectPerformerImpl sp = new SelectPerformerImpl();
                        sp.Select(
                            out dst_Row,
                            sKeyFieldName,
                            sExpectedValue,
                            bExpectedValueRequired,
                            o_KeyFldDef,
                            o_Table.DataTable,
                            parent_Cf_Query,
                            log_Reports
                            );
                    }
                    else
                    {
                        // 条件が指定されていない場合。

                        SelectPerformerImpl sp = new SelectPerformerImpl();
                        sp.Select(
                            out dst_Row,
                            bExpectedValueRequired,
                            o_Table.DataTable,
                            parent_Cf_Query,
                            log_Reports
                            );
                    }



                    reslt_Rs.AddList(dst_Row, log_Reports);
                    if (!log_Reports.Successful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullTable:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, Log_RecordReportsImpl.ToMessage_Configurationtree(parent_Cf_Query), log_Reports);//設定位置パンくずリスト

                this.Owner_MemoryApplication.CreateErrorReport("Er:6019;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return reslt_Rs;
        }

        /// <summary>
        /// 制約の判定。
        /// </summary>
        /// <param name="log_Reports"></param>
        /// <returns></returns>
        private void E_Execute_P4(
            int nHitsCount,//eRecordList.Count
            EnumHitcount hits,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "E_Execute_P4",log_Reports);
            //
            //

            switch (hits)
            {
                case EnumHitcount.One:
                    if (1 != nHitsCount)
                    {
                        //
                        // エラー。
                        goto gt_Error_NotOne;
                        // オブジェクトに設定されているプロパティーが想定しない操作と判断。
                    }
                    break;

                case EnumHitcount.One_Or_Zero:
                    if (!(1 == nHitsCount || 0 == nHitsCount))
                    {
                        //
                        // エラー。
                        goto gt_Error_NotOneOrZero;
                        // オブジェクトに設定されているプロパティーが想定しない操作と判断。
                    }
                    break;

                case EnumHitcount.First_Exist_Or_Zero:
                    {
                        //
                        // 特にエラーとなる条件はありません。
                    }
                    break;

                case EnumHitcount.Exists:
                    if (nHitsCount < 1)
                    {
                        //
                        // エラー。
                        goto gt_Error_NotExists;
                        // オブジェクトに設定されているプロパティーが想定しない操作と判断。
                    }
                    break;

                case EnumHitcount.Unconstraint:
                    {
                        //
                        // 特にエラーとなる条件はありません。
                    }
                    break;

                default:
                    {
                        //
                        // エラー。
                        goto gt_Error_UndefinedEnum;
                        // オブジェクトに設定されているプロパティーが想定しない操作と判断。
                    }
                //break;
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NotOne:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, nHitsCount.ToString(), log_Reports);//検索ヒット数

                this.Owner_MemoryApplication.CreateErrorReport("Er:6020;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotOneOrZero:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, nHitsCount.ToString(), log_Reports);//検索ヒット数

                this.Owner_MemoryApplication.CreateErrorReport("Er:6021;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_NotExists:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, nHitsCount.ToString(), log_Reports);//検索ヒット数

                this.Owner_MemoryApplication.CreateErrorReport("Er:6022;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_UndefinedEnum:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, hits.ToString(), log_Reports);//要求した検索ヒット区分

                this.Owner_MemoryApplication.CreateErrorReport("Er:6023;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return;
        }

        //────────────────────────────────────────
        #endregion

    }
}
