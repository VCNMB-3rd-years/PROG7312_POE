# 🏛 Municipality Report Issues Portal (MVC_POE)

## Overview

The *Municipality Report Issues Portal* is a web application designed to allow citizens to report local municipal issues such as sanitation problems, road repairs, utility disruptions, and loadshedding. The system provides an intuitive interface to submit reports, upload media attachments, and review all submissions. It is built using *ASP.NET Core MVC*, and all reports are temporarily stored in memory using a **HashSet** service.  

The application also features a *confirmation workflow, dynamic progress bars, and search/filter functionality* by location and category.  

In addition, the application includes an **Event Dashboard** where users can view, favorite, and navigate local events and announcements.

---

## 📂 Features

| Feature | Description |
|---------|-------------|
| Submit Reports | Users can submit issues by filling in *Location, Category, Description*, and optional media attachments. |
| File Upload & Preview | Uploaded images are displayed as previews on the confirmation page. |
| Confirmation Workflow | After entering details, users review their submission on a confirmation page before final submission. |
| Dynamic Progress Bar | Shows the completion percentage as users fill in form fields. |
| View All Reports | Displays all submitted reports as mini-cards with images in a carousel grouped by location. |
| Search & Filter | Users can filter reports by location and category. |
| Download Attachments | Uploaded files can be downloaded directly from the reports list. |
| Event Dashboard | Users can view local events and announcements, filter by date/category, and favorite events. |
| Favorites & Recommendations | Favorited events are stored in a priority queue, influencing recommended events on the dashboard. |
| Collapsible Sidebar | Announcements sidebar shows latest and older announcements for easy navigation. |

---

## 🧩 Technologies Used

- *C#* / ASP.NET Core MVC  
- *Razor Pages* for Views  
- *Bootstrap 5* for styling & carousels  
- *JavaScript* for dynamic form interactions  
- *HTML & CSS* for UI  
- *In-memory HashSet* service for storing reports  
- *PriorityQueue* for favorites/events  
- *IFormFile* for file uploads  

---

## 🏗 Project Structure

## 🏗 Project Structure

MVC_POE/
├── Controllers/
│   ├── ReportIssuesController.cs
│   ├── EventController.cs
│   └── AnnouncementController.cs
├── Models/
│   ├── ReportIssuesForm.cs
│   ├── Event.cs
│   └── Announcement.cs
├── Services/
│   ├── HashSetService.cs
│   ├── PriorityQueueService.cs
│   └── FavoritesService.cs
├── Views/
│   ├── ReportIssues/
│   │   ├── CreateReportIssues.cshtml
│   │   ├── ReportIssuesConfirmation.cshtml
│   │   └── ViewReportIssues.cshtml
│   ├── Event/
│   │   ├── AllEvents.cshtml
│   │   └── EventDetails.cshtml
│   └── Announcement/
│       ├── AllAnnouncements.cshtml
│       └── AnnouncementDetails.cshtml
├── wwwroot/
│   ├── images/
│   └── uploads/
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

### Event

| Property | Type | Description |
|----------|------|-------------|
| EventId | Guid | Unique identifier for the event |
| EventName | string | Name of the event |
| EventCategory | string | Category (e.g., Music, Market, Walk) |
| EventDescription | string | Description of the event |
| EventDateTime | DateTime | Scheduled date and time |
| EventImage | string? | Optional image URL/path |
| IsFavorite | bool | Indicates if the user has “hearted” the event |

### Announcement

| Property | Type | Description |
|----------|------|-------------|
| AnnouncementId | Guid | Unique ID for the announcement |
| AnnouncementName | string | Title of the announcement |
| AnnouncementCategory | string | Category (e.g., News, Event, Alert) |
| AnnouncementDescription | string | Body content of the announcement |
| AnnouncementDate | DateTime | Date of posting |

---

## 🔧 Controllers

### ReportIssuesController

| Action | Method | Description |
|--------|--------|-------------|
| CreateReportIssues | GET | Displays the report submission form |
| ReportIssuesConfirmation | POST | Handles form submission and shows confirmation page |
| ConfirmReportIssues | POST | Saves the report to the HashSet service and redirects to view page |
| ViewReportIssues | GET | Displays all reports grouped by location in a carousel |
| ShowReportIssuesConfirmation | POST | Handles filtered form submission with location/category selection |

### EventController

| Action | Method | Description |
|--------|--------|-------------|
| AllEvents | GET | Displays all events grouped by category with search/filter options |
| EventDetails | GET | Shows details of a selected event, allows “heart/favorite” |
| FavoriteEvent | POST | Marks an event as favorite for the logged-in user |
| UnfavoriteEvent | POST | Removes event from the user's favorites |
| RecommendedEvents | GET | Returns events recommended based on user favorites |

### AnnouncementController

| Action | Method | Description |
|--------|--------|-------------|
| AllAnnouncements | GET | Displays recent and older announcements with filters |
| AnnouncementDetails | GET | Shows full details of a selected announcement |
| FilterAnnouncements | POST | Filters announcements by date or category |

---

## 🎨 Views

### Report Issues

- **CreateReportIssues.cshtml**: Form to submit a report with dynamic progress bar.
- **ReportIssuesConfirmation.cshtml**: Displays submitted information for confirmation.
- **ViewReportIssues.cshtml**: Shows reports in mini-cards inside carousels, grouped by location.

### Event Dashboard

- **AllEvents.cshtml**: Shows all events grouped by category in a carousel style.
- Users can **search events** by keyword or filter by category/date.
- Each event card includes:
  - Event name, category, description, date, and image.
  - “View Details” button.
  - Heart icon to **favorite/heart** events.
- Favorited events are stored in a **priority queue**, sorted by date.
- Users can **remove favorites** from their list.
- Favorited categories are used for **recommended events** on the dashboard.

### Announcements

- **AllAnnouncements.cshtml**: Displays announcements separated into:
  - **Latest announcements** (most recent 3)
  - **Older announcements** (older 3)
- Each card shows name, description, category, date, and a view link.
- Users can filter announcements by **date** or **category**.

---

## 💾 File Uploads

- All uploaded images are saved in `wwwroot/uploads/`.
- Previews are shown in confirmation and listing views.
- Users can download uploaded files from the card footer.

---

## 🧩 Services

### HashSetService

- Stores user-submitted report issues in-memory.
- Provides CRUD operations on reports.

### PriorityQueueService

- Manages all events using a priority queue.
- Stores events by `EventDateTime` and allows efficient retrieval.
- Works with **FavoritesService** to track user favorite events.
- Provides recommended events based on favorite categories.

### FavoritesService

- Tracks user favorites (hearted events).
- Provides methods:
  - `AddFavorite(Event e)`
  - `RemoveFavorite(Guid eventId)`
  - `GetFavoriteCategories()`
  - `GetFavoriteEvents()`

---

## 🚀 Running the Application

1. Clone the repository:

```bash
git clone https://github.com/VCNMB-3rd-years/PROG7312_POE.git
```
2. Navigate into the project folder:
```
cd PROG7312_POE
```
3. Build and run the application:
```
dotnet run
```
4. Open a browser and go to https://localhost:5001/ (or the specified port).
