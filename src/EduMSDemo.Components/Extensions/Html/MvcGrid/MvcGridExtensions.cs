using EduMSDemo.Components.Security;
using EduMSDemo.Resources;
using EduMSDemo.Resources.Table;
using NonFactors.Mvc.Grid;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;

namespace EduMSDemo.Components.Extensions.Html
{
    public static class MvcGridExtensions
    {
        public static IGridColumn<T> AddActionLink<T>(this IGridColumns<T> columns, String action, String iconClass, object routeValues = null, object htmlAttributes = null) where T : class
        {
            if (!IsAuthorizedToView(columns.Grid, action))
                return new GridColumn<T, String>(columns.Grid, model => "");

            return columns
                .Add(model => GetLink(columns.Grid, model, action, iconClass, routeValues, htmlAttributes))
                .Css("action-cell")
                .Encoded(false);
        }

        public static IGridColumn<T> AddActionConfirmLink<T>(this IGridColumns<T> columns, String action, String iconClass, String message, object routeValues = null, object htmlAttributes = null) where T : class
        {
            if (!IsAuthorizedToView(columns.Grid, action))
                return new GridColumn<T, String>(columns.Grid, model => "");


            IDictionary<string, object> attrs;

            if (htmlAttributes != null)
            {
                attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            }
            else
            {
                attrs = new Dictionary<string, object>();
            }
            attrs["data-action"] = "smart-confirm";
            attrs["data-message"] = message;


            return columns
                .Add(model => GetConfirmLink(columns.Grid, model, action, iconClass, routeValues, attrs))
                .Css("action-cell")
                .Encoded(false);
        }

        public static IGridColumn<T> AddDateProperty<T>(this IGridColumns<T> columns, Expression<Func<T, DateTime>> expression)
        {
            return columns.AddProperty(expression).Formatted("{0:d}");
        }
        public static IGridColumn<T> AddDateProperty<T>(this IGridColumns<T> columns, Expression<Func<T, DateTime?>> expression)
        {
            return columns.AddProperty(expression).Formatted("{0:d}");
        }
        public static IGridColumn<T> AddBooleanProperty<T>(this IGridColumns<T> columns, Expression<Func<T, Boolean>> expression)
        {
            Func<T, Boolean> valueFor = expression.Compile();

            return columns
                .AddProperty(expression)
                .RenderedAs(model =>
                    valueFor(model)
                        ? TableResources.Yes
                        : TableResources.No);
        }
        public static IGridColumn<T> AddBooleanProperty<T>(this IGridColumns<T> columns, Expression<Func<T, Boolean?>> expression)
        {
            Func<T, Boolean?> valueFor = expression.Compile();

            return columns
                .AddProperty(expression)
                .RenderedAs(model =>
                    valueFor(model) != null
                        ? valueFor(model) == true
                            ? TableResources.Yes
                            : TableResources.No
                        : "");
        }
        public static IGridColumn<T> AddDateTimeProperty<T>(this IGridColumns<T> columns, Expression<Func<T, DateTime>> expression)
        {
            return columns.AddProperty(expression).Formatted("{0:g}");
        }
        public static IGridColumn<T> AddDateTimeProperty<T>(this IGridColumns<T> columns, Expression<Func<T, DateTime?>> expression)
        {
            return columns.AddProperty(expression).Formatted("{0:g}");
        }
        public static IGridColumn<T> AddProperty<T, TProperty>(this IGridColumns<T> columns, Expression<Func<T, TProperty>> expression)
        {
            return columns
                .Add(expression)
                .Css(GetCssClassFor<TProperty>())
                .Titled(ResourceProvider.GetPropertyTitle(expression));
        }

        public static IHtmlGrid<T> ApplyDefaults<T>(this IHtmlGrid<T> grid)
        {
            return grid
                .Pageable(pager => { pager.RowsPerPage = 16; })
                .Named(typeof(T).Name.Replace("View", ""))
                .Empty(TableResources.NoDataFound)
                .Css("table-hover")
                .Filterable()
                .Sortable();
        }

        private static String GetLink<T>(IGrid grid, T model, String action, String iconClass, object routeValues = null, object htmlAttributes = null)
        {
            UrlHelper url = new UrlHelper(grid.HttpContext.Request.RequestContext);
            TagBuilder actionTag = new TagBuilder("a");
            TagBuilder icon = new TagBuilder("i");

            if (htmlAttributes != null)
            {
                IDictionary<string, object> attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                actionTag.MergeAttributes(attrs);
            }

            actionTag.MergeAttribute("href", url.Action(action, GetRouteValuesFor(model, routeValues)));
            actionTag.AddCssClass(action.ToLower() + "-action");
            icon.AddCssClass(iconClass);

            actionTag.InnerHtml = icon.ToString();

            return actionTag.ToString();
        }

        private static String GetConfirmLink<T>(IGrid grid, T model, String action, String iconClass, object routeValues = null, IDictionary<string, object> htmlAttributes = null)
        {
            UrlHelper url = new UrlHelper(grid.HttpContext.Request.RequestContext);
            TagBuilder actionTag = new TagBuilder("a");
            TagBuilder icon = new TagBuilder("i");

            if (htmlAttributes != null)
            {
                actionTag.MergeAttributes(htmlAttributes);
            }

            actionTag.MergeAttribute("data-href", url.Action(action, GetRouteValuesFor(model, routeValues)));
            actionTag.MergeAttribute("href", "#");
            actionTag.AddCssClass(action.ToLower() + "-action");
            icon.AddCssClass(iconClass);

            actionTag.InnerHtml = icon.ToString();

            return actionTag.ToString();
        }

        private static Boolean IsAuthorizedToView(IGrid grid, String action)
        {
            if (Authorization.Provider == null)
                return true;

            Int32? accountId = grid.HttpContext.User.Id();
            String area = grid.HttpContext.Request.RequestContext.RouteData.Values["area"] as String;
            String controller = grid.HttpContext.Request.RequestContext.RouteData.Values["controller"] as String;

            return Authorization.Provider.IsAuthorizedFor(accountId, area, controller, action);
        }
        private static RouteValueDictionary GetRouteValuesFor<T>(T model, object routeValues = null)
        {
            PropertyInfo keyProperty = typeof(T)
                .GetProperties()
                .FirstOrDefault(property => property.IsDefined(typeof(KeyAttribute), false));

            if (keyProperty == null)
                throw new Exception(String.Format("{0} type does not have a key property.", typeof(T).Name));

            String key = Char.ToLower(keyProperty.Name[0]) + keyProperty.Name.Substring(1);
            RouteValueDictionary routeVals = new RouteValueDictionary(routeValues);
            routeVals.Add(key, keyProperty.GetValue(model));

            return routeVals;
        }
        private static String GetCssClassFor<TProperty>()
        {
            Type type = Nullable.GetUnderlyingType(typeof(TProperty)) ?? typeof(TProperty);
            if (type.IsEnum) return "text-left";

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.SByte:
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return "text-right";
                case TypeCode.Boolean:
                case TypeCode.DateTime:
                    return "text-center";
                default:
                    return "text-left";
            }
        }
    }
}
