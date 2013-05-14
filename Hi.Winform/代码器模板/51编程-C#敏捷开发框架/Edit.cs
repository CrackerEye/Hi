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
	public partial class Frm$ClassName$Edit : Hi.Client.BaseForm.BaseFormEdit
    {
    	
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="doRefresh"></param>
    	public Frm$ClassName$Edit(Hi.Client.BaseForm.BaseFormList.DoRefreshHandler doRefresh)
        {
            InitializeComponent();
            this._DoRefresh = doRefresh;
        }
        
        /// <summary>
        /// ��д��ȡ��ϸ�¼�
        /// </summary>
        protected override void Detail()
        {
            if (string.IsNullOrEmpty(IdValue))
                return;
            Hi.Model.$ClassName$ model = new Hi.Model.$ClassName$();
            model = Hi.IBLL.HiInstanceBLL.$ClassName$BLL().Detail(IdValue);
            $GetDetail$
        }
        private Hi.Model.$ClassName$ SetDetail()
        {
        	Hi.Model.$ClassName$ model = new Hi.Model.$ClassName$();
            model.$KeyName$ = this.IdValue;
            $SetDetail$

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

            if (string.IsNullOrEmpty(this.IdValue))
            {
                blResult = Hi.IBLL.HiInstanceBLL.$ClassName$BLL().Add(SetDetail());
                this.MsgStr = "����";
            }
            else
            {
                blResult = Hi.IBLL.HiInstanceBLL.$ClassName$BLL().Update(SetDetail());
                this.MsgStr = "�޸�";
            }
            if (blResult)
            {
                MsgBox.ShowInformation(this.MsgStr+"�ɹ�!");
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
            /*if (string.IsNullOrEmpty(this.txtName.Text))
            {
                
                MsgBox.ShowInformation("��������Ʒ�������");
                this.txtName.Focus();
                return false;
            }*/
            return true;
        }
    }
}

