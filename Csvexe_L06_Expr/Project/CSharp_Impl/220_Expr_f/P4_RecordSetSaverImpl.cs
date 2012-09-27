using System;
using System.Collections.Generic;
using System.Data;//DataRow
using System.Linq;
using System.Text;

using Xenon.Middle;
using Xenon.Syntax;
using Xenon.Table;

namespace Xenon.Expr
{

    public class P4_RecordSetSaverImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="moOpyopyo"></param>
        public P4_RecordSetSaverImpl(MemoryApplication owner_MemoryApplication)
        {
            this.owner_MemoryApplication = owner_MemoryApplication;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// レコードセットを、一時記憶。
        /// </summary>
        /// <param name="p3_RecordSet"></param>
        /// <param name="RecordSetSaveTo_or_null"></param>
        /// <param name="log_Reports"></param>
        public void P4_Save(
            RecordSet recordSet_toSave,
            Expressionv_4ASelectRecord ecvRequest_SelRec_OrNull,//ｗｈｅｒｅ
            Log_Reports log_Reports
            )
        {

            if (null != ecvRequest_SelRec_OrNull)
            {
                //
                // "RECORD_SAVE_TO:FC_mr_skillLst_001" といった、名前。
                string sStorage = ecvRequest_SelRec_OrNull.Expression_Storage.Execute_OnExpressionString(Request_SelectingImpl.Unconstraint, log_Reports);

                if ("" != sStorage.Trim())
                {
                    //
                    // 内容のコピー。 
                    //p3_Selectstatement.NFld = nRequest_saveTo_orNull.NField;
                    //p3_Selectstatement.NLookupValue = nRequest_saveTo_orNull.NLookupValue;
                    //p3_Selectstatement.NRequired = nRequest_saveTo_orNull.NRequired;
                    //p3_Selectstatement.NFrom = nRequest_saveTo_orNull.NFrom;
                    //p3_Selectstatement.NStorage = nRequest_saveTo_orNull.NStorage;
                    //p3_Selectstatement.NDescription = nRequest_saveTo_orNull.NDescription;

                    //
                    // レコードセットを一時記憶。
                    this.Owner_MemoryApplication.MemoryRecordset.RecordsetStorage.Add(
                        ecvRequest_SelRec_OrNull.Expression_Storage,
                        recordSet_toSave,// p3_Selectstatement,
                        log_Reports);
                }
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private MemoryApplication owner_MemoryApplication;

        /// <summary>
        /// いろいろなエディターに変形するアプリケーションのモデルです。
        /// </summary>
        public MemoryApplication Owner_MemoryApplication
        {
            set
            {
                owner_MemoryApplication = value;
            }
            get
            {
                return owner_MemoryApplication;
            }
        }

        //────────────────────────────────────────
        #endregion



    }

}
