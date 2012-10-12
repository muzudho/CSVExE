using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xenon.Syntax;

namespace Xenon.Table
{



    /// <summary>
    /// フィールド定義。
    /// </summary>
    public class FielddefinitionImpl : Fielddefinition
    {



        #region 用意
        //────────────────────────────────────────

        public const string S_STRING = "string";

        public const string S_INT = "int";

        public const string S_BOOL = "bool";

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="name_humanInput"></param>
        /// <param name="typeField">string,int,boolに対応。</param>
        public FielddefinitionImpl(string name_Humaninput, EnumTypeFielddefinition typeField)
        {
            this.Name_Humaninput = name_Humaninput;
            this.Type_Field = typeField;
            this.comment = "";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public static EnumTypeFielddefinition TypefieldFromString(
            string name_Typefield,
            bool isRequired,
            Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.Name_Library, "FielddefinitionImpl", "TypefieldFromString", log_Reports);

            EnumTypeFielddefinition result;

            switch(name_Typefield)
            {
                case FielddefinitionImpl.S_STRING:
                    {
                        result = EnumTypeFielddefinition.String;
                    }
                    break;
                case FielddefinitionImpl.S_INT:
                    {
                        result = EnumTypeFielddefinition.Int;
                    }
                    break;
                case FielddefinitionImpl.S_BOOL:
                    {
                        result = EnumTypeFielddefinition.Bool;
                    }
                    break;
                default:
                    {
                        //文字列型にしておく。
                        result = EnumTypeFielddefinition.String;

                        if (isRequired)
                        {
                            //エラー
                            goto gt_Error_Unspported;
                        }
                    }
                    break;
            }

            goto gt_EndMethod;
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Unspported:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー471！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("指定された文字列[");
                s.Append(name_Typefield);
                s.Append("]は、サポートされていないデータベースの列の型でした。");
                s.Newline();

                s.Append("サポートされている型は、[");
                s.Append(FielddefinitionImpl.S_STRING);
                s.Append("],[");
                s.Append(FielddefinitionImpl.S_INT);
                s.Append("],[");
                s.Append(FielddefinitionImpl.S_BOOL);
                s.Append("]のいずれかです。");
                s.Newline();

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        return result;
        }

        //────────────────────────────────────────

        public Value_Humaninput NewField(string nodeConfigtree, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Table.Name_Library, this, "NewField", log_Reports);

            Value_Humaninput result;

            switch (this.Type_Field)
            {
                case EnumTypeFielddefinition.String:
                    {
                        result = new String_HumaninputImpl(nodeConfigtree);
                    }
                    break;
                case EnumTypeFielddefinition.Int:
                    {
                        result = new Int_HumaninputImpl(nodeConfigtree);
                    }
                    break;
                case EnumTypeFielddefinition.Bool:
                    {
                        result = new Bool_HumaninputImpl(nodeConfigtree);
                    }
                    break;
                default:
                    {
                        // 未該当
                        result = null;
                        goto gt_Error_Unspported;
                    }
            }

            goto gt_EndMethod;
            //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Unspported:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー464！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();

                s.Append("フィールド定義を元にして、フィールド値を用意しようとしましたが、未定義のフィールド型でした。");
                s.Newline();

                s.Append("this.Type.ToString()=[");
                s.Append(this.ToString_Type());
                s.Append("]");
                s.Newline();

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            return result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// string,int,boolを返します。未該当の時は空文字列を返します。
        /// </summary>
        /// <returns></returns>
        public string ToString_Type()
        {
            string result;

            switch(this.Type_Field)
            {
                case EnumTypeFielddefinition.String:
                    {
                        result = FielddefinitionImpl.S_STRING;
                    }
                    break;
                case EnumTypeFielddefinition.Int:
                    {
                        result = FielddefinitionImpl.S_INT;
                    }
                    break;
                case EnumTypeFielddefinition.Bool:
                    {
                        result = FielddefinitionImpl.S_BOOL;
                    }
                    break;
                default:
                    {
                        // 未該当
                        result = "";
                    }
                    break;
            }

            return result;
        }

        /// <summary>
        /// string,int,boolを返します。未該当の時はヌルを返します。
        /// </summary>
        /// <returns></returns>
        public Type ToType_Field()
        {
            if (this.Type_Field == EnumTypeFielddefinition.String)
            {
                return typeof(String_HumaninputImpl);
            }
            else if (this.Type_Field == EnumTypeFielddefinition.Int)
            {
                return typeof(Int_HumaninputImpl);
            }
            else if (this.Type_Field == EnumTypeFielddefinition.Bool)
            {
                return typeof(Bool_HumaninputImpl);
            }
            else
            {
                // todo:エラー
                //
                // 未該当
                //
                return null;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        /// <summary>
        /// 入力したままのフィールド名。
        /// </summary>
        private string name_Humaninput;

        /// <summary>
        /// トリムして大文字化したフィールド名。
        /// </summary>
        private string name_Trimupper;

        /// <summary>
        /// フィールドの名前。入力したままの文字列。
        /// </summary>
        public string Name_Humaninput
        {
            set
            {
                name_Humaninput = value;
                this.name_Trimupper = name_Humaninput.Trim().ToUpper();
            }
            get
            {
                return name_Humaninput;
            }
        }

        /// <summary>
        /// フィールドの名前。トリムして英字大文字に加工した文字列。読み取り専用。
        /// </summary>
        public string Name_Trimupper
        {
            get
            {
                return this.name_Trimupper;
            }
        }

        //────────────────────────────────────────

        private EnumTypeFielddefinition type_Field;

        /// <summary>
        /// フィールドの型。
        /// </summary>
        public EnumTypeFielddefinition Type_Field
        {
            get
            {
                return type_Field;
            }
            set
            {
                type_Field = value;
            }
        }

        //────────────────────────────────────────

        private string comment;

        /// <summary>
        /// フィールドについてのコメント。
        /// </summary>
        public string Comment
        {
            set
            {
                comment = value;
            }
            get
            {
                return comment;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
