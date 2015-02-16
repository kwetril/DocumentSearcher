using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;

namespace DocumentSearcher.Helpers
{
    public class MongoObjectIdBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                return new ObjectId(result.AttemptedValue);
            }
            catch (Exception ex)
            {
                return ObjectId.Empty;
            }
        }
    }
}