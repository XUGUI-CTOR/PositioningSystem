using Position_BulletinBoard.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Position_BulletinBoard.DBModel
{
    public class CK_JZXXB: ModelBase<CK_JZXXB>
    {
        /// <summary>
        /// 
        /// </summary>
        public CK_JZXXB()
        {
        }

        private System.Int16 _nID;
        /// <summary>
        /// 主键id
        /// </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity =true)]
        public System.Int16 nID { get { return this._nID; } set { this._nID = value; } }

        private System.String _cCKBH;
        /// <summary>
        /// 
        /// </summary>
        public System.String cCKBH { get { return this._cCKBH; } set { this._cCKBH = value; } }

        private System.String _cJZBH;
        /// <summary>
        /// 基站编号 唯一号，一般为15位
        /// </summary>
        public System.String cJZBH { get { return this._cJZBH; } set { this._cJZBH = value; } }

        private System.Decimal _nJZZB_X;
        /// <summary>
        /// 基站X坐标 单位：米
        /// </summary>
        public System.Decimal nJZZB_X { get { return this._nJZZB_X; } set { this._nJZZB_X = value; } }

        private System.Decimal _nJZZB_Y;
        /// <summary>
        /// 基站Y坐标 单位：米
        /// </summary>
        public System.Decimal nJZZB_Y { get { return this._nJZZB_Y; } set { this._nJZZB_Y = value; } }

        private System.Decimal _nJZAZGD;
        /// <summary>
        /// 基站安装高度
        /// </summary>
        public System.Decimal nJZAZGD { get { return this._nJZAZGD; } set { this._nJZAZGD = value; } }

        private System.Decimal _nJZJCZDJL;
        /// <summary>
        /// 基站检测最大距离
        /// </summary>
        public System.Decimal nJZJCZDJL { get { return this._nJZJCZDJL; } set { this._nJZJCZDJL = value; } }

        private System.Decimal? _nJZKJCBJ;
        /// <summary>
        /// 基站可检测半径
        /// </summary>
        public System.Decimal? nJZKJCBJ { get { return this._nJZKJCBJ; } set { this._nJZKJCBJ = value; } }

        private System.String _cBeiz;
        /// <summary>
        /// 备注(该基站的一些说明)
        /// </summary>
        public System.String cBeiz { get { return this._cBeiz; } set { this._cBeiz = value; } }

        public override bool ValidationModel()
        {
            if (string.IsNullOrWhiteSpace(cCKBH))
                throw new Exception("仓库编号不能为空");
            if (string.IsNullOrWhiteSpace(cJZBH))
                throw new Exception("基站编号不能为空");
            return true;
        }
    }
}
