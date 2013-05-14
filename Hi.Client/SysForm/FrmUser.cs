/*
------------------------------------------------------------------------------------------
 �����ṩ �� 51���-������
 ��    �� �� ������
       QQ �� 88130278
   EMail  �� LiangSunXiang@139.com
 �� �� �� �� www.51program.net
 ���˲��� �� blog.csdn.net/liangsx
 ��ܰ��ʾ �� ���ð汾�����Ӱ�Ȩ���ݡ�����Ӱ������ʹ��,��ͨ������ע�����δ���Ϣ��лл��
 ע�᷽�� �� ��������ʹٷ�����������ѯ
-------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------
 ��Ŀ���� �� Vs2008+Winfrom+����ģʽ�ܹ�
 �������� ��
 ������Ϣ ��[����Ա][�汾][��ע][����]
            [Administrator][V1.0][51���-�������Զ�����][2011-5-5 12:35:28]
 �޸���Ϣ ��(1)[����Ա][V1.1][��ע][����]
            (2)[����Ա][V1.2][��ע][����]
--------------------------------------------------------------------------------------------------

*/

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Hi.Common;

namespace Hi.Client
{
    public partial class FrmUser : Hi.Client.BaseForm.BaseFormList
    {
        
        public FrmUser()
        {
           
            this.pageDataGridViewEx1.ClearDataGridView();
            //DataGridViw����
            this.pageDataGridViewEx1.IsShowCheckBox = -1;
            this.pageDataGridViewEx1.MyColumnName = "UserID,UserCode,Realname,orgname,sex_title,userTelephone,Email,Qq,Address,LoginTimes,LastLoginTime,remark";
            this.pageDataGridViewEx1.MyColumnTitle = "����,�û���,��ʵ����,��������,�Ա�,��ϵ�绰,Email,Qq,��ַ,��¼����,����¼ʱ��,��ע";
            this.pageDataGridViewEx1.SetDgvHeader();
            
            this.KeyName = "userid";
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
          
            this.pageDataGridViewEx1.SetNavButtonVisible(true, true, true, false, false);
            SetModulePurview(this.Name);
        }
       
       
        //������Դ
        protected override void  ListData()
        {
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                //Hashtable dict = new Hashtable();
                int totalcount = Hi.IBLL.HiInstanceBLL.UserBLL().TotalCount(dict);
                this.pageDataGridViewEx1.TotalCount = totalcount;
                if (totalcount > 0)
                {
                    this.pageDataGridViewEx1.SetPageButton(true);

                    DataSet ds = Hi.IBLL.HiInstanceBLL.UserBLL().List(dict, this.pageDataGridViewEx1.CurrentPage, this.pageDataGridViewEx1.PageSize, "");

                    if (ds != null)
                    {
                        this.pageDataGridViewEx1.MyDataTable = ds.Tables[0];
                        this.pageDataGridViewEx1.BindingData(true);  
                    }
                    //�������費�ɼ�
                    this.pageDataGridViewEx1.ucdgv.Columns[this.KeyName].Visible = false;
                }
                else
                {
                    this.pageDataGridViewEx1.SetPageButton(false);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message);
                
                Error.ErrorMsg(ex);
            }
            
        }
       
        //˫����ͷ�򿪱༭����
        protected override void DoDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DoEdit(null, null);
        }
        protected override void DoEdit(object sender, EventArgs e)
        {
            int rowIndex= this.pageDataGridViewEx1.ucdgv.CurrentRow.Index;
            string id = this.pageDataGridViewEx1.ucdgv.Rows[rowIndex].Cells[this.KeyName].EditedFormattedValue.ToString();//�����ڵ�һ��
            if (string.IsNullOrEmpty(id))
                return;
            ShowEditForm(id, "�༭");
            
        }
        protected override void DoAdd(object sender, EventArgs e)
        {
            ShowEditForm("", "����");
        }
        private void ShowEditForm(string id,string action)
        {
            FrmUserEdit f = new FrmUserEdit(new DoRefreshHandler(this.DoQuery));
            f.IdValue = id;
	        f.ShowDialog();
	       
        }
       
        #region ��ѡɾ��
        protected override void DoDelete(object sender, EventArgs e)
        {
            
            string id=string.Empty;
            int selectCount = 0;
            DataGridView dgv = this.pageDataGridViewEx1.ucdgv;

            if (this.SelectCount() == 0)
                return;

            if (this.pageDataGridViewEx1.IsShowCheckBox > -1)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    //�ֶβ�Ϊ���ұ�ѡ��
                    if (row.Cells["chkSelect"].EditedFormattedValue.ToString().Equals("True"))
                    {
                        selectCount++;
                        id += Convert.ToString(row.Cells[this.KeyName].Value) + ",";

                    }
                }
                id = id.Remove(id.Length - 1, 1);
            }
            else
            {
                int rowIndex = this.pageDataGridViewEx1.ucdgv.CurrentRow.Index;
                id = this.pageDataGridViewEx1.ucdgv.Rows[rowIndex].Cells[this.KeyName].EditedFormattedValue.ToString();//�����ڵ�һ��
                string usercode=this.pageDataGridViewEx1.ucdgv.Rows[rowIndex].Cells["UserCode"].EditedFormattedValue.ToString();//�����ڵ�һ��
                if (usercode.ToLower() == "admin")
                {
                    MsgBox.ShowInformation("ϵͳ�û�����ɾ��!");
                    return;
                }
            }

            bool blFlag = Hi.IBLL.HiInstanceBLL.UserBLL().Delete(id);
            
            if (blFlag)
            {
                this.DoQuery();
            }
        }
        #endregion

        private void FrmUser_Load(object sender, EventArgs e)
        {

        }
    }
}




