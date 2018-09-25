using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using SaludAr.BLL.Traductor;

namespace SaludAr.GUI.Editores
{
    public static class ExtensionesTraductor
    {
        public static string TraducirEntidad<T>(this ITraductor traductor)
        {
            var key = typeof(T).Name;
            return traductor.Traducir(key);
        }

        public static string TraducirCampoEntidad<T>(this ITraductor traductor, string campo)
        {
            var key = string.Format("{0}_{1}", typeof(T).Name, campo);
            return traductor.Traducir(key);
        }

        public static string TraducirCampoEntidad<TSource>(this ITraductor traductor, Expression<Func<TSource, dynamic>> propertyLambda)
        {
            var propertyInfo = GetPropertyInfo(propertyLambda);
            var key = string.Format("{0}_{1}", propertyInfo.DeclaringType.Name, propertyInfo.Name);
            return traductor.Traducir(key);
        }

        public static void PropagarCambioIdiomaEnControlesCompatibles(this System.Windows.Forms.Form thisForm, BE.Infraestructura.Idioma nuevoIdioma)
        {
            var subscriptoresAnidados = GetChildren(thisForm.Controls).OfType<ISubscriptorCambioIdioma>().ToArray();
            foreach (var subscriptorAnidado in subscriptoresAnidados)
                subscriptorAnidado.IdiomaCambiado(nuevoIdioma);
        }

        private static IEnumerable<System.Windows.Forms.Control> GetChildren(System.Windows.Forms.Control.ControlCollection ctrls)
        {
            var controls = ctrls.Cast<System.Windows.Forms.Control>();

            return controls
                .SelectMany(c => GetChildren(c.Controls))
                .Concat(controls);
        }

        private static PropertyInfo GetPropertyInfo<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        {
            var type = typeof(TSource);

            var member = propertyLambda.Body as MemberExpression;
            if (member == null)
            {
                member = (propertyLambda.Body as UnaryExpression).Operand as MemberExpression;
                if(member == null)
                    throw new ArgumentException(string.Format("Expression '{0}' refers to a method, not a property.", propertyLambda));
            }

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format("Expression '{0}' refers to a field, not a property.", propertyLambda));

            if (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format("Expression '{0}' refers to a property that is not from type {1}.", propertyLambda, type)); 

            return propInfo;
        }
    }
}
