using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;
using System.Windows.Forms;//Form
using System.Xml;//XmlNode

using Xenon.Syntax;//N_FilePath
using Xenon.Controls;
using Xenon.Middle;
using Xenon.Table; //DefaultTable
using Xenon.Expr;

namespace Xenon.MiddleImpl
{
    /// <summary>
    ///
    /// </summary>
    public class MemoryRecordsetImpl : MemoryRecordset
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public MemoryRecordsetImpl()
        {
            this.recordsetStorage = new RecordsetStorageImpl();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        public static MemoryRecordset NullObject = new MemoryRecordsetImpl();

        //────────────────────────────────────────

        private RecordsetStorage recordsetStorage;

        /// <summary>
        /// レコードセットの一時記憶。
        /// </summary>
        public RecordsetStorage RecordsetStorage
        {
            get
            {
                return recordsetStorage;
            }
            set
            {
                recordsetStorage = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
