using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Hi.Common;
namespace Hi.Client.BaseForm
{
    public partial class BaseFormList : Form
    {
        /// <summary>
        /// ί���¼�ˢ��������
        /// </summary>
        public delegate void DoRefreshHandler();

        #region ����
        /// <summary>
        /// �����ֶ���������
        /// </summary>
        public string KeyName { get; set; }

        public string Sort { get; set; }


        #endregion

        public BaseFormList()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.pageDataGridViewEx1.onPageClick += new Hi.UserControlEx.OnPageClickEventHander(PageClick);
            this.pageDataGridViewEx1.onPageToKeyPress += new Hi.UserControlEx.OnPageToKeyPressEventHander(PageToKeyPress);
            this.pageDataGridViewEx1.onPageSizeChanged += new Hi.UserControlEx.OnPageSizeChangedEventHander(PageSizeChanged);

            this.pageDataGridViewEx1.onAddClick += new Hi.UserControlEx.OnAddClickEventHander(DoAdd);
            this.pageDataGridViewEx1.onEditClick += new Hi.UserControlEx.OnEditClickEventHander(DoEdit);
            this.pageDataGridViewEx1.onDeleteClick += new Hi.UserControlEx.OnDeleteClickEventHander(DoDelete);
            this.pageDataGridViewEx1.onRowHeaderDoubleClick += new Hi.UserControlEx.OnRowHeaderDoubleClickEventHandler(DoDoubleClick);
            this.pageDataGridViewEx1.onPrintClick += new Hi.UserControlEx.OnPrintClickEventHander(DoPrint);


        }
        /// <summary>
        /// �����û�Ȩ�����ø���ťEnabled
        /// </summary>
        /// <param name="form_name"></param>
        protected void SetModulePurview(string form_name)
        {
            try
            {
                string module_code = form_name.Substring(3, form_name.Length - 3);
                char[] mychar = MenuClass.GetPurviewCharArray(AppSetting.SysOption.Purview, module_code);
                if (mychar.Length == 0)
                {
                    this.pageDataGridViewEx1.SetNavButtonEnabled(false, false, false, false, false);
                    return;
                }
                this.pageDataGridViewEx1.ucAdd.Enabled = (mychar[0] == 'Y' ? true : false);
                this.pageDataGridViewEx1.ucEdit.Enabled = (mychar[1] == 'Y' ? true : false);
                this.pageDataGridViewEx1.ucDelete.Enabled = (mychar[2] == 'Y' ? true : false);
                this.pageDataGridViewEx1.ucPrint.Enabled = (mychar[3] == 'Y' ? true : false);
                this.pageDataGridViewEx1.ucExport.Enabled = (mychar[4] == 'Y' ? true : false);
            }
            catch (Exception ex)
            {
                Error.ErrorMsg(ex);
            }
        }

        private void BaseFormList_Load(object sender, EventArgs e)
        {
            this.pageDataGridViewEx1.CurrentPage = 1;
            DoQuery();
        }
        private void PageClick(object sender, EventArgs e)
        {
            DoQuery();
        }
        private void PageToKeyPress(object sender, KeyPressEventArgs e)
        {
            DoQuery();
        }
        private void PageSizeChanged(object sender, EventArgs e)
        {
            DoQuery();
        }
        /// <summary>
        /// ��ʾ�б����ݼ��¼�
        /// </summary>
        protected void DoQuery()
        {
            try
            {
                this.pageDataGridViewEx1.ucdgv.Rows.Clear();
                ThreadData();

            }
            catch (Exception ex)
            {

                MsgBox.ShowError(ex.Message);
                Error.ErrorMsg(ex.Message);
            }
        }
        /// <summary>
        /// ���̵߳������ݲ��¼�
        /// </summary>
        protected void ThreadData()
        {
            Thread myThread = null;
            //if (myThread != null && myThread.IsAlive)
            //    myThread.Abort();

            myThread = new Thread(new ThreadStart(BindingData)); //�����߳�

            myThread.Start();
        }
        /// <summary>
        /// ���ݲ��¼�
        /// </summary>
        protected void BindingData()
        {
            try
            {
                ListData();
                this.pageDataGridViewEx1.ucdgv.ReadOnly = true;
                Thread.Sleep(3);
               
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message);
                this.pageDataGridViewEx1.SetPageButton(false);
                Error.ErrorMsg(ex);
            }

        }
        /// <summary>
        /// �������ݲ㣬��ȡ���ݼ�,���󶨵�DataGridView
        /// ��������鷽����������д
        /// </summary>
        protected virtual void ListData()
        {

        }
        /// <summary>
        /// �����鷽��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DoAdd(object sender, EventArgs e)
        { }
        /// <summary>
        /// �༭�鷽��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DoEdit(object sender, EventArgs e)
        { }
        /// <summary>
        /// ɾ���鷽��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DoDelete(object sender, EventArgs e)
        { }
        /// <summary>
        /// ��ӡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DoPrint(object sender, EventArgs e)
        { }
        /// <summary>
        /// ˫��RowHeader�༭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DoDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        /// <summary>
        /// ��ȡDataGridView����ֵ
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected string GetKeyValue(int index)
        {
            if (index == -1)
                return "";
            return this.pageDataGridViewEx1.ucdgv.Rows[index].Cells[KeyName].EditedFormattedValue.ToString();
        }
        /// <summary>
        /// �ж�ѡ����
        /// �з���true��֮
        /// </summary>
        /// <returns></returns>
        protected int SelectCount()
        {

            int selectCount = 0;
            if (this.pageDataGridViewEx1.ucdgv == null || this.pageDataGridViewEx1.ucdgv.CurrentRow == null)
                return 0;
            //û�и�ѡ��
            if (this.pageDataGridViewEx1.IsShowCheckBox < 0)
            {

                int index = this.pageDataGridViewEx1.ucdgv.CurrentRow.Index;
                if (index == -1)
                    selectCount = -1;

                selectCount = 1;
            }
            else//�и�ѡ��
            {
                for (int i = 0; i < this.pageDataGridViewEx1.ucdgv.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)this.pageDataGridViewEx1.ucdgv.Rows[i].Cells["chkSelect"];
                    string id = Convert.ToString(this.pageDataGridViewEx1.ucdgv.Rows[i].Cells[KeyName].EditedFormattedValue.ToString());
                    if ((bool)chk.FormattedValue)
                    {
                        selectCount++;
                    }
                }//end for
            }//if
            if (selectCount < 1)
                MsgBox.ShowInformation("����ѡ����!");
            return selectCount;
        }
        protected void SetCheckBoxTrue()
        {
            if (this.pageDataGridViewEx1.IsShowCheckBox > -1)
            {
                this.pageDataGridViewEx1.ucdgv.Rows[this.pageDataGridViewEx1.ucdgv.CurrentRow.Index].Selected = true;
            }
        }
        protected void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(((e.KeyChar >= (char)48) && (e.KeyChar <= (char)57)) || (e.KeyChar == (char)13) || (e.KeyChar == (char)8) || (e.KeyChar == (char)110) || (e.KeyChar == (char)190)))
            {
                e.Handled = true;
            }
        }
    }
}