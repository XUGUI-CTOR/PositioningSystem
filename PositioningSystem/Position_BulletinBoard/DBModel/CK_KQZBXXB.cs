using Position_BulletinBoard.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Position_BulletinBoard.DBModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CK_KQZBXXB : ModelBase<CK_KQZBXXB>
    {
        /// <summary>
        /// 
        /// </summary>
        public CK_KQZBXXB()
        {
            nID = -1;
        }

        private System.Int16 _nID;
        /// <summary>
        /// 主键id
        /// </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public System.Int16 nID { get { return this._nID; } set { this._nID = value; } }

        private System.String _cCKBH;
        /// <summary>
        /// 仓库编号
        /// </summary>
        public System.String cCKBH { get { return this._cCKBH; } set { this._cCKBH = value; } }

        private System.String _cKuq;
        /// <summary>
        /// 库区编号 仓库内唯一号
        /// </summary>
        public System.String cKuq { get { return this._cKuq; } set { this._cKuq = value; } }

        private System.Decimal _nKQZB_X1;
        /// <summary>
        /// 库区顶点1坐标X 单位：米
        /// </summary>
        public System.Decimal nKQZB_X1 { get { return this._nKQZB_X1; } set { this._nKQZB_X1 = value; } }

        private System.Decimal _nKQZB_Y1;
        /// <summary>
        /// 库区顶点1坐标Y 单位：米
        /// </summary>
        public System.Decimal nKQZB_Y1 { get { return this._nKQZB_Y1; } set { this._nKQZB_Y1 = value; } }

        private System.Decimal _nKQZB_X2;
        /// <summary>
        /// 库区顶点2坐标X 单位：米
        /// </summary>
        public System.Decimal nKQZB_X2 { get { return this._nKQZB_X2; } set { this._nKQZB_X2 = value; } }

        private System.Decimal _nKQZB_Y2;
        /// <summary>
        /// 库区顶点2坐标Y 单位：米
        /// </summary>
        public System.Decimal nKQZB_Y2 { get { return this._nKQZB_Y2; } set { this._nKQZB_Y2 = value; } }

        private System.Decimal _nKQZB_X3;
        /// <summary>
        /// 库区顶点3坐标X 单位：米
        /// </summary>
        public System.Decimal nKQZB_X3 { get { return this._nKQZB_X3; } set { this._nKQZB_X3 = value; } }

        private System.Decimal _nKQZB_Y3;
        /// <summary>
        /// 库区顶点3坐标Y 单位：米
        /// </summary>
        public System.Decimal nKQZB_Y3 { get { return this._nKQZB_Y3; } set { this._nKQZB_Y3 = value; } }

        private System.Decimal _nKQZB_X4;
        /// <summary>
        /// 库区顶点4坐标X 单位：米
        /// </summary>
        public System.Decimal nKQZB_X4 { get { return this._nKQZB_X4; } set { this._nKQZB_X4 = value; } }

        private System.Decimal _nKQZB_Y4;
        /// <summary>
        /// 库区顶点4坐标Y 单位：米
        /// </summary>
        public System.Decimal nKQZB_Y4 { get { return this._nKQZB_Y4; } set { this._nKQZB_Y4 = value; } }

        public override bool ValidationModel()
        {
            if (string.IsNullOrWhiteSpace(cCKBH) || cCKBH.Length > 1)
                throw new Exception("仓库编号不能为空，且长度不能大于1");
            if (string.IsNullOrWhiteSpace(cKuq))
                throw new Exception("库区编号不能为空");
            return true;
        }
    }
}
