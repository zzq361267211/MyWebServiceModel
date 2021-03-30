using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyModel.Model
{

    /// <summary>
    /// 护士用户
    /// </summary>
    public class NurseUser
    {
        [DisplayName("姓名")]
        public string NurseName { get; set; }

        [DisplayName("性别")]
        public string Sex { get; set; }

        [DisplayName("用户名")]
        public string UserName { get; set; }

        [DisplayName("编码")]
        public string UserCode { get; set; }
        [DisplayName("编码")]
        public string NurseNo { get; set; }

        [DisplayName("护士ID")]
        public string NurseId { get; set; }

        [DisplayName("护士的HIS系统ID")]
        public string HisId { get; set; }

        [DisplayName("职务")]
        public string Post { get; set; }

        /// <summary>
        /// 简码类型,PY 拼音,WB 五笔
        /// </summary>
        [DisplayName("简码类型")]
        public string ShortCodeType { get; set; } = "PY";

        //工作的护理单元
        public List<NurseWorkWard> WorkWards { get; set; }

        public string Token { get; set; }

       // public List<NurseRole> Roles { get; set; }
    }
    /// <summary>
    /// 护士所属病区/护理单元
    /// </summary>
    public class NurseWorkWard
    {

        [DisplayName("护理单元名称")]
        public string CareUnitName { get; set; }

        [DisplayName("护理单元ID")]
        public string CareUnitID { get; set; }


        [DisplayName("病区名称")]
        public string WardName { get; set; }

        [DisplayName("病区ID")]
        public string WardId { get; set; }

        [DisplayName("缺省病区")]
        public decimal DefaultWard { get; set; }

        [DisplayName("护士ID")]
        public string NurseId { get; set; }

        [DisplayName("病区站点")]
        public string WardStation { get; set; }

        [DisplayName("病区工作性质")]
        public string Type { get; set; }
    }
    /// <summary>
    /// 登录用户
    /// </summary>
    public class LoginUser
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 登录时的密码
        /// </summary>
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        /// <summary>
        /// 登录时的密码
        /// </summary>
        [DataType(DataType.Password)]
        public string NewPassWord { get; set; }

    }
    /// <summary>
    /// 责任护士
    /// </summary>
    public class WardNurse
    {
        [DisplayName("护士ID")]
        public string NurseId { get; set; }

        [DisplayName("姓名")]
        public string NurseName { get; set; }

        [DisplayName("工号")]
        public string NurseNo { get; set; }


        [DisplayName("性别")]
        public string NurseSex { get; set; }

        [DisplayName("层级")]
        public string NurseGrd { get; set; }
    }
    /// <summary>
    /// 医生
    /// </summary>
    public class WardDoctor
    {
        [DisplayName("ID")]
        public decimal? Id { get; set; }

        [DisplayName("编码")]
        public string Code { get; set; }

        [DisplayName("简码")]
        public string Py { get; set; }

        [DisplayName("名称")]
        public string Name { get; set; }
        [DisplayName("专业技术职务")]
        public string Propst { get; set; }

        [DisplayName("医疗小组ID")]
        public decimal? MdcGroupId { get; set; }

        [DisplayName("医疗小组名称")]
        public string MdcGroupName { get; set; }

    }

    public class WardType
    {
        [DisplayName("病区ID")]
        public string WardId { get; set; }

        [DisplayName("病区工作性质")]
        public string Type { get; set; }
    }

}
