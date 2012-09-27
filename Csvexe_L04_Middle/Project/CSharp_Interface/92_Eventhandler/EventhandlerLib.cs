///
/// このファイルには、
/// イベント・ハンドラー関係のロジックを詰め込みました。
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Middle
{



    /// <summary>
    /// イベントの種類。
    /// </summary>
    public enum EnumEventkind
    {
        /// <summary>
        /// 未設定時。
        /// </summary>
        Null,

        /// <summary>
        /// テキスト変更時。
        /// </summary>
        TextChanged
    }



    /// <summary>
    /// ユーザー定義イベント・ハンドラーのラッパー。
    /// </summary>
    public class UsereventhandlerWrapperImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public UsereventhandlerWrapperImpl()
        {
            this.enumKind = EnumEventkind.Null;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        protected EnumEventkind enumKind;

        /// <summary>
        /// イベント・ハンドラーの区別。"TextChanged" など。
        /// </summary>
        public EnumEventkind EnumKind
        {
            set
            {
                enumKind = value;
            }
            get
            {
                return enumKind;
            }
        }

        //────────────────────────────────────────

        protected EventHandler eventHandler;

        /// <summary>
        /// イベント・ハンドラー。
        /// </summary>
        public EventHandler EventHandler
        {
            set
            {
                eventHandler = value;
            }
            get
            {
                return eventHandler;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
