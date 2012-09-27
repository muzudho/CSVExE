using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xenon.Table
{
    /// <summary>
    /// </summary>
    class CsvEscapeImpl
    {



        #region アクション
        //────────────────────────────────────────

        public List<string> UnescapeRecordToFieldList(string sSrc, char chDelimiter)
        {
            int nLen = sSrc.Length;
            List<string> sList_Dst = new List<string>();
            char ch;

            // 空か。
            if(sSrc.Length<1)
            {
                goto gt_EndMethod;
            }


            StringBuilder sb_Cell = new StringBuilder();
            int nI = 0;
            while(nI < nLen)
            {
                sb_Cell.Length = 0;
                ch = sSrc[nI];

                if(','==ch)
                {
                    // 空を追加して次へ。
                    nI++;
                }
                else if ('"' == ch)
                {
                    // 1文字目が「"」なら、2文字目へ。
                    nI++;
                    
                    // エスケープしながら、単独「"」が出てくるまでそのまま出力。
                    while (nI < nLen)
                    {
                        ch = sSrc[nI];

                        if ('"' == ch)
                        {
                            // 「"」だった。

                            if (nI + 1 == nLen)
                            {
                                // 2文字目が無ければ、
                                //「"」を無視して終了。
                                nI++;
                                break;
                            }
                            else if ('"' == sSrc[nI + 1])
                            {
                                // 2文字目も「"」なら、
                                // 1,2文字目の「""」を「"」に変換して続行。
                                nI += 2;
                                sb_Cell.Append('"');
                            }
                            else
                            {
                                // 2文字目が「"」でなければ、
                                //「"」を無視して終了。
                                nI++;
                                break;
                            }
                        }
                        else
                        {
                            // 通常文字なので続行。
                            sb_Cell.Append(ch);
                            nI++;
                        }
                    }

                    //ystem.Console.WriteLine(InfxenonTable.LibraryName + ":" + this.GetType().Name + "#UnescapeToList: 「\"」で囲まれた文字=["+sCell.ToString()+"]");
                }
                else
                {
                    sb_Cell.Append(ch);
                    nI++;

                    // 1文字目が「"」でないなら、「,」が出てくるか、次がなくなるまでそのまま出力。
                    // フォーマットチェックは行わない。
                    while(nI < nLen)
                    {
                        ch = sSrc[nI];

                        if (chDelimiter != ch)
                        {
                            // 文字を追加して次へ。
                            sb_Cell.Append(ch);
                            nI++;
                        }
                        else
                        {
                            // 「,」を見つけたのでこれを無視し、
                            // このセル読取は脱出。
                            nI++;
                            break;
                        }
                    }
                    // 次が無くなったか、「,」の次の文字を指している。
                }

                //ystem.Console.WriteLine(InfxenonTable.LibraryName + ":" + this.GetType().Name + "#UnescapeToList: cell=["+sCell.ToString()+"]");
                sList_Dst.Add(sb_Cell.ToString());

            }



        gt_EndMethod:
            return sList_Dst;
        }

        //────────────────────────────────────────

        /// <summary>
        /// （１）「,」または「"」が含まれていれば、両端に「"」を付加します。
        /// （２）含まれている「"」は、「""」に変換します。
        /// </summary>
        /// <param name="sSrc"></param>
        /// <returns></returns>
        public string EscapeCell(string sSrc)
        {
            int nLen = sSrc.Length;

            // エスケープが必要なら真。
            bool bEscape = false;
            char ch;

            StringBuilder s = new StringBuilder();

            for (int nI = 0; nI < nLen; )
            {
                ch = sSrc[nI];
                if (',' == ch)
                {
                    // エスケープが必要
                    bEscape = true;
                    s.Append(ch);
                    nI++;
                }
                else if ('"' == ch)
                {
                    // エスケープが必要
                    bEscape = true;
                    s.Append("\"\"");
                    nI++;
                }
                else
                {
                    s.Append(ch);
                    nI++;
                }
            }

            if (bEscape)
            {
                s.Insert(0, '"');
                s.Append('"');
            }

            return s.ToString();
        }

        //────────────────────────────────────────
        #endregion



    }
}
