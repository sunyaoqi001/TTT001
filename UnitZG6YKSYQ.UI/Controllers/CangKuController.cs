using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitZG6YKSYQ.BLL;
using UnitZG6YKSYQ.DAL;
using UnitZG6YKSYQ.Model;

namespace UnitZG6YKSYQ.UI.Controllers
{
    public class CangKuController : Controller
    {
        NewBLL _bll;
        NPdao _host;
        public CangKuController(NewBLL bll, NPdao host) 
        {
            _bll = bll;
            _host = host;
        }
        //显示视图
        public IActionResult Index()
        {
            return View();
        }
        //显示查询分页方法
        public IActionResult InData(int page=1,int limit=10,int Yid=-1,string Bian="",string Hname="",string Cai="",string ChuDan="",string ZhiDan="",DateTime? Csj=null,DateTime? Jsj=null,int Kid=-1,int Jid= -1,int Zid=-1)
        {
            var list = _bll.Show();
            //查询业务实体
            if (Yid!=-1)
            {
                list = list.Where(s => s.Yid==Yid).ToList();
            }
            //查询合同编号
            if (!string.IsNullOrEmpty(Bian))
            {
                list = list.Where(s=>s.Bian.Contains(Bian)).ToList();
            }
            //查询合同名称
            if (!string.IsNullOrEmpty(Hname))
            {
                list = list.Where(s => s.Hname.Contains(Hname)).ToList();
            }
            //查询采购单号
            if (!string.IsNullOrEmpty(Cai))
            {
                list = list.Where(s => s.Cai.Contains(Cai)).ToList();
            }
            //查询出库单号
            if (!string.IsNullOrEmpty(ChuDan))
            {
                list = list.Where(s => s.ChuDan.Contains(ChuDan)).ToList();
            }
            //查询制单人
            if (!string.IsNullOrEmpty(ZhiDan))
            {
                list = list.Where(s => s.ZhiDan.Contains(ZhiDan)).ToList();
            }
            //查询出库时间
            if (Csj!=null)
            {
                list = list.Where(s => s.Csj>= Csj).ToList();
            }
            //查询至
            if (Jsj != null)
            {
                list = list.Where(s => s.Jsj <= Jsj).ToList();
            }
            //查询库存名称
            if (Kid != -1)
            {
                list = list.Where(s => s.Kid == Yid).ToList();
            }
            //查询单据类型
            if (Jid != -1)
            {
                list = list.Where(s => s.Jid == Jid).ToList();
            }
            //查询状态
            if (Zid != -1)
            {
                list = list.Where(s => s.Zid == Zid).ToList();
            }


            var _list = list.Skip((page-1)*limit).Take(limit);
            return Ok(new { code = 0, data = _list, msg = "", count = list.Count }) ;
        }
        //业务实体绑定方法
        public IActionResult YBang()
        {
            var list = _bll.YBang();    
            return Ok(new { data=list});
        }
        //库存名称绑定方法
        public IActionResult Kang()
        {
            var list = _bll.KBang();
            return Ok(new { data = list });
        }
        //单据类型绑定方法
        public IActionResult DBang()
        {
            var list = _bll.DBang();
            return Ok(new { data = list });
        }
        //状态绑定方法
        public IActionResult ZBang()
        {
            var list = _bll.ZBang();
            return Ok(new { data = list });
        }
        //导出方法
        public IActionResult Dao()
        {           
            var list = _host.DaoChu(_bll.Chuan());
            var typel = "application/octet-stream";
            var namel = $"{DateTime.Now.ToString("yyyyMMdd")}.xls";
            return File(list.ToArray(),typel,namel);
        }

        //出库视图
        public IActionResult Add()
        {
            return View();
        }

        //反填方法
        public IActionResult Fan(int id)
        {
            var list = _bll.Fan(id);
            return Ok(new { data=list});
        }
        //添加方法
        public IActionResult ADDD(KuCun s)
        {
            var list = _bll.Add(s);
            return Ok(new { data = list>0?"添加成功":"添加失败",msg=list>0?true:false });
        }
        //显示明细方法
        public IActionResult Ming()
        {
            var list = _bll.Ming();
            return Ok(new { code = 0,data = list });
        }
    }
}
