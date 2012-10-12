using System;
using System.Collections.Generic;
using System.Data;//DataRowView
using System.Drawing;//Point,Brush
using System.Linq;
using System.Text;
using System.Windows.Forms;//DrawItemEventArgs

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//MoOpyopyo
using Xenon.Table; //FieldDefinition,IntCellData,DefaultTable


namespace Xenon.Layout
{
    /// <summary>
    /// モンスター・リストボックスの項目の描画。
    /// 
    /// "EXPL-SS"を使って、項目に色を付けるなどの機能に、変更。
    /// 
    /// 例：
    /// データソーステーブルの"EXPL-SS"フィールドにスタイル名（"1"等）が入っており、
    /// スタイルシートテーブルには"NAME"フィールドに"1"、"STYLE"フィールドに"color:red;"が入っている。
    /// </summary>
    public class ListboxItemDrawer_03Impl : ListboxItemDrawer_01Impl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public ListboxItemDrawer_03Impl(MemoryApplication owner_MemoryApplication)
            : base(owner_MemoryApplication)
        {
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        public override string P2b_GetStyleName(
            int nCurIx, CustomcontrolListbox cctLst, Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_LayoutImpl.Name_Library, this, "P2_GetStyleAttrNames",pg_Logging);
            //
            //


            string sResult;

            // 行をセットしたので、取り出されるのも行です。
            // DataRowをセットしましたが、取り出されるのは DataRowViewになるようです。
            DataRowView row = (DataRowView)cctLst.Items[nCurIx];

            // スタイルのNAME値が入っている。
            Value_Humaninput valueH = Utility_Row.GetFieldvalue(
                NamesFld.S_EXPL_SS,
                row.Row,
                false,//該当なしも可
                pg_Logging,
                Info_LayoutImpl.Name_Library+":"+this.GetType().Name+"#P2_:リストボックスのEXPL-SS"
                );
            if (!pg_Logging.Successful)
            {
                // 既エラー。
                sResult = "";
                goto gt_EndMethod;
            }

            if (pg_Logging.Successful)
            {
                // 正常時

                if (null == valueH)
                {
                    sResult = "";
                }
                else
                {
                    sResult = ((Value_Humaninput)valueH).Text;
                }
            }
            else
            {
                sResult = "";
            }

            goto gt_EndMethod;

            //
            //
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
            return sResult;
        }

        //────────────────────────────────────────
        #endregion



    }
}
