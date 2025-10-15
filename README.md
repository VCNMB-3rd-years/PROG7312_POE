# 🏛 Municipality Report Issues Portal (MVC_POE)

## Overview

The *Municipality Report Issues Portal* is a web application designed to allow citizens to report local municipal issues such as sanitation problems, road repairs, utility disruptions, and loadshedding. The system provides an intuitive interface to submit reports, upload media attachments, and review all submissions. It is built using *ASP.NET Core MVC, and all reports are temporarily stored in memory using a **HashSet* service.  

The application also features a *confirmation workflow, dynamic **progress bars, and **search/filter functionality* by location and category.  

---

## 📂 Features

| Feature | Description |
|---------|-------------|
| Submit Reports | Users can submit issues by filling in *Location, **Category, **Description*, and optional media attachments. |
| File Upload & Preview | Uploaded images are displayed as previews on the *confirmation page*. |
| Confirmation Workflow | After entering details, users review their submission on a *confirmation page* before final submission. |
| Dynamic Progress Bar | Shows the completion percentage as users fill in form fields. |
| View All Reports | Displays all submitted reports as *mini-cards* with images in a *carousel grouped by location*. |
| Search & Filter | Users can filter reports by *location* and *category*. |
| Download Attachments | Uploaded files can be downloaded directly from the reports list. |

---

## 🧩 Technologies Used

- *C#* / ASP.NET Core MVC
- *Razor Pages* for Views
- *Bootstrap 5* for styling & carousels
- *JavaScript* for dynamic form interactions
- *HTML & CSS* for UI
- *In-memory HashSet* service for storing reports
- *IFormFile* for file uploads

---

## 🏗 Project Structure

MVC_POE/
├── Controllers/
│ └── ReportIssuesController.cs
├── Models/
│ └── ReportIssuesForm.cs
├── Services/
│ └── HashSetService.cs
├── Views/
│ ├── ReportIssues/
│ │ ├── CreateReportIssues.cshtml
│ │ ├── ReportIssuesConfirmation.cshtml
│ │ └── ViewReportIssues.cshtml
├── wwwroot/
│ ├── images/
│ └── uploads/
├── Program.cs
└── README.md


---

## 📝 Models

### ReportIssuesForm

| Property | Type | Description |
|----------|------|-------------|
| FormId | Guid | Unique ID for each report (auto-generated) |
| Location | string | Location of the issue (required) |
| Category | string | Category of issue (required) |
| Description | string | Details of the problem (required) |
| MediaAttachment | string? | Optional file path for uploaded media |

---

## 🔧 Controllers

### ReportIssuesController

| Action | Method | Description |
|--------|--------|-------------|
| CreateReportIssues | GET | Displays the report submission form |
| ReportIssuesConfirmation | POST | Handles form submission and shows confirmation page |
| ConfirmReportIssues | POST | Saves the report to the *HashSet* service and redirects to view page |
| ViewReportIssues | GET | Displays all reports grouped by location in a carousel |
| ShowReportIssuesConfirmation | POST | Handles filtered form submission with location/category selection |

---

## 🎨 Views

- *CreateReportIssues.cshtml*: Form to submit a report, includes a dynamic progress bar.
- *ReportIssuesConfirmation.cshtml*: Displays the submitted information for confirmation, with “Back” and “Confirm” buttons.
- *ViewReportIssues.cshtml: Shows all reports as **mini-cards* inside carousels, grouped by location, with image previews and download/view options.

---

## 💾 File Uploads

- All uploaded images are saved in wwwroot/uploads/.
- Previews of uploaded images are displayed in *confirmation* and *report listing* views.
- Users can *download files* directly from the card footer.

---

## 🚀 Running the Application

1. Clone the repository:

```bash
git clone (https://github.com/VCNMB-3rd-years/PROG7312_POE.git)

