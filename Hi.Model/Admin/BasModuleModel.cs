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
    /// bas_module ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class BasModule
    {
        //���캯��
        public BasModule() { }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleFather { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleIcon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleWidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleHeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleSort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EnableFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ToolbarFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModulePurview { get; set; }

    }
}

