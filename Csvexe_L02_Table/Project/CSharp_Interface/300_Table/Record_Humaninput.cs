using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Xenon.Syntax;

namespace Xenon.Table
{



    #region 用意
    //────────────────────────────────────────

    public delegate void DELEGATE_Fields(Value_Humaninput field, ref bool isBreak, Log_Reports log_Reports);

    //────────────────────────────────────────
    #endregion


    
    public interface Record_Humaninput
    {



        #region アクション
        //────────────────────────────────────────

        void ForEach(DELEGATE_Fields delegate_Fields, Log_Reports log_Reports);

        //────────────────────────────────────────

        /// <summary>
        /// 配列の要素を取得します。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Value_Humaninput ValueAt(int index);

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expected"></param>
        /// <returns>該当がなければ -1。</returns>
        int ColumnIndexOf_Trimupper(string expected);

        //────────────────────────────────────────
        
        /// <summary>
        /// デバッグ用に内容をダンプします。
        /// </summary>
        /// <returns></returns>
        string ToString_DebugDump();

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        DataRow DataRow
        {
            get;
        }

        //────────────────────────────────────────
        #endregion



    }



}
