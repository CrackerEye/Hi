using System;
using System.Data;
using System.Collections.Generic;
using Hi.Model;
namespace Hi.IDAL
{
    public  interface ISysAdmin
    {
        #region ϵͳ����
        DataSet ParamList(Dictionary<string, string> dict, int pageindex, int pagesize, string sort);
        int ParamTotalCount(Dictionary<string, string> dict);
        DataSet ParamList(int parent_type);
        DataSet ParamListFromCode(string parent_code);
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool ParamExists(string strwhere);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool ParamAdd(BasParam model);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool ParamUpdate(BasParam model);

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool ParamDelete(string id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        BasParam ParamDetail(string id);
        #endregion 

        #region ϵͳ�˵�ά��
        bool BasModuleExists(string strWhere);
        bool BasModuleDelete(string id);
        bool BasModuleUpdate(BasModule model);
        bool BasModuleAdd(BasModule model);
        BasModule BasModuleDetail(string id);
        DataSet BasModuleList(int pageindex, int pagesize);
        int BasModuleTotalCount();
        bool ExistsChild(string module_father);
        #endregion 

        #region ϵͳ��ɫά��
        DataSet RoleList(int pageindex, int pagesize);
        int RoleTotalCount();

        bool AddRole(BasRole model);
        bool UpdateRole(BasRole model);
        bool DeleteRole(string id);
        bool ExistsRole(string strvalue,int id);
        BasRole DetailRole(string id);
        #endregion


        #region ϵͳ�˵���ɫά��
        DataSet BasModuleRole();
        DataSet ModuleInRole(int roleid);
        bool AddModuleRole(string ids, string roleid);
        #endregion

        #region ϵͳ�û���ɫά��
        #endregion

        
        #region ����ϵͳ�˵�
        DataSet GetSysMenu(string parent_id);
        DataSet GetSysMenu(string parent_id, string role_id);
        #endregion 
    }
}
