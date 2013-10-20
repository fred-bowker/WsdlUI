using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;

using System.Security.Principal;

namespace CustomActions {
    public class AllActions {
    
        [CustomAction]
        public static ActionResult GetGlobalGroupNames(Session session) {

            session.Log("Begin GetGlobalGroupNames");

            var sid = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
            var account = (NTAccount)sid.Translate(typeof(NTAccount));

            session["UsersAccount"] = account.Value;

            session.Log("UserAccount: " + account.Value);
            session.Log("End GetGlobalGroupNames");

            return ActionResult.Success;
        }

    
    }
}
