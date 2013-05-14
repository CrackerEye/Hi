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
            [Administrator][V1.0][51���-�������Զ�����][2011-5-5 12:35:29]
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
    public partial class FrmUserEdit : Hi.Client.BaseForm.BaseFormEdit
    {
       
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="doRefresh"></param>
        public FrmUserEdit(Hi.Client.BaseForm.BaseFormList.DoRefreshHandler doRefresh)
        {
            InitializeComponent();
            this._DoRefresh = doRefresh;
            bas_org();
            SetModulePurview(this.Name);
        }
        private void bas_org()
        {
           
            Dictionary<string, string> dict = new Dictionary<string, string>();
            DataSet ds = Hi.IBLL.HiInstanceBLL.BasOrgBLL().List(dict, 1, 100);
            if (ds == null || ds.Tables.Count == 0)
                return;
            this.cmbDepartment.DataSource = ds.Tables[0];
            this.cmbDepartment.DisplayMember = "org_name";
            this.cmbDepartment.ValueMember = "id";
            if(this.cmbDepartment.Items.Count>0)
                this.cmbDepartment.SelectedIndex = 0;
        }
        /// <summary>
        /// ��д��ȡ��ϸ�¼�
        /// </summary>
        protected override void Detail()
        {
            if (string.IsNullOrEmpty(IdValue))
            {
                this.txtUserpassword.Text = Utils.GetRandomString(6);
                return;
            }
            else
            {
                this.txtUserpassword.Enabled = false;
                this.txtUserpassword.Text = "******";
                this.txtUsercode.Enabled = false;
            }
            Hi.Model.BasUser model = new Hi.Model.BasUser();
            model = Hi.IBLL.HiInstanceBLL.UserBLL().Detail(this.IdValue);
            if (model == null)
                return;
            this.txtUsercode.Text = model.UserCode;
           
            this.txtRealname.Text = model.RealName;
            if (model.Sex.Trim() == "1")
            {
                this.rdoBoy.Checked = true;
                this.rdoBirl.Checked = false;
            }
            else
            {
                this.rdoBoy.Checked = false;
                this.rdoBirl.Checked = true;
            }
            this.txtUsertelephone.Text = model.UserTelephone;
            this.txtEmail.Text = model.Email;
            this.txtQq.Text = model.Qq;

            this.txtAddress.Text = model.Address;

            this.txtRemark.Text = model.Remark;
            //this.cmbDepartment.SelectedIndex = this.cmbDepartment.FindString(model.OrgId.ToString());
            //ModuleData.SetComboBoxSelectedIndex(this.cmbDepartment,1,model.OrgId);
            this.cmbDepartment.Text = model.OrgName;
            if (model.IsLocked == "2")
            {
                this.rdo2.Checked = true;
                //this.rdo1.Checked = false;
                //this.rdo0.Checked = false;
                this.groupBox1.Enabled = false;
                
            }
            else if (model.IsLocked == "1")
            {
                this.rdo2.Checked = false;
                this.rdo1.Checked = true;
                this.rdo0.Checked = false;
                this.groupBox1.Enabled = true;
               
            }
            else
            {
                this.rdo2.Checked = false;
                this.rdo1.Checked = false;
                this.rdo0.Checked = true;
                this.groupBox1.Enabled = true;
                
            }
        }
        private Hi.Model.BasUser SetDetail()
        {
            Hi.Model.BasUser model = new Hi.Model.BasUser();
            model.UserId =  this.IdValue;

            model.UserCode = this.txtUsercode.Text;
            model.UserPassword = MD5.MD5Encrypt(this.txtUserpassword.Text);
            model.RealName = this.txtRealname.Text;

            model.Sex = this.rdoBoy.Checked?"1":"0";
            model.UserTelephone = this.txtUsertelephone.Text;
            model.Email = this.txtEmail.Text;
            model.Qq = this.txtQq.Text;

            model.Address = this.txtAddress.Text;
            model.IsLocked = this.rdo2.Checked ? "2" : (this.rdo1.Checked ? "1" : "0");

            model.Remark = this.txtRemark.Text;
            model.OrgId = this.cmbDepartment.SelectedValue.ToString();
            model.OrgName = this.cmbDepartment.Text;
            return model;
        }
        /// <summary>
        /// ��д�����¼�
        /// </summary>
        /// <returns></returns>
        protected override bool Save()
        {
            bool blResult = false;
            if (!CheckedInput())
                return blResult;

            if (IsExists("usercode", this.txtUsercode.Text.Trim(), "�û��ʺ��ظ�"))
            {
                this.txtUsercode.Focus();
                return blResult;
            }
            
            if (string.IsNullOrEmpty(this.IdValue))
            {
                blResult = Hi.IBLL.HiInstanceBLL.UserBLL().Add(SetDetail()) ;
                this.MsgStr = "����";
            }
            else
            {
                blResult = Hi.IBLL.HiInstanceBLL.UserBLL().Update(SetDetail() );
                this.MsgStr = "�޸�";
            }
            if (blResult)
            {
                MsgBox.ShowInformation(this.MsgStr + "�ɹ�!");
                _DoRefresh();
            }
            else
            {
                MsgBox.ShowInformation(this.MsgStr + "ʧ��!");
            }
            return blResult;
        }
        /// <summary>
        /// ��֤����
        /// </summary>
        /// <returns></returns>
        private bool CheckedInput()
        {
            if (string.IsNullOrEmpty(this.txtUsercode.Text))
            {
                MsgBox.ShowInformation("�������¼�˺�");
                this.txtUsercode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtRealname.Text))
            {
                MsgBox.ShowInformation("��������ʵ����");
                this.txtRealname.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtUserpassword.Text))
            {
                MsgBox.ShowInformation("�������û�����");
                this.txtUserpassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.cmbDepartment.Text))
            {
                MsgBox.ShowInformation("������ѡ��������");
                this.cmbDepartment.Focus();
                return false;
            }
            return true;
        }
        /// ����ظ�
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        private bool IsExists(string fieldName,string strValue, string strMsg)
        {
            bool blResult = false;
            string strWhere = " and " + fieldName + "='" + strValue + "' ";
            if (!string.IsNullOrEmpty(this.IdValue))
            {
                strWhere += " and userid<>" + this.IdValue;
            }
            blResult = Hi.IBLL.HiInstanceBLL.UserBLL().Exists(strWhere);
            if (blResult)
                MsgBox.ShowInformation(strMsg);
            return blResult;
        }
    }
}


