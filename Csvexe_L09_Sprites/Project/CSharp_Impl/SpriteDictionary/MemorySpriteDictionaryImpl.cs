using System;
using System.Collections.Generic;
using System.IO;//File
using System.Linq;
using System.Text;
using System.Drawing;//Bitmap,Point
using System.Windows.Forms;//Graphics

using Xenon.Syntax;

///
/// クラス・ライブラリ。
/// 
/// Xenon … 鬼畜大王が作ったクラスが入る名前空間。
///
/// Sprites … スプライトを画面上で動かすクラスが入る名前空間。
///
namespace Xenon.Sprites
{

    /// <summary>
    /// マウスで操作されるスプライトたち。
    /// 
    /// スプライトが描画されるパネルの、次の2つのイベントハンドラで、
    /// SpriteMouseSystemのメソッドを呼び出してください。
    /// (1) Paint
    /// (2) OnLoad
    /// 
    /// (Model Of Sprites Dictionary Impl)
    /// </summary>
    public class MemorySpriteDictionaryImpl : MemorySpriteDictionary
    {



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター。
        /// 
        /// 使い始める前に、PutDefaultメソッドを使うか、必要な値を全てセットし終えてください。
        /// </summary>
        public MemorySpriteDictionaryImpl()
        {
            // 1回設定するだけでＯＫなデリゲーター
            this.dlgt_OnMouseTargettingChanged = new DLGT_OnMouseTargettingChanged(this.OnMouseTargettingChanged);
            this.dlgt_OnSpriteSelectionChanged = new DLGT_OnSpriteSelectionChanged(this.OnSpriteSelectionChanged);

            // 空のディクショナリーとリスト。
            this.dictionary_Sprite = new Dictionary<int, Sprite>();
            this.list_SpriteZOrder = new List<KeyValuePair<int, Sprite>>();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 登録されているスプライトと、それに関連する内部データを全てクリアーします。
        /// </summary>
        public void Clear()
        {
            this.Dictionary_Sprite.Clear();
            this.List_SpriteZOrder.Clear();

            // クリアーすることで、エラーが起こりえるプロパティーは、クリアーしません。
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 最初のデフォルト設定にします。
        /// 
        /// ゴミデータを除去するには、クリアーも併用してください。
        /// </summary>
        public void PutDefault()
        {
            // 赤色の枠線や×印を描くペン。
            this.BorderPen4OnInvalid = new Pen(Color.Brown, 4);
            this.BorderPen2OnInvalid = new Pen(Color.Red, 2);

            // 警告メッセージを塗るブラシ。
            this.BorderBrushOnInvalid = new SolidBrush(Color.Red);


            // 緑色の線を描くペン。
            this.BorderPen4OnOver = new Pen(Color.Green, 4);
            this.BorderPen2OnOver = new Pen(Color.GreenYellow, 2);

            // 青色の矩形を塗るペンとブラシ。
            this.BorderPen4OnSelected = new Pen(Color.Blue, 4);
            this.BorderBrushOnSelected = new SolidBrush(Color.FromArgb(128, 0, 0, 255));
        }

        //────────────────────────────────────────

        /// <summary>
        /// 画像の選択のキャンセルを解除。
        /// </summary>
        public void CancelSelectToggleAll()
        {
            foreach (Sprite sprite in this.Dictionary_Sprite.Values)
            {
                sprite.BSelectToggled = false;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 選択中のスプライトを全て取得。
        /// </summary>
        public Dictionary<int, Sprite> SelectedSprites()
        {
            Dictionary<int, Sprite> dic_SelectedSprite = new Dictionary<int, Sprite>();

            foreach (KeyValuePair<int, Sprite> kvPair in this.Dictionary_Sprite)
            {
                if (kvPair.Value.BSelected)
                {
                    dic_SelectedSprite.Add(kvPair.Key, kvPair.Value);
                }
            }

            return dic_SelectedSprite;
        }

        //────────────────────────────────────────

        /// <summary>
        /// ドラッグ中のスプライトを全て取得。
        /// </summary>
        public Dictionary<int, Sprite> DraggingSprites()
        {
            Dictionary<int, Sprite> dic_DraggingSprite = new Dictionary<int, Sprite>();

            foreach (KeyValuePair<int, Sprite> kvPair in this.Dictionary_Sprite)
            {
                if (kvPair.Value.BDragging)
                {
                    dic_DraggingSprite.Add(kvPair.Key, kvPair.Value);
                }
            }

            return dic_DraggingSprite;
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウスターゲットになっているスプライトを全て取得。
        /// </summary>
        public Dictionary<int, Sprite> TargetSprites()
        {
            Dictionary<int, Sprite> dic_TargetSprite = new Dictionary<int, Sprite>();

            foreach (KeyValuePair<int, Sprite> kvPair in this.Dictionary_Sprite)
            {
                if (kvPair.Value.BMouseTarget)
                {
                    dic_TargetSprite.Add(kvPair.Key, kvPair.Value);
                }
            }

            return dic_TargetSprite;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 指定のスプライトを、名前で削除します。
        /// 
        /// 同名のスプライトがないという前提です。
        /// </summary>
        public void Remove(int nSpriteIndex)
        {
            // 連想配列から
            this.dictionary_Sprite.Remove(nSpriteIndex);

            // 表示リストの再構築
            this.SortByZOrder();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 指定のスプライトを、名前で削除します。
        /// 
        /// 同名のスプライトがないという前提です。
        /// </summary>
        public void RemoveAll(Dictionary<int, Sprite>.KeyCollection spriteNameList)
        {
            foreach (int nSpriteIndex in spriteNameList)
            {
                // 削除を実行します。

                // 連想配列から
                this.dictionary_Sprite.Remove(nSpriteIndex);
            }

            // 表示リストの再構築
            this.SortByZOrder();
        }

        //────────────────────────────────────────

        /// <summary>
        /// 1つでもドラッグ中のスプライトがあれば真です。
        /// </summary>
        /// <returns></returns>
        public bool IsDraggingAnything()
        {
            foreach (Sprite sprite in this.Dictionary_Sprite.Values)
            {
                if (sprite.BDragging)
                {
                    return true;
                }
            }

            return false;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 選択されている画像の位置を動かします。
        /// </summary>
        public void OffsetLocationOfSelectedSprite(
            int nTranslateX,
            int nTranslateY,
            bool bSelectedOfDraggingImage
            )
        {
            foreach (Sprite sprite in this.Dictionary_Sprite.Values)
            {
                // ドラッグ中か、ドラッグ中の画像として選択されていて、選択中のスプライトなら。
                if (sprite.BDragging || (bSelectedOfDraggingImage && sprite.BSelected))
                {
                    //.Console.WriteLine(this.GetType().Name + "#OffsetLocationOfSelectedSprite: ▲ドラッグで移動　スプライト インデックス＝["+sprite.Index+"]　移動量＝["+translateX+", "+translateY+"]　グリッド スナップを無視して移動していないか？");

                    // 画像の左上隅の位置を動かすので、マウスカーソルの位置から、画像内座標を引いて、左上隅の座標を算出します。
                    sprite.OffsetLefttopLocation(
                        nTranslateX,
                        nTranslateY
                        );
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// スプライトの上に、マウスカーソルが重なっているか判定します。
        /// </summary>
        public void CheckMouseOveredAll(
            Point mouseLocation,
            Point parentLocation
            )
        {
            //
            // 複数個のマウスカーソルが重なっている場合、
            // 最前景のスプライトを選択するものとします。
            //
            Sprite lastOveredSprite = null;

            foreach (KeyValuePair<int, Sprite> spriteKV in this.List_SpriteZOrder)
            {
                if (spriteKV.Value.BoundsLefttopScaled.Contains(
                    mouseLocation.X - parentLocation.X,
                    mouseLocation.Y - parentLocation.Y
                    ))
                {
                    //spriteKV.Value.MouseOvered = true;
                    lastOveredSprite = spriteKV.Value;
                }
                else
                {
                    //spriteKV.Value.MouseOvered = false;
                }
            }

            //
            //
            // 新しく選択対象になるスプライト以外は、全て選択対象から外します。
            //
            foreach (KeyValuePair<int, Sprite> spriteKV in this.List_SpriteZOrder)
            {
                if (spriteKV.Value != lastOveredSprite)
                {
                    // 新しく選択対象になるスプライト以外

                    if (!spriteKV.Value.BMouseTarget)
                    {
                        // もともとマウスターゲットでなかったのなら、変更はありません。
                    }
                    else
                    {
                        // マウスターゲットを解除。
                        spriteKV.Value.BMouseTarget = false;

                        // マウス ターゲット変更
                        //.WriteLine(this.GetType().Name + "#CheckMouseOveredAll: ▲マウスターゲットが解除されました。");
                        this.dlgt_OnMouseTargettingChanged(
                            spriteKV.Value,
                            parentLocation
                            );
                    }
                }
            }

            if (null != lastOveredSprite)
            {
                // 最後の番号

                if (lastOveredSprite.BMouseTarget)
                {
                    // 既にマウス ターゲットだった場合、変更はありません。
                }
                else
                {
                    lastOveredSprite.BMouseTarget = true;

                    // マウス ターゲット変更
                    //.WriteLine(this.GetType().Name + "#CheckMouseOveredAll: ▲マウスターゲットに設定されました。");
                    this.dlgt_OnMouseTargettingChanged(
                        lastOveredSprite,
                        parentLocation
                        );
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// マウスに重なっている画像の選択／非選択を切り替える可能性が発生します。マウス・ムーブを挟むと、切り替えの意思を解除。
        /// </summary>
        public void CheckSelectToggledAll(Point mouseLocation, Point parentLocation)
        {
            // 最前面のスプライトだけを判定します。
            Sprite foregroundSprite = null;

            foreach (KeyValuePair<int, Sprite> spriteKV in this.List_SpriteZOrder)
            {
                if (spriteKV.Value.BoundsLefttopScaled.Contains(
                    mouseLocation.X - parentLocation.X,
                    mouseLocation.Y - parentLocation.Y
                    ))
                {
                    foregroundSprite = spriteKV.Value;
                }
            }

            if (null != foregroundSprite)
            {
                foregroundSprite.BSelectToggled = true;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 描画を行います。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="parentLocation"></param>
        /// <param name="pg_Logging"></param>
        public void Paint(
            Graphics g,
            Point parentLocation,
            Log_Reports pg_Logging
            )
        {
            foreach (KeyValuePair<int, Sprite> spriteKV in this.List_SpriteZOrder)
            {
                spriteKV.Value.Paint(g, parentLocation, this, pg_Logging);
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteIndex"></param>
        /// <param name="imageFilePath"></param>
        /// <param name="initX"></param>
        /// <param name="initY"></param>
        /// <param name="sConfigStack_OfSprite">新しく作るスプライトに設定されるデバッグ用情報</param>
        /// <returns></returns>
        public Sprite CreateSprite(
            int nSpriteIndex,
            string sFpath_Image,
            int nInitX,
            int nInitY,
            string sConfigStack_OfSprite
            )
        {
            // スプライトの新規作成
            Sprite sprite = new SpriteImpl(sConfigStack_OfSprite);
            sprite.NIndex = nSpriteIndex;
            // 座標
            sprite.SetLefttopLocation(nInitX, nInitY);

            bool bRead = false;

            // 画像の読取り
            if ("" == sFpath_Image.Trim())
            {
                // ファイルパスが未指定の場合。
            }
            else
            {
                if (File.Exists(sFpath_Image))
                {
                    // 一応チェックはするが、タイミングにより
                    // 画像パスが無くなっているかも。

                    try
                    {
                        sprite.Bmp = new Bitmap(sFpath_Image);

                        bRead = true;
                        // サイズ指定
                        sprite.SetSize(sprite.Bmp.Width, sprite.Bmp.Height);
                    }
                    catch (Exception)
                    {
                        // 画像が取得できませんでした。
                    }
                }
                else
                {
                    // todo:画像ファイルが無い場合。
                }
            }

            if (!bRead)
            {
                // 画像ファイルを読み込めなかった場合。

                // 暫定で 32x32にしておく。
                sprite.SetSize(32, 32);
            }

            return sprite;
        }

        //────────────────────────────────────────

        /// <summary>
        /// スプライトを追加します。
        /// 
        /// 事前に CanAddSprite を使って、スプライトを追加できることを確認してから使用してください。
        /// </summary>
        public void AddSprite(Sprite sprite, Log_Reports pg_Logging)
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Sprite.SName_Library, this, "AddSprite",pg_Logging);

            Exception err_Excp;
            if (this.Dictionary_Sprite.ContainsKey(sprite.NIndex))
            {
                if (pg_Logging.CanCreateReport)
                {
                    Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー805！", pg_Method);

                    StringBuilder t = new StringBuilder();
                    t.Append("スプライトを追加しようとしましたが、既に スプライト[");
                    t.Append(sprite.NIndex);
                    t.Append("]番は追加済みです。");

                    //text.Append(Environment.NewLine);
                    //text.Append(Environment.NewLine);
                    //text.Append("実行経路ヒント：");
                    //text.Append(runningHintName);

                    r.Message = t.ToString();
                    pg_Logging.EndCreateReport();
                }
            }
            else
            {
                try
                {
                    // システムにスプライトを追加し、Z-Order順に再計算します。

                    // スプライトを追加します。
                    this.Dictionary_Sprite.Add(sprite.NIndex, sprite);

                    this.SortByZOrder();
                }
                catch (Exception e)
                {
                    err_Excp = e;
                    goto gt_Error_Exception;
                }
            }

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Exception:
            if (pg_Logging.CanCreateReport)
            {
                Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー806！", pg_Method);

                StringBuilder t = new StringBuilder();
                t.Append("sprite.Index=[");
                t.Append(sprite.NIndex);
                t.Append("]");
                t.Append(Environment.NewLine);
                t.Append("エラーメッセージ：");
                t.Append(err_Excp.Message);

                //text.Append(Environment.NewLine);
                //text.Append(Environment.NewLine);
                //text.Append("実行経路ヒント：");
                //text.Append(runningHintName);

                r.Message = t.ToString();
                pg_Logging.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
        }

        //────────────────────────────────────────

        /// <summary>
        /// Z-Order順にソートします。
        /// </summary>
        private void SortByZOrder()
        {
            // リストを新規作成。
            this.List_SpriteZOrder = new List<KeyValuePair<int, Sprite>>(this.Dictionary_Sprite);

            // Valueの大きい順にソート
            this.List_SpriteZOrder.Sort(CompareZOrder);
        }

        //────────────────────────────────────────

        private int CompareZOrder(
            KeyValuePair<int, Sprite> sprite1,
            KeyValuePair<int, Sprite> sprite2)
        {
            return sprite2.Value.NZOrder - sprite1.Value.NZOrder;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// デフォルト・デリゲート
        /// </summary>
        public void OnMouseTargettingChanged(Sprite sprite, Point parentLocation)
        {
            // 何もしません。
        }

        //────────────────────────────────────────

        /// <summary>
        /// デフォルト・デリゲート
        /// </summary>
        public void OnSpriteSelectionChanged(Sprite sprite, Point parentLocation)
        {
            // 何もしません。
        }

        //────────────────────────────────────────

        /// <summary>
        /// デフォルト・デリゲートの処理を実行します。
        /// </summary>
        public void Dlgt_OnSpriteSelectionChangedPerform(Sprite sprite, Point parentLocation)
        {
            this.dlgt_OnSpriteSelectionChanged(sprite, parentLocation);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 選択されているスプライトを削除する条件です。
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        private static bool CompareOfSelectedSpriteForDeletes(Sprite sprite)
        {
            return sprite.BSelected;
        }

        //────────────────────────────────────────
        #endregion



        #region 判定
        //────────────────────────────────────────

        /// <summary>
        /// スプライトを、コレクションに追加可能かどうか。
        /// </summary>
        /// <returns></returns>
        public bool CanAddSprite(
            Sprite sprite,
            Log_Reports pg_Logging
            )
        {
            Log_Method pg_Method = new Log_MethodImpl(0);
            pg_Method.BeginMethod(Info_Sprite.SName_Library, this, "CanAddSprite",pg_Logging);


            bool bResult;

            if (null == sprite)
            {
                // エラー
                goto gt_Error_NullSprite;
            }

            if (this.Dictionary_Sprite.ContainsKey(sprite.NIndex))
            {
                // 既に指定の名前のスプライトは含まれています。

                // エラー
                goto gt_Error_ExistsSprite;
            }

            bResult = true;

            goto gt_EndMethod;
        //
        //
            #region 異常系
        //────────────────────────────────────────
        gt_Error_NullSprite:
            {
                bResult = false;

                if (pg_Logging.CanCreateReport)
                {
                    Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー803！", pg_Method);
                    r.Message = "スプライト コレクションにヌルは追加できません。";

                    pg_Logging.EndCreateReport();
                }
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_ExistsSprite:
            {
                bResult = false;

                if (pg_Logging.CanCreateReport)
                {
                    Log_RecordReport r = pg_Logging.BeginCreateReport(EnumReport.Error);
                    r.SetTitle("▲エラー804！", pg_Method);

                    StringBuilder t = new StringBuilder();
                    t.Append("スプライト コレクションに格納するためのスプライト番号がぶつかりました。");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);
                    t.Append("既に指定のスプライト[");
                    t.Append(sprite.NIndex);
                    t.Append("]番は含まれています。");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);
                    t.Append("もしかすると？　既に使われている番号を、これから追加するスプライトに");
                    t.Append(Environment.NewLine);
                    t.Append("　　　　　　　　付けたプログラムのミス？");
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);
                    t.Append(Environment.NewLine);
                    t.Append("問題箇所ヒント（スプライト）：");
                    t.Append(sprite.SLogStack);

                    //text.Append(Environment.NewLine);
                    //text.Append(Environment.NewLine);
                    //text.Append("実行経路ヒント：");
                    //text.Append(runningHintName);

                    r.Message = t.ToString();
                    pg_Logging.EndCreateReport();
                }
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        //
        //
        gt_EndMethod:
            pg_Method.EndMethod(pg_Logging);
            return bResult;
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Dictionary<int, Sprite> dictionary_Sprite;

        /// <summary>
        /// 画面上に配置される画像データです。
        /// 
        /// 並び順は指定できません。
        /// </summary>
        public Dictionary<int, Sprite> Dictionary_Sprite
        {
            get
            {
                return dictionary_Sprite;
            }
            set
            {
                dictionary_Sprite = value;
            }
        }

        //────────────────────────────────────────

        private List<KeyValuePair<int, Sprite>> list_SpriteZOrder;

        /// <summary>
        /// スプライトを Z-Orderの昇順（表示で最背面から最前面への順）に並び替えたリストです。
        /// </summary>
        public List<KeyValuePair<int, Sprite>> List_SpriteZOrder
        {
            get
            {
                return list_SpriteZOrder;
            }
            set
            {
                list_SpriteZOrder = value;
            }
        }

        //────────────────────────────────────────

        private Pen borderPen4OnInvalid;

        /// <summary>
        /// 警告のために表示される赤枠や×印を描くペン。赤色で太い。
        /// 
        /// 画像が読み込まれていなかったり、配置位置が不妥当だった場合など警告用。
        /// </summary>
        public Pen BorderPen4OnInvalid
        {
            get
            {
                return borderPen4OnInvalid;
            }
            set
            {
                borderPen4OnInvalid = value;
            }
        }

        //────────────────────────────────────────

        private Pen borderPen2OnInvalid;

        /// <summary>
        /// 赤色の枠や×印を描くためのペン。桃色で細い。
        /// 
        /// 画像が読み込まれていなかったり、配置位置が不妥当だった場合など警告用。
        /// </summary>
        public Pen BorderPen2OnInvalid
        {
            get
            {
                return borderPen2OnInvalid;
            }
            set
            {
                borderPen2OnInvalid = value;
            }
        }

        //────────────────────────────────────────

        private Brush borderBrushOnInvalid;

        /// <summary>
        /// 警告文字用ブラシ。
        /// </summary>
        public Brush BorderBrushOnInvalid
        {
            get
            {
                return borderBrushOnInvalid;
            }
            set
            {
                borderBrushOnInvalid = value;
            }
        }

        //────────────────────────────────────────

        private Pen borderPen2OnOver;

        /// <summary>
        /// マウスオーバーした時に付く枠を描くペン。緑色で太い。
        /// </summary>
        public Pen BorderPen2OnOver
        {
            get
            {
                return borderPen2OnOver;
            }
            set
            {
                borderPen2OnOver = value;
            }
        }

        //────────────────────────────────────────

        private Pen borderPen4OnOver;

        /// <summary>
        /// マウスオーバーした時に付く枠を描くペン。緑色で太い。
        /// </summary>
        public Pen BorderPen4OnOver
        {
            get
            {
                return borderPen4OnOver;
            }
            set
            {
                borderPen4OnOver = value;
            }
        }

        //────────────────────────────────────────

        private Brush borderBrushOnSelected;

        /// <summary>
        /// 選択した時に付く枠を描くブラシ。青い。
        /// </summary>
        public Brush BorderBrushOnSelected
        {
            get
            {
                return borderBrushOnSelected;
            }
            set
            {
                borderBrushOnSelected = value;
            }
        }

        //────────────────────────────────────────

        private Pen borderPen4OnSelected;

        /// <summary>
        /// 選択した時に付く枠を描くペン。青くて太い。
        /// </summary>
        public Pen BorderPen4OnSelected
        {
            get
            {
                return borderPen4OnSelected;
            }
            set
            {
                borderPen4OnSelected = value;
            }
        }

        //────────────────────────────────────────

        private DLGT_OnMouseTargettingChanged dlgt_OnMouseTargettingChanged;

        /// <summary>
        /// マウスの操作対象が変更されたとき。
        /// </summary>
        public DLGT_OnMouseTargettingChanged Dlgt_OnMouseTargettingChanged
        {
            set
            {
                dlgt_OnMouseTargettingChanged = value;
            }
        }

        //────────────────────────────────────────

        private DLGT_OnSpriteSelectionChanged dlgt_OnSpriteSelectionChanged;

        /// <summary>
        /// スプライトの選択が変更されたとき。
        /// </summary>
        public DLGT_OnSpriteSelectionChanged Dlgt_OnSpriteSelectionChanged
        {
            set
            {
                dlgt_OnSpriteSelectionChanged = value;
            }
        }

        //────────────────────────────────────────

        public int NCount
        {
            get
            {
                return dictionary_Sprite.Count;
            }
        }

        //────────────────────────────────────────
        #endregion


    }
}
