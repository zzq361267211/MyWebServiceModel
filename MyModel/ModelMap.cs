using Mapster;
using MyModel.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace MyModel
{
    /// <summary>
    /// 用于类型的映射转换   
    /// </summary>
    public class ModelMap
    {
        public static void ModelMapInit()
        {
            TypeAdapterConfig<NurseWorkWard, Ward>.NewConfig()
               .ShallowCopyForSameType(true)
               .PreserveReference(true)
               .Map(j => j.WardId, k => k.WardId)
               .Map(j => j.WardName, k => k.WardName)
               .Map(j => j.DefaultWard, k => k.DefaultWard)
               .Map(j => j.WardStation, k => k.WardStation)
               ;

        }
    }
}
