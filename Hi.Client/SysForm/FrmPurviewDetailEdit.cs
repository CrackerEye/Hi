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
            [Administrator][V1.0][51���-�������Զ�����][2011-5-3 9:16:45]
 �޸���Ϣ ��(1)[����Ա][V1.1][��ע][����]
            (2)[����Ա][V1.2][��ע][����]
--------------------------------------------------------------------------------------------------

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using Hi.Common;

namespace Hi.Client
{
    public partial class FrmPurviewDetailEdit : Hi.Client.BaseForm.BaseFormEdit
    {
        private Hi.BLL.User userBll = new Hi.BLL.User();//HiBLL.HiInstanceBLL().UserBLL();
        private Hi.Model.BasUser _UserModel=null;
        private string _ModuleCode;
        private string _UserId;
        private string _ParentCode;
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="doRefresh"></param>
        public FrmPurviewDetailEdit(string user_id,string module_code,string module_name)
        {
            InitializeComponent();
            this.listView1.Dock = DockStyle.Fill;
            this.pnlWorkSpace.Controls.Add(this.listView1);
            this._ModuleCode = module_code;
            this._UserId = user_id;
            this.Text = "���á�"+module_name+"������Ȩ��";
        }
        private void FrmPurviewDetailEdit_Load(object sender, EventArgs e)
        {
            GetUserInfo();
            SetModulePurview(this.Name);

            DetailInfo();
            this.btnAddAndSave.Enabled = true;
        }

        private void GetUserInfo()
        {
           _UserModel  = new Model.BasUser();
           int tmpId = 0;
           int.TryParse(this._UserId, out tmpId);
           _UserModel = userBll.Detail(tmpId.ToString());
           if (_ModuleCode != null)
               this.lblUserInfo.Text = "���á�" + _UserModel.RealName + "��Ȩ��";
        }
       
        /// <summary>
        /// ��д��ȡ��ϸ�¼�
        /// </summary>
        private  void DetailInfo()
        {
            if (this._ModuleCode.ToLower() == "hiorderprophase")
            {
                _ParentCode = ModuleData.ParamParentCode.P06.ToString(); 
            }else
                _ParentCode = ModuleData.ParamParentCode.P07.ToString();
            if (_UserModel == null)
            {
                this.btnAddAndSave.Enabled = false;
                return ;
            }
           
             ListViewData();

        }
        private void ListViewData( )
        {
            if (ModuleData.ParamDataSet == null || ModuleData.ParamDataSet.Tables.Count == 0)
                return;
            this.listView1.BeginUpdate();

            this.listView1.Items.Clear();

            ListViewItem item = null;
            string child_code;
            foreach (DataRow dr in ModuleData.ParamDataSet.Tables[0].Select(" pcode='" + _ParentCode + "'", "sort"))
            {
                item = new ListViewItem();
                child_code = dr["code"].ToString().Trim();
                item.SubItems.Add(child_code);
                item.SubItems.Add(dr["title"].ToString().Trim());
                //if (ModuleData.IsExstsPurview(_UserModel.PurviewDetail,_ParentCode, child_code))
                //    item.Checked = true;
                
                listView1.Items.Add(item);
            }

            listView1.EndUpdate();

        }
        /// <summary>
        /// ��д�����¼�
        /// </summary>
        /// <returns></returns>
        protected override bool Save()
        {
           
            return this.SavePurview(_UserId,"purview_detail");
           
        }
        private  bool SavePurview(string user_id, string module_code)
        {
            bool blFlag = false;
            try
            {
                ListViewItem item = null;
                string strPurview = "";
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    item = this.listView1.Items[i];
                    if (item.Checked)
                        strPurview += item.SubItems[1].Text + "$";
                }
                if (string.IsNullOrEmpty(strPurview))
                    return false;
                strPurview = strPurview.Remove(strPurview.Length - 1);
                strPurview =_ParentCode+"|"+strPurview;

                string tmpPurview = IsExitsParentCode();
                if (!string.IsNullOrEmpty(tmpPurview))
                    strPurview = strPurview + "," + tmpPurview;

                blFlag = userBll.UpdatePurview(user_id, module_code, strPurview);
                if (blFlag)
                {
                    if (AppSetting.SysOption.UserId == user_id)
                        AppSetting.SysOption.PurviewDetail = strPurview;
                    MsgBox.ShowInformation("����ɹ���");
                }
                else
                    MsgBox.ShowInformation("����ʧ��!");
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message);
                Error.ErrorMsg(ex);

            }
            return blFlag;
        }
        private string IsExitsParentCode()
        {
            if (this._UserModel == null)
                return "";
            if (string.IsNullOrEmpty(this._UserModel.PurviewDetail))
                return "";
            string tmpPurviewDetail="" ;
            if (_UserModel.PurviewDetail.IndexOf(this._ParentCode) > -1)
            {
                string[] myarry = _UserModel.PurviewDetail.Split(',');
                for (int i = 0; i < myarry.Length; i++)
                {
                    if (myarry[i].IndexOf(this._ParentCode) == -1)
                    {
                        tmpPurviewDetail += myarry[i] + ",";
                    }
                }
                if (string.IsNullOrEmpty(tmpPurviewDetail))
                    return "";
                tmpPurviewDetail = tmpPurviewDetail.Remove(tmpPurviewDetail.Length - 1);

            }
            else
                tmpPurviewDetail = this._UserModel.PurviewDetail;
            return tmpPurviewDetail;
        }
       
    }
}