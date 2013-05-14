using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Threading;


using Hi.Common;
namespace Hi.Client
{
    /// <summary>
    /// ϵͳ���ò�����
    /// </summary>
    public class SysInfo
    {
      
       
       
        /// <summary>
        /// ������������ݼ�
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="ds"></param>
        /// <param name="parentCode"></param>
        public static void BindComboBox(ComboBox cmb, DataSet ds, string parentCode)
        {
            Ctrls.CbbItem item;
            foreach (DataRow dr in ds.Tables[0].Select(" parent_code='" + parentCode + "'"))
            {
                item = new Ctrls.CbbItem();
                item.Text = dr["title"].ToString();
                item.Value = dr["code"].ToString();
                item.Name = dr["code"].ToString();
                cmb.Items.Add(item);
            }

        }
        
    }
   
}
