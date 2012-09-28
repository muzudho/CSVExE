using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xenon.Controls;

namespace Xenon.ListboxWrap
{
    public class OperatorOfListbox
    {



        public class ReplacesResultImpl
        {



            #region 生成と破棄
            //────────────────────────────────────────

            public ReplacesResultImpl(object before, object after)
            {
                this.before = before;
                this.after = after;
            }

            //────────────────────────────────────────
            #endregion



            #region プロパティー
            //────────────────────────────────────────

            private object before;

            /// <summary>
            /// 変更前の項目
            /// </summary>
            public object Before
            {
                get
                {
                    return before;
                }
            }

            //────────────────────────────────────────

            private object after;

            /// <summary>
            /// 変更後の項目
            /// </summary>
            public object After
            {
                get
                {
                    return after;
                }
            }

            //────────────────────────────────────────
            #endregion



        }



        #region 生成と破棄
        //────────────────────────────────────────

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="listBox"></param>
        private OperatorOfListbox()
        {
            this.sMessage_SelectionPrompted = "項目を選択してください。";
            this.sMessage_AddsRepeated = "既に追加されている項目は、追加できません。";
            this.sMessage_ReplacesRepeated = "既に追加されている項目には、置換できません。";
            this.SMessage_ReplacesRepeated2 = "重複が許されていないリストで、複数の項目を同じ値にしようとしましたが、最初の1件分だけ処理します。";
            this.sMessage_TextboxEmpty = "テキストボックスに、項目を入力してください。";
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="listBox"></param>
        public OperatorOfListbox(ListBox listbox)
            : base()
        {
            this.listboxWrapper = new ListboxWrapperImpl(listbox);
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="listBox"></param>
        public OperatorOfListbox(UsercontrolListbox usercontrolListbox)
            : base()
        {
            this.listboxWrapper = new ListboxWrapperImpl(usercontrolListbox);
        }

        /// <summary>
        /// 項目の全削除
        /// </summary>
        public void Clear()
        {
            this.listboxWrapper.Items.Clear();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 項目の追加
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool AddItem(object item)
        {
            bool bChanged;

            if (this.listboxWrapper.Items.Contains(item) && this.bNoRepeated)
            {
                // 無重複リストで、既に追加されている項目を追加しようとした場合。

                // エラー
                MessageBox.Show(this.SMessage_AddsRepeated);

                bChanged = false;
            }
            else
            {
                // テキストボックスの中の文字列を、
                // 項目として追加
                this.listboxWrapper.Items.Add(item);

                bChanged = true;
            }

            return bChanged;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 置換します。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<ReplacesResultImpl> ReplaceItem(object item)
        {
            List<ReplacesResultImpl> list_Result = new List<ReplacesResultImpl>();

            // Containsメソッドでは、文字列型以外の判定だと、失敗していることがある。
            if (this.listboxWrapper.Items.Contains(item) && this.bNoRepeated)
            {
                // 無重複リストで、既に追加されている項目に置換しようとした場合。

                // エラー
                MessageBox.Show(this.SMessage_ReplacesRepeated);
            }
            else
            {
                // 選択インデックス
                ListBox.SelectedIndexCollection collection = this.listboxWrapper.SelectedIndices;

                if (collection.Count < 1)
                {
                    // リストボックスの項目が選択されていなかった場合は、メッセージボックスを出します。
                    MessageBox.Show(this.SMessage_SelectionPrompted);
                }
                else
                {
                    // 逆回転します。前から置換・挿入を繰り返すと、処理が１個飛ばしになるので。
                    for (int nIndex = collection.Count - 1; 0 <= nIndex; nIndex--)
                    {
                        // 項目を置換します。
                        int nInsIndex = (int)collection[nIndex];
                        object beforeValue = this.listboxWrapper.Items[nInsIndex];

                        this.listboxWrapper.Items.RemoveAt(nInsIndex);

                        object afterValue = item;
                        this.listboxWrapper.Items.Insert(nInsIndex, item);

                        list_Result.Add(new ReplacesResultImpl(beforeValue, afterValue));

                        if (this.bNoRepeated && 1 < collection.Count)
                        {
                            // 無重複リストで、1件以上の置換の指定があっても、
                            // 最初の1件だけで処理を終了します。

                            // 無重複にしたいリストで、2個以上の項目を同じ値にしようとしたときの警告メッセージ。
                            MessageBox.Show(this.SMessage_ReplacesRepeated2);
                            break;
                        }
                    }
                }
            }

            return list_Result;
        }

        //────────────────────────────────────────
        //
        //テキストボックスを利用した項目の追加、置換
        //

        /// <summary>
        /// 項目の追加
        /// 
        /// テキストボックスに入力されているテキストを、リストの項目として追加します。
        /// 追加に成功した場合、テキストボックスは空になります。
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>追加が成功していれば真、失敗していれば偽。</returns>
        public bool AddItemFromTextbox(TextBox textbox)
        {
            return this.AddItemFromTextbox(new TextboxWrapperImpl(textbox));
        }

        //────────────────────────────────────────

        /// <summary>
        /// 項目の追加
        /// 
        /// テキストボックスに入力されているテキストを、リストの項目として追加します。
        /// 追加に成功した場合、テキストボックスは空になります。
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>追加が成功していれば真、失敗していれば偽。</returns>
        public bool AddItemFromTextbox(UsercontrolTextbox uctTxt)
        {
            return this.AddItemFromTextbox(new TextboxWrapperImpl(uctTxt));
        }

        //────────────────────────────────────────

        /// <summary>
        /// 項目の追加
        /// 
        /// テキストボックスに入力されているテキストを、リストの項目として追加します。
        /// 追加に成功した場合、テキストボックスは空になります。
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>追加が成功していれば真、失敗していれば偽。</returns>
        public bool AddItemFromTextbox(TextboxWrapperImpl textboxWrapper)
        {
            bool bChanged;

            string sText = textboxWrapper.SText;

            if (sText == "")
            {
                // テキストボックスが空だった場合は、メッセージボックスを出します。
                MessageBox.Show(this.SMessage_TextboxEmpty);

                bChanged = false;
            }
            else
            {
                bChanged = this.AddItem(sText);

                if (bChanged)
                {
                    // テキストボックスをクリアー
                    textboxWrapper.Clear();
                }
            }

            return bChanged;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 項目の追加
        /// 
        /// テキストボックスに入力されているテキストを、リストの項目として追加します。
        /// 現在選択されているアイテムの上に挿入されます。
        /// 追加に成功した場合、テキストボックスは空になります。
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>追加が成功していれば真、失敗していれば偽。</returns>
        public bool AddBeforeFromTextbox(TextBox textbox)
        {
            return this.AddBeforeFromTextbox(new TextboxWrapperImpl(textbox));
        }

        //────────────────────────────────────────

        /// <summary>
        /// 項目の追加
        /// 
        /// テキストボックスに入力されているテキストを、リストの項目として追加します。
        /// 現在選択されているアイテムの上に挿入されます。
        /// 追加に成功した場合、テキストボックスは空になります。
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>追加が成功していれば真、失敗していれば偽。</returns>
        public bool AddBeforeFromTextbox(UsercontrolTextbox uctTxt)
        {
            return this.AddBeforeFromTextbox(new TextboxWrapperImpl(uctTxt));
        }

        //────────────────────────────────────────

        /// <summary>
        /// 項目の追加
        /// 
        /// テキストボックスに入力されているテキストを、リストの項目として追加します。
        /// 現在選択されているアイテムの上に挿入されます。
        /// 追加に成功した場合、テキストボックスは空になります。
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>追加が成功していれば真、失敗していれば偽。</returns>
        public bool AddBeforeFromTextbox(TextboxWrapperImpl textboxWrapper)
        {
            if (textboxWrapper.SText == "")
            {
                // テキストボックスが空だった場合は、メッセージボックスを出します。
                MessageBox.Show(this.SMessage_TextboxEmpty);

                return false;
            }
            else
            {
                if (this.listboxWrapper.Items.Contains(textboxWrapper.SText) && this.bNoRepeated)
                {
                    // 無重複リストで、既に追加されている項目を追加しようとした場合。

                    // エラー
                    MessageBox.Show(this.SMessage_AddsRepeated);

                    return false;
                }
                else
                {
                    // 選択インデックス
                    ListBox.SelectedIndexCollection collection = this.listboxWrapper.SelectedIndices;

                    if (collection.Count < 1)
                    {
                        // リストボックスの項目が選択されていなかった場合は、メッセージボックスを出します。
                        MessageBox.Show(this.SMessage_SelectionPrompted);

                        return false;
                    }
                    else
                    {
                        // 逆回転します。前から挿入すると、要素番号が前倒しにずれてくるので。
                        for (int nIndex = collection.Count - 1; 0 <= nIndex; nIndex--)
                        {
                            // アイテム名を挿入します。
                            int insIndex = (int)collection[nIndex];
                            this.listboxWrapper.Items.Insert(insIndex, textboxWrapper.SText);
                        }

                        // テキストボックスをクリアーします。
                        textboxWrapper.Clear();
                    }

                    return true;
                }
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 項目の置換
        /// 
        /// 現在選択されているアイテムを、テキストボックスに入力されているテキストに置換します。
        /// 置換に成功した場合、テキストボックスは空になります。
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>追加が成功していれば真、失敗していれば偽。</returns>
        public List<ReplacesResultImpl> ReplaceItemFromTextbox(TextBox textbox)
        {
            return this.ReplaceItemFromTextbox(new TextboxWrapperImpl(textbox));
        }

        //────────────────────────────────────────

        /// <summary>
        /// 項目の置換
        /// 
        /// 現在選択されているアイテムを、テキストボックスに入力されているテキストに置換します。
        /// 置換に成功した場合、テキストボックスは空になります。
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>追加が成功していれば真、失敗していれば偽。</returns>
        public List<ReplacesResultImpl> ReplaceItemFromTextbox(UsercontrolTextbox uctTxt)
        {
            return this.ReplaceItemFromTextbox(new TextboxWrapperImpl(uctTxt));
        }

        //────────────────────────────────────────

        /// <summary>
        /// 項目の置換
        /// 
        /// 現在選択されているアイテムを、テキストボックスに入力されているテキストに置換します。
        /// 置換に成功した場合、テキストボックスは空になります。
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>追加が成功していれば真、失敗していれば偽。</returns>
        public List<ReplacesResultImpl> ReplaceItemFromTextbox(TextboxWrapperImpl textboxWrapper)
        {
            List<ReplacesResultImpl> list_Result;

            string sText = textboxWrapper.SText;

            if (sText == "")
            {
                // 警告メッセージを表示
                MessageBox.Show(this.SMessage_TextboxEmpty);

                list_Result = new List<ReplacesResultImpl>();
            }
            else
            {

                list_Result = this.ReplaceItem(sText);
            }

            if (0 < list_Result.Count)
            {
                // 置換した項目数が1件以上なら

                // テキストボックスをクリアーします。
                textboxWrapper.Clear();
            }

            return list_Result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 項目の削除
        /// 
        /// リストで選択されている項目を削除します。
        /// </summary>
        /// <returns>削除した項目数。</returns>
        public List<object> RemoveSelectedItem()
        {
            List<object> list_RemovedItem = new List<object>();

            ListBox.SelectedObjectCollection collection = this.listboxWrapper.SelectedItems;

            if (collection.Count < 1)
            {
                // リストボックスの項目が選択されていなかった場合は、メッセージボックスを出します。
                MessageBox.Show(this.SMessage_SelectionPrompted);
            }
            else
            {
                // 逆回転します。前から削除すると、要素番号が前倒しにずれてくるので。
                for (int nIndex = collection.Count - 1; 0 <= nIndex; nIndex--)
                {
                    list_RemovedItem.Add(collection[nIndex]);

                    this.listboxWrapper.Items.Remove(collection[nIndex]);
                }

                // 選択を解除します。
                this.listboxWrapper.ClearSelected();
            }

            return list_RemovedItem;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 選択アイテムの順番を上へ移動します。
        /// </summary>
        public bool MoveSelectedItemsToUp()
        {
            bool bChanged = false;

            bool bOldEnabled = this.listboxWrapper.BEnabled;
            this.listboxWrapper.BEnabled = false;

            int nUnmovableIndex = -1; // [-1]番目（0スタートの連番）の要素は、位置を変更しません。

            // 選択している要素の数は、スワップの最中に変化するので、別配列に移動します。
            int[] selectedIndices = new int[this.listboxWrapper.SelectedIndices.Count];

            if (selectedIndices.Length < 1)
            {
                // リストボックスの項目が選択されていなかった場合は、メッセージボックスを出します。
                MessageBox.Show(this.SMessage_SelectionPrompted);

                return false;
            }
            else
            {
                this.listboxWrapper.SelectedIndices.CopyTo(selectedIndices, 0);

                foreach (int selectedIndex in selectedIndices)
                {
                    if (nUnmovableIndex != selectedIndex - 1)
                    {
                        // 移動できるとき。

                        object tmp = this.listboxWrapper.Items[selectedIndex - 1];
                        this.listboxWrapper.Items[selectedIndex - 1] = this.listboxWrapper.Items[selectedIndex];
                        this.listboxWrapper.Items[selectedIndex] = tmp;

                        bChanged = true;
                    }
                    else
                    {
                        // 移動できないとき。

                        nUnmovableIndex = selectedIndex;
                    }
                }

                this.listboxWrapper.BEnabled = bOldEnabled;
            }

            return bChanged;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 選択アイテムの順番を下へ移動します。
        /// </summary>
        public bool MoveSelectedItemsToDown()
        {
            bool bChanged = false;

            bool bOldEnabled = this.listboxWrapper.BEnabled;
            this.listboxWrapper.BEnabled = false;

            int nUnmovableIndex = this.listboxWrapper.Items.Count; // [-1]番目（0スタートの連番）の要素は、位置を変更しません。

            // 選択している要素の数は、スワップの最中に変化するので、別配列に移動します。
            int[] selectedIndices = new int[this.listboxWrapper.SelectedIndices.Count];

            if (selectedIndices.Length < 1)
            {
                // リストボックスの項目が選択されていなかった場合は、メッセージボックスを出します。
                MessageBox.Show(this.SMessage_SelectionPrompted);

                return false;
            }
            else
            {
                this.listboxWrapper.SelectedIndices.CopyTo(selectedIndices, 0);

                // 逆順にします。
                Array.Reverse(selectedIndices);

                foreach (int nSelectedIndex in selectedIndices)
                {
                    if (nUnmovableIndex != nSelectedIndex + 1)
                    {
                        // 移動できるとき。

                        object tmp = this.listboxWrapper.Items[nSelectedIndex + 1];
                        this.listboxWrapper.Items[nSelectedIndex + 1] = this.listboxWrapper.Items[nSelectedIndex];
                        this.listboxWrapper.Items[nSelectedIndex] = tmp;

                        bChanged = true;
                    }
                    else
                    {
                        // 移動できないとき。

                        nUnmovableIndex = nSelectedIndex;
                    }
                }

                this.listboxWrapper.BEnabled = bOldEnabled;
            }

            return bChanged;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 指定項目A（1～複数件）を、指定項目Bの下に移動させます。
        /// </summary>
        /// <param name="sourceIndices">移動待ち要素のリスト。インデックスの昇順に並んでいる必要があります。</param>
        /// <param name="destinationIndex"></param>
        public void MoveItemsBefore(int[] sourceIndices, int nDestinationIndex)
        {
            if (nDestinationIndex < 0 && this.listboxWrapper.Items.Count <= nDestinationIndex)
            {
                // 無視。
                // 配列の長さと同数の数字を指定しても、現実装では無視。

                return;
            }

            bool bOldEnabled = this.listboxWrapper.BEnabled;
            this.listboxWrapper.BEnabled = false;

            // 位置調整に使うカウンター。
            int nOffset = 0;

            for (int nSourceArrayIndex = 0; nSourceArrayIndex < sourceIndices.Length; nSourceArrayIndex++)
            {
                int nSourceIndex = sourceIndices[nSourceArrayIndex];

                // 要素が動いた後の、移動待ちの全要素のインデックスを見直します。
                if (nDestinationIndex == nSourceIndex)
                {
                    // 移動元要素が動かなかったら

                    // 無視します。
                }
                else if (nDestinationIndex < nSourceIndex)
                {
                    // 移動元要素が、上に移動したのなら

                    // 移動元要素が移動後に　その後ろに来る要素で、
                    // もともと移動元要素より上にあった要素は、
                    // 位置が 1つ繰り下がり（+1）ます。
                    for (int nArrayIndex2 = nSourceArrayIndex+1; nArrayIndex2 < sourceIndices.Length; nArrayIndex2++)
                    {
                        if (nDestinationIndex <= sourceIndices[nArrayIndex2] && sourceIndices[nArrayIndex2] < nSourceIndex)
                        {
                            sourceIndices[nArrayIndex2]++;
                        }
                    }

                    // 移動元要素を、リストから一旦抜いた後で、移動先の要素の上に挿入します。
                    object sourceItem = this.listboxWrapper.Items[nSourceIndex];
                    this.listboxWrapper.Items.RemoveAt(nSourceIndex);

                    // Insertメソッドは、0から始まる数字を指定します。
                    // 指定したインデックスの上に挿入されます。
                    //
                    // 2つ目以降の要素が追加されるときは、
                    // 「先に追加した要素と同じインデックスにInsertする＝どんどん上に追加される」
                    // ことになるので、逆順になります。
                    // それを防ぐために offset で調整します。
                    this.listboxWrapper.Items.Insert(nDestinationIndex + nOffset, sourceItem);
                    nOffset++;
                }
                else
                {
                    // 移動元要素が、下に移動したのなら

                    // 移動元要素より下にあった要素で、
                    // 移動元要素が移動後に、その前に来る要素は、
                    // 位置が 1つ繰り上がり（-1）ます。
                    for (int nArrayIndex2 = nSourceArrayIndex+1; nArrayIndex2 < sourceIndices.Length; nArrayIndex2++)
                    {
                        if (sourceIndices[nArrayIndex2] <= nDestinationIndex && nSourceIndex < sourceIndices[nArrayIndex2])
                        {
                            sourceIndices[nArrayIndex2]--;
                        }
                    }

                    // 移動元要素を、一旦リストから抜いて、移動先の要素の上に挿入します。
                    object sourceItem = this.listboxWrapper.Items[nSourceIndex];
                    this.listboxWrapper.Items.RemoveAt(nSourceIndex);

                    // Insertメソッドは、0から始まる数字を指定します。
                    // 指定したインデックスの上に挿入されます。

                    // 移動元の要素が抜かれているので、移動先は1つ繰り下がって(+1)ずれこんでいます。
                    // -1 して、ずれこみを解消します。
                    this.listboxWrapper.Items.Insert(nDestinationIndex - 1, sourceItem);
                    // 2つ目以降の要素も　同じインデックスに追加されますが、
                    // 自分が削除されている瞬間に　移動先の要素は上に移動しているので、
                    // その空いたスペースに　自分が入ることになります。
                    // これで、正順に並ぶことになります。
                }
            }


            this.listboxWrapper.BEnabled = bOldEnabled;
        }

        //────────────────────────────────────────
        #endregion

        

        #region プロパティー
        //────────────────────────────────────────

        private string sMessage_SelectionPrompted;

        /// <summary>
        /// 項目を選択するよう促す警告メッセージ。
        /// </summary>
        public string SMessage_SelectionPrompted
        {
            set
            {
                sMessage_SelectionPrompted = value;
            }
            get
            {
                return sMessage_SelectionPrompted;
            }
        }

        //────────────────────────────────────────

        private bool bNoRepeated;

        /// <summary>
        /// 無重複なリストにしたい場合は真に設定してください。
        /// </summary>
        public bool BNoRepeated
        {
            set
            {
                bNoRepeated = value;
            }
            get
            {
                return bNoRepeated;
            }
        }

        //────────────────────────────────────────

        private string sMessage_AddsRepeated;

        /// <summary>
        /// 無重複にしたいリストで、既存の項目を追加しようとしたときの警告メッセージ。
        /// </summary>
        public string SMessage_AddsRepeated
        {
            set
            {
                sMessage_AddsRepeated = value;
            }
            get
            {
                return sMessage_AddsRepeated;
            }
        }

        //────────────────────────────────────────

        private string sMessage_ReplacesRepeated;

        /// <summary>
        /// 無重複にしたいリストで、既存の項目に置換しようとしたときの警告メッセージ。
        /// </summary>
        public string SMessage_ReplacesRepeated
        {
            set
            {
                sMessage_ReplacesRepeated = value;
            }
            get
            {
                return sMessage_ReplacesRepeated;
            }
        }

        //────────────────────────────────────────

        private string sMessage_ReplacesRepeated2;

        /// <summary>
        /// 無重複にしたいリストで、2個以上の項目を同じ値にしようとしたときの警告メッセージ。
        /// </summary>
        public string SMessage_ReplacesRepeated2
        {
            set
            {
                sMessage_ReplacesRepeated2 = value;
            }
            get
            {
                return sMessage_ReplacesRepeated2;
            }
        }

        //────────────────────────────────────────

        private string sMessage_TextboxEmpty;

        /// <summary>
        /// テキストボックスが空だった場合の警告メッセージ。
        /// </summary>
        public string SMessage_TextboxEmpty
        {
            set
            {
                sMessage_TextboxEmpty = value;
            }
            get
            {
                return sMessage_TextboxEmpty;
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// リストボックス ラッパー
        /// </summary>
        private ListboxWrapperImpl listboxWrapper;

        //────────────────────────────────────────
        #endregion

    }
}
