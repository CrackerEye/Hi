using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

using Hi.Common;
using Hi.DALFactory;
using Hi.IDAL;
using Hi.Model;

namespace Hi.BLL
{
    /// <summary>
    /// ҵ���߼���$TableName$ ��ժҪ˵����
    /// </summary>
    public class $ClassName$BLL
    {
        private readonly I$ClassName$ dal = DataAccess.Create$ClassName$();

        public $ClassName$()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string strwhere)
        {
            return dal.Exists(strwhere);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add($ClassName$ model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update($ClassName$ model)
        {
            return dal.Update(model);
        }

       
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(string id)
        {
           return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public $ClassName$ Detail(string id)
        {
            return dal.Detail(id);
        }

        public DataSet List(Dictionary<string, string> dict,int pageIndex, int pageSize ,string sort)
        {
            return dal.List(dict,pageIndex,  pageSize,sort);
        }
        /// <summary>
		/// ��������ܼ�¼��
		/// </summary>
		public  int TotalCount(Dictionary<string, string> dict)
		{
		     return dal.TotalCount(dict);
		}
        #endregion  ��Ա����
    }
}














