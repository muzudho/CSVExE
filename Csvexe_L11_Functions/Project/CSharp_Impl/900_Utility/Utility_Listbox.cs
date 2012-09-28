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
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Functions.SName_Library, "Util_Listbox", "BindTableToDataSource",pg_Logging);
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


            XenonTable o_Table = owner_MemoryApplication.MemoryTables.GetXenonTableByName(
                ec_TableName,
                true,
                pg_Logging
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

                uctLst.CustomcontrolListbox1.XenonTable_Datasource = o_Table;
            }
            else
            {
                string sName_Usercontrol = uct.ControlCommon.Expression_Name_Control.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, pg_Logging);

                MessageBox.Show("該当する型のないコントロールでした。[" + sName_Usercontrol + "]", "▲L11エラー③！");
            }

            goto gt_EndMethod;
            //
            //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────
        #endregion



    }
}
