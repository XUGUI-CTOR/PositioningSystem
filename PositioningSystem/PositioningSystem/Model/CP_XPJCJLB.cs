using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositioningSystem.Model
{
    public class CP_XPJCJLB
    {
        /// <summary>
        /// 
        /// </summary>
        public CP_XPJCJLB()
        {
        }

        private System.Int16 _nID;
        /// <summary>
        /// 主键id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)] //是主键, 还是标识列
        public System.Int16 nID { get { return this._nID; } set { this._nID = value; } }

        private System.String _CXPH;
        /// <summary>
        /// 芯片号
        /// </summary>
        public System.String CXPH { get { return this._CXPH; } set { this._CXPH = value; } }

        private System.String _CJZH;
        /// <summary>
        /// 基站号
        /// </summary>
        public System.String CJZH { get { return this._CJZH; } set { this._CJZH = value; } }

        private System.DateTime _TJCSJ;
        /// <summary>
        /// 最后检测的时间
        /// </summary>
        public System.DateTime TJCSJ { get { return this._TJCSJ; } set { this._TJCSJ = value; } }
    }
}
