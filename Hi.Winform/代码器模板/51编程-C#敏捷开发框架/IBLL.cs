using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

using Hi.Common;
using Hi.DALFactory;
using Hi.IDAL;
using Hi.Model;

namespace Hi.IBLL
{
    /// <summary>
    /// ��չҵ���߼���$TableName$ ��ժҪ˵����
    /// </summary>
    public class HiInstanceBLL
    {
       private static string ClientType = ConfigurationManager.AppSettings["ClientType"];
       /// <summary>
       /// ʵ����$TableRemark$
       /// </summary>
       /// <returns></returns>
	   public  static Hi.BLL.$ClassName$ $ClassName$BLL()
       {
            return new Hi.BLL.$ClassName$();
       }
    }
}














