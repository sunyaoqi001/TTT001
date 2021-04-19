using System;
using System.Collections.Generic;
using System.Text;

namespace UnitZG6YKSYQ.Model
{
    public class ChuMin
    {
        public int id     { get; set; }
        public string Name   { get; set; }
        public string Pian   { get; set; }
        public string Hao    { get; set; }
        public string Ming   { get; set; }
        public string Bao    { get; set; }
        public string WuName { get; set; }
        public string Shuo   { get; set; }
        public string Xing   { get; set; }
        public int Num    { get; set; }
        public int Dan    { get; set; }
        public int BDan   { get; set; }
        public int Zong   { get; set; }
        public int BHzong { get; set; }
        public string Jia    { get; set; }
        public string HSjia  { get; set; }
        public string BHSjia { get; set; }
        public string Cheng { get; set; }
        /// <summary>
        /// 计算含税总价
        /// </summary>
        public int HanZong { get { return this.Num * this.Dan; } set { } }
        /// <summary>
        /// 计算不含税总价
        /// </summary>
        public int BuHanZong { get { return this.Num * this.BDan; } set { } }
    }
}
