using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyModel.Model
{
    [Serializable]
    public class Ward
    {
        //病区ID
        [DisplayName("病区ID")]
        public string WardId { get; set; }
        //病区名称
        [DisplayName("病区名称")]
        public string WardName { get; set; }
        //病区编码
        [DisplayName("病区编码")]
        public string WardCode { get; set; }
        //缺省病区
        [DisplayName("缺省病区")]
        public decimal DefaultWard { get; set; }

        [DisplayName("病区站点")]
        public string WardStation { get; set; }

        [DisplayName("病区工作性质")]
        public string Type { get; set; }
    }
    public class WardDeptVs
    {
        //科室ID
        [DisplayName("科室ID")]
        public decimal deptId { get; set; }
    }
}
