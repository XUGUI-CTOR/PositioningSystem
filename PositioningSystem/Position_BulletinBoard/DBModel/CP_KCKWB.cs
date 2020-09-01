using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Position_BulletinBoard.DBModel
{
    public class CP_KCKWB
    {
        /// <summary>
        /// 
        /// </summary>
        public CP_KCKWB()
        {
        }

        private System.Int16 _nID;
        /// <summary>
        /// 主键id
        /// </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey =true,IsIdentity = true)]
        public System.Int16 nID { get { return this._nID; } set { this._nID = value; } }

        private System.String _cTZDH;
        /// <summary>
        /// 通知单号 来自XS_SCTZD.cTZDH
        /// </summary>
        public System.String cTZDH { get { return this._cTZDH; } set { this._cTZDH = value; } }

        private System.String _cTPH;
        /// <summary>
        /// 托盘号 对应绑定的芯片号
        /// </summary>
        public System.String cTPH { get { return this._cTPH; } set { this._cTPH = value; } }

        private System.Byte _nDDH;
        /// <summary>
        /// 堆叠序号	该托盘对应该订单的堆叠序号
        /// </summary>
        public System.Byte nDDH { get { return this._nDDH; } set { this._nDDH = value; } }

        private System.Int32 _nKCSL;
        /// <summary>
        /// 库存数量	该托盘的物品数量
        /// </summary>
        public System.Int32 nKCSL { get { return this._nKCSL; } set { this._nKCSL = value; } }

        private System.String _cSLDW;
        /// <summary>
        /// 数量单位，张/只/付
        /// </summary>
        public System.String cSLDW { get { return this._cSLDW; } set { this._cSLDW = value; } }

        private System.String _cKWM;
        /// <summary>
        /// 库位码 与AGV模式兼容
        /// </summary>
        public System.String cKWM { get { return this._cKWM; } set { this._cKWM = value; } }

        private System.String _cKWMS;
        /// <summary>
        /// 库位描述	用文字描述具体位置
        /// </summary>
        public System.String cKWMS { get { return this._cKWMS; } set { this._cKWMS = value; } }

        private System.DateTime? _dZXGXRQ;
        /// <summary>
        /// 最近更新日期
        /// </summary>
        public System.DateTime? dZXGXRQ { get { return this._dZXGXRQ; } set { this._dZXGXRQ = value; } }
    }
}
