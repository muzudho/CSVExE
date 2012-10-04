using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;
using Xenon.Syntax;
using Xenon.Middle;
using Xenon.Expr;


namespace Xenon.Functions
{

    /// <summary>
    /// システム定義アクション。（Ｓａ）
    /// 
    /// イベントハンドラーに対応している。
    /// </summary>
    public abstract class Expression_Node_FunctionAbstract : Expression_Node_FunctionImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// 
        /// コンストラクターで生成したインスタンスは内容未設定です。必ず、#NewInstance でもう一度インスタンスを作って、そっちを使ってください。
        /// </summary>
        /// <param name="sNodeName"></param>
        /// <param name="parent_Ec"></param>
        /// <param name="cur_Gcav"></param>
        public Expression_Node_FunctionAbstract(EnumEventhandler enumEventhandler, List<string> listS_ArgName, ConfigurationtreeToFunction_Item functiontranslatoritem)
            : base(null/*parent_Expression*/, null/*cur_Gcav*/, listS_ArgName)
        {
            this.EnumEventhandler = enumEventhandler;
            this.functiontranslatoritem = functiontranslatoritem;
        }

        public abstract override Expression_Node_Function NewInstance(
            Expression_Node_String parent_Expression,
            Configurationtree_Node cur_Gcav,
            object/*MemoryApplication*/ owner_MemoryApplication, Log_Reports log_Reports);

        //────────────────────────────────────────
        #endregion


        
        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// アクション実行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override string Execute5_Main(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Execute5_Main", log_Reports);

            if (log_Method.CanWarning())
            {
                log_Method.WriteWarning_ToConsole(" ▲▲▲▲▲オーバーライド実装してください。");
            }

            log_Method.EndMethod(log_Reports);
            return "";
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 最新仕様での関数変換一覧。
        /// </summary>
        private ConfigurationtreeToFunction_Item functiontranslatoritem;

        public ConfigurationtreeToFunction_Item Functiontranslatoritem
        {
            get
            {
                return this.functiontranslatoritem;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
