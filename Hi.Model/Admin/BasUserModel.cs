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
            [Administrator][V1.0][51���-�������Զ�����][2011-4-25 15:36:47]
 �޸���Ϣ ��(1)[����Ա][V1.1][��ע][����]
            (2)[����Ա][V1.2][��ע][����]
--------------------------------------------------------------------------------------------------

*/
using System;

namespace Hi.Model
{
    /// <summary>
    /// bas_user ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class BasUser
    {
        //���캯��
        public BasUser() { }
        /// <summary>
        /// UserID
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// UserCode
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// UserPassword
        /// </summary>
        public string UserPassword { get; set; }
        /// <summary>
        /// Realname
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// roleid
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// sex
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// userTelephone
        /// </summary>
        public string UserTelephone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Qq
        /// </summary>
        public string Qq { get; set; }
        /// <summary>
        /// RegTime
        /// </summary>
        public string Regtime { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Islocked
        /// </summary>
        public string IsLocked { get; set; }
        /// <summary>
        /// LastLoginIP
        /// </summary>
        public string LastLoginIp { get; set; }
        /// <summary>
        /// LoginTimes
        /// </summary>
        public string LoginTimes { get; set; }
        /// <summary>
        /// LastLoginTime
        /// </summary>
        public string LastLoginTime { get; set; }
        /// <summary>
        /// remark
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// ���Ż����ID
        /// </summary>
        public string OrgId { get; set; }
        /// <summary>
        /// ���Ż��������
        /// </summary>
        public string OrgName { get; set; }
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public string Purview { get; set; }
        /// <summary>
        /// ������һģ��������ݣ��������أ�
        /// ��ʽ(�������|С�����$С�����)��P01|1$2$10$11
        /// </summary>
        public string PurviewDetail { get; set; }
    }
}

