using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;

using Hi.Common;
namespace Hi.Client
{
    public partial class FrmLogin : Hi.UserControlEx.UcOpacityForm
    {
        //private Mutex mutex;
        //5����������˳���¼
        private int _LoginCount = 0;
        public FrmLogin()
        {
            InitializeComponent();
            this.Icon = HiBLL.GetIcoLogo;
            this.txtUserCode.Focus();
            this.txtUserCode.Text = Utils.IniRead("Option", "UserCode", Hi.Common.AppSetting.IniFileName);
           // this.txtPassword.Text = "123456";

           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnSumbit.Enabled = false;
                DoLogion();

            }
            catch (Exception ex)
            {
                Error.ErrorMsg(ex.Message);
                MsgBox.ShowError(ex.Message);
                this.btnSumbit.Enabled = true;
            }
        }
        private void DoLogion()
        {
          
            string strResult = "";
            bool blFlag = false;
            blFlag = HiBLL.DoLogin(this.txtUserCode.Text, this.txtPassword.Text, out strResult);
            if (!blFlag)
            {
                if (_LoginCount < 4)
                    MsgBox.ShowWarning("��ȫ�������[" + strResult + "]\r\n�㻹���Գ���" + Convert.ToString(4 - _LoginCount) + "�Ρ�");
                if (_LoginCount >= 4)
                {
                    MsgBox.ShowWarning("��ε�¼ʧ�ܣ�ϵͳ�Զ��˳�\r\n����ϵϵͳ����Ա������");
                    this.Close();
                }
                _LoginCount++;
            }
            else
            {
                Utils.IniWrite("Option", "UserCode", this.txtUserCode.Text, Hi.Common.AppSetting.IniFileName);
                this.DialogResult = DialogResult.OK;
            }
            this.btnSumbit.Enabled = true;
        }

        private void txtUserCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSumbit_Click(null, null);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSumbit_Click(null, null);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtUserCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}