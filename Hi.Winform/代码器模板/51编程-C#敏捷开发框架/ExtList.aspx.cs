/*
------------------------------------------------------------------------------------------
 �����ṩ �� 51���-������
 ��    �� �� ������
       QQ �� 88130278
   EMail  �� LiangSunXiang@139.com
 �� �� �� �� www.51program.net
 ���˲��� �� blog.csdn.net/liangsx
-------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------
 ��Ŀ���� �� ����ͨ�ÿ͹���ϵͳ
 �������� ��
 ������Ϣ ��[����Ա][�汾][��ע][����]
            [Administrator][V1.0][51���-�������Զ�����][2010-12-14 9:18:10]
 �޸���Ϣ ��(1)[����Ա][V1.1][��ע][����]
            (2)[����Ա][V1.2][��ע][����]
--------------------------------------------------------------------------------------------

*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


using Ext.Net;
using Hi.BLL;
using Hi.Model;
using Hi.Common;
namespace Hi.Web.PageExt
{
    public partial class Modules_$ClassName$ : AdminBasePage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLogin();
            if (!Page.IsPostBack)
            {
                WebUtils.SetPageSizeList(this.PagingToolBar1, this.cmbPageSize);
               
            }
        }

     
      
        //ˢ��GridPanel
        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            DataQuery bll = new DataQuery();
            int pagesize = int.Parse(this.cmbPageSize.SelectedItem.Value);
            int pageindex = e.Start / int.Parse(this.cmbPageSize.SelectedItem.Value) + 1;
            Dictionary<string, string> dict = getDictionary();
            DataSet ds = bll.List(dict, pageindex, pagesize, "");
            int totalcount = bll.TotalCount(dict);
            e.Total = totalcount;
            Store1.DataSource = ds;
            Store1.DataBind();
            WebUtils.SetAfterPageText(this.PagingToolBar1, totalcount, pagesize);

        }

        //��ȡ��ѯ����
        protected Dictionary<string, string> getDictionary()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("table_name","$TableName$");
           
            return dict;
        }
        protected void btnDetail_Click(object sender, DirectEventArgs e)
        {
            string values = e.ExtraParams["Values"];

            Dictionary<string, string>[] griddata = JSON.Deserialize<Dictionary<string, string>[]>(values);
            for (int i = 0; i < griddata.Length; i++)
            {
            }
			this.winDetail.Show();
        }

        //�༭�󱣴�
        protected void btnSave_Click(object sender, DirectEventArgs e)
        {
            Save(true);
        }
        //����������
        protected void btnAddAndSave_Click(object sender, DirectEventArgs e)
        {
            Save(false);

        }
        private void Save(bool isHide)
        {
            User bll = new User();
            BasUser model = new BasUser();
            
            int count = 0;

            string msg = "";

            if (Exists(model))
                return;
           

            if (count > 0)
            {

                ShowNotification("" + msg + "����ɹ���");
                this.GridPanel1.Reload();
                if (isHide)
                    this.winDetail.Hide();
            }
            else
            {
                ShowNotification(msg);
            }
        }
        /// <summary>
        /// Ψһ����֤
        /// </summary>
        /// <returns>true</returns>
        private bool Exists(BasUser model)
        {
            User bll = new User();
            bool blFlag = false;
            string strWhere = "";
            strWhere = " UserCode='" + model.UserCode + "'";
            if (!string.IsNullOrEmpty(model.UserId.ToString()))
                strWhere += " and userid<>" + model.UserId;

            blFlag = bll.Exists(strWhere);
            if (blFlag)
                ShowNotification("����ʧ�ܣ���" + model.UserCode + "���Ѵ���");

            return blFlag;
        }
        //��ѡɾ��
        protected void btnDelete_Click(object sender, DirectEventArgs e)
        {
            User bll = new User();
            string values = e.ExtraParams["Values"].ToString();
            XmlUtils xml = new XmlUtils(values);
            string id = xml.GetXmlNodeValue("$KeyName$");
            if (string.IsNullOrEmpty(id))
                return;
            if (int.Parse(id) < 0)
                this.GridPanel1.DeleteSelected();
            else
            {
                bool blFlag = bll.Delete(id);
                if (blFlag)
                {
                    this.GridPanel1.Reload();
                    ShowNotification("ɾ���ɹ�");
                }
            }

        }

        //��ѯ
        protected void btnQuery_Click(object sender, DirectEventArgs e)
        {
            this.GridPanel1.Reload();
        }

      

    }
}