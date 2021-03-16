// HermesChat - Simple real-time chat application.
// Copyright (C) 2021  Jerrett D. Davis
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.IO;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUi.Areas.Identity.Pages.Account.Manage
{
    [PublicAPI]
    public static class ManageNavPages
    {
        public static string Index => "Index";

        public static string Email => "Email";

        public static string ChangePassword => "ChangePassword";

        public static string DownloadPersonalData => "DownloadPersonalData";

        public static string DeletePersonalData => "DeletePersonalData";

        public static string ExternalLogins => "ExternalLogins";

        public static string PersonalData => "PersonalData";

        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        public static string? IndexNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, Index);
        }

        public static string? EmailNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, Email);
        }

        public static string? ChangePasswordNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, ChangePassword);
        }

        public static string? DownloadPersonalDataNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, DownloadPersonalData);
        }

        public static string? DeletePersonalDataNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, DeletePersonalData);
        }

        public static string? ExternalLoginsNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, ExternalLogins);
        }

        public static string? PersonalDataNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, PersonalData);
        }

        public static string? TwoFactorAuthenticationNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, TwoFactorAuthentication);
        }

        private static string? PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                             ?? Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}