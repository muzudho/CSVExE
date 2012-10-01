using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Syntax
{
    /// <summary>
    /// 「-7~-5」「-3~1」「3」といった記述で数字を記述できる。
    /// </summary>
    public class O_IntegerRangeImpl : O_IntegerRange
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="nSingle">数値</param>
        public O_IntegerRangeImpl(int nSingle)
        {
            this.nFirst = nSingle;
            this.nLast = nSingle;
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="nFirst">始値</param>
        /// <param name="nLast">終値</param>
        public O_IntegerRangeImpl(int nFirst, int nLast)
        {
            this.nFirst = nFirst;
            this.nLast = nLast;
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        // 説明はインターフェース参照。
        public void ToNumbers(ref List<int> listN)
        {
            for (int nI = this.nFirst; nI <= this.nLast; nI++)
            {
                listN.Add(nI);
            }
        }

        //────────────────────────────────────────

        // 説明はインターフェース参照。
        public string ToCsv()
        {
            StringBuilder sb = new StringBuilder();

            for (int nI = this.nFirst; nI <= this.nLast; nI++)
            {
                sb.Append(nI);

                if (nI + 1 <= this.nLast)
                {
                    sb.Append(",");
                }
            }

            return sb.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「1」や、「3~5」といった文字列を返す。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.nFirst == this.nLast)
            {
                sb.Append(this.nFirst);
            }
            else
            {
                sb.Append(this.nFirst);
                sb.Append("~");
                sb.Append(this.nLast);
            }

            return sb.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        // 説明はインターフェース参照。
        public bool Contains(int nValue)
        {
            if (this.nFirst <= nValue && nValue <= this.nLast)
            {
                return true;
            }

            return false;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private int nFirst;

        // 説明はインターフェース参照。
        public int Number_First
        {
            set
            {
                nFirst = value;
            }
            get
            {
                return nFirst;
            }
        }

        //────────────────────────────────────────

        private int nLast;

        // 説明はインターフェース参照。
        public int Number_Last
        {
            set
            {
                nLast = value;
            }
            get
            {
                return nLast;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
