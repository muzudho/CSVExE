using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Xenon.Syntax;
using Xenon.Middle;

namespace Xenon.Functions
{



    public class FilesystemrunnerImpl : Filesystemrunner
    {


        #region 用意
        //────────────────────────────────────────

        public const string S_FILE = "File";
        public const string S_FOLDER = "Folder";
        public const string S_BOTH = "Both";

        //────────────────────────────────────────
        #endregion


        #region アクション
        //────────────────────────────────────────

        public void Run(
            Filesystemreport filesystemreporter,
            string folderpathabsolute,
            string filter,
            string search_Subfolder,
            Log_Reports log_Reports
            )
        {
            Log_Method log_Method = new Log_MethodImpl(0);
            log_Method.BeginMethod(Info_Functions.Name_Library, this, "Run", log_Reports);

            //log_Method.WriteDebug_ToConsole("folderpathabsolute=[" + folderpathabsolute + "] filter=[" + filter + "] search_Subfolder=[" + search_Subfolder + "]");

            switch (filter)
            {
                case S_FILE:
                    {
                        string[] array_Filesystementry = Directory.GetFiles(folderpathabsolute);

                        // ファイル・フィルターの場合、サブフォルダーは無い。
                        filesystemreporter.AddList(new List<string>(array_Filesystementry));
                    }
                    break;
                case S_FOLDER:
                    {
                        string[] array_Filesystementry = Directory.GetDirectories(folderpathabsolute);
                        if (ValuesAttr.S_YES == search_Subfolder)
                        {
                            foreach (string child_Folderpath in array_Filesystementry)
                            {
                                filesystemreporter.Add(child_Folderpath);

                                //log_Method.WriteDebug_ToConsole("Folder フォルダー子実行 folderpathabsolute=[" + folderpathabsolute + "] filter=[" + filter + "] search_Subfolder=[" + search_Subfolder + "]");
                                this.Run(
                                    filesystemreporter,
                                    child_Folderpath,
                                    filter,
                                    search_Subfolder,
                                    log_Reports
                                    );
                            }
                        }
                        else
                        {
                            filesystemreporter.AddList(new List<string>(array_Filesystementry));
                        }
                    }
                    break;
                default:
                    // BOTH
                    {
                        string[] array_Filesystementry = Directory.GetFileSystemEntries(folderpathabsolute);
                        if (ValuesAttr.S_YES == search_Subfolder)
                        {
                            foreach (string child_Folderpath in array_Filesystementry)
                            {
                                filesystemreporter.Add(child_Folderpath);

                                if (Directory.Exists(child_Folderpath))
                                {
                                    // フォルダーなら実行。
                                    //log_Method.WriteDebug_ToConsole("Both フォルダー子実行。 folderpathabsolute=[" + folderpathabsolute + "] filter=[" + filter + "] search_Subfolder=[" + search_Subfolder + "]");
                                    this.Run(
                                        filesystemreporter,
                                        child_Folderpath,
                                        filter,
                                        search_Subfolder,
                                        log_Reports
                                        );
                                }

                            }
                        }
                        else
                        {
                            filesystemreporter.AddList(new List<string>(array_Filesystementry));
                        }
                    }
                    break;
            }

            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion




    }



}
