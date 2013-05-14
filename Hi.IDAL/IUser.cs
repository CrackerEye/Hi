using System;
using System.Data;
using System.Collections.Generic;

using Hi.Model;

namespace Hi.IDAL
{
    public interface IUser
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string strwhere);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Add(BasUser model);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Update(BasUser model);
        bool UpdateLogin(BasUser model);
        bool UpdatePurview(string user_id, string strPurview);
        bool UpdatePurview(string user_id, string module_code, string strPurview);
        bool ResetPassword(string UserID, string newsPassword);

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(string id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        BasUser Detail(string id);

        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet List(Dictionary<string, string> dict, int pageIndex, int pageSize, string sort);
        /// <summary>
        /// ��������ܼ�¼��
        /// </summary>
        int TotalCount(Dictionary<string, string> dict);
        #endregion  ��Ա����
    }
}
