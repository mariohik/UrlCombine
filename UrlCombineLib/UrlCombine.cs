﻿using System;
using System.Linq;

namespace UrlCombineLib
{
    public static class UrlCombine
    {
        /// <summary>
        /// Combines the url base and the relative url into one, consolidating the '/' between them
        /// </summary>
        /// <param name="urlBase">Base url that will be combined</param>
        /// <param name="relativeUrl">The relative path to combine</param>
        /// <returns>The merged url</returns>
        public static string Combine(string baseUrl, string relativeUrl)
        {
            if (string.IsNullOrEmpty(baseUrl?.Trim() ?? null))
                throw new ArgumentNullException(nameof(baseUrl));

            if (string.IsNullOrEmpty(relativeUrl?.Trim() ?? null))
                return baseUrl;

            baseUrl = baseUrl.TrimEnd('/');
            relativeUrl = relativeUrl.TrimStart('/');
            
            return $"{baseUrl}/{relativeUrl}";
        }

        /// <summary>
        /// Combines the url base and the array of relatives urls into one, consolidating the '/' between them
        /// </summary>
        /// <param name="urlBase">Base url that will be combined</param>
        /// <param name="relativeUrl">The array of relative paths to combine</param>
        /// <returns>The merged url</returns>
        public static string Combine(string baseUrl, params string[] relativePaths)
        {
            if (string.IsNullOrEmpty(baseUrl?.Trim() ?? null))
                throw new ArgumentNullException(nameof(baseUrl));

            if (relativePaths.Length == 0)
                return baseUrl;

            var currentUrl = Combine(baseUrl, relativePaths[0]);

            return Combine(currentUrl, relativePaths.Skip(1).ToArray());
        }
    }
}