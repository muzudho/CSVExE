using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{

    /// <summary>
    /// カスタム・コントロール、ユーザー・コントロールのどちらにしろ、共通に使われる内容。
    /// </summary>
    public interface ControlCommon
    {



        #region プロパティー
        //────────────────────────────────────────

        MemoryApplication Owner_MemoryApplication
        {
            get;
            set;
        }

        /// <summary>
        /// コントロールの名前。
        /// 
        /// C#のControlのNameプロパティーとは連動していないので、
        /// 設定、取得する際は注意。
        /// </summary>
        Expression_Node_String Expression_Name_Control
        {
            get;
            set;
        }
        
        /// <summary>
        /// このフラグが立っているときは、「手入力による変更」処理を行いません。
        /// (automatic inputting)
        /// </summary>
        bool BAutomaticinputting
        {
            get;
            set;
        }

        /// <summary>
        /// このコントロールが、破棄されているなら真。
        /// </summary>
        bool BDestructed
        {
            get;
            set;
        }

        /// <summary>
        /// コントロール。
        /// </summary>
        Expression_Node_String Expression_Control
        {
            get;
            set;
        }

        /// <summary>
        /// コントロールの設定記述。未設定ならヌル。
        /// </summary>
        Givechapterandverse_Node Givechapterandverse_Control
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion



    }
}
