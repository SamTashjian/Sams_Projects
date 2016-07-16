using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models.Data;

namespace HRPortal.Models.ViewModels
{
    public class ViewPolicyVM
    {
        public Policy Policy;
        public List<SelectListItem> CategoryItems { get; set; }

        public ViewPolicyVM()
        {
            CategoryItems = new List<SelectListItem>();

            Policy = new Policy();
        }

        public void SetCategoryItems(IEnumerable<Policy> policies)
        {
            foreach (var policy in policies.Select(p=>p.Category).Distinct())
            {
                CategoryItems.Add(new SelectListItem()
                {
                    Value = policy,
                    Text = policy
                });
            }
        }
    }
    
}