using GarageSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Logic
{
    public class EnumControl
    {
        /// <summary>
        /// Converts a string rapresenting the ItemLinkType enumerator (usually coming from database), to an ItemLinkType enumerator.
        /// Returns ItemLinkType.UNKNOWN if it cannot be parsed.
        /// </summary>
        /// <param name="typeString"></param>
        /// <returns></returns>
        public static ItemLinkType ConvertToLinkType(string typeString)
        {
            if (Enum.TryParse(typeString, true, out ItemLinkType result))
            {
                return result;
            }
            else
            {
                return ItemLinkType.UNKNOWN;
            }
        }

        /// <summary>
        /// Converts a string rapresenting the ItemImageType enumerator (usually coming from database), to an ItemImageType enumerator.
        /// Returns ItemImageType.UNKNOWN if it cannot be parsed.
        /// </summary>
        /// <param name="typeString"></param>
        /// <returns></returns>
        public static ItemImageType ConvertToImageType(string typeString)
        {
            if (Enum.TryParse(typeString, true, out ItemImageType result))
            {
                return result;
            }
            else
            {
                return ItemImageType.UNKNOWN;
            }
        }

        /// <summary>
        /// Returns the string equivalent of the given Enumerator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetImageTypeEnumName<T>(T type)
        {
            return Enum.GetName(typeof(T), type);
        }
    }
}