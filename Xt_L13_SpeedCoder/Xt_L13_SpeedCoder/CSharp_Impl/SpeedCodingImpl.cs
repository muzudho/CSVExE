using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using Xenon.Syntax;

namespace Xenon.SpeedCoder
{
    public class SpeedCodingImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public SpeedCodingImpl()
        {
            this.Title = "";
            this.Explain = "";
            this.ListDefinitionParameterline = new List<DefinitionParameterlineImpl>();
            this.DictionaryOptionline = new Dictionary<string,OptionlineTemplateImpl>();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public string Perform(out bool isError, TextdropareaImpl Textdroparea1, TextdropareaImpl Textdroparea2, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_SpeedCoder.Name_Library, this, "Perform", log_Reports);


            isError = false;
            this.ListDefinitionParameterline.Clear();


            StringBuilder result = new StringBuilder();
            string template;
            if (1 <= Textdroparea1.ListFilepath.Count)
            {
                if (System.IO.File.Exists(Textdroparea1.ListFilepath[0]))
                {
                    template = System.IO.File.ReadAllText(Textdroparea1.ListFilepath[0], Encoding.UTF8);
                }
                else
                {
                    template = "";
                }
            }
            else
            {
                template = "";
            }
            //log_Method.WriteDebug_ToConsole("template=[" + template + "]");

            string argumentfile;
            if (1 <= Textdroparea2.ListFilepath.Count)
            {
                if (System.IO.File.Exists(Textdroparea2.ListFilepath[0]))
                {
                    argumentfile = System.IO.File.ReadAllText(Textdroparea2.ListFilepath[0], Encoding.UTF8);
                }
                else
                {
                    argumentfile = "";
                }
            }
            else
            {
                argumentfile = "";
            }
            //log_Method.WriteDebug_ToConsole("input=[" + input + "]");


            //テンプレートの解析
            string bracketBegin = "";//デフォルトでは「<<<<」で説明。正規表現で利用されている魔法の文字（[]+*?$等色々）は使わないこと。
            string bracketEnd = "";//デフォルトでは「>>>>」で説明。正規表現で利用されている魔法の文字（[]+*?$等色々）は使わないこと。
            {
                this.ListDefinitionParameterline.Clear();
                int phase = 0;
                //  0:　「<<<<タイトルここから>>>>」を探す。その間無視。
                //  1:　「<<<<タイトルここまで>>>>」が出てくるまでがタイトル。
                //  2:　「<<<<説明ここから>>>>」が出てくるまで探す。その間無視。
                //  3:　「<<<<説明ここまで>>>>」が出てくるまでが説明。
                //  4:　「<<<<反復入力行セット定義ここから>>>>」を探す。その間無視。
                //  5:　「<<<<反復入力行セット定義ここまで>>>>」が出てくるまでがタイトル。
                //  6:　「<<<<テンプレートここから>>>>」を探す。その間無視。
                //  7:　「<<<<テンプレートここまで>>>>」が出てくるまでがタイトル。
                //  8:　「<<<<オプションここから>>>>」を探す。その間無視。
                //  9:　「<<<<オプションここまで>>>>」が出てくるまでがタイトル。
                // 10:　終了します。
                string[] symbols = null;

                StringBuilder sbTitle = new StringBuilder();
                StringBuilder sbExplain = new StringBuilder();
                int previousParamNumber = 0;
                StringBuilder sbTemplate = new StringBuilder();
                string[] lines = template.Split(new string[] {Environment.NewLine },StringSplitOptions.None);
                int numberLine = 1;
                foreach (string line in lines)
                {

                    if (3 <= numberLine)
                    {
                        if(null==symbols)
                        {
                            symbols = new string[]
                            {
                                bracketBegin + "タイトルここから" + bracketEnd,
                                bracketBegin + "タイトルここまで" + bracketEnd,
                                bracketBegin + "説明ここから" + bracketEnd,
                                bracketBegin + "説明ここまで" + bracketEnd,
                                bracketBegin + "反復入力行セット定義ここから" + bracketEnd,
                                bracketBegin + "反復入力行セット定義ここまで" + bracketEnd,
                                bracketBegin + "テンプレートここから" + bracketEnd,
                                bracketBegin + "テンプレートここまで" + bracketEnd,
                                bracketBegin + "オプションここから" + bracketEnd,
                                bracketBegin + "オプションここまで" + bracketEnd
                            };
                        }

                        switch (phase)
                        {
                            case 0:
                                //「<<<<タイトルここから>>>>」
                                {
                                    if (symbols[0] == line.Trim())
                                    {
                                        phase = 1;
                                        //log_Method.WriteDebug_ToConsole("(0a) line=[" + line + "]");
                                    }
                                    else
                                    {
                                        //log_Method.WriteDebug_ToConsole("(0b) line=[" + line + "]");
                                    }
                                }
                                break;
                            case 1:
                                //「<<<<タイトルここまで>>>>」
                                {
                                    if (symbols[1] == line.Trim())
                                    {
                                        phase = 2;
                                        //log_Method.WriteDebug_ToConsole("(1a) line=[" + line + "]");
                                    }
                                    else
                                    {
                                        if (0 < sbTitle.Length)
                                        {
                                            //文字をつなげる場合は、改行を入れます。
                                            sbTitle.Append(Environment.NewLine);
                                        }
                                        sbTitle.Append(line);
                                        //最後に改行が付いていないようにします。

                                        //log_Method.WriteDebug_ToConsole("(1b) line=[" + line + "]");
                                    }
                                }
                                break;
                            case 2:
                                //「<<<<説明ここから>>>>」
                                {
                                    if (symbols[2] == line.Trim())
                                    {
                                        phase = 3;
                                        //log_Method.WriteDebug_ToConsole("(2a) line=[" + line + "]");
                                    }
                                    else
                                    {
                                        //log_Method.WriteDebug_ToConsole("(2b) line=[" + line + "]");
                                    }
                                }
                                break;
                            case 3:
                                //「<<<<説明ここまで>>>>」
                                {
                                    if (symbols[3] == line.Trim())
                                    {
                                        phase = 4;
                                        //log_Method.WriteDebug_ToConsole("(3a) line=[" + line + "]");
                                    }
                                    else
                                    {
                                        if (0 < sbExplain.Length)
                                        {
                                            //文字をつなげる場合は、改行を入れます。
                                            sbExplain.Append(Environment.NewLine);
                                        }
                                        sbExplain.Append(line);
                                        //最後に改行が付いていないようにします。
                                        //log_Method.WriteDebug_ToConsole("(3b) line=[" + line + "]");
                                    }
                                }
                                break;
                            case 4:
                                //「<<<<反復入力行セット定義ここから>>>>」
                                {
                                    if (symbols[4] == line.Trim())
                                    {
                                        phase = 5;
                                        //log_Method.WriteDebug_ToConsole("(4a) line=[" + line + "]");
                                    }
                                    else
                                    {
                                        //log_Method.WriteDebug_ToConsole("(4b) line=[" + line + "]");
                                    }
                                }
                                break;
                            case 5:
                                {
                                    //「<<<<反復入力行セット定義ここまで>>>>」
                                    if (symbols[5] == line.Trim())
                                    {
                                        phase = 6;
                                        //log_Method.WriteDebug_ToConsole("(5a) line=[" + line + "]");
                                    }
                                    else
                                    {
                                        DefinitionParameterlineImpl definition = new DefinitionParameterlineImpl();
                                        definition.Parse(out isError, line, previousParamNumber);
                                        if (isError)
                                        {
                                            //エラー
                                            //log_Method.WriteDebug_ToConsole(definition.Comment);
                                            result.Append(definition.Comment);
                                            goto gt_EndMethod;
                                        }
                                        this.ListDefinitionParameterline.Add(definition);
                                        //log_Method.WriteDebug_ToConsole("(5b) line=[" + line + "] numberDefinitionline=[" + numberDefinitionline + "] パースしたか？ 変数名=[" + definition.NameParameter + "]");
                                        previousParamNumber = definition.NumberLine;
                                    }
                                }
                                break;
                            case 6:
                                //「<<<<テンプレートここから>>>>」
                                {
                                    if (symbols[6] == line.Trim())
                                    {
                                        phase = 7;
                                        //log_Method.WriteDebug_ToConsole("(6a) line=[" + line + "]");
                                    }
                                    else
                                    {
                                        //log_Method.WriteDebug_ToConsole("(6b) line=[" + line + "]");
                                    }
                                }
                                break;
                            case 7:
                                //「<<<<テンプレートここまで>>>>」
                                {
                                    if (symbols[7] == line.Trim())
                                    {
                                        phase = 8;
                                        //log_Method.WriteDebug_ToConsole("(7a) line=[" + line + "]");
                                    }
                                    else
                                    {
                                        if (0<sbTemplate.Length)
                                        {
                                            //文字をつなげる場合は、改行を入れます。
                                            sbTemplate.Append(Environment.NewLine);
                                        }
                                        sbTemplate.Append(line);
                                        //最後に改行が付いていないようにします。
                                        //log_Method.WriteDebug_ToConsole("(7b) line=[" + line + "]");
                                    }
                                }
                                break;
                            case 8:
                                //「<<<<オプションここから>>>>」
                                {
                                    if (symbols[8] == line.Trim())
                                    {
                                        phase = 9;
                                        //log_Method.WriteDebug_ToConsole("(6a) line=[" + line + "]");
                                    }
                                    else
                                    {
                                        //log_Method.WriteDebug_ToConsole("(6b) line=[" + line + "]");
                                    }
                                }
                                break;
                            case 9:
                                //「<<<<オプションここまで>>>>」
                                {
                                    if (symbols[9] == line.Trim())
                                    {
                                        phase = 10;
                                        //log_Method.WriteDebug_ToConsole("(9a) line=[" + line + "]");
                                    }
                                    else
                                    {
                                        OptionlineTemplateImpl optionline = new OptionlineTemplateImpl();
                                        optionline.Parse( line);
                                        this.DictionaryOptionline.Add(optionline.NameOption,optionline);
                                        //log_Method.WriteDebug_ToConsole("(9b) line=[" + line + "] オプションのはず。名=[" + optionline.NameOption + "] 値=[" + optionline.Value + "] コメント=[" + optionline.Comment + "]");
                                    }
                                }
                                break;
                            default:
                                {
                                    //log_Method.WriteDebug_ToConsole("(8) line=[" + line + "]");
                                    goto gt_EndLoop;
                                }
                        }
                    }
                    else if (1 == numberLine)
                    {
                        bracketBegin = line.Trim();
                        //log_Method.WriteDebug_ToConsole("(1行目) line=[" + line + "]");
                    }
                    else if (2 == numberLine)
                    {
                        bracketEnd = line.Trim();
                        //log_Method.WriteDebug_ToConsole("(2行目) line=[" + line + "]");
                    }


                    numberLine++;
                }
            gt_EndLoop:

                this.Title = sbTitle.ToString().TrimEnd('\r', '\n');//末尾の改行をchompします。
                this.Explain = sbTitle.ToString().TrimEnd('\r', '\n');//末尾の改行をchompします。
                this.Template = sbTemplate.ToString().TrimEnd('\r','\n');//末尾の改行をchompします。
            }

            //入力値をセットに分ける。
            //最後の改行はカットします。
            int sizeOfSet = 0;//0スタート配列のサイズ。セットの最後の番号。１セット目は 0。
            {
                string[] argumentlines = argumentfile.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                //log_Method.WriteDebug_ToConsole("lines.Count=[" + argumentlines.Length + "]");
                int paramsBySet = this.ListDefinitionParameterline.Count;
                //log_Method.WriteDebug_ToConsole("paramsBySet=[" + paramsBySet + "]");

                //引数を定義している場合。
                if (0 < paramsBySet)
                {
                    int parameterIndex = 0;
                    
                    int sizeArgumentlines = argumentlines.Length;
                    int indexArgumentline = 0;
                    while ( indexArgumentline<sizeArgumentlines)
                    {
                        string argumentline = argumentlines[indexArgumentline].TrimEnd('\r', '\n');//行末の改行をchompします。
                        if ((indexArgumentline+1) == sizeArgumentlines && "" == argumentline)
                        {
                            //最後の改行は無かったことにします。

                            if (0 < parameterIndex)
                            {
                                //中途半端なところで引数セットが終わった。
                                sizeOfSet++;
                                parameterIndex = 0;
                                //log_Method.WriteDebug_ToConsole("★6★行番号(" + indexArgumentline + "/" + sizeArgumentlines + "):(" + parameterIndex + "/" + paramsBySet + "): line=[" + argumentline + "]を引数リストに追加。★最後の改行は無かったことにしますが、端数があるのでセットは１つ増やします。sizeOfSet=[" + sizeOfSet + "]");
                            }
                            else
                            {
                                //log_Method.WriteDebug_ToConsole("★1★行番号(" + indexArgumentline + "/" + sizeArgumentlines + "):(" + parameterIndex + "/" + paramsBySet + "): line=[" + argumentline + "]を引数リストに追加。★最後の改行は無かったことにします。sizeOfSet=[" + sizeOfSet + "]");
                            }

                            break;
                        }
                        else
                        {
                            DefinitionParameterlineImpl currentParam = this.ListDefinitionParameterline[parameterIndex];
                            int previousNumberLine = currentParam.NumberLine;

                            currentParam.AddArgumentline(argumentline);
                            //log_Method.WriteDebug_ToConsole("★2★" + indexArgumentline + ":(" + parameterIndex + "/" + paramsBySet + "): line=[" + argumentline + "]を引数リストに追加。size(" + currentParam.CountArgumentlines() + ") sizeOfSet=[" + sizeOfSet + "]");

                            for (; (parameterIndex + 1) < paramsBySet; parameterIndex++, indexArgumentline++)
                            {
                                DefinitionParameterlineImpl nextParam = this.ListDefinitionParameterline[parameterIndex+1];
                                if (previousNumberLine == nextParam.NumberLine)
                                {
                                    //同じ行番号が続いていれば。

                                    nextParam.AddArgumentline(argumentline);
                                    //log_Method.WriteDebug_ToConsole("★3★" + indexArgumentline + ":(" + parameterIndex + "/" + paramsBySet + "): line=[" + argumentline + "]を引数リストに追加。size(" + currentParam.CountArgumentlines() + ") sizeOfSet=[" + sizeOfSet + "]");
                                }
                                else
                                {
                                    //同じ行番号は続いていない。
                                    //log_Method.WriteDebug_ToConsole("★5★" + indexArgumentline + ":(" + parameterIndex + "/" + paramsBySet + "): ★break。size(" + currentParam.CountArgumentlines() + ") sizeOfSet=[" + sizeOfSet + "]");
                                    break;
                                }
                            }
                        }

                        parameterIndex++;
                        if (paramsBySet <= parameterIndex)
                        {
                            //引数が１セット分終わった。
                            sizeOfSet++;
                            parameterIndex = 0;
                            //log_Method.WriteDebug_ToConsole("★4★引数が１セット分終わった。sizeOfSet=[" + sizeOfSet + "]");
                        }

                        indexArgumentline++;
                    }
                    //log_Method.WriteDebug_ToConsole("★7★ループから抜けた。引数リストの要素数にインデックスの数が達したので。indexArgumentline=[" + indexArgumentline + "] sizeArgumentlines=[" + sizeArgumentlines + "] sizeOfSet=[" + sizeOfSet + "]");

                    if (sizeOfSet==0 && sizeArgumentlines < this.ListDefinitionParameterline.Count)
                    {
                        //log_Method.WriteDebug_ToConsole("★8★ sizeOfSetが0で、入力引数の数が、定義引数の数にそもそも足りていなければ、sizeOfSetを1にします。 前sizeOfSet=[" + sizeOfSet + "]");
                        sizeOfSet = 1;
                    }
                }
            }
        //gt_EndLoop_Input:

            //「定義セット」の数だけ、繰り返してテンプレートを適用します。
            {
                //一行につなげるかどうか。
                bool isSingleline;
                {
                    OptionlineTemplateImpl optionOneline;
                    if (this.DictionaryOptionline.TryGetValue("SingleLine", out optionOneline))
                    {
                        bool temp;
                        if (bool.TryParse(optionOneline.Value, out temp))
                        {
                            isSingleline = temp;
                        }
                        else
                        {
                            isSingleline = false;
                        }
                    }
                    else
                    {
                        isSingleline = false;
                    }
                }
                //log_Method.WriteDebug_ToConsole("isSingleline=[" + isSingleline + "]");

                if (!Textdroparea1.IsDropped)
                {
                    result.Append("次は、左上の青い欄にテンプレートもドラッグ＆ドロップしてください。");
                    result.Append(Environment.NewLine);
                    result.Append("（エンコーディングは UTF-8 にするのも忘れずに）");
                }
                else if (!Textdroparea2.IsDropped)
                {
                    result.Append("次は、右上の緑色の欄にインプットもドラッグ＆ドロップしてください。");
                    result.Append(Environment.NewLine);
                    result.Append("（エンコーディングは UTF-8 にするのも忘れずに）");
                }
                else if (0 == this.ListDefinitionParameterline.Count)
                {
                    //エラー
                    result.Append("インプットエラー：「反復入力行セット定義」のセット数が 0 件でした。");
                    isError = true;
                }
                else
                {
                    //log_Method.WriteDebug_ToConsole("sizeOfSet=[" + sizeOfSet + "]");
                    for (int currentSet = 0; currentSet < sizeOfSet; currentSet++)
                    {
                        string resultText = this.Template;
                        int countParam = this.ListDefinitionParameterline.Count;
                        //log_Method.WriteDebug_ToConsole("countParam=[" + countParam + "]");
                        for (int paramNum = 0; paramNum < countParam; paramNum++)
                        {
                            DefinitionParameterlineImpl parameterline = this.ListDefinitionParameterline[paramNum];

                            string nameParam = parameterline.NameParameter;
                            string matchPattern = bracketBegin + nameParam + bracketEnd;
                            //log_Method.WriteDebug_ToConsole("matchPattern=[" + matchPattern + "] nameParam=[" + nameParam + "]");
                            Regex replacer = new Regex(matchPattern, RegexOptions.Compiled & RegexOptions.Multiline);

                            string argument;
                            if (currentSet < parameterline.CountArgumentlines())
                            {
                                argument = parameterline.GetArgumentBySet(currentSet,log_Reports);
                            }
                            else
                            {
                                //エラー
                                argument = "★★★★エラー：引数の数が１セット分に足りない。セット数(" + (currentSet+1) + "/" + (sizeOfSet+1) + ") 引数番号[" + paramNum + "]入力argumentなし=(" + parameterline.CountArgumentlines() + ")★★★★";
                                isError = true;
                            }
                            resultText = replacer.Replace(resultText, argument);
                            //log_Method.WriteDebug_ToConsole("matchPattern=[" + matchPattern + "]を→argument=[" + argument + "]に置換しました。currentSet=[" + currentSet + "]/[" + sizeOfSet + "] paramNum=[" + paramNum + "]/[" + countParam + "] resultText=[" + resultText + "]");
                        }

                        result.Append(resultText);
                        if (isSingleline)
                        {
                            //改行を入れません。
                            //log_Method.WriteDebug_ToConsole("★改行を入れません。");
                        }
                        else
                        {
                            //log_Method.WriteDebug_ToConsole("★改行をいれました。isSingleline=[" + isSingleline + "]");
                            result.Append(Environment.NewLine);
                        }
                    }
                }
            }

            goto gt_EndMethod;
            //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private string title;

        /// <summary>
        /// タイトル。
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        //────────────────────────────────────────

        private string explain;

        /// <summary>
        /// 説明。
        /// </summary>
        public string Explain
        {
            get
            {
                return this.explain;
            }
            set
            {
                this.explain = value;
            }
        }

        //────────────────────────────────────────

        private List<DefinitionParameterlineImpl> listDefinitionParameterline;

        /// <summary>
        /// 反復入力行セット定義。
        /// </summary>
        public List<DefinitionParameterlineImpl> ListDefinitionParameterline
        {
            get
            {
                return this.listDefinitionParameterline;
            }
            set
            {
                this.listDefinitionParameterline = value;
            }
        }

        //────────────────────────────────────────

        private Dictionary<string,OptionlineTemplateImpl> dictionaryOptionline;

        /// <summary>
        /// オプション行。
        /// </summary>
        public Dictionary<string, OptionlineTemplateImpl> DictionaryOptionline
        {
            get
            {
                return this.dictionaryOptionline;
            }
            set
            {
                this.dictionaryOptionline = value;
            }
        }

        //────────────────────────────────────────

        private string template;

        /// <summary>
        /// テンプレート。
        /// </summary>
        public string Template
        {
            get
            {
                return this.template;
            }
            set
            {
                this.template = value;
            }
        }

        //────────────────────────────────────────
        #endregion


    }
}
