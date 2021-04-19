using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UnitZG6YKSYQ.DAL;
using UnitZG6YKSYQ.Model;

namespace UnitZG6YKSYQ.BLL
{
   public class NewBLL
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<KuCun> Show()
        {
            string sql = $"select * from KuCun join YBang on KuCun.Yid=YBang.YId join KBang on KuCun.Kid=KBang.KId join DBang on KuCun.Jid = DBang.DId join ZBang on KuCun.Zid = ZBang.ZId";

            return DBHelper.GetList<KuCun>(sql);
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        public DataTable Chuan()
        {
            string sql = $"select * from KuCun join YBang on KuCun.Yid=YBang.YId join KBang on KuCun.Kid=KBang.KId join DBang on KuCun.Jid = DBang.DId join ZBang on KuCun.Zid = ZBang.ZId";
            return DBHelper.Dao(sql);
        }
        /// <summary>
        /// 业务实体绑定
        /// </summary>
        /// <returns></returns>
        public List<YBang> YBang()
        {
            string sql = $"select * from YBang";
            return DBHelper.GetList<YBang>(sql);
        }
        /// <summary>
        /// 库存名称绑定方法
        /// </summary>
        /// <returns></returns>
        public List<KBang> KBang()
        {
            string sql = $"select * from KBang";
            return DBHelper.GetList<KBang>(sql);
        }
        /// <summary>
        /// 单据类型绑定方法
        /// </summary>
        /// <returns></returns>
        public List<DBang> DBang()
        {
            string sql = $"select * from DBang";
            return DBHelper.GetList<DBang>(sql);
        }
        /// <summary>
        /// 状态绑定方法
        /// </summary>
        /// <returns></returns>
        public List<ZBang> ZBang()
        {
            string sql = $"select * from ZBang";
            return DBHelper.GetList<ZBang>(sql);
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <returns></returns>
        public int Add(KuCun s)
        {
            string sql = $"insert into KuCun(Bian,Hname,Cai,ChuDan,Jid,Bu,ZhiDan,Zong,Cjin) values('{s.Bian}', '{s.Hname}', '{s.Cai}', '{s.ChuDan}', {s.Jid}, '{s.Bu}', '{s.ZhiDan}', '{s.Zong}', '{s.Cjin}')";
            return DBHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <returns></returns>
        public KuCun Fan(int id)
        {
            string sql = $"select* from KuCun where id = {id}";
            return DBHelper.Get<KuCun>(sql);
        }
        /// <summary>
        /// 显示明细方法
        /// </summary>
        /// <returns></returns>
        public List<ChuMin> Ming()
        {
            string sql = $"select * from ChuMin";
            return DBHelper.GetList<ChuMin>(sql);
        }
    }
}
