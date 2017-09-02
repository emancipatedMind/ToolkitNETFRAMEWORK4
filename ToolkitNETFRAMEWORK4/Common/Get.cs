namespace ToolkitNFW4.Common {
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    public static class Get {

        public static OperationResult<T> EnumValue<T>(object v) where T : struct =>
            typeof(T).IsEnum == false ?
                new OperationResult<T>(new Exception[] { new NotSupportedException("Type must be System.Enum.") }) :
                new OperationResult<T>(Enum.IsDefined(typeof(T), v), (T)v);

        public static List<T> List<T>(Action<List<T>> action) =>
            General(action);

        public static T General<T>(Action<T> action, object[] parameters = null) {
            var g = (T) Activator.CreateInstance(typeof(T), parameters);
            action(g);
            return g;
        }

    }
}