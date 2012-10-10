using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Table;//

namespace Xenon.Operating
{
    /// <summary>
    /// ゲームパッド全部のキーコンフィグ。
    /// </summary>
    public class KeyconfigImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public KeyconfigImpl()
        {
            this.dic_KeyCnf = new Dictionary<int, KeyconfigPadImpl>();
            this.o_Table_Keycnf = null;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 無ければヌルを返す。
        /// </summary>
        /// <param name="controllerNumber"></param>
        /// <returns></returns>
        public KeyconfigPadImpl GetBy(int nControllerNumber)
        {
            if (this.dic_KeyCnf.ContainsKey(nControllerNumber))
            {
                return this.dic_KeyCnf[nControllerNumber];
            }
            else
            {
                return null;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<int, KeyconfigPadImpl> dic_KeyCnf;

        public Dictionary<int, KeyconfigPadImpl> Dic_KeyCnf
        {
            get
            {
                return dic_KeyCnf;
            }
            set
            {
                dic_KeyCnf = value;
            }
        }

        //────────────────────────────────────────

        private TableHumaninput o_Table_Keycnf;

        /// <summary>
        /// CSV形式などのテーブル状に記憶されたキーコンフィグ設定。
        /// 未読込時はヌル。
        /// </summary>
        public TableHumaninput O_Table_Keycnf
        {
            get
            {
                return this.o_Table_Keycnf;
            }
            set
            {
                this.o_Table_Keycnf = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
