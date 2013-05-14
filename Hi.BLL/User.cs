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
 ��Ŀ���� �� Vs2008+Winfrom+����ģʽ�ܹ�
 �������� ��
 ������Ϣ ��[����Ա][�汾][��ע][����]
            [Administrator][V1.0][51���-�������Զ�����][2011-7-11 9:46:25]
 �޸���Ϣ ��(1)[����Ա][V1.1][��ע][����]
            (2)[����Ա][V1.2][��ע][����]
--------------------------------------------------------------------------------------------------

*/
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
    /// ҵ���߼���bas_user ��ժҪ˵����
    /// </summary>
    [Serializable]
    public class User : MarshalByRefObject
    {
        private readonly IUser dal = DataAccess.CreateUser();

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
        public bool Add(BasUser model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(BasUser model)
        {
            return dal.Update(model);
        }
        public bool UpdatePurview(string user_id, string strPurview)
        {
            return dal.UpdatePurview(user_id, strPurview);
        }
        public bool UpdatePurview(string user_id, string module_code, string strPurview)
        {
            return dal.UpdatePurview(user_id, module_code, strPurview);
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="UserID">�û�ID</param>
        /// <param name="newsPassword">������</param>
        /// <returns></returns>
        public bool ResetPassword(string UserID, string newsPassword)
        {
            if (string.IsNullOrEmpty(UserID) || string.IsNullOrEmpty(newsPassword))
                return false;
            return dal.ResetPassword(UserID, MD5.MD5Encrypt(newsPassword.Trim()));
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
        public BasUser Detail(string id)
        {
            return dal.Detail(id);
        }

        public DataSet List(Dictionary<string, string> dict, int pageIndex, int pageSize, string sort)
        {
            return dal.List(dict, pageIndex, pageSize, sort);
        }
        /// <summary>
        /// ��������ܼ�¼��
        /// </summary>
        public int TotalCount(Dictionary<string, string> dict)
        {
            return dal.TotalCount(dict);
        }
        #endregion  ��Ա����
    }
}
