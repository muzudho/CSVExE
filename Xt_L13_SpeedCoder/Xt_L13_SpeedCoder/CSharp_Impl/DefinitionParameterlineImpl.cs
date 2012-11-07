using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using Xenon.Syntax;

namespace Xenon.SpeedCoder
{



    /// <summary>
    /// 1行入力の定義。
    /// </summary>
    public class DefinitionParameterlineImpl
    {



        #region 用意
        //────────────────────────────────────────

        /// <summary>
        /// 先頭の文字を大文字にします。
        /// </summary>
        private const string OPTION_FIRST_LETTER_UPPER = "FirstLetterUpper";

        /// <summary>
        /// 先頭の文字を小文字にします。
        /// </summary>
        private const string OPTION_FIRST_LETTER_LOWER = "FirstLetterLower";

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public DefinitionParameterlineImpl()
        {
            this.NameParameter = "";
            this.Comment = "";
            this.Option = "";
            this.ListPuttingArgumentBySet = new List<string>();
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="previousNumberLine">1スタート。</param>
        /// <param name="line"></param>
        public void Parse(out bool isError, string line, int previousNumberLine)
        {
            //    1:%cat% CAP_LOW //2行目はアイテム2です。
            //    2:%ball% //3行目はアイテム3です。

            isError = false;

            string matchPattern = @"^\s*(\d+)?\s*:\s*(\%.*\%)\s*(.*?)\s*(//.*)?$";
            Match m1 = Regex.Match(line, matchPattern);
            if (m1.Success)
            {
                int newNumberLine;
                if ("" == m1.Groups[1].Value)
                {
                    this.numberLine = previousNumberLine;
                }
                else if (int.TryParse(m1.Groups[1].Value, out newNumberLine))
                {
                    if (previousNumberLine == newNumberLine || previousNumberLine + 1 == newNumberLine)
                    {
                        this.numberLine = newNumberLine;
                        //this.Comment = "正常： previousNumberLine=[" + previousNumberLine + "] matchPattern=[" + matchPattern + "] line=[" + line + "]★★★★";
                    }
                    else
                    {
                        //エラー
                        isError = true;
                        this.NameParameter = "";
                        this.Comment = "★★★★エラー3： 引数番号は 1 から始まる連番である必要があります。同じ番号が続いたり、「:%引数名%」のように、数字を省略すると上の行と同じ引数番号になります。★★★★";
                    }
                }
                else
                {
                    //エラー
                    isError = true;
                    this.NameParameter = "";
                    this.Comment = "★★★★エラー2： previousNumberLine=[" + previousNumberLine + "] matchPattern=[" + matchPattern + "] line=[" + line + "]★★★★";
                }


                // 変数名
                this.NameParameter = m1.Groups[2].Value;

                // オプションCSV
                {
                    string token = m1.Groups[3].Value;

                    this.Option = token.Trim();
                }

                // コメント
                this.Comment = m1.Groups[4].Value;
            }
            else
            {
                //エラー
                isError = true;
                this.NameParameter = "";
                this.Comment = "★★★★エラー1： previousNumberLine=[" + previousNumberLine + "] matchPattern=[" + matchPattern + "] line=[" + line + "]★★★★";
            }

        }

        //────────────────────────────────────────

        public string GetArgumentBySet(int index, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_SpeedCoder.Name_Library, this, "GetArgumentBySet", log_Reports);

            string result = this.listPuttingArgumentBySet[index];

            switch (this.Option)
            {
                case "":
                    {
                        //無視。
                    }
                    break;
                case DefinitionParameterlineImpl.OPTION_FIRST_LETTER_UPPER:
                    {
                        if(1<=result.Length)
                        {
                            string head = result.Substring(0,1);//頭
                            string left = result.Remove(0, 1);//残り
                            result = head.ToUpper() + left;
                        }
                    }
                    break;
                case DefinitionParameterlineImpl.OPTION_FIRST_LETTER_LOWER:
                    {
                        if (1 <= result.Length)
                        {
                            string head = result.Substring(0, 1);//頭
                            string left = result.Remove(0, 1);//残り
                            result = head.ToLower() + left;
                        }
                    }
                    break;
                default:
                    {
                        //サポートしていないオプション。
                        //無視します。
                        log_Method.WriteWarning_ToConsole("サポートしていないオプション=[" + this.Option + "]");
                    }
                    break;
            }

            log_Method.EndMethod(log_Reports);
            return result;
        }

        public void AddArgumentline(string argument)
        {
            this.listPuttingArgumentBySet.Add(argument);
        }

        public int CountArgumentlines()
        {
            return this.listPuttingArgumentBySet.Count();
        }

        //────────────────────────────────────────
        #endregion




        #region プロパティー
        //────────────────────────────────────────

        private int numberLine;

        /// <summary>
        /// 行番号。1スタート。
        /// </summary>
        public int NumberLine
        {
            get
            {
                return this.numberLine;
            }
            set
            {
                this.numberLine = value;
            }
        }

        //────────────────────────────────────────

        private string nameParameter;

        /// <summary>
        /// 引数名。
        /// </summary>
        public string NameParameter
        {
            get
            {
                return this.nameParameter;
            }
            set
            {
                this.nameParameter = value;
            }
        }

        //────────────────────────────────────────

        private string option;

        /// <summary>
        /// 引数名。
        /// </summary>
        public string Option
        {
            get
            {
                return this.option;
            }
            set
            {
                this.option = value;
            }
        }

        //────────────────────────────────────────

        private string comment;

        /// <summary>
        /// 変数名。
        /// </summary>
        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        //────────────────────────────────────────

        private List<string> listPuttingArgumentBySet;

        /// <summary>
        /// 入力値を入れていきます。
        /// </summary>
        public List<string> ListPuttingArgumentBySet
        {
            //get
            //{
            //    return this.listPuttingArgumentBySet;
            //}
            set
            {
                this.listPuttingArgumentBySet = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }



}
