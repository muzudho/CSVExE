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

        string Name
        {
            get;
            set;
        }


        EnumTypedb EnumTypedb
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
