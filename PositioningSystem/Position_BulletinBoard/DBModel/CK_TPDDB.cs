using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Position_BulletinBoard.DBModel
{
    public class CK_TPDDB
    {
        /// <summary>
        /// 
        /// </summary>
        public CK_TPDDB()
        {
        }

        private System.Int16 _nID;
        /// <summary>
        /// 主键id
        /// </summary>
        [SqlSugar.SugarColumn(IsIdentity = true,IsPrimaryKey = true)]
        public System.Int16 nID { get { return this._nID; } set { this._nID = value; } }

        private System.String _cTPH;
        /// <summary>
        /// 托盘号 一个托盘一个号，具体由绑定的芯片编号决定，一般为15位
        /// </summary>
        public System.String cTPH { get { return this._cTPH; } set { this._cTPH = value; } }

        private System.String _cTZDH;
        /// <summary>
        /// 通知单号 来自XS_SCTZD.cTZDH
        /// </summary>
        public System.String cTZDH { get { return this._cTZDH; } set { this._cTZDH = value; } }

        private System.DateTime? _tPDSJ;
        /// <summary>
        /// 绑定时间
        /// </summary>
        public System.DateTime? tPDSJ { get { return this._tPDSJ; } set { this._tPDSJ = value; } }

        private System.DateTime? _tZJJCSJ;
        /// <summary>
        /// 最近检测时间 该托盘最近检测到的时间
        /// </summary>
        public System.DateTime? tZJJCSJ { get { return this._tZJJCSJ; } set { this._tZJJCSJ = value; } }

        private System.Boolean? _lTPYXBZ;
        /// <summary>
        /// 托盘有效标志 1：有货，0：空盘
        /// </summary>
        public System.Boolean? lTPYXBZ { get { return this._lTPYXBZ; } set { this._lTPYXBZ = value; } }
    }
}
