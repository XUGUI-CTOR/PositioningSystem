using Position_BulletinBoard.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Position_BulletinBoard.DBModel
{
    public class CP_CKKWB:ModelBase<CP_CKKWB>
    {
        /// <summary>
        /// 
        /// </summary>
        public CP_CKKWB()
        {
        }

        private System.Int16 _nID;
        /// <summary>
        /// 主键id
        /// </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey = true,IsIdentity = true)]
        public System.Int16 nID { get { return this._nID; } set { this._nID = value; } }

        private System.String _cCKBH;
        /// <summary>
        /// 仓库编号
        /// </summary>
        public System.String cCKBH { get { return this._cCKBH; } set { this._cCKBH = value; } }

        private System.String _cKWM;
        /// <summary>
        /// 库位码 库位码(唯一号,自动生成：cCKBH-cKQBH-cKWBH)，可打印条码
        /// </summary>
        public System.String cKWM { get { return this._cKWM; } set { this._cKWM = value; } }

        private System.String _cKQBH;
        /// <summary>
        /// 库区编号
        /// </summary>
        public System.String cKQBH { get { return this._cKQBH; } set { this._cKQBH = value; } }

        private System.String _cKWBH;
        /// <summary>
        /// 库位编号
        /// </summary>
        public System.String cKWBH { get { return this._cKWBH; } set { this._cKWBH = value; } }

        private System.Byte _nZDDFS;
        /// <summary>
        /// 最大堆放数 该库位最多可堆放的托盘数
        /// </summary>
        public System.Byte nZDDFS { get { return this._nZDDFS; } set { this._nZDDFS = value; } }

        private System.String _cKWMS;
        /// <summary>
        /// 库位描述	用文字描述具体位置
        /// </summary>
        public System.String cKWMS { get { return this._cKWMS; } set { this._cKWMS = value; } }

        public override bool ValidationModel()
        {
            if (string.IsNullOrWhiteSpace(cCKBH))
                throw new Exception("仓库编号不能为空");
            if (string.IsNullOrWhiteSpace(cKQBH))
                throw new Exception("库区编号不能为空");
            if (nZDDFS <= 0)
                throw new Exception("最大堆放数堆叠数必须大于0");
            return true;
        }
    }
}
