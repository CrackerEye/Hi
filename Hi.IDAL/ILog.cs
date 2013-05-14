using System;
using System.Data;
using System.Collections;

using Hi.Model;
namespace Hi.IDAL
{
    public interface ILog
    {
        int Add(BasLog model);
        int DeleteLogBeforeTwoDays();
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet List(Hashtable hash, int pageIndex, int pageSize);
        /// <summary>
        /// ��������ܼ�¼��
        /// </summary>
        int TotalCount(Hashtable hash);

        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet BasLogSqlList(Hashtable hash, int pageIndex, int pageSize);
        /// <summary>
        /// ��������ܼ�¼��
        /// </summary>
        int BasLogSqlTotalCount(Hashtable hash);
        int DeleteBasLogSql(string id);
    }
}
