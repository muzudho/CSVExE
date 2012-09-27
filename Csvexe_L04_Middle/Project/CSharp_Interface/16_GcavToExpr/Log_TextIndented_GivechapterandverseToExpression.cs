using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Middle
{

    /// <summary>
    /// 要るのこれ？
    /// </summary>
    public interface Log_TextIndented_GivechapterandverseToExpression : Log_TextIndented
    {

        // ──────────────────────────────

        /// <summary>
        /// 採ログの有無。
        /// </summary>
        bool BEnabled
        {
            get;
            set;
        }

        // ──────────────────────────────

        void Increment(string sComment_NodeName);

        void Increment(string sComment_NodeName, Dictionary<string, string> dicS_Attr);

        void Decrement(string sComment_NodeName);

        // ──────────────────────────────

    }
}
