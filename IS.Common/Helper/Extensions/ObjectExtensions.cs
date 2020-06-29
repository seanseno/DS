using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Common.Helper.Extensions
{
    public static class ObjectExtensions
    {
        public static Model Overwrite<Model>(this Model model, object newModel) where Model : class
        {
            if (newModel == null)
            {
                return model;
            }
            var newType = newModel.GetType();
            var oldType = model.GetType();
            var properties =
                newType
                .GetProperties()
                .Where(x => x.GetValue(newModel) != null);
            foreach (var newProperty in properties)
            {
                var property = oldType.GetProperty(newProperty.Name);
                if (property != null && property.CanWrite)
                {
                    var value = newType.GetProperty(newProperty.Name).GetValue(newModel);
                    property.SetValue(model, value);
                }
            }
            return model;
        }
    }
}
