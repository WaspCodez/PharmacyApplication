using Microsoft.AspNetCore.Mvc;

namespace PharmacyApplication.Controllers
{
    public class BaseApiController: ControllerBase
    {
        /// <summary>
        ///
        /// </summary>
        public Dictionary<string, string> Claims
        {
            get
            {
                var list = new Dictionary<string, string>();

                foreach (var claim in User.Claims)
                    list.Add(claim.Type, claim.Value);

                return list;
            }
        }
    }
}
