using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Expr
{
    public class FieldListImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public FieldListImpl()
        {
            this.List_SField = new List<Expression_Node_String>();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private List<Expression_Node_String> list_SField;

        public List<Expression_Node_String> List_SField
        {
            get
            {
                return list_SField;
            }
            set
            {
                list_SField = value;
            }
        }

        //────────────────────────────────────────

        public void Add(Expression_Node_String expr_String)
        {
            this.list_SField.Add(expr_String);
        }

        //────────────────────────────────────────
        #endregion



    }
}
