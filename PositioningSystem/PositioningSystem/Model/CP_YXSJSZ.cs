using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace PositioningSystem.Model
{
    public class CP_YXSJSZ
    {
        /// <summary>
        /// 
        /// </summary>
        public CP_YXSJSZ()
        {
        }

        private System.Int16 _nID;
        /// <summary>
        /// 主键id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)] //是主键, 还是标识列
        public System.Int16 nID { get { return this._nID; } set { this._nID = value; } }

        private System.String _CKEY;
        /// <summary>
        /// 唯一索引
        /// </summary>
        public System.String CKEY { get { return this._CKEY; } set { this._CKEY = value; } }

        private System.String _CVALUE;
        /// <summary>
        /// 值
        /// </summary>
        public System.String CVALUE { get { return this._CVALUE; } set { this._CVALUE = value; } }

        private System.String _CEXPLAIN;
        /// <summary>
        /// 说明(可为空)
        /// </summary>
        public System.String CEXPLAIN { get { return this._CEXPLAIN; } set { this._CEXPLAIN = value; } }
    }
}
