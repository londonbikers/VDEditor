using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using VDEditor.VDService;

namespace VDEditor.Code
{
    public static class Helpers
    {
        public static SelectList GetErrorSelectList()
        {
            var item = new SelectListItem {Text = "** Error **"};
            var source = new List<SelectListItem> {item};
            return new SelectList(source);
        }

        #region page messages
        public static void AddPageMessage(UpdateOperationResultType resultType)
        {
            switch (resultType)
            {
                case UpdateOperationResultType.FailureApplicationFault:
                    AddPageMessage(UserMessages.GenericServiceFailure);
                    break;
                case UpdateOperationResultType.FailureEntityAlreadyExists:
                    AddPageMessage(UserMessages.EntityAlreadyExists);
                    break;
                case UpdateOperationResultType.FailureEntityIsInvalid:
                    AddPageMessage(UserMessages.EntityIsInvalid);
                    break;
                case UpdateOperationResultType.Success:
                    AddPageMessage(UserMessages.EntityUpdated);
                    break;
            }
        }

        public static void AddPageMessage(GetOperationResultType resultType)
        {
            switch (resultType)
            {
                case GetOperationResultType.FailureApplicationFault:
                    AddPageMessage(UserMessages.GenericServiceFailure);
                    break;
                case GetOperationResultType.FailureEntityDoesntExist:
                    AddPageMessage(UserMessages.EntityAlreadyExists);
                    break;
            }
        }

        public static void AddPageMessage(DeleteOperationResultType resultType)
        {
            switch (resultType)
            {
                case DeleteOperationResultType.FailureApplicationFault:
                    AddPageMessage(UserMessages.GenericServiceFailure);
                    break;
                case DeleteOperationResultType.FailureEntityDoesntExist:
                    AddPageMessage(UserMessages.EntityDoesntExist);
                    break;
                case DeleteOperationResultType.FailureEntityHasDependencies:
                    AddPageMessage(UserMessages.CannotDeleteEntityHasDepedencies);
                    break;
                case DeleteOperationResultType.Success:
                    AddPageMessage(UserMessages.EntityDeleted);
                    break;
            }
        }

        public static void AddPageMessage(string message)
        {
            HttpContext.Current.Session["PageMessage"] = message;
        }

        public static string RenderPageMessage()
        {
            if (string.IsNullOrEmpty((string)HttpContext.Current.Session["PageMessage"]))
                return string.Empty;

            var message = (string) HttpContext.Current.Session["PageMessage"];
            HttpContext.Current.Session.Remove("PageMessage");

            // format message with notification mechanism html.
            var output = string.Format("<div id=\"notification\">{0}</div>", message);
            return output;
        }
        #endregion
    }
}