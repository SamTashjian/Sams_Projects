using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using HRPortal.Models.Data;

namespace HRPortal.Models.Repositories
{
    public class PolicyRepository
    {
        private static List<Policy> _policies;

        static PolicyRepository()
        {
            _policies = new List<Policy>
            {
                new Policy {Category = "Family and Illness Leave", PolicyTitle = "Pay During Leave", PolicyContent = "During an employee's own illness or immediate family member's illness, employees will be paid in full for up to 3 months."},
                new Policy {Category = "Harassment", PolicyTitle = "Sexual Harassment", PolicyContent = "Anyone who says anything sexual or touches anyone sexually in the workplace will be disciplined."},
                new Policy {Category = "PEDs", PolicyTitle = "Loss of Pay", PolicyContent = "Any player who is suspended due to PED violations will not be paid for games missed."},
                new Policy {Category = "Family and Illness Leave", PolicyTitle = "Leave Time Limit", PolicyContent = "an Employee's job may be filled permanently if his or her leave lasts longer than 9 months."},
                new Policy {Category = "PEDs", PolicyTitle = "Violation Count", PolicyContent = "Any player who receives 3 or more PED violations will be kicked off the team permanently."},
                new Policy {Category = "Harassment", PolicyTitle = "Verbal Harassment", PolicyContent = "Anyone who uses racial, sexist, or any other type of offensive language in the workplace will be disciplined."}      
            }; 
        }

        public static IEnumerable<Policy> GetAll()
        {
            return _policies;
        }

        public static Policy Get(string policyTitle)
        {
            return _policies.FirstOrDefault(p => p.PolicyTitle == policyTitle);
        }

        public static void Add(Policy policy)
        {
            Policy newPolicy = new Policy();

            newPolicy.Category = policy.Category;
            newPolicy.PolicyTitle = policy.PolicyTitle;
            newPolicy.PolicyContent = policy.PolicyContent;

            _policies.Add(newPolicy);
        }

        public static void Delete(string policyTitle)
        {
            _policies.RemoveAll(p => p.PolicyTitle == policyTitle);
        }
    }
}