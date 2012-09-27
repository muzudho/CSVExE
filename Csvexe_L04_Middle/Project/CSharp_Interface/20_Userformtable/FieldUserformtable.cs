using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Middle
{



    public interface FieldUserformtable
    {


        #region プロパティー
        //────────────────────────────────────────

        string SName
        {
            get;
            set;
        }


        EnumTypedb Typedb
        {
            get;
            set;
        }


        object Data
        {
            get;
            set;
        }

        //────────────────────────────────────────
        #endregion


    }



}
