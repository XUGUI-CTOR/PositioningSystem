using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Position_BulletinBoard.DBModel
{
    public class CK_JZXGXXB
    {
        /// <summary>
        /// 
        /// </summary>
        public CK_JZXGXXB()
        {
        }

        private System.Int16 _nID;
        /// <summary>
        /// 主键id
        /// </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey = true,IsIdentity = true)]
        public System.Int16 nID { get { return this._nID; } set { this._nID = value; } }

        private System.String _cZJZH;
        /// <summary>
        /// 主基站号 来自CK_JZXXB.cJZBH
        /// </summary>
        public System.String cZJZH { get { return this._cZJZH; } set { this._cZJZH = value; } }

        private System.String _cXGJZH;
        /// <summary>
        /// 相关基站号 来自CK_JZXXB.cJZBH
        /// </summary>
        public System.String cXGJZH { get { return this._cXGJZH; } set { this._cXGJZH = value; } }

        private System.Decimal? _nJZCDQJ1;
        /// <summary>
        /// 基站X轴重叠区间1 X坐标起点：x1
        /// </summary>
        public System.Decimal? nJZCDQJ1 { get { return this._nJZCDQJ1; } set { this._nJZCDQJ1 = value; } }

        private System.Decimal? _nJZCDQJ2;
        /// <summary>
        /// 基站X轴重叠区间2 X坐标终点：x2
        /// </summary>
        public System.Decimal? nJZCDQJ2 { get { return this._nJZCDQJ2; } set { this._nJZCDQJ2 = value; } }
    }
}
