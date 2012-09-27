using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Operating
{
    /// <summary>
    /// </summary>
    public class XenonStyleImpl : XenonStyle
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public XenonStyleImpl()
        {
        }

        //────────────────────────────────────────
        #endregion


        
        #region プロパティー
        //────────────────────────────────────────

        private XenonColor foreXenonColor;

        /// <summary>
        /// 前景色。設定されていなければヌル。
        /// </summary>
        /// <returns>設定されていなければヌル。</returns>
        public XenonColor ForeColor
        {
            set
            {
                foreXenonColor = value;
            }
            get
            {
                return foreXenonColor;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
