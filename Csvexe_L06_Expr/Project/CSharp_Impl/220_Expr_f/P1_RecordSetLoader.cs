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
    public class P1_RecordSetLoader
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public P1_RecordSetLoader(MemoryApplication owner_MemoryApplication)
        {
            this.owner_MemoryApplication = owner_MemoryApplication;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 一時記憶から、レコードセット取得。
        /// </summary>
        /// <param name="RecordSetLoadFrom"></param>
        /// <param name="s_ParentNode"></param>
        /// <param name="log_Reports"></param>
        /// <returns>該当がなければヌル。</returns>
        public RecordSet P1_Load(
            Expression_Node_String ec_RecordSetLoadFrom,//Ｗｈｅｒｅ
            Configurationtree_Node parent_Conf,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0, Log_ReportsImpl.BDebugmode_Static);
            log_Method.BeginMethod(Info_Expr.Name_Library, this, "P1_Load",log_Reports);
            //
            //

            //
            // レコードセットを求めます。
            RecordSet recordSet;

            if (null != ec_RecordSetLoadFrom)
            {
                string sRecordSetLoadFrom = ec_RecordSetLoadFrom.Execute4_OnExpressionString(EnumHitcount.Unconstraint, log_Reports).Trim();

                if ("" != sRecordSetLoadFrom)
                {
                    //
                    // レコードセットを取得。
                    recordSet = this.Owner_MemoryApplication.MemoryRecordset.RecordsetStorage.Get(
                        ec_RecordSetLoadFrom,
                        this.Owner_MemoryApplication,
                        log_Reports);
                }
                else
                {
                    recordSet = null;
                }

            }
            else
            {
                recordSet = null;
            }

            goto gt_EndMethod;


            //
        //
        //
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return recordSet;
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
