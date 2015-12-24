﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace HyrjChina.Web.Extendsions
{
    public static class StringExtendsions
    {
        public static string MaxSubstring(this string origin, int maxLength)
        {
            return MaxSubstring(origin, maxLength, string.Empty);
        }

        public static string MaxSubstring(this string origin, int maxLength, string ellipsis)
        {
            return origin.Length >= maxLength ? origin.Substring(0, maxLength) + ellipsis : origin;
        }

        public static string ToMd5(this string origin)
        {
            if (string.IsNullOrWhiteSpace(origin))
            {
                return string.Empty;
            }

            var md5Algorithm = MD5.Create();
            var utf8Bytes = Encoding.UTF8.GetBytes(origin);
            var md5Hash = md5Algorithm.ComputeHash(utf8Bytes);
            var hexString = new StringBuilder();
            foreach (var hexByte in md5Hash)
            {
                hexString.Append(hexByte.ToString("x2"));
            }
            return hexString.ToString();
        }

        public static string ToUtf8Base64String(this string origin)
        {
            return string.IsNullOrEmpty(origin) ? string.Empty : Convert.ToBase64String(Encoding.UTF8.GetBytes(origin));
        }

        public static string[] ToQueryString(this string origin, char separator = '&')
        {
            return origin.Split(separator);
        }

        public static string[] ToKeyValues(this string origin, char separator = '=')
        {
            return origin.Split(separator);
        }
    }
}