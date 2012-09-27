using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;//DataRow
using Xenon.Syntax;
using Xenon.Table;//

namespace Xenon.Operating
{
    public class XTo_KeyconfigImpl
    {



        #region アクション
        //────────────────────────────────────────

        public void XTo(
            out KeyconfigImpl out_Keycnf,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            Log_Reports log_Reports_Load = new Log_ReportsImpl(pg_Method);
            pg_Method.BeginMethod(Info_Operating.SName_Library, this, "XToO",log_Reports_Load);
            //
            //

            out_Keycnf = new KeyconfigImpl();

            CsvTo_XenonTableImpl csvTo = new CsvTo_XenonTableImpl();
            Request_ReadsTable oRequest_TableReads = new Request_ReadsTableImpl();
            {
                Givechapterandverse_NodeImpl cf_ConfigStack = new Givechapterandverse_NodeImpl(Info_Operating.SName_Library + ":" + this.GetType().Name + "#<init>:",null);
                Givechapterandverse_Filepath cf_Fpath = new Givechapterandverse_FilepathImpl("ファイルパス出典未指定L03_1", cf_ConfigStack);

                cf_Fpath.InitPath(
                    "Editor-config/GAME_PAD/Key-config.csv",
                    log_Reports
                    );
                Expression_Node_Filepath ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath);
                oRequest_TableReads.Expression_Filepath = ec_Fpath;

                if (!log_Reports.BSuccessful)
                {
                    // エラー
                    goto gt_EndMethod;
                }
            }

            XenonTableformat o_TableFormat = new XenonTableformatImpl();
            out_Keycnf.O_Table_Keycnf = csvTo.Read(
                oRequest_TableReads,
                o_TableFormat,
                true,
                log_Reports
                );

            if (!log_Reports.BSuccessful)
            {
                // エラー
                goto gt_EndMethod;
            }

            //
            // テーブルを上から１行ずつ読んでいきます。
            //
            foreach (DataRow dataRow in out_Keycnf.O_Table_Keycnf.DataTable.Rows)
            {
                //NO	ID	Expl	PLAYER	BEFORE	AFTER

                // プレイヤー番号
                int nPlayer;
                {
                    XenonValue_IntImpl o_Player = (XenonValue_IntImpl)dataRow["PLAYER"];
                    if (XenonValue_IntImpl.TryParse(
                        o_Player,
                        out nPlayer,
                        EnumOperationIfErrorvalue.Error,
                        0,
                        log_Reports
                        ))
                    {
                    }

                    if (!log_Reports.BSuccessful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }
                }

                // BEFORE
                EnumGamepadkeyIx enumGmkeyArray;
                {
                    string sBefore;
                    string sDebug1 = "";
                    string sDebug2 = "";
                    XenonValue_StringImpl o_Before = (XenonValue_StringImpl)dataRow["BEFORE"];

                    if (XenonValue_StringImpl.TryParse(
                        o_Before,
                        out sBefore,
                        sDebug1,
                        sDebug2,
                        pg_Method,
                        log_Reports
                        ))
                    {
                    }

                    if (!log_Reports.BSuccessful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }


                    switch (sBefore)
                    {
                        case "Up":
                            enumGmkeyArray = EnumGamepadkeyIx.Up;
                            break;
                        case "Right":
                            enumGmkeyArray = EnumGamepadkeyIx.Right;
                            break;
                        case "Down":
                            enumGmkeyArray = EnumGamepadkeyIx.Down;
                            break;
                        case "Left":
                            enumGmkeyArray = EnumGamepadkeyIx.Left;
                            break;
                        case "0":
                            enumGmkeyArray = EnumGamepadkeyIx.B0;
                            break;
                        case "1":
                            enumGmkeyArray = EnumGamepadkeyIx.B1;
                            break;
                        case "2":
                            enumGmkeyArray = EnumGamepadkeyIx.B2;
                            break;
                        case "3":
                            enumGmkeyArray = EnumGamepadkeyIx.B3;
                            break;
                        case "4":
                            enumGmkeyArray = EnumGamepadkeyIx.B4;
                            break;
                        case "5":
                            enumGmkeyArray = EnumGamepadkeyIx.B5;
                            break;
                        case "6":
                            enumGmkeyArray = EnumGamepadkeyIx.B6;
                            break;
                        case "7":
                            enumGmkeyArray = EnumGamepadkeyIx.B7;
                            break;
                        default:
                            // エラー
                            enumGmkeyArray = EnumGamepadkeyIx.B0;
                            break;
                    }
                }


                // AFTER
                EnumGamepadkeyBit gmkeyPushEnum;
                {
                    string sAfter;
                    string sDebug1 = "";
                    string sDebug2 = "";
                    XenonValue_StringImpl o_Before = (XenonValue_StringImpl)dataRow["AFTER"];

                    if (XenonValue_StringImpl.TryParse(
                        o_Before,
                        out sAfter,
                        sDebug1,
                        sDebug2,
                        pg_Method,
                        log_Reports
                        ))
                    {
                    }

                    if (!log_Reports.BSuccessful)
                    {
                        // エラー
                        goto gt_EndMethod;
                    }

                    switch (sAfter)
                    {
                        case "Up":
                            gmkeyPushEnum = EnumGamepadkeyBit.Up;
                            break;
                        case "Right":
                            gmkeyPushEnum = EnumGamepadkeyBit.Right;
                            break;
                        case "Down":
                            gmkeyPushEnum = EnumGamepadkeyBit.Down;
                            break;
                        case "Left":
                            gmkeyPushEnum = EnumGamepadkeyBit.Left;
                            break;
                        case "A":
                            gmkeyPushEnum = EnumGamepadkeyBit.A;
                            break;
                        case "B":
                            gmkeyPushEnum = EnumGamepadkeyBit.B;
                            break;
                        case "X":
                            gmkeyPushEnum = EnumGamepadkeyBit.X;
                            break;
                        case "Y":
                            gmkeyPushEnum = EnumGamepadkeyBit.Y;
                            break;
                        case "L":
                            gmkeyPushEnum = EnumGamepadkeyBit.L;
                            break;
                        case "R":
                            gmkeyPushEnum = EnumGamepadkeyBit.R;
                            break;
                        case "Select":
                            gmkeyPushEnum = EnumGamepadkeyBit.Select;
                            break;
                        case "Start":
                            gmkeyPushEnum = EnumGamepadkeyBit.Start;
                            break;
                        default:
                            // エラー
                            gmkeyPushEnum = EnumGamepadkeyBit.A;
                            break;
                    }
                }

                //
                // 記憶
                //
                KeyconfigPadImpl keycnfPad;
                if (out_Keycnf.Dic_KeyCnf.ContainsKey(nPlayer))
                {
                    keycnfPad = out_Keycnf.Dic_KeyCnf[nPlayer];
                }
                else
                {
                    keycnfPad = new KeyconfigPadImpl();
                }

                keycnfPad.KeyconfigArray[(int)enumGmkeyArray] = gmkeyPushEnum;

                out_Keycnf.Dic_KeyCnf[nPlayer] = keycnfPad;
            }


            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports_Load);
            log_Reports_Load.EndLogging(pg_Method);
            return;
        }

        //────────────────────────────────────────
        #endregion



    }
}
