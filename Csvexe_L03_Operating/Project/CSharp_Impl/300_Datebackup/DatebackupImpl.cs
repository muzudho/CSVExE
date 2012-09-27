using System;
using System.Collections.Generic;
using System.IO;//Directory
using System.Linq;
using System.Text;

using Xenon.Syntax;//N_FilePath

namespace Xenon.Operating
{
    /// <summary>
    /// １日最大１個までバックアップ。
    ///
    /// 
    /// 
    /// バックアップ先。
    ///
    /// (例1) editor-backup/20091202/apple.txt
    ///
    /// (例2) editor-backup/20091203_yamada/apple.txt
    ///
    ///
    /// 上の例で、
    /// 
    /// ・「editor-backup」が『バックアップ・ホーム』。
    /// 
    /// ・「20091202」や「20091203_yamada」が『日付フォルダー』。
    ///
    /// ・「yamada」は『サブネーム』。
    ///
    /// 
    ///
    /// バックアップ・フォルダーの特殊例
    /// 
    /// (例3) editor-backup/20091202/C@/Work/grape.txt
    ///
    /// (例4) editor-backup/20091202/LONG_NAME/0@Work@grape.txt
    ///
    /// ・例3の「C@」は、絶対パスの「C:」のコロン(:)をアットマーク(@)に置換したもの。
    ///
    /// ・例4の「LONG_NAME/0@Work@grape.txt」は、長すぎたファイル名を強引に縮めたもの。
    ///
    /// ・例4の「0」がある場所の数字を『代替ファイル番号』と呼びます。
    /// 
    /// 
    /// ■用語解説
    /// 
    /// ・サブネーム　……　どのアプリケーションが、そのフォルダーの保存、破棄等を担当するかを区別する名前。
    /// 例えば「20091203_yamada」の「yamada」に当たる文字列。アンダースコアは含まない。
    /// 
    /// ・代替ファイル番号　……　被らない適当な数字。ファイル名が長い場合に強引に短くするためのもの。
    /// 
    ///
    /// 
    /// このクラスでは、ファイルのバックアップ（コピー）を行います。
    /// 
    /// 既定では、最大、(指定数)日分のみ保管し、古いものは破棄します。
    /// </summary>
    public class DatebackupImpl : Datebackup
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public DatebackupImpl()
        {
            this.list_Expression_Filepath_Request = new List<Expression_Node_Filepath>();

            // 保管するファイル数。
            this.nKeptbuckups = 10;

            // 代替ファイル番号。
            this.nSubstitutionFileNumber = 0;

            // サブネーム。　既定値：なし
            this.sName_Sub = "";
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 実行します。
        /// </summary>
        /// <param name="filePathList">保存するファイルの相対パスの一覧。「起動アプリケーション・ファイル(.exe)からの相対パス」として設定してあること。</param>
        /// <param name="oDateBackupBaseDirectory"></param>
        /// <param name="d_Thread"></param>
        public void Perform(
            Log_Reports log_Reports
            )
        {
            Log_Method pg_Method = new Log_MethodImpl();
            pg_Method.BeginMethod(Info_Operating.SName_Library, this, "Perform",log_Reports);

            //
            //
            //
            //

            Exception err_Excp;
            string err_SFpatha_Source;
            string err_SFpatha_Dst;

            if (null == this.Expression_Filepath_Backuphome)
            {
                // エラー
                goto gt_Error_BkFolder;//todo:バックアップを無視する。
            }

            //
            // バックアップ・ディレクトリーの絶対パス
            //
            // 例：「editor-backup」
            // 
            string sFpatha_BkHome = this.Expression_Filepath_Backuphome.Execute_OnExpressionString(
                Request_SelectingImpl.Unconstraint,
                log_Reports
                );
            if (!log_Reports.BSuccessful)
            {
                // 既エラー。
                goto gt_EndMethod;
            }

            //.WriteLine(this.GetType().Name + "#Perform: バックアップディレクトリーの絶対パス=[" + backupAbsFilePath + "]" );


            // 日付フォルダー名(FOlder Name)
            string sDateFon = DatebackupImpl.CreateDateFolderName(this.SName_Sub);


            Givechapterandverse_Node s_ParentNode = new Givechapterandverse_NodeImpl("!ハードコーディング_DataBackup#Perform", null);
            // バックアップ・フォルダー下の日付ファイル名


            // 日付フォルダーパス（「…略…\20091201」など）
            string sFopatha_date;
            {
                Expression_Node_Filepath ec_Dir;
                {
                    Givechapterandverse_Filepath cf_dir = new Givechapterandverse_FilepathImpl("ファイルパス出典未指定L03_3", s_ParentNode);
                    cf_dir.InitPath(sFpatha_BkHome, sDateFon,
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                    ec_Dir = new Expression_Node_FilepathImpl(cf_dir);
                }

                if (!log_Reports.BSuccessful)// 異常時はスキップ
                {
                    goto gt_EndMethod;
                }

                sFopatha_date = ec_Dir.Execute_OnExpressionString(
                    Request_SelectingImpl.Unconstraint,
                    log_Reports
                    );
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }

            // temp日付フォルダーパス（「…略…\temp20091201」など）
            string sFopatha_dateTemp;
            {
                Expression_Node_Filepath ec_Dir;
                {
                    Givechapterandverse_Filepath s_dir = new Givechapterandverse_FilepathImpl("ファイルパス出典未指定L03_4", s_ParentNode);
                    s_dir.InitPath(sFpatha_BkHome, "temp" + sDateFon,
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                    ec_Dir = new Expression_Node_FilepathImpl(s_dir);
                }

                if (!log_Reports.BSuccessful)// 異常時はスキップ
                {
                    goto gt_EndMethod;
                }

                sFopatha_dateTemp = ec_Dir.Execute_OnExpressionString(
                    Request_SelectingImpl.Unconstraint,
                    log_Reports
                );
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }
            }
            //.WriteLine(this.GetType().Name + "#Perform: absDateDirTemp=[" + absDateDirTemp + "]");

            if (!log_Reports.BSuccessful)// 異常時はスキップ
            {
                goto gt_EndMethod;
            }


            // 今日の日付のフォルダーの有無を確認します。
            if (Directory.Exists(sFopatha_date))
            {
                // ある場合
                // バックアップは取りません。

                // 注意書きを出力してみる。
                //.WriteLine(this.GetType().Name + "#Perform: バックアップを取りません。バックアップ・フォルダーに、既に今日の日付フォルダーがあるので。[" + absDateDir + "]");

                // スキップ
                goto gt_EndMethod;
            }

            //
            // まず、今日の日付のテンポラリーファイル（「temp20091201」など）が存在すれば、削除します。
            //
            if (Directory.Exists(sFopatha_dateTemp))
            {
                // ある場合

                // 該当する「tempXXXXXXXX」フォルダーを削除します。
                // フォルダーの中身も破棄します。
                Directory.Delete(sFopatha_dateTemp, true);
            }

            //
            // 今日の日付のテンポラリー・ディレクトリーを作成します。
            //
            //
            Directory.CreateDirectory(sFopatha_dateTemp);
            // 作っておかないと、自作のクラスの中で「存在しないファイルパス・エラー」という事前チェックが誤発動してしまいます。


            // バックアップを取ります。
            foreach (Expression_Node_Filepath ec_Fpath_WrittenPlace in list_Expression_Filepath_Request)
            {
                //.WriteLine(this.GetType().Name + "#Perform: バックアップを取りたいファイルのパス sourceFilePath.HumanInputText=[" + oWrittenPlaceFilePath.HumanInputText + "]");

                // 保存先
                Expression_Node_Filepath ec_Fpath_Dst;
                {
                    Givechapterandverse_Filepath cf_fpath_Destination = new Givechapterandverse_FilepathImpl("ファイルパス出典未指定L03_5", s_ParentNode);
                    cf_fpath_Destination.InitPath(
                        sFopatha_dateTemp,
                        ec_Fpath_WrittenPlace.SHumaninput,
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                    ec_Fpath_Dst = new Expression_Node_FilepathImpl(cf_fpath_Destination);
                }

                if (!log_Reports.BSuccessful)// 異常時はスキップ
                {
                    goto gt_EndMethod;
                }

                string sFpatha_Source = ec_Fpath_WrittenPlace.Execute_OnExpressionString(
                    Request_SelectingImpl.Unconstraint,
                    log_Reports
                );
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }

                // 人間オペレーターが記述しているファイルパス。
                // 「相対パス」か「絶対パス」のどちらか。
                string sFpath_HumanInput = ec_Fpath_Dst.SHumaninput;


                //
                // 絶対パスで指定されたファイルを、バックアップに保存する方法
                //
                // 例： 例えば、「C:\」を「C@\」に置換し、日付フォルダーの下に保存します。
                //
                // 注意：「C:」より長い文字列と置換すると、文字列の長さ制限に引っかかることがあります。
                //

                // 「絶対パス」か、「相対パス」かを判断します。
                bool bPathRooted = Utility_Givechapterandverse_Filepath.IsRooted_Path(sFpath_HumanInput,
                    log_Reports
                    );
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }


                if (!log_Reports.BSuccessful)// 異常時はスキップ
                {
                    goto gt_EndMethod;
                }

                // 絶対パスへの対応。
                if (bPathRooted)
                {
                    // 絶対パスであれば、「C:\」といった文字列が先頭に来ることが予想されます。
                    // 文字「:」が 2文字目 だけに存在することを想定して、
                    // 「:」を「@」に置換します。
                    //
                    // 「絶対パスのようなもの」を、バックアップ日付フォルダーの下に作る想定です。
                    // ファイル名が長くなりすぎるので、この後、ファイル名を縮める処理になることが多い。
                    //
                    //.WriteLine(this.GetType().Name + "#Perform: バックアップを取りたいファイルのパス名 humanInputFilePathStr=[" + humanInputFilePathStr + "]");
                    string sNewRelHPath3 = sFpath_HumanInput.Replace(":", "@");
                    //.WriteLine(this.GetType().Name + "#Perform: コロン記号を置換した後のファイルパス名 newRelHPathStr3=[" + newRelHPathStr3 + "]");

                    // 絶対パスでバックアップ対象ファイルが指定されていた場合

                    //
                    // 「C:\banana」は、「C@\banana」に置換
                    //

                    // 設定のし直し。
                    // 出力ファイルの絶対パスが長すぎると真。
                    bool bPathTooLong = Utility_Givechapterandverse_Filepath.IsPathTooLong(
                        sNewRelHPath3,
                        log_Reports,
                        s_ParentNode
                        );
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                    if (!log_Reports.BSuccessful)// 異常時はスキップ
                    {
                        goto gt_EndMethod;
                    }

                    if (bPathTooLong)
                    {

                        // 強引に短縮。
                        sNewRelHPath3 = DatebackupImpl.ReplaceToJammingFilePath(
                            sNewRelHPath3,
                            this.NSubstitutionFileNumber,
                            this.GetType().Name + "#Perform:"
                            );
                        this.NSubstitutionFileNumber++;
                        //.WriteLine(this.GetType().Name + "#Perform: 短くした保存先ファイルパス名 newRelHPathStr3=[" + newRelHPathStr3 + "]");

                        // それでも、出力ファイルの絶対パスが長すぎると、後ろのプログラムで例外を投げます。
                    }

                    // (2010-02-24 ※修正)
                    // 保存先ファイルパスをセット。
                    ec_Fpath_Dst.SetSHumaninput(
                        sNewRelHPath3,
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }
                // 絶対パスへの対応終了

                if (!log_Reports.BSuccessful)// 異常時はスキップ
                {
                    goto gt_EndMethod;
                }

                // もう一回、絶対パスの取得し直し
                string sFpatha_Dst = ec_Fpath_Dst.Execute_OnExpressionString(
                    Request_SelectingImpl.Unconstraint,
                    log_Reports
                    );
                if (!log_Reports.BSuccessful)
                {
                    // 既エラー。
                    goto gt_EndMethod;
                }


                // ファイルのコピーで作成します。
                //.WriteLine(this.GetType().Name + "#Perform: [" + sourceAbsFilePath + "]を");
                //.WriteLine(this.GetType().Name + "#Perform: [" + absDstPathStr + "]にコピーします。");
                try
                {
                    string sDestinationParent = Path.GetDirectoryName(sFpatha_Dst);
                    if (!Directory.Exists(sDestinationParent))
                    {
                        // 指定のファイルの、ディレクトリーが存在しなかった場合。

                        // ディレクトリーを作成します。
                        Directory.CreateDirectory(sDestinationParent);
                    }

                }
                catch (Exception e)
                {
                    // エラー
                    err_Excp = e;
                    goto gt_Error_MissIo;
                }

                try
                {
                    // todo: 同名のファイルがあれば、「aaa(1).txt」「aaa(2).txt」といった風に番号を付けていきたい。

                    // ファイルのコピー
                    System.IO.File.Copy(sFpatha_Source, sFpatha_Dst, false);
                }
                catch (Exception e)
                {
                    // エラー
                    err_Excp = e;
                    err_SFpatha_Source = sFpatha_Source;
                    err_SFpatha_Dst = sFpatha_Dst;
                    goto gt_Error_MissCopy;
                }
            }

            if (!log_Reports.BSuccessful)
            {
                // 異常時はスキップ
                goto gt_EndMethod;
            }

            try
            {

                // テンポラリーフォルダーを、正規の名前にリネームします。
                Directory.Move(sFopatha_dateTemp, sFopatha_date);

            }
            catch (Exception e)
            {
                // エラー
                err_Excp = e;
                goto gt_Error_MissMove;
            }

            // 「バックアップ日付フォルダー」が11個以上あるとき、
            // 日付が新しいものを(指定)個残して　他の日付フォルダーを破棄します。

            this.DeleteOldBackup(
                sFpatha_BkHome,
                sName_Sub,
                log_Reports
                );
            // 異常時は、「temp20091202」といった、処理を中断したゴミ・ファイルが残ることがあります。


            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_BkFolder:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle( "▲エラー508！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("バックアップ・フォルダーが指定されていません。");

                // ヒント

                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_MissIo:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle( "▲エラー65507！", pg_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("エラー：");
                //
                // ヒント
                s.Append(r.Message_SException(err_Excp));
                r.SMessage = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_MissCopy:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle( "▲エラー65506！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("ファイルのコピーに失敗。");
                t.Append(Environment.NewLine);
                t.Append(Environment.NewLine);

                t.Append("[");
                t.Append(err_SFpatha_Source);
                t.Append("]");
                t.Append("を");
                t.Append(Environment.NewLine);

                t.Append("[");
                t.Append(err_SFpatha_Dst);
                t.Append("]");
                t.Append("へコピーしようとしたとき。");
                t.Append(Environment.NewLine);

                //
                // ヒント
                t.Append(r.Message_SException(err_Excp));

                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_MissMove:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReport r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle( "▲エラー65508！", pg_Method);

                Log_TextIndentedImpl t = new Log_TextIndentedImpl();
                t.Append("ファイルのリネーム（Move）に失敗。");
                //
                // ヒント
                t.Append(r.Message_SException(err_Excp));
                r.SMessage = t.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────

        /// <summary>
        /// このアプリケーションが担当する「バックアップ日付フォルダー」が
        /// (指定)個以上あるとき、
        /// 日付が新しいものを(指定)個残して
        /// このアプリケーションが担当する他の「バックアップ日付フォルダー」を破棄します。
        /// </summary>
        private void DeleteOldBackup(
            string sFilepathabsolute_Backuphome,
            string sName_Sub,
            Log_Reports log_Reports
            )
        {
            // バックアップ・フォルダー直下のフォルダーの絶対パス
            string[] sFpatha_FolderArray = Directory.GetDirectories(sFilepathabsolute_Backuphome);

            // 日付フォルダーの名前のリストを作成します。
            List<string> sList_Name_MyDateFolder = new List<string>();
            foreach (string sFpatha_Folder in sFpatha_FolderArray)
            {
                // 区切り文字の次。
                char[] separatorChars = new char[] { '\\', '/' };
                int nFolderNameIndex = sFpatha_Folder.LastIndexOfAny(separatorChars) + 1;

                // 絶対パスから、最下層の「フォルダー名」だけを切り抜き。
                string sFolderName = sFpatha_Folder.Substring(nFolderNameIndex, sFpatha_Folder.Length - nFolderNameIndex);
                //allFolderNames.Add(folderName);

                try
                {

                    // 次の2つは、担当する日付フォルダーとして扱います。
                    // ・ファイル名が8桁の数字
                    // ・ファイル名の先頭8桁が数字で、アンダースコアが続く。
                    // ・フォルダー・オーナー名が、このアプリケーションのものと一致する。
                    int nDammyDateNumber = 0;
                    string sFolderOwnerName = "";
                    bool bDateFolder = DatebackupImpl.IsDateFolderName(
                        sFolderName, ref nDammyDateNumber, ref sFolderOwnerName);

                    // フォルダー名の書式と、オーナー判定
                    if (bDateFolder && sFolderOwnerName == sName_Sub)
                    {
                        sList_Name_MyDateFolder.Add(sFolderName);
                    }

                }
                catch (Exception)
                {
                    // 無視して続行
                }
            }

            // 日付フォルダー名の日付の逆順（数字の降順）にソート。同値は順が不安定。
            sList_Name_MyDateFolder.Sort(
                delegate(string sName_Folder1, string sName_Folder2)
                {

                    int nDateNumber1 = 0;
                    int nDateNumber2 = 0;
                    string sDammyFolderOwnerName = "";

                    // 日付フォルダーでない場合は、dateNumberN に-1が入ります。
                    bool bDate1 = DatebackupImpl.IsDateFolderName(sName_Folder1, ref nDateNumber1, ref sDammyFolderOwnerName);
                    bool bDate2 = DatebackupImpl.IsDateFolderName(sName_Folder2, ref nDateNumber2, ref sDammyFolderOwnerName);

                    return nDateNumber2 - nDateNumber1;
                }
            );

            // 日付の数字が大きい先頭から(指定数)件以外を、
            // 削除するフォルダー名のリストに追加します。
            List<string> sList_Name_DeleteeFolder = new List<string>();
            int nCount = 0;
            foreach (string sName_DateFolder in sList_Name_MyDateFolder)
            {
                if (nCount < this.NKeptbackups)
                {
                    // (指定)件の間は無視。
                }
                else
                {
                    // (指定)件を超過した分は、削除リストに追加。

                    sList_Name_DeleteeFolder.Add(sName_DateFolder.ToString());
                }

                nCount++;
            }
            sList_Name_MyDateFolder = null;//使用終了


            foreach (string sName_DeleteeFolder in sList_Name_DeleteeFolder)
            {
                // 指定のフォルダーを削除



                // 絶対パスの作成

                Expression_Node_Filepath ec_Fpath;
                {
                    Givechapterandverse_Node parent_Givechapterandverse_Node = new Givechapterandverse_NodeImpl("!ハードコーディング_DataBackup#DeleteOldBackup", null);
                    Givechapterandverse_Filepath cf_Fpath = new Givechapterandverse_FilepathImpl("ファイルパス出典未指定L03_6", parent_Givechapterandverse_Node);
                    cf_Fpath.InitPath(
                        sFilepathabsolute_Backuphome,
                        sName_DeleteeFolder,
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }

                    ec_Fpath = new Expression_Node_FilepathImpl(cf_Fpath);
                }

                string sFopath_Deletee;
                if (log_Reports.BSuccessful)
                {
                    // 正常時
                    sFopath_Deletee = ec_Fpath.Execute_OnExpressionString(
                        Request_SelectingImpl.Unconstraint,
                        log_Reports
                        );
                    if (!log_Reports.BSuccessful)
                    {
                        // 既エラー。
                        goto gt_EndMethod;
                    }
                }
                else
                {
                    sFopath_Deletee = "";
                }

                if (log_Reports.BSuccessful)
                {
                    // 正常時

                    Directory.Delete(sFopath_Deletee, true);
                }

            }

            goto gt_EndMethod;
        //
        //
        gt_EndMethod:
            return;
        }

        /// <summary>
        /// 「20091011」や、「20091203_yamada」といった文字列。
        /// 
        /// 「今日の日付」と「サブネーム」をもとに作成されます。
        /// フォルダー名に使用される想定です。
        /// </summary>
        /// <returns></returns>
        public static string CreateDateFolderName(string sName_Sub)
        {
            DateTime today = DateTime.Today;

            StringBuilder sb = new StringBuilder();

            // 年：4桁の数字
            sb.Append(String.Format("{0:D4}", today.Year));

            // 月：2桁の数字
            sb.Append(String.Format("{0:D2}", today.Month));

            // 日：2桁の数字
            sb.Append(String.Format("{0:D2}", today.Day));

            if ("" != sName_Sub)
            {
                sb.Append("_");
                sb.Append(sName_Sub);
            }

            return sb.ToString();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「grape/fruit/dog/banana/apple.txt」といった長いファイルパスを、
        /// 「LONG_NAME/1@banana@apple.txt」といったように、
        /// 強引に無理矢理縮めるメソッドです。
        /// 
        /// バックアップ・ファイルを取るときなどに必要であれば使います。
        /// </summary>
        /// <param name="oFilePath">ファイルパス</param>
        /// <param name="substitutionFileNumber">代替ファイル番号。ファイル名が重複しないようメソッド外部で既に振り分けられた数字。</param>
        /// <returns></returns>
        public static string ReplaceToJammingFilePath(
            string sFpath,
            int nSubstitutionFileNumber,
            string sLogStack
            )
        {
            // 出力ファイルの絶対パスの長さがファイル・システムの上限を超えたとき。

            // 出力ファイル・パスを短く加工します。
            // 方法としては、ディレクトリの名前を次のように変換します。
            //
            // 「LONG_NAME_000000/親ディレクトリ名/ファイル名」（名前の長さはだいたい16文字ぐらいを想定）
            //
            // 数字は特に決まりなく被っていない数字です。前ゼロも付けません。

            // TODO 余計に長くなる可能性をどうするか？

            // TODO filePathが長いと、落ちてしまう。

            char[] pathSeparator = new char[] { '\\', '/' };
            int nLastIndex1 = sFpath.LastIndexOfAny(pathSeparator);

            // ファイル名
            string sFileName;
            if (0 <= nLastIndex1)
            {
                sFileName = sFpath.Substring(nLastIndex1 + 1, sFpath.Length - (nLastIndex1 + 1));
            }
            else
            {
                // TODO エラー対応
                sFileName = "";
            }

            // 親ディレクトリ名（1つ前の文字から読取り開始）
            int nLastIndex2 = sFpath.LastIndexOfAny(pathSeparator, nLastIndex1 - 1);

            string sName_ParentDir;
            if (0 <= nLastIndex2)
            {
                // 区切り記号は「\」と「/」がある。ともに1文字なのは同じ。
                sName_ParentDir = sFpath.Substring(nLastIndex2 + 1, nLastIndex1 - nLastIndex2 - "\\".Length);
            }
            else
            {
                // 親ディレクトリ名がない場合もある。
                sName_ParentDir = "";
            }


            StringBuilder sb = new StringBuilder();
            sb.Append("LONG_NAME");
            sb.Append(Path.DirectorySeparatorChar);
            sb.Append(nSubstitutionFileNumber);
            sb.Append("@");// パスの区切り記号を、あまり使わない「@」に変換
            if ("" != sName_ParentDir)
            {
                sb.Append(sName_ParentDir);//親ディレクトリ名
                sb.Append("@");// パスの区切り記号を、あまり使わない「@」に変換
            }
            sb.Append(sFileName);//ファイル名

            // 置換
            return sb.ToString();
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// 次の2つは、日付フォルダーとして扱います。
        /// ・ファイル名が8桁の数字
        /// ・ファイル名の先頭8桁が数字で、アンダースコアが続く。
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="refDateNumber">日付の8桁の数値。日付フォルダーでない場合は、-1が入ります。</param>
        /// <param name="folderOwnerName">フォルダーの保存、破棄を担当するアプリケーションを区別する名前。</param>
        /// <returns></returns>
        private static bool IsDateFolderName(
            string sName_Folder,
            ref int nRefDate,
            ref string sName_Sub
            )
        {
            sName_Folder = sName_Folder.Trim();

            // 先頭の8文字。
            string sName0to7;

            if (sName_Folder.Length < 8)
            {
                // フォルダー名が8文字未満なら

                nRefDate = -1;

                return false;
            }
            else if (8 < sName_Folder.Length)
            {
                // フォルダー名が9文字以上なら

                // 9文字目は、0から始まる数字で[8]。
                string charAt8 = sName_Folder.Substring(8, 1); ;
                if ("_" != charAt8)
                {
                    // 9文字目がアンダースコアでないなら

                    nRefDate = -1;
                    return false;
                }

                sName0to7 = sName_Folder.Substring(0, 8);

                // 9文字目の _ の後ろは、フォルダー・オーナー名とする。
                sName_Sub = sName_Folder.Substring(9, sName_Folder.Length - 9);

            }
            else
            {
                // フォルダー名が8文字なら

                sName0to7 = sName_Folder;

                // フォルダー・オーナー名はなし。
                sName_Sub = "";
            }

            // フォルダー名が8文字か、
            // あるいは　フォルダー名が9文字以上で、9文字目がアンダースコアのとき。

            if (!int.TryParse(sName0to7, out nRefDate))
            {
                // 先頭8文字が数字でないなら

                nRefDate = -1;
                return false;
            }
            else
            {
                // 先頭8文字が数字なら

                return true;
            }
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private List<Expression_Node_Filepath> list_Expression_Filepath_Request;

        /// <summary>
        /// バックアップしたいファイルのパス一覧。
        /// </summary>
        public List<Expression_Node_Filepath> List_Expression_Filepath_Request
        {
            get
            {
                return list_Expression_Filepath_Request;
            }
            set
            {
                list_Expression_Filepath_Request = value;
            }
        }

        //────────────────────────────────────────

        private Expression_Node_Filepath expression_Filepath_Backuphome;

        /// <summary>
        /// バックアップ・ホーム・フォルダー。
        /// </summary>
        public Expression_Node_Filepath Expression_Filepath_Backuphome
        {
            get
            {
                return expression_Filepath_Backuphome;
            }
            set
            {
                expression_Filepath_Backuphome = value;
            }
        }

        //────────────────────────────────────────

        private int nKeptbuckups;

        /// <summary>
        /// 保管する日付バックアップ・フォルダー数。
        /// </summary>
        public int NKeptbackups
        {
            set
            {
                nKeptbuckups = value;
            }
            get
            {
                return nKeptbuckups;
            }
        }

        //────────────────────────────────────────

        private string sName_Sub;

        /// <summary>
        /// サブネーム。
        /// 例えば「20091203_yamada」の「yamada」に当たる文字列。アンダースコアは含まない。
        /// </summary>
        public string SName_Sub
        {
            set
            {
                sName_Sub = value;
            }
            get
            {
                return sName_Sub;
            }
        }

        //────────────────────────────────────────

        private int nSubstitutionFileNumber;

        /// <summary>
        /// 代替ファイル番号。
        /// ファイル名が長かった場合、変わりにこの数字に置換します。
        /// 
        /// 非スレッドセーフ。同じ処理が走っていれば、重複します。
        /// </summary>
        private int NSubstitutionFileNumber
        {
            set
            {
                nSubstitutionFileNumber = value;
            }
            get
            {
                return nSubstitutionFileNumber;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}
