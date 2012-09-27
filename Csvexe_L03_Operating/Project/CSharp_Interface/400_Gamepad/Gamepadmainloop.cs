using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{

    /// <summary>
    /// メインループです。
    /// </summary>
    public interface Gamepadmainloop
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// フォームのコンストラクト時。
        /// </summary>
        void Init();

        /// <summary>
        /// フォームのロード時。
        /// </summary>
        void Load();

        /// <summary>
        /// タイマー1回分の実行。
        /// </summary>
        void Step();

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// メインループの中の、入力担当。
        /// </summary>
        Gamepadmainloop_Input Input
        {
            get;
        }

        /// <summary>
        /// タイマー。
        /// </summary>
        long NTimer
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }
}
