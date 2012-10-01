using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;//S_WrittenPlaceImpl
using Xenon.Middle;//ControlCommon

namespace Xenon.Controls
{
    /// <summary>
    /// ユーザーコントロールの共通プロパティー、およびロジックが含まれているクラスです。
    /// 
    /// C#では多重継承ができないので、共通のプロパティー、ロジックがあれば、ここに含めます。
    /// </summary>
    public class ControlCommonImpl : ControlCommon
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public ControlCommonImpl()
        {
            Log_Method log_Method = new Log_MethodImpl();
            Log_Reports log_Reports_ThisMethod = new Log_ReportsImpl(log_Method);
            log_Method.BeginMethod(Info_Controls.Name_Library, this, "ControlCommonImpl", log_Reports_ThisMethod);

            // コントロールを作った時に、必ずnameプロパティを設定してください。
            // ただし、直接 Visual Studio のビジュアルエディターで配置した場合は設定できません。
            Givechapterandverse_Node cur_Cf = new Givechapterandverse_NodeImpl(log_Method.Fullname+"<init>", null);

            this.givechapterandverse_Control = new Givechapterandverse_NodeImpl(NamesNode.S_CONTROL1, cur_Cf);//ダミーのデフォルト・オブジェクト？
            this.expression_Name_Control = new Expression_Node_StringImpl(null, cur_Cf);

            log_Method.EndMethod(log_Reports_ThisMethod);
            log_Reports_ThisMethod.EndLogging(log_Method);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Givechapterandverse_Node givechapterandverse_Control;

        /// <summary>
        /// コントロール設定ファイルの &lt;control&gt;要素。
        /// 
        /// 未設定ならヌル。実装は、生成時にセットしてください。
        /// </summary>
        public Givechapterandverse_Node Givechapterandverse_Control
        {
            get
            {
                return givechapterandverse_Control;
            }
            set
            {
                givechapterandverse_Control = value;
            }
        }

        //────────────────────────────────────────

        private Expression_Node_String expression_Control;

        /// <summary>
        /// コントロール。
        /// </summary>
        public Expression_Node_String Expression_Control
        {
            set
            {
                expression_Control = value;
            }
            get
            {
                return expression_Control;
            }
        }

        //────────────────────────────────────────

        private bool bAutomaticinputting;

        /// <summary>
        /// このフラグが立っているときは、「手入力による変更」処理を行いません。
        /// </summary>
        public bool BAutomaticinputting
        {
            set
            {
                bAutomaticinputting = value;
            }
            get
            {
                return bAutomaticinputting;
            }
        }

        //────────────────────────────────────────

        private bool bDestructed;

        /// <summary>
        /// このコントロールが、破棄されているなら真。
        /// </summary>
        public bool BDestructed
        {
            get
            {
                return bDestructed;
            }
            set
            {
                bDestructed = value;
            }
        }

        //────────────────────────────────────────

        private Expression_Node_String expression_Name_Control;

        /// <summary>
        /// コントロール名。
        /// 
        /// C#のControlのNameプロパティーとは連動していないので、
        /// 設定、取得する際は注意。
        /// </summary>
        public Expression_Node_String Expression_Name_Control
        {
            set
            {
                expression_Name_Control = value;

                //if (null == e_fcName)
                //{
                //    throw new Exception(Info_Forms.LibraryName + ":ヌル入れた。");
                //}
                //else
                //{
                //    ystem.Console.WriteLine(Info_Forms.LibraryName + ":ControlCommonImpl#Expression_Name_Control: コントロールに命名["+e_fcName.E_Execute(null)+"]");
                //}
            }
            get
            {
                return expression_Name_Control;
            }
        }

        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        public MemoryApplication Owner_MemoryApplication
        {
            get
            {
                return owner_MemoryApplication;
            }
            set
            {
                owner_MemoryApplication = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
