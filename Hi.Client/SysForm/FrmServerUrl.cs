using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;

using Hi.Common;
namespace Hi.Client
{
    public partial class FrmServerUrl : Form
    {
        public FrmServerUrl()
        {
            InitializeComponent();
            this.Icon = HiBLL.GetIcoLogo;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            if(MsgBox.ShowQuestionYesNo("�������÷�������ַ������������ϵͳ����Ч\r\nȷ���ύ��"))
            {
                SetConfigValue();
                Process.Start(Application.ExecutablePath);
                Environment.Exit(0);
            }
        }
        #region ��дApp.config�ļ�
        /// <summary>
        /// д��App.config����
        /// </summary>
        private void SetConfigValue()
        {
            XmlDocument xmlDoc = new XmlDocument();
            //��ȡ��ִ���ļ���·��������
            xmlDoc.Load(Application.ExecutablePath + ".config");

            XmlNode xNode;
            xNode = xmlDoc.SelectSingleNode("//configuration/applicationSettings/Hi.Client.Properties.Settings/setting/value");
            xNode.InnerText = this.txtServicesUrl.Text; 

            xmlDoc.Save(Path.GetFileName(Application.ExecutablePath) + ".config");
        }


        /// <summary>
        /// ��ȡApp.config����
        /// </summary>
        private string GetConfigValue()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(Application.ExecutablePath + ".config");

                XmlNode xNode;
                //XmlElement xElem;
                xNode = xmlDoc.SelectSingleNode("//configuration/applicationSettings/Hi.Client.Properties.Settings/setting/value");
                return xNode.InnerText;
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion

        private void FrmServerUrl_Load(object sender, EventArgs e)
        {
            this.txtServicesUrl.Text = GetConfigValue();
            //this.btnSumbit.Enabled = false;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            #region ���Է�����
            try
            {
                SetConfigValue();
                //if (HiServicesBLL.Test() != "ok")
                //{
                //    MsgBox.ShowError("�������ӷ�����ʧ�ܣ�");
                //    return;
                //}else
                //    this.btnSumbit.Enabled = true;
            }
            catch (Exception ex)
            {
                Error.ErrorMsg(ex.Message);
                MsgBox.ShowError(ex.Message );
            }
            #endregion 
        }
    }
}