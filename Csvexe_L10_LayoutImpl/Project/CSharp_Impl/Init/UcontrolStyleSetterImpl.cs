using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Controls;
using Xenon.Middle;//MoOpyopyo,Usercontrol

namespace Xenon.Layout
{
    public class UsercontrolStyleSetterImpl : UsercontrolStyleSetter
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// コントロールにスタイルを設定します。
        /// </summary>
        public void SetupStyle(
            TableUserformconfig fo_Config,
            MemoryApplication moApplication,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_LayoutImpl.Name_Library, this, "SetupStyle",pg_Logging);
            //

            //
            // 全てのフォームの、レイアウトを一時停止。
            //
            this.SuspendLayout(
                fo_Config,
                moApplication,
                pg_Logging
                );

            foreach (RecordUserformconfig fo_Record in fo_Config.List_RecordUserformconfig)
            {
                string sName_Control;
                fo_Record.TryGetString(out sName_Control, NamesFld.S_NAME, true, "", pg_Logging);

                //
                // S → E。 コントロール名
                Expression_Node_StringImpl e_fcName = new Expression_Node_StringImpl(null, fo_Record.Parent_TableUserformconfig.Cur_Configurationtree);
                e_fcName.AppendTextNode(
                    sName_Control,
                    fo_Record.Parent_TableUserformconfig.Cur_Configurationtree,
                    pg_Logging
                    );


                //
                // 名前から、コントロールの取得。
                //
                List<Usercontrol> fcUcList;
                if (pg_Logging.Successful)
                {
                    fcUcList = moApplication.MemoryForms.GetUsercontrolsByName(
                        e_fcName,
                        true,
                        pg_Logging
                        );
                }
                else
                {
                    fcUcList = new List<Usercontrol>();
                }


                //
                // スタイルの設定。
                //
                if (pg_Logging.Successful)
                {
                    Usercontrol fcUc = fcUcList[0];
                    fcUc.SetupStyle(
                        fo_Record,
                        pg_Logging
                        );
                }



                // 「メインウィンドウ」の場合、更にスタイル設定の上書き。
                string sType_Control;
                fo_Record.TryGetString(out sType_Control, NamesFld.S_TYPE, true, "", pg_Logging);
                if (NamesF.S_MAINWND == sType_Control)
                {
                    //
                    // スタイルの設定。
                    //
                    if (pg_Logging.Successful)
                    {
                        moApplication.MemoryForms.Mainwnd_FormWrapping.SetupStyle(
                            fo_Record,
                            pg_Logging
                            );
                    }

                }

            }

            //
            //
            // 全てのフォームの、レイアウトの一時停止を解除。
            //
            //
            this.ResumeLayout(
                fo_Config,
                moApplication,
                pg_Logging
                );


            //
            //
            //
            //
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 全てのフォームの、レイアウトを一時停止。
        /// </summary>
        private void SuspendLayout(
            TableUserformconfig fo_Config,
            MemoryApplication moApplication,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_LayoutImpl.Name_Library, this, "SuspendLayout",pg_Logging);
            //
            //

            foreach (RecordUserformconfig fo_Record in fo_Config.List_RecordUserformconfig)
            {
                string sName_Control;
                fo_Record.TryGetString(out sName_Control, NamesFld.S_NAME, true, "", pg_Logging);

                //
                // S → E。 コントロール名
                Expression_Node_StringImpl e_fcName = new Expression_Node_StringImpl(null, fo_Record.Parent_TableUserformconfig.Cur_Configurationtree);
                e_fcName.AppendTextNode(
                    sName_Control,
                    fo_Record.Parent_TableUserformconfig.Cur_Configurationtree,
                    pg_Logging
                    );


                List<Usercontrol> list_FcUc;
                if (pg_Logging.Successful)
                {
                    list_FcUc = moApplication.MemoryForms.GetUsercontrolsByName(
                        e_fcName,
                        true,
                        pg_Logging
                        );
                }
                else
                {
                    list_FcUc = new List<Usercontrol>();
                }


                if (pg_Logging.Successful)
                {
                    Usercontrol uct = list_FcUc[0];

                    if (uct is UsercontrolWindow)
                    {
                        UsercontrolWindow uctWnd = (UsercontrolWindow)uct;
                        uctWnd.CustomcontrolWindow1.SuspendLayout();
                    }
                }
            }

            //
            //
            //
            //
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 全てのフォームの、レイアウトの一時停止を解除。
        /// </summary>
        private void ResumeLayout(
            TableUserformconfig fo_Config,
            MemoryApplication moApplication,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_LayoutImpl.Name_Library, this, "ResumeLayout",pg_Logging);
            //
            //

            foreach (RecordUserformconfig fo_Record in fo_Config.List_RecordUserformconfig)
            {
                string sName_Control;
                fo_Record.TryGetString(out sName_Control, NamesFld.S_NAME, true, "", pg_Logging);

                //
                // S → E。 コントロール名
                Expression_Node_StringImpl ec_FcName = new Expression_Node_StringImpl(null, fo_Record.Parent_TableUserformconfig.Cur_Configurationtree);
                ec_FcName.AppendTextNode(
                    sName_Control,
                    fo_Record.Parent_TableUserformconfig.Cur_Configurationtree,
                    pg_Logging
                    );


                List<Usercontrol> list_FcUc;
                if (pg_Logging.Successful)
                {
                    list_FcUc = moApplication.MemoryForms.GetUsercontrolsByName(
                        ec_FcName,
                        true,
                        pg_Logging
                        );
                }
                else
                {
                    list_FcUc = new List<Usercontrol>();
                }


                if (pg_Logging.Successful)
                {
                    Usercontrol uct = list_FcUc[0];

                    if (uct is UsercontrolWindow)
                    {
                        UsercontrolWindow uctWnd = (UsercontrolWindow)uct;
                        uctWnd.CustomcontrolWindow1.ResumeLayout(false);
                    }
                }
            }

            //
            //
            //
            //
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────
        #endregion

    }
}
