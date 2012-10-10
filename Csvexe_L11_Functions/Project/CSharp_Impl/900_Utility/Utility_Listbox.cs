using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//Control

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//FormObjectProperties,HEventHandlerWrapper,HFormObject
using Xenon.Table; //FieldDefinition,IntCellData,DefaultTable

namespace Xenon.Functions
{
    public class Utility_Listbox
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 指定のテーブルに、テーブルデータを　データソースとして関連付けます。
        /// </summary>
        /// <param name="oEventName"></param>
        /// <param name="nTableType"></param>
        public static void BindTableToDatasource(
            Usercontrol uct,
            Expression_Node_String ec_TableName,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Functions.Name_Library, "Util_Listbox", "BindTableToDataSource",log_Reports);
            //
            //


            if (null == uct)
            {
                MessageBox.Show(
                    "テーブルデータを、コントロールに対応付けようとしましたが、コントロールがヌルでした。\ntableId=[" + ec_TableName + "]"
                    , "▲L11エラー②！"
                    );
                goto gt_EndMethod;
            }


            TableHumaninput o_Table = owner_MemoryApplication.MemoryTables.GetTableHumaninputByName(
                ec_TableName,
                true,
                log_Reports
                );

            if (null == o_Table)
            {
                // エラー中断。
                goto gt_EndMethod;
            }



            //
            // テーブルに対して行われた変更を、明示的に確定しておきます。
            //
            //↓重い処理。
            //o_Table.DataTable.AcceptChanges();
            //↑これに6003msぐらいかかってる。

            if (uct is UsercontrolListbox)
            {
                UsercontrolListbox uctLst = (UsercontrolListbox)uct;

                //
                // リストボックスのデータ取得元をテーブルとします。
                //

                //
                // データソースをセットします。
                //
                //     （SelectedIndexChangedイベントが６０回ぐらい呼び出される？）
                //
                uctLst.ControlCommon.BAutomaticinputting = true;
                // ↓ 0.2秒ぐらいかかる処理。
                uctLst.DataSource = o_Table.DataTable;
                // ↑ 0.2秒ぐらいかかる処理。
                uctLst.ControlCommon.BAutomaticinputting = false;

                uctLst.CustomcontrolListbox1.TableHumaninput_Datasource = o_Table;
            }
            else
            {
                string sName_Usercontrol = uct.ControlCommon.Expression_Name_Control.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports);

                MessageBox.Show("該当する型のないコントロールでした。[" + sName_Usercontrol + "]", "▲L11エラー③！");
            }

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



    }
}
