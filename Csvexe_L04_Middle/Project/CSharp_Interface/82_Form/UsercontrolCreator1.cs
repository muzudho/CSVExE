using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{

    /// <summary>
    /// 1と2がある。
    /// </summary>
    public interface UsercontrolCreator1
    {



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 『フォーム設定ファイル』をもとに、コントロールを作成します。
        /// 
        /// プロパティーの設定は、この時点では、名前だけ行います。
        /// </summary>
        /// <param name="fo_Record"></param>
        /// <param name="bRequired">未定義の設定があったときに、エラーにするなら真。</param>
        /// <param name="log_Reports"></param>
        Usercontrol Create(
            RecordUserformconfig fo_Record,
            bool bRequired,
            MemoryApplication memoryApplication,
            Log_Reports log_Reports
            );

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// コントロールを生成するオブジェクトのディクショナリー。
        /// </summary>
        Dictionary<string, UsercontrolCreator2> Dictionary_UsercontrolCreator
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
