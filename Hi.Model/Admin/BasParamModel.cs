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
    /// bas_param ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class BasParam
    {
        //���캯��
        public BasParam() { }
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EnableFlag { get; set; }

    }
}

