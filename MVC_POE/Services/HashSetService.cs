using MVC_POE.Models;

namespace MVC_POE.Services
{
    public class HashSetService
    {
        private static readonly HashSet<ReportIssuesForm> _reportIssuesForms = new HashSet<ReportIssuesForm>();

        public IEnumerable<ReportIssuesForm> GetAllForms() => _reportIssuesForms;

        public void AddForm(ReportIssuesForm reportIssuesForm)
        {
            _reportIssuesForms.Add(reportIssuesForm);
        }
    }
}
