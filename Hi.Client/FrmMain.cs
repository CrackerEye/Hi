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
 ��Ŀ���� �� 51���-���ݿ������-�ͻ��ˣ������棩
 �������� �� 
 ������Ϣ ��[����Ա][�汾][��ע][����]
            [Administrator][V1.0][51���-�������Զ�����][2011-5-5 12:35:28]
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
using System.Reflection;
using System.Threading;
using System.Resources;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using Hi.Common;

namespace Hi.Client
{
    public partial class FrmMain : Hi.UserControlEx.UcMain
    {
        #region ȫ�ֱ���
        public Mutex mutex;
        #endregion 

        public FrmMain()
        {
            AppSetting.MyResourceManager = Properties.Resources.ResourceManager;
            //��������
            this.ThisAssembly = Assembly.GetExecutingAssembly();
            this.ProgramName = this.ThisAssembly.ManifestModule.Name;
            Config.AppPath = Application.StartupPath;
            Icon icoLogo = HiBLL.GetIcoLogo;
            this.Icon = icoLogo;
            ucNotifyIcon.Icon = icoLogo;
            //�����ļ�����
            this.Text = ConfigurationManager.AppSettings["ProjectName"];
            this.NameSpace = ConfigurationManager.AppSettings["ProjectNamespace"];
            AppSetting.UpdateXml = ConfigurationManager.AppSettings["UpdateXml"];
            Hi.Common.AppSetting.IniFileName = ConfigurationManager.AppSettings["SysConfigFile"];
            //gridview���б�ɫ
            Hi.Common.AppSetting.SkinStyle.RowColor = SystemColors.ControlLight;
            Config.IsDebug = false;

            InitializeComponent();   
            CheckForIllegalCrossThreadCalls = false;

            mutex = new Mutex(false, this.NameSpace+"_Single_MUTEX");
            if (!mutex.WaitOne(0, false))
            {
                mutex.Close();
                mutex = null;
            }
        }

        #region ��ʼ�������¼� 
        
        protected override void Init()
        {
            //Hi.UserControlEx.UcSplash.SetStatus("��������ϵͳ�˵�");

            ////ϵͳ�˵�
            //InitMenu();

            //this.uclblUser.Text = "��λ��" + AppSetting.SysOption.OrgName + "  �û���" + AppSetting.SysOption.UserName + "";
            ////this.uclblUserRole.Text = "��ɫ��" + AppSetting.SysOption.;

            //Hi.UserControlEx.UcSplash.SetStatus("�������ӷ�����...");
            ////HiBLL.ConnectedServices();
            ////ϵͳ����

            //Hi.UserControlEx.UcSplash.SetStatus("���ڳ�ʼ��ϵͳ����...");
            ////ModuleData.ParamDataSet();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //�½�������tabPage��ʾ
            this.ParentTabControl = this.ucTabControl1.tabWorkSpace;
            this.tbpnl.Dock = DockStyle.Fill;
            this.ucTabControl1.tabWorkSpace.TabPages[0].Controls.Add(this.tbpnl);

            Thread.Sleep(1500);
            Hi.UserControlEx.UcSplash.CloseForm();
            if (!HiBLL.SetConn())
                ExitApplication();
            Login();
            Init();
        }
 
        #endregion 

        #region ϵͳ�����¼��򷽷�
        /// <summary>
        /// �û���֤
        /// </summary>
        private void Login()
        {
            this.uclblMsg.Text = "�������û����������¼...";
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                ExitApplication();
            }
            else
            {
                this.uclblMsg.Text = "����";
                InitThread(); 
            }
            FrmTrail frmttt = new FrmTrail();
            frmttt.Show();
        }

        /// <summary>
        /// �û���֤
        /// </summary>
        private void ReLogin()
        {
            this.uclblMsg.Text = "�������û����������¼...";
            FrmReLogin frm = new FrmReLogin();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                InitThread();
            }else
                this.uclblMsg.Text = "����";
        }
        /// <summary>
        /// �������ݿ�
        /// </summary>
        private void ConnectedDb()
        {
            this.uclblMsg.Text = "�������û����������¼...";
            Hi.Common.FrmDbRegion frm = new FrmDbRegion();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                InitThread();
            }
            else
                this.uclblMsg.Text = "����";
        }
        #endregion 

        #region �˵��򹤾����¼�
        
        /// <summary>
        /// ��дUcMain�е��鷽��
        /// </summary>
        public override void ShowNewForm()
        {
             if (this.MenuProperty == null)
                return;
            if (this.MenuProperty.ModuleCode.ToLower() == "login")
            {
                Login();
                return;
            }
            if (this.MenuProperty.ModuleCode.ToLower() == "relogin")
            {
                ReLogin();
                return;
            }
            if (this.MenuProperty.ModuleCode.ToLower() == "dbconfig")
            {
                ConnectedDb();
                return;
            }
            NewForm(this.ucTabControl1);
        }
        #endregion 
    }
}

