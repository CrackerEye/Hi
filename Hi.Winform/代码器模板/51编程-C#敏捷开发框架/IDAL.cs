using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

using Hi.Model;
namespace Hi.IDAL
{
    /// <summary>
    /// �ӿڲ�I$ClassName$ ��ժҪ˵����
    /// </summary>
    public interface I$ClassName$
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string strwhere);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Add($ClassName$ model);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Update($ClassName$ model);

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(string id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        $ClassName$ Detail(string id);
        
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet List(Dictionary<string, string> dict,int pageIndex, int pageSize,string sort);
         /// <summary>
		/// ��������ܼ�¼��
		/// </summary>
		int TotalCount(Dictionary<string, string> dict);
        #endregion  ��Ա����
    }
}











