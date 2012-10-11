using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Table;//Table_Humaninput

namespace Xenon.Operating
{
    public interface Gamepadmainloop_Input
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// ゲームコントローラーの接続を監視。
        /// </summary>
        void ListenController(Gamepadmainloop mainloop);

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 接続されているゲームコントローラーの状態のリスト。
        /// </summary>
        Dictionary<int, Memory_GameController> Dictionary_GameController
        {
            get;
            set;
        }

        /// <summary>
        /// ゲームパッド全部のキーコンフィグを記憶します。
        /// </summary>
        Table_Humaninput Table_Humaninput_Keyconfig
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
