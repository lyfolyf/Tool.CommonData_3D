using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.Tool.XML;

namespace Lead.Tool.CommonData_3D
{
    [Serializable]
    public class FSPoint
    {
        public uint index;
        public int Location;
        public int Intensity;
        public double X;
        public double Y;
        public double Z;
    }
    public class CMM_SegmentInfo_3D
    {
        /// 是否为左，否则为右
        public bool IsLeft { get; set; }

        /// 触发起始位置
        public double StartPos { get; set; }

        /// 触发结束位置
        public double EndPos { get; set; }

        //是否等间距
        public bool IsUsing { get; set; }

        /// 间隔
        public double Pitch { get; set; }

        /// 是否传给算法
        public bool IsSendToTestReal { get; set; }

        //是否热飘逸
        public bool IsHotOffset { get; set; }

        //是否热飘逸
        public bool IsBase { get; set; }

        /// 索引，传给算法的顺序
        public int TestRealIndex { get; set; }

        //触发点位
        public List<double> TrigPosList { get; set; }

        /// 索引，传给算法的顺序
        public int Order { get; set; } = 0;
    }



    public enum SenserType
    { 
        基恩士 =0,
        Focal,
        LMI,
    }

    public class CMM_SenserInfo_3D
    {
        public string Name { get; set; }

        public SenserType Type { get; set; }

        public List<CMM_SegmentInfo_3D> SegmentList { get; set; } = new List<CMM_SegmentInfo_3D>();
    }

    public class CMM_StationInfo_3D
    {
        public string StationName { get; set; }
        public List<CMM_SenserInfo_3D> SenserList { get; set; }
    }


    public class ParseCommonTrigInfo
    {
        public  List<CMM_StationInfo_3D> ReadTrigInfo(string XMLPath)
        {
            List<CMM_StationInfo_3D> Result = new List<CMM_StationInfo_3D>();

            try
            {
                Result = (List<CMM_StationInfo_3D>)XmlSerializerHelper.ReadXML(XMLPath, typeof(List<CMM_StationInfo_3D>));
            }
            catch (Exception ex)
            {
                throw new Exception("读取触发文件(" + XMLPath + ")出错:" + ex.Message);
            }

            return Result;
        }

        public void  WriteTrigInfo(string XMLPath, List<CMM_StationInfo_3D> Param)
        {
            try
            {
                XmlSerializerHelper.WriteXML(Param,XMLPath, typeof(List<CMM_StationInfo_3D>));
            }
            catch (Exception ex)
            {
                throw new Exception("写入触发文件(" + XMLPath + ")出错:" + ex.Message);
            }
        }
    }
}
