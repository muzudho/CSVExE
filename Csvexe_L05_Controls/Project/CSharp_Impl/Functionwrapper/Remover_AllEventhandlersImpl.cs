using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms; //Control
using System.ComponentModel; //EventHandlerList
using System.Reflection;

using Xenon.Syntax;
using Xenon.Middle;//Remover_AllEventhandlers

namespace Xenon.Controls
{
    /// <summary>
    /// 全てのイベントハンドラーを削除します。
    /// </summary>
    public class Remover_AllEventhandlersImpl : Remover_AllEventhandlers
    {



        #region 用意
        //────────────────────────────────────────

        private const string S_EVENTS = "Events";
        private const string S_HEAD = "head";

        private const string S_HANDLER = "handler";
        private const string S_KEY = "key";
        private const string S_NEXT = "next";

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public Remover_AllEventhandlersImpl(
            Control control,
            object/*MemoryApplication*/ owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Remover_AllEventhandlersImpl",log_Reports);
            //
            //

            if (control == null)
            {
                goto gt_Error_NullControl;
            }

            Exception err_Excp;
            Type err_Type_Control = null;
            Type err_Type_EventHandlerListType_Control = null;
            try
            {
                Type type_Control = control.GetType();
                err_Type_Control = type_Control;


                BindingFlags flag = BindingFlags.NonPublic | BindingFlags.Instance;

                PropertyInfo propertyinfo_SrcControlEvents = type_Control.GetProperty(
                    Remover_AllEventhandlersImpl.S_EVENTS, flag);
                this.eventHandlerList_Control = (EventHandlerList)propertyinfo_SrcControlEvents.GetValue(
                    control, null);
                Type type_EventHandlerListType_Control = this.eventHandlerList_Control.GetType();
                err_Type_EventHandlerListType_Control = type_EventHandlerListType_Control;

                this.fieldinfo_Head_EventHandlerListType_Control = type_EventHandlerListType_Control.GetField(
                    Remover_AllEventhandlersImpl.S_HEAD, flag);
            }
            catch (Exception e)
            {
                // エラー
                err_Excp = e;
                goto gt_Error_Exception;
            }

            goto gt_EndMethod;
            //
            //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullControl:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                //%N%なし

                ((MemoryApplication)owner_MemoryApplication).CreateErrorReport("Er:514;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Exception:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_Excp.GetType().Name, log_Reports);//例外の型名
                tmpl.SetParameter(2, err_Excp.Message, log_Reports);//例外メッセージ
                if (null == err_Type_Control)
                {
                    tmpl.SetParameter(3, "ヌル", log_Reports);//コントロールの型名
                }
                else
                {
                    tmpl.SetParameter(3, err_Type_Control.GetType().Name, log_Reports);//コントロールの型名
                }

                if (null == this.eventHandlerList_Control)
                {
                    tmpl.SetParameter(4, "ヌル", log_Reports);//イベントハンドラーリストの型名
                }
                else
                {
                    tmpl.SetParameter(4, this.eventHandlerList_Control.GetType().Name, log_Reports);//イベントハンドラーリストの型名
                }

                ((MemoryApplication)owner_MemoryApplication).CreateErrorReport("Er:527;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// こんなイベントハンドラーを持っていますよ、という情報を作成。
        /// </summary>
        /// <param nFcName="log_Reports"></param>
        private void BuildList(
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "BulidList",log_Reports);
            //
            //

            Exception err_Excp;
            if (log_Reports.Successful)
            {

                try
                {

                    this.dictionary_EventHandler = new Dictionary<object, Delegate[]>();
                    object head = this.fieldinfo_Head_EventHandlerListType_Control.GetValue(
                        this.eventHandlerList_Control);

                    if (head != null)
                    {
                        // クラスの情報を直接見ます。（listEntryType）
                        Type type = head.GetType();

                        BindingFlags flag = BindingFlags.NonPublic | BindingFlags.Instance;

                        // クラスのフィールドの情報を直接見ます。
                        FieldInfo fi_Handler = type.GetField(
                            Remover_AllEventhandlersImpl.S_HANDLER,flag);

                        FieldInfo fi_Key = type.GetField(
                            Remover_AllEventhandlersImpl.S_KEY,flag);

                        FieldInfo fi_Next = type.GetField(
                            Remover_AllEventhandlersImpl.S_NEXT,flag);

                        this.BuildListWalk(
                            head,
                            fi_Handler,
                            fi_Key,
                            fi_Next,
                            owner_MemoryApplication,
                            log_Reports
                            );
                    }
                }
                catch (Exception e)
                {
                    //エラー
                    err_Excp = e;
                    goto gt_Error_AnotherEvent;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_AnotherEvent:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_Excp.GetType().Name, log_Reports);//例外の型名
                tmpl.SetParameter(2, err_Excp.Message, log_Reports);//例外メッセージ

                owner_MemoryApplication.CreateErrorReport("Er:528;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// こんなイベントハンドラーを持っていますよ、という情報を作成。
        /// </summary>
        /// <param nFcName="entry"></param>
        /// <param nFcName="delegateFI"></param>
        /// <param nFcName="keyFI"></param>
        /// <param nFcName="nextFI"></param>
        private void BuildListWalk(
            object head,//entry
            FieldInfo fi_Handler,
            FieldInfo fi_Key,
            FieldInfo fi_Next,
            MemoryApplication owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "BuildListWalk",log_Reports);
            //
            //

            Exception err_Excp = null;
            Delegate err_Dele = null;
            object err_Key = null;
            object err_Next = null;
            if (log_Reports.Successful)
            {

                //.Console.WriteLine(this.GetType().NFcName + "#BuildListWalk: 【実行】");

                try
                {
                    if (null != head)
                    {
                        Delegate dele = (Delegate)fi_Handler.GetValue(head);

                        if (null != dele)
                        {

                            object key = fi_Key.GetValue(head);
                            object next = fi_Next.GetValue(head);

                            err_Dele = dele;
                            err_Key = key;
                            err_Next = next;

                            // デリゲーターの呼び出しリスト
                            Delegate[] listeners = dele.GetInvocationList();

                            if (listeners != null && 0 < listeners.Length)
                            {
                                dictionary_EventHandler.Add(key, listeners);
                            }

                            if (null != next)
                            {
                                this.BuildListWalk(
                                    next,
                                    fi_Handler,
                                    fi_Key,
                                    fi_Next,
                                    owner_MemoryApplication,
                                    log_Reports
                                    );
                            }
                        }

                    }
                }
                catch (Exception e)
                {
                    err_Excp = e;
                    goto gt_Error_Exception;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Exception:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_Excp.GetType().Name, log_Reports);//例外の型名
                tmpl.SetParameter(2, err_Excp.Message, log_Reports);//例外メッセージ
                //fi_Handlerの型名
                if (null == fi_Handler)
                {
                    tmpl.SetParameter(3, "ヌル", log_Reports);
                }
                else
                {
                    tmpl.SetParameter(3, fi_Handler.GetType().Name, log_Reports);
                }
                //err_Deleの型名
                if (null == err_Dele)
                {
                    tmpl.SetParameter(4, "ヌル", log_Reports);
                }
                else
                {
                    tmpl.SetParameter(4, err_Dele.GetType().Name, log_Reports);
                }
                //fi_Keyの型名
                if (null == fi_Key)
                {
                    tmpl.SetParameter(5, "ヌル", log_Reports);
                }
                else
                {
                    tmpl.SetParameter(5, fi_Key.GetType().Name, log_Reports);
                }
                //err_Keyの型名
                if (null == err_Key)
                {
                    tmpl.SetParameter(6, "ヌル", log_Reports);
                }
                else
                {
                    tmpl.SetParameter(6, err_Key.GetType().Name, log_Reports);
                }
                //nextFIの型名
                if (null == fi_Next)
                {
                    tmpl.SetParameter(7, "ヌル", log_Reports);
                }
                else
                {
                    tmpl.SetParameter(7, fi_Next.GetType().Name, log_Reports);
                }
                //err_Nextの型名
                if (null == fi_Next)
                {
                    tmpl.SetParameter(8, "ヌル", log_Reports);
                }
                else
                {
                    tmpl.SetParameter(8, err_Next.GetType().Name, log_Reports);
                }
                
                owner_MemoryApplication.CreateErrorReport("Er:529;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        public void Resume(
            object/*MemoryApplication*/ owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Resume",log_Reports);

            Exception err_Excp;
            if (log_Reports.Successful)
            {

                try
                {

                    if (dictionary_EventHandler == null)
                    {
                        throw new ApplicationException("Events have not been suppressed.");

                    }

                    foreach (KeyValuePair<object, Delegate[]> pair in dictionary_EventHandler)
                    {
                        for (int nX = 0; nX < pair.Value.Length; nX++)
                        {
                            this.eventHandlerList_Control.AddHandler(pair.Key, pair.Value[nX]);
                        }
                    }

                    dictionary_EventHandler = null;
                }
                catch (Exception e)
                {
                    err_Excp = e;
                    goto gt_Error_Exception;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Exception:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_Excp.GetType().Name, log_Reports);//例外の型
                tmpl.SetParameter(2, err_Excp.Message, log_Reports);//例外メッセージ

                ((MemoryApplication)owner_MemoryApplication).CreateErrorReport("Er:530;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 全てのイベントハンドラーを削除します。
        /// </summary>
        public void Suppress(
            object/*MemoryApplication*/ owner_MemoryApplication,
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            pg_Method.BeginMethod(Info_Controls.Name_Library, this, "Suppress",log_Reports);
            //
            //

            Exception err_Excp;
            if (log_Reports.Successful)
            {

                try
                {

                    if (dictionary_EventHandler != null)
                    {
                        throw new ApplicationException("Events are already being suppressed.");
                    }

                    this.BuildList(
                        (MemoryApplication)owner_MemoryApplication,
                        log_Reports
                        );

                    foreach (KeyValuePair<object, Delegate[]> pair in dictionary_EventHandler)
                    {
                        for (int nX = pair.Value.Length - 1; nX >= 0; nX--)
                        {
                            this.eventHandlerList_Control.RemoveHandler(pair.Key, pair.Value[nX]);
                        }
                    }
                }
                catch (Exception e)
                {
                    err_Excp = e;
                    goto gt_Error_Exception;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Exception:
            {
                Builder_TexttemplateP1p tmpl = new Builder_TexttemplateP1pImpl();
                tmpl.SetParameter(1, err_Excp.GetType().Name, log_Reports);//例外の型名
                tmpl.SetParameter(2, err_Excp.Message, log_Reports);//例外メッセージ

                ((MemoryApplication)owner_MemoryApplication).CreateErrorReport("Er:531;", tmpl, log_Reports);
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// イベントハンドラーのリスト。
        /// </summary>
        private EventHandlerList eventHandlerList_Control;

        //────────────────────────────────────────

        /// <summary>
        /// _sourceコントロールのイベントハンドラーリストの型のheadフィールド。
        /// </summary>
        private FieldInfo fieldinfo_Head_EventHandlerListType_Control;

        //────────────────────────────────────────

        /// <summary>
        /// イベントハンドラーのリスト。
        /// </summary>
        private Dictionary<object, Delegate[]> dictionary_EventHandler;

        //────────────────────────────────────────
        #endregion



    }
}
