using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.MiddleImpl
{
    public class MemoryCodefileinfoImpl : MemoryCodefileinfo
    {



        #region 生成と破棄
        //────────────────────────────────────────
        
        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MemoryCodefileinfoImpl()
        {
            this.sName = "";
            this.sTypedata = "";
            this.expression_Filepath = new Expression_Node_FilepathImpl(new Givechapterandverse_FilepathImpl("ファイルパス出典未指定L09Mid_7", null));//todo:
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string sName;

        /// <summary>
        /// スクリプトファイル呼出名。
        /// </summary>
        public string SName
        {
            get
            {
                return this.sName;
            }
            set
            {
                this.sName = value;
            }
        }

        //────────────────────────────────────────

        private string sTypedata;

        /// <summary>
        /// タイプデータ。
        /// </summary>
        public string STypedata
        {
            get
            {
                return this.sTypedata;
            }
            set
            {
                this.sTypedata = value;
            }
        }

        //────────────────────────────────────────

        private Expression_Node_Filepath expression_Filepath;

        /// <summary>
        /// ファイルパス。
        /// </summary>
        public Expression_Node_Filepath Expression_Filepath
        {
            get
            {
                return this.expression_Filepath;
            }
            set
            {
                this.expression_Filepath = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
