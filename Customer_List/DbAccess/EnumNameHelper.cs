using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CustomersWebDemo.DbAccess
{
    public static class EnumNameHelper
    {
       
    public static string GetDisplayName(this Enum enumValue)
    {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
    }

    public static List<SelectListItem> CustTypeValues = GetDisplayNameList(typeof(CustomersWebDemo.Models.CustomerTypeEnum));

    private static List<SelectListItem> GetDisplayNameList(Type enumType)
    {
        List<SelectListItem> selectList = new List<SelectListItem>();
        
        var values = Enum.GetValues(enumType);
        foreach(Enum v in values)
        {
            SelectListItem item = new SelectListItem();
           item.Text = GetDisplayName(v);
            item.Value = v.ToString();
            selectList.Add(item);
        }
        return selectList;
    }


        
}



}